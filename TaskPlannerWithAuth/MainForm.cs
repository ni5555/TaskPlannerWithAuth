using System;
using System.Linq;
using System.Windows.Forms;
using TaskPlanner.Models;
using TaskPlanner.Services;

namespace TaskPlanner
{
    public partial class MainForm : Form
    {
        private AuthService authService;
        private TaskService taskService;
        private NotificationService notificationService;

        private User currentUser;
        private string authToken;
        private System.Windows.Forms.Timer notificationTimer;
        private bool isClosing = false; // Флаг для отслеживания закрытия формы

        public MainForm(User user, string token)
        {
            InitializeComponent();

            currentUser = user;
            authToken = token;
            authService = new AuthService();
            taskService = new TaskService();
            notificationService = new NotificationService();

            SetupNotificationTimer();
            RefreshTaskList();
            Text = $"Планировщик задач - {currentUser.Username}";
        }

        private void SetupNotificationTimer()
        {
            notificationTimer = new System.Windows.Forms.Timer();
            notificationTimer.Interval = 60000; // 1 минута
            notificationTimer.Tick += CheckNotifications;
            notificationTimer.Start();
        }

        private void CheckNotifications(object sender, EventArgs e)
        {
            if (isClosing) return; // Если форма закрывается, не выполняем проверки

            // ВРЕМЕННО КОММЕНТИРУЕМ проверку токена
            /*
            if (!authService.ValidateToken(authToken))
            {
                SafeCloseForm();
                return;
            }
            */

            try
            {
                var upcomingTasks = taskService.GetUpcomingTasks(currentUser.Id);
                foreach (var task in upcomingTasks)
                {
                    notificationService.ShowBrowserNotification(task);
                }
            }
            catch (Exception ex)
            {
                // Игнорируем ошибки в уведомлениях
                System.Diagnostics.Debug.WriteLine($"Ошибка уведомления: {ex.Message}");
            }
        }

        private void RefreshTaskList()
        {
            if (isClosing) return; // Если форма закрывается, не обновляем список

            // ВРЕМЕННО КОММЕНТИРУЕМ проверку токена
            /*
            if (!authService.ValidateToken(authToken))
            {
                SafeCloseForm();
                return;
            }
            */

            try
            {
                SortType sortType;
                if (cmbSort.SelectedIndex == 0)
                    sortType = SortType.ByCreationDate;
                else
                    sortType = SortType.ByDueDate;

                var tasks = taskService.GetUserTasks(currentUser.Id, sortType);

                dataGridViewTasks.DataSource = tasks.Select(t => new
                {
                    t.Id,
                    t.Title,
                    t.Description,
                    DueDate = t.DueDate.ToString("dd.MM.yyyy HH:mm"),
                    t.IsCompleted,
                    IsShared = t.SharedWithUserId > 0 ? "Да" : "Нет"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var taskForm = new TaskForm())
            {
                if (taskForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        taskService.CreateTask(taskForm.TaskTitle, taskForm.TaskDescription, taskForm.DueDate, currentUser.Id);
                        RefreshTaskList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка создания задачи: {ex.Message}");
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow != null)
            {
                int taskId = (int)dataGridViewTasks.CurrentRow.Cells["Id"].Value;

                var tasks = taskService.GetTasks(currentUser.Id);
                var task = tasks.FirstOrDefault(t => t.Id == taskId);

                if (task != null)
                {
                    using (var taskForm = new TaskForm(task))
                    {
                        if (taskForm.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                taskService.UpdateTask(taskId, taskForm.TaskTitle, taskForm.TaskDescription, taskForm.DueDate, taskForm.IsCompleted);
                                RefreshTaskList();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка обновления задачи: {ex.Message}");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для редактирования");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow != null)
            {
                int taskId = (int)dataGridViewTasks.CurrentRow.Cells["Id"].Value;

                var result = MessageBox.Show("Удалить выбранную задачу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        taskService.DeleteTask(taskId);
                        RefreshTaskList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления задачи: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления");
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (dataGridViewTasks.CurrentRow != null)
            {
                int taskId = (int)dataGridViewTasks.CurrentRow.Cells["Id"].Value;

                try
                {
                    var users = authService.GetUsers().Where(u => u.Id != currentUser.Id).ToList();

                    if (users.Any())
                    {
                        using (var shareForm = new ShareForm(users))
                        {
                            if (shareForm.ShowDialog() == DialogResult.OK)
                            {
                                taskService.ShareTask(taskId, shareForm.SelectedUserId);
                                RefreshTaskList();
                                MessageBox.Show("Задача успешно расшарена");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет других пользователей для общего доступа");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка общего доступа: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для общего доступа");
            }
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void dataGridViewTasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true; // Устанавливаем флаг закрытия

            if (notificationTimer != null)
            {
                notificationTimer.Stop();
                notificationTimer.Dispose();
                notificationTimer = null;
            }
        }

        // Безопасное закрытие формы
        private void SafeCloseForm()
        {
            if (isClosing) return;

            isClosing = true;
            this.BeginInvoke(new Action(() =>
            {
                if (!this.IsDisposed)
                {
                    this.Close();
                }
            }));
        }
    }
}
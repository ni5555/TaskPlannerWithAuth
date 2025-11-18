using System;
using System.Windows.Forms;
using TaskPlanner.Models;

namespace TaskPlanner
{
    public partial class TaskForm : Form
    {
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool IsCompleted { get; private set; }

        public TaskForm()
        {
            InitializeComponent();
            DueDate = DateTime.Now.AddDays(1);
            dtpDueDate.Value = DueDate;
        }

        public TaskForm(TaskItem task)
        {
            InitializeComponent();
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpDueDate.Value = task.DueDate;
            chkCompleted.Checked = task.IsCompleted;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название задачи");
                return;
            }

            TaskTitle = txtTitle.Text.Trim();
            TaskDescription = txtDescription.Text.Trim();
            DueDate = dtpDueDate.Value;
            IsCompleted = chkCompleted.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
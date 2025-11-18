using System;
using System.Windows.Forms;
using TaskPlanner.Models;

namespace TaskPlanner.Services
{
    public class NotificationService
    {
        public void ShowBrowserNotification(TaskItem task)
        {
            // Имитация браузерного уведомления
            MessageBox.Show($"Задача скоро истекает!\n\n{task.Title}\nДо: {task.DueDate:HH:mm}",
                          "Уведомление",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }

        public void ShowEmailNotification(TaskItem task)
        {
            // Имитация email уведомления
            Console.WriteLine($"Email отправлен: Задача '{task.Title}' истекает в {task.DueDate:HH:mm}");
        }
    }
}
using System;
using System.Windows.Forms;

namespace TaskPlanner
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // УБИРАЕМ using и делаем явное управление формой
            var loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем данные ДО закрытия формы
                var currentUser = loginForm.CurrentUser;
                var authToken = loginForm.AuthToken;

                // Закрываем форму
                loginForm.Close();
                loginForm.Dispose();

                // Запускаем главную форму с сохраненными данными
                Application.Run(new MainForm(currentUser, authToken));
            }
            else
            {
                // Если пользователь отменил вход, закрываем форму
                loginForm.Close();
                loginForm.Dispose();
            }
        }
    }
}
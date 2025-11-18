using System;
using System.Windows.Forms;
using TaskPlanner.Models;
using TaskPlanner.Services;

namespace TaskPlanner
{
    public partial class LoginForm : Form
    {
        private AuthService authService;

        public User CurrentUser { get; private set; }
        public string AuthToken { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            authService = new AuthService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authenticate(true);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Authenticate(false);
        }

        private void Authenticate(bool isLogin)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите имя пользователя и пароль");
                return;
            }

            var response = authService.MakeAuthRequest(txtUsername.Text, txtPassword.Text, isLogin);

            if (response.Success)
            {
                CurrentUser = response.User;
                AuthToken = response.Token;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(response.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
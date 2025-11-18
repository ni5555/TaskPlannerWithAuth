namespace TaskPlanner
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Text = "Аутентификация";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label Username
            this.label1.Text = "Имя пользователя:";
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Size = new System.Drawing.Size(100, 20);

            // TextBox Username
            this.txtUsername.Location = new System.Drawing.Point(20, 45);
            this.txtPassword.Size = new System.Drawing.Size(250, 20);

            // Label Password
            this.label2.Text = "Пароль:";
            this.label2.Location = new System.Drawing.Point(20, 75);
            this.label2.Size = new System.Drawing.Size(100, 20);

            // TextBox Password
            this.txtPassword.Location = new System.Drawing.Point(20, 100);
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.UseSystemPasswordChar = true;

            // Button Login
            this.btnLogin.Text = "Вход";
            this.btnLogin.Location = new System.Drawing.Point(20, 140);
            this.btnLogin.Size = new System.Drawing.Size(120, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Button Register
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.Location = new System.Drawing.Point(150, 140);
            this.btnRegister.Size = new System.Drawing.Size(120, 30);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Add controls
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegister);

            this.ResumeLayout(false);
        }
    }
}
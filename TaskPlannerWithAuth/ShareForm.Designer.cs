namespace TaskPlanner
{
    partial class ShareForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;

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
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.btnShare = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Text = "Поделиться задачей";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label
            this.label1.Text = "Выберите пользователя:";
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Size = new System.Drawing.Size(150, 20);

            // ListBox Users
            this.listBoxUsers.Location = new System.Drawing.Point(20, 40);
            this.listBoxUsers.Size = new System.Drawing.Size(250, 150);

            // Button Share
            this.btnShare.Text = "Поделиться";
            this.btnShare.Location = new System.Drawing.Point(20, 200);
            this.btnShare.Size = new System.Drawing.Size(100, 30);
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);

            // Button Cancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(130, 200);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
    }
}
namespace TaskPlanner
{
    partial class TaskForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.CheckBox chkCompleted;

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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.chkCompleted = new System.Windows.Forms.CheckBox();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "Задача";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Label Title
            this.lblTitle.Text = "Название:";
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(100, 20);

            // TextBox Title
            this.txtTitle.Location = new System.Drawing.Point(120, 17);
            this.txtTitle.Size = new System.Drawing.Size(250, 20);

            // Label Description
            this.lblDescription.Text = "Описание:";
            this.lblDescription.Location = new System.Drawing.Point(20, 50);
            this.lblDescription.Size = new System.Drawing.Size(100, 20);

            // TextBox Description
            this.txtDescription.Location = new System.Drawing.Point(120, 47);
            this.txtDescription.Size = new System.Drawing.Size(250, 60);
            this.txtDescription.Multiline = true;

            // Label DueDate
            this.lblDueDate.Text = "Срок выполнения:";
            this.lblDueDate.Location = new System.Drawing.Point(20, 120);
            this.lblDueDate.Size = new System.Drawing.Size(100, 20);

            // DateTimePicker DueDate
            this.dtpDueDate.Location = new System.Drawing.Point(120, 117);
            this.dtpDueDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDueDate.ShowUpDown = true;

            // CheckBox Completed
            this.chkCompleted.Text = "Выполнена";
            this.chkCompleted.Location = new System.Drawing.Point(120, 150);
            this.chkCompleted.Size = new System.Drawing.Size(100, 20);

            // Button Save
            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 190);
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Button Cancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(210, 190);
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.chkCompleted);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
    }
}
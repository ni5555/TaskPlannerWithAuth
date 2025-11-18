namespace TaskPlanner
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected System.Windows.Forms.DataGridView dataGridViewTasks;
        protected System.Windows.Forms.Button btnAdd;
        protected System.Windows.Forms.Button btnEdit;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnShare;
        protected System.Windows.Forms.ComboBox cmbSort;
        protected System.Windows.Forms.Label lblSort;

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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();

            // Form
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Text = "Планировщик задач";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            // Label Sort
            this.lblSort = new System.Windows.Forms.Label();
            this.lblSort.Text = "Сортировка:";
            this.lblSort.Location = new System.Drawing.Point(20, 15);
            this.lblSort.Size = new System.Drawing.Size(70, 20);

            // ComboBox Sort
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.cmbSort.Location = new System.Drawing.Point(100, 12);
            this.cmbSort.Size = new System.Drawing.Size(150, 21);
            this.cmbSort.Items.AddRange(new object[] { "По дате создания", "По сроку выполнения" });
            this.cmbSort.SelectedIndex = 0;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);

            // Button Add
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(270, 10);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // Button Edit
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Location = new System.Drawing.Point(360, 10);
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // Button Delete
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(460, 10);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Button Share
            this.btnShare = new System.Windows.Forms.Button();
            this.btnShare.Text = "Поделиться";
            this.btnShare.Location = new System.Drawing.Point(550, 10);
            this.btnShare.Size = new System.Drawing.Size(80, 30);
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);

            // DataGridView
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.dataGridViewTasks.Location = new System.Drawing.Point(20, 50);
            this.dataGridViewTasks.Size = new System.Drawing.Size(750, 400);
            this.dataGridViewTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTasks.ReadOnly = true;
            this.dataGridViewTasks.AllowUserToAddRows = false;
            this.dataGridViewTasks.AllowUserToDeleteRows = false;
            this.dataGridViewTasks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTasks_CellDoubleClick);

            // Add controls
            this.Controls.Add(this.lblSort);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnShare);
            this.Controls.Add(this.dataGridViewTasks);

            this.ResumeLayout(false);
        }
    }
}
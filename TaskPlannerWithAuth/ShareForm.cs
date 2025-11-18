using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TaskPlanner.Models;

namespace TaskPlanner
{
    public partial class ShareForm : Form
    {
        public int SelectedUserId { get; private set; }

        private List<User> users;

        public ShareForm(List<User> availableUsers)
        {
            InitializeComponent();
            users = availableUsers;
            LoadUsers();
        }

        private void LoadUsers()
        {
            listBoxUsers.DisplayMember = "Username";
            listBoxUsers.ValueMember = "Id";
            listBoxUsers.DataSource = users;
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItem != null)
            {
                SelectedUserId = ((User)listBoxUsers.SelectedItem).Id;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
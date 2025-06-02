using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, 'user')";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration successful!");
                this.Close();
            }
        }

        private void btnLoginBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm LoginForm = new LoginForm();
            this.Hide();
            LoginForm.Show();
        }

    }
}

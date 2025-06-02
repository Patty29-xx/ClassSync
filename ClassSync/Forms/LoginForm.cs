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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username=@username AND Password=@password";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text); // Reminder: Use hashing in real apps!

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string role = reader["Role"].ToString();
                    string userId = reader["UserID"].ToString();
                    string username = reader["Username"].ToString();

                    this.Hide();

                    if (role == "admin")
                        new AdminDashboard().Show();
                    else
                        new MainForm(userId, username).Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide(); 
            registerForm.Show(); 
        }

    }
}

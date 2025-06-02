using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class MainForm : Form
    {
        private string userId;
        private string username;
       public MainForm(string userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;

            lblWelcome.Text = "Welcome, " + username;
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            // Optional: any click logic for the welcome label
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReserveRoom_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form

            var reservationForm = new ReservationForm(userId);
            reservationForm.ShowDialog();

            this.Show(); // Show the main form again after reservation form closes
        }


    }

}

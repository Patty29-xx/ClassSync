using ClassSync.Helpers;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class AdminDashboard : Form
    {
        private Timer refreshTimer = new Timer(); 
        public AdminDashboard()
        {
            InitializeComponent();
            RefreshReservationsGrid();

            // Setup timer
            refreshTimer.Interval = 30000; 
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshReservationsGrid()
        {
            dataGridView1.DataSource = ReservationHelper.LoadReservationsByStatuses();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void RefreshTimer_Tick(object sender, EventArgs e) 
        {
            RefreshReservationsGrid();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int reservationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                using (var conn = DBHelper.GetConnection())
                {
                    string updateQuery = "UPDATE Reservations SET Status='Approved' WHERE ReservationID=@id";
                    SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    cmd.ExecuteNonQuery();
                }
                RefreshReservationsGrid();
            }
            else
            {
                MessageBox.Show("Please select a reservation.");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int reservationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                using (var conn = DBHelper.GetConnection())
                {
                    string updateQuery = "UPDATE Reservations SET Status='Rejected' WHERE ReservationID=@id";
                    SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    cmd.ExecuteNonQuery();
                }
                RefreshReservationsGrid();
            }
            else
            {
                MessageBox.Show("Please select a reservation.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int reservationId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                using (var conn = DBHelper.GetConnection())
                {
                    string updateQuery = "UPDATE Reservations SET Status='Cancelled' WHERE ReservationID=@id";
                    SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@id", reservationId);
                    cmd.ExecuteNonQuery();
                }
                RefreshReservationsGrid();
            }
            else
            {
                MessageBox.Show("Please select a reservation.");
            }
        }

        public void ManualRefreshReservations()
        {
            RefreshReservationsGrid();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoomForm addRoomForm = new AddRoomForm();
            addRoomForm.ShowDialog();
           
        }
        private void btnRoomList_Click(object sender, EventArgs e)
        {
            RoomListForm roomListForm = new RoomListForm();
            roomListForm.ShowDialog();  
        }

        private void btnViewAvailability_Click(object sender, EventArgs e)
        {
            ViewAvailabilityForm viewForm = new ViewAvailabilityForm();
            viewForm.ShowDialog(); 
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); 
        }

    }
}

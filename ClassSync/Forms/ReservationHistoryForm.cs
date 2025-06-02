using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class ReservationHistoryForm : Form
    {
        private string currentUserId;

        public ReservationHistoryForm(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadReservationHistory();
        }

        private void LoadReservationHistory()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = @"
        SELECT r.Date, r.StartTime, r.EndTime, rm.RoomName, r.Purpose, r.Attendees, r.Status
        FROM Reservations r
        INNER JOIN Rooms rm ON r.RoomID = rm.RoomID
        WHERE r.UserID = @userId
        ORDER BY r.Date DESC";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", currentUserId);

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Format StartTime and EndTime to 12-hour format
                foreach (DataRow row in dt.Rows)
                {
                    if (TimeSpan.TryParse(row["StartTime"].ToString(), out TimeSpan startTime))
                    {
                        row["StartTime"] = DateTime.Today.Add(startTime).ToString("hh:mm tt");
                    }

                    if (TimeSpan.TryParse(row["EndTime"].ToString(), out TimeSpan endTime))
                    {
                        row["EndTime"] = DateTime.Today.Add(endTime).ToString("hh:mm tt");
                    }
                }

                dataGridViewHistory.DataSource = dt;
                dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }



        private void dataGridViewHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
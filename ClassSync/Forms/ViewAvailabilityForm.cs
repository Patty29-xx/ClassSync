using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class ViewAvailabilityForm : Form
    {
        public ViewAvailabilityForm()
        {
            InitializeComponent();
        }

        private void ViewAvailabilityForm_Load(object sender, EventArgs e)
        {
            LoadAllRooms();
         
        }

        private void LoadAllRooms()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Rooms";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridRooms.DataSource = table;
            }
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            if (cmbStartTime.SelectedItem == null || cmbEndTime.SelectedItem == null)
            {
                MessageBox.Show("Please select both start and end times.");
                return;
            }

            // Parse selected times
            bool isStartValid = DateTime.TryParseExact(
                cmbStartTime.SelectedItem.ToString(),
                "hh:mm tt",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime startTime);

            bool isEndValid = DateTime.TryParseExact(
                cmbEndTime.SelectedItem.ToString(),
                "hh:mm tt",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime endTime);

            if (!isStartValid || !isEndValid)
            {
                MessageBox.Show("Invalid time format.");
                return;
            }

            if (startTime >= endTime)
            {
                MessageBox.Show("Start time must be earlier than end time.");
                return;
            }
            LoadAvailableRooms(datePicker.Value.Date, startTime.TimeOfDay, endTime.TimeOfDay);
        }


        private void LoadAvailableRooms(DateTime selectedDate, TimeSpan startTime, TimeSpan endTime)
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = @"
        SELECT 
            r.RoomID,
            r.RoomName,
            r.Capacity,
            CASE 
                WHEN EXISTS (
                    SELECT 1 
                    FROM Reservations res
                    WHERE res.RoomID = r.RoomID
                    AND res.Date = @selectedDate
                    AND res.Status = 'Approved'
                    AND NOT (
                        TIME(res.EndTime) <= TIME(@startTime) OR TIME(res.StartTime) >= TIME(@endTime)
                    )
                )
                THEN 'Reserved'
                ELSE 'Available'
            END AS Availability,
            (
                SELECT 
                    GROUP_CONCAT(printf('%s - %s', 
                        strftime('%H:%M', res.StartTime), 
                        strftime('%H:%M', res.EndTime)), ', ')
                FROM Reservations res
                WHERE res.RoomID = r.RoomID
                AND res.Date = @selectedDate
                AND res.Status = 'Approved'
                AND NOT (
                    TIME(res.EndTime) <= TIME(@startTime) OR TIME(res.StartTime) >= TIME(@endTime)
                )
            ) AS ConflictTimes
            FROM Rooms r";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@startTime", startTime.ToString(@"hh\:mm"));
                cmd.Parameters.AddWithValue("@endTime", endTime.ToString(@"hh\:mm"));

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Add selected info for display
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("SelectedFrom", typeof(string));
                dt.Columns.Add("SelectedTo", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["Date"] = selectedDate.ToString("yyyy-MM-dd");
                    row["SelectedFrom"] = startTime.ToString(@"hh\:mm");
                    row["SelectedTo"] = endTime.ToString(@"hh\:mm");

                    // If no conflict time, show "N/A"
                    if (row["ConflictTimes"] == DBNull.Value || string.IsNullOrEmpty(row["ConflictTimes"].ToString()))
                    {
                        row["ConflictTimes"] = "N/A";
                    }
                }

                dataGridRooms.DataSource = dt;

                // Set headers
                dataGridRooms.Columns["RoomID"].HeaderText = "Room ID";
                dataGridRooms.Columns["RoomName"].HeaderText = "Room Name";
                dataGridRooms.Columns["Capacity"].HeaderText = "Capacity";
                dataGridRooms.Columns["Availability"].HeaderText = "Status";
                dataGridRooms.Columns["ConflictTimes"].HeaderText = "Conflicting Time(s)";
                dataGridRooms.Columns["Date"].HeaderText = "Date";
                dataGridRooms.Columns["SelectedFrom"].HeaderText = "From";
                dataGridRooms.Columns["SelectedTo"].HeaderText = "To";
            }
        }

        private void cmbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

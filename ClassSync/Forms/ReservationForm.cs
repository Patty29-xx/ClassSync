using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class ReservationForm : Form
    {
        private string currentUserId;

        public ReservationForm(string userId)
        {
            InitializeComponent();
            currentUserId = userId;

            LoadRooms();

            comboRoom.SelectedIndexChanged += (s, e) => LoadAvailableTimeSlots();
            datePicker.ValueChanged += (s, e) => LoadAvailableTimeSlots();

            // Initially clear time combos
            comboStartTime.DataSource = null;
            comboEndTime.DataSource = null;

            txtPurpose.Validating += txtPurpose_Validating;
        }

        private List<string> GenerateTimeSlots()
        {
            List<string> slots = new List<string>();
            DateTime start = DateTime.Today.AddHours(8); 
            DateTime end = DateTime.Today.AddHours(20);   

            while (start <= end)
            {
                slots.Add(start.ToString("hh:mm tt")); 
                start = start.AddMinutes(30);
            }
            return slots;
        }

        private void LoadAvailableTimeSlots()
        {
            if (comboRoom.SelectedValue == null)
            {
                comboStartTime.DataSource = null;
                comboEndTime.DataSource = null;
                return;
            }

            var allSlots = GenerateTimeSlots();

            List<(TimeSpan Start, TimeSpan End)> reservedSlots = new List<(TimeSpan, TimeSpan)>();

            using (var conn = DBHelper.GetConnection())
            {
                string query = @"SELECT StartTime, EndTime FROM Reservations
                                 WHERE RoomID = @room AND Date = @date
                                 AND Status IN ('Pending', 'Approved')";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room", comboRoom.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", datePicker.Value.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TimeSpan reservedStart = TimeSpan.Parse(reader["StartTime"].ToString());
                            TimeSpan reservedEnd = TimeSpan.Parse(reader["EndTime"].ToString());
                            reservedSlots.Add((reservedStart, reservedEnd));
                        }
                    }
                }
            }

            // Filter out time slots that fall within reserved periods
            var availableSlots = allSlots.Where(slot =>
            {
                DateTime dtSlot = DateTime.Parse(slot);
                TimeSpan tsSlot = dtSlot.TimeOfDay;

                // Slot is available only if it does not start within any reserved interval
                return !reservedSlots.Any(rs => tsSlot >= rs.Start && tsSlot < rs.End);
            }).ToList();

            comboStartTime.DataSource = new List<string>(availableSlots);
            comboEndTime.DataSource = new List<string>(availableSlots);

            comboStartTime.SelectedIndex = -1;
            comboEndTime.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validate room selection
            if (comboRoom.SelectedValue == null)
            {
                MessageBox.Show("Please select a room.");
                comboRoom.Focus();
                return;
            }

            // Validate time selections
            if (comboStartTime.SelectedItem == null || comboEndTime.SelectedItem == null)
            {
                MessageBox.Show("Please select start and end times.");
                comboStartTime.Focus();
                return;
            }

            // Validate purpose (not empty or whitespace)
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Purpose cannot be empty.");
                txtPurpose.Focus();
                return;
            }

            // Validate attendees input
            if (string.IsNullOrWhiteSpace(txtAttendees.Text))
            {
                MessageBox.Show("Please enter the number of attendees.");
                txtAttendees.Focus();
                return;
            }

            if (!int.TryParse(txtAttendees.Text, out int attendees))
            {
                MessageBox.Show("Attendees must be a number.");
                txtAttendees.Focus();
                return;
            }

            bool isStartValid = DateTime.TryParse(comboStartTime.SelectedItem.ToString(), out DateTime startDateTime);
            bool isEndValid = DateTime.TryParse(comboEndTime.SelectedItem.ToString(), out DateTime endDateTime);

            if (!isStartValid || !isEndValid)
            {
                MessageBox.Show("Invalid time selection.");
                return;
            }

            if (startDateTime >= endDateTime)
            {
                MessageBox.Show("Start time must be earlier than end time.");
                return;
            }

            using (var conn = DBHelper.GetConnection())
            {
                string checkQuery = @"SELECT * FROM Reservations 
                              WHERE RoomID = @room AND Date = @date 
                              AND (@start < EndTime AND @end > StartTime)";

                SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@room", comboRoom.SelectedValue);
                checkCmd.Parameters.AddWithValue("@date", datePicker.Value.ToString("yyyy-MM-dd"));
                checkCmd.Parameters.AddWithValue("@start", startDateTime.ToString("HH:mm"));
                checkCmd.Parameters.AddWithValue("@end", endDateTime.ToString("HH:mm"));

                var reader = checkCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Conflict detected. Please choose another time.");
                    return;
                }
                reader.Close();

                string insertQuery = @"INSERT INTO Reservations 
                               (UserID, RoomID, Date, StartTime, EndTime, Purpose, Attendees, Status) 
                               VALUES (@user, @room, @date, @start, @end, @purpose, @attendees, 'Pending')";

                SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@user", currentUserId);
                insertCmd.Parameters.AddWithValue("@room", comboRoom.SelectedValue);
                insertCmd.Parameters.AddWithValue("@date", datePicker.Value.ToString("yyyy-MM-dd"));
                insertCmd.Parameters.AddWithValue("@start", startDateTime.ToString("HH:mm"));
                insertCmd.Parameters.AddWithValue("@end", endDateTime.ToString("HH:mm"));
                insertCmd.Parameters.AddWithValue("@purpose", txtPurpose.Text.Trim());
                insertCmd.Parameters.AddWithValue("@attendees", attendees);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Reservation submitted. Awaiting approval.");
                ResetForm();
            }
        }


        private void ResetForm()
        {
            comboRoom.SelectedIndex = -1;
            comboStartTime.DataSource = null;
            comboEndTime.DataSource = null;
            txtPurpose.Clear();
            txtAttendees.Clear();
            datePicker.Value = DateTime.Today;
        }

        private void LoadRooms()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "SELECT RoomID, RoomName FROM Rooms";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboRoom.DataSource = dt;
                comboRoom.DisplayMember = "RoomName";
                comboRoom.ValueMember = "RoomID";
                comboRoom.SelectedIndex = -1;
            }
        }

        private void btnViewAvailability_Click(object sender, EventArgs e)
        {
            ViewAvailabilityForm viewForm = new ViewAvailabilityForm();
            viewForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart(); // Restarts the whole app and brings back the login form
        }



        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            ReservationHistoryForm historyForm = new ReservationHistoryForm(currentUserId);
            historyForm.Show();  
        }


        private void txtPurpose_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPurpose_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPurpose.Text))
            {
                MessageBox.Show("Purpose cannot be empty.");
                e.Cancel = true;  
            }
        }

        private void comboEndTime_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

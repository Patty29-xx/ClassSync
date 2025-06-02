using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class AddRoomForm : Form
    {
        private int? editingRoomId = null;

        // Constructor for adding new room
        public AddRoomForm()
        {
            InitializeComponent();
        }

        // Constructor for editing existing room
        public AddRoomForm(int roomId, string roomName, int capacity, string features) : this()
        {

            editingRoomId = roomId;

            txtRoomName.Text = roomName;
            txtCapacity.Text = capacity.ToString();
            txtFeatures.Text = features;

            this.Text = "Edit Room";
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();
            int capacity;
            if (!int.TryParse(txtCapacity.Text.Trim(), out capacity))
            {
                MessageBox.Show("Please enter a valid number for capacity.");
                return;
            }
            string features = txtFeatures.Text.Trim();

            using (var conn = DBHelper.GetConnection())
            {
                SQLiteCommand cmd;

                if (editingRoomId.HasValue)
                {
                    // Update existing room
                    string updateQuery = @"UPDATE Rooms 
                                   SET RoomName = @roomName, Capacity = @capacity, Features = @features 
                                   WHERE RoomID = @roomId";
                    cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@roomName", roomName);
                    cmd.Parameters.AddWithValue("@capacity", capacity);
                    cmd.Parameters.AddWithValue("@features", features);
                    cmd.Parameters.AddWithValue("@roomId", editingRoomId.Value);
                }
                else
                {
                    // Insert new room
                    string insertQuery = @"INSERT INTO Rooms (RoomName, Capacity, Features) 
                                   VALUES (@roomName, @capacity, @features)";
                    cmd = new SQLiteCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@roomName", roomName);
                    cmd.Parameters.AddWithValue("@capacity", capacity);
                    cmd.Parameters.AddWithValue("@features", features);
                }

                cmd.ExecuteNonQuery();
            }

            this.Close();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblRoomName_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCapacity_Click(object sender, EventArgs e)
        {

        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

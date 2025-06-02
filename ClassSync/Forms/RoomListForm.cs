using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ClassSync.Forms
{
    public partial class RoomListForm : Form
    {
        public RoomListForm()
        {
            InitializeComponent();

            // Attach event handlers
            btnAddRoom.Click += BtnAddRoom1_Click;
            dgvRooms.CellClick += dgvRooms_CellClick;
        }

        private void RoomListForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "SELECT RoomID, RoomName, Capacity, Features FROM Rooms";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvRooms.DataSource = dt;

                // Prevent duplicate button columns
                if (!dgvRooms.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                    editBtn.HeaderText = "Edit";
                    editBtn.Name = "Edit";
                    editBtn.Text = "Edit";
                    editBtn.UseColumnTextForButtonValue = true;
                    dgvRooms.Columns.Add(editBtn);
                }

                if (!dgvRooms.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                    deleteBtn.HeaderText = "Delete";
                    deleteBtn.Name = "Delete";
                    deleteBtn.Text = "Delete";
                    deleteBtn.UseColumnTextForButtonValue = true;
                    dgvRooms.Columns.Add(deleteBtn);
                }

                dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var selectedRow = dgvRooms.Rows[e.RowIndex];

            if (dgvRooms.Columns[e.ColumnIndex].Name == "Edit")
            {
                int roomId = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);
                string roomName = selectedRow.Cells["RoomName"].Value.ToString();
                int capacity = Convert.ToInt32(selectedRow.Cells["Capacity"].Value);
                string features = selectedRow.Cells["Features"].Value.ToString();

                AddRoomForm editForm = new AddRoomForm(roomId, roomName, capacity, features);
                editForm.FormClosed += (s, args) => LoadRooms();
                editForm.ShowDialog();
            }
            else if (dgvRooms.Columns[e.ColumnIndex].Name == "Delete")
            {
                int roomId = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);
                string roomName = selectedRow.Cells["RoomName"].Value.ToString();

                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete room '{roomName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (var conn = DBHelper.GetConnection())
                    {
                        string deleteQuery = "DELETE FROM Rooms WHERE RoomID = @roomId";
                        SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@roomId", roomId);
                        cmd.ExecuteNonQuery();
                    }
                    LoadRooms();
                }
            }
        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAddRoom1_Click(object sender, EventArgs e)
        {
            AddRoomForm addForm = new AddRoomForm();
            addForm.FormClosed += (s, args) => LoadRooms();
            addForm.ShowDialog();
        }
    }
}

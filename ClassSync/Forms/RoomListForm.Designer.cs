namespace ClassSync.Forms
{
    partial class RoomListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRooms;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.BtnAddRoom1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRooms.Location = new System.Drawing.Point(0, 0);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.Size = new System.Drawing.Size(904, 450);
            this.dgvRooms.TabIndex = 0;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellClick);
            this.dgvRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellContentClick);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(10, 10);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(100, 30);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            // 
            // BtnAddRoom1
            // 
            this.BtnAddRoom1.Location = new System.Drawing.Point(920, 14);
            this.BtnAddRoom1.Name = "BtnAddRoom1";
            this.BtnAddRoom1.Size = new System.Drawing.Size(75, 23);
            this.BtnAddRoom1.TabIndex = 2;
            this.BtnAddRoom1.Text = "Add Room";
            this.BtnAddRoom1.UseVisualStyleBackColor = true;
            this.BtnAddRoom1.Click += new System.EventHandler(this.BtnAddRoom1_Click);
            // 
            // RoomListForm
            // 
            this.ClientSize = new System.Drawing.Size(1007, 450);
            this.Controls.Add(this.BtnAddRoom1);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnAddRoom);
            this.Name = "RoomListForm";
            this.Text = "Room List";
            this.Load += new System.EventHandler(this.RoomListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button BtnAddRoom1;
    }
}

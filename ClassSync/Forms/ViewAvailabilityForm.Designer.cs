namespace ClassSync.Forms
{
    partial class ViewAvailabilityForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridRooms;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.ComboBox cmbEndTime;
        private System.Windows.Forms.Button btnCheckAvailability;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridRooms = new System.Windows.Forms.DataGridView();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.btnCheckAvailability = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRooms
            // 
            this.dataGridRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRooms.Location = new System.Drawing.Point(69, 12);
            this.dataGridRooms.Name = "dataGridRooms";
            this.dataGridRooms.Size = new System.Drawing.Size(702, 280);
            this.dataGridRooms.TabIndex = 0;
            this.dataGridRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRooms_CellContentClick);
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(72, 298);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(100, 20);
            this.datePicker.TabIndex = 1;
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartTime.FormattingEnabled = true;
            this.cmbStartTime.Items.AddRange(new object[] {
            "08:00 AM",
            "09:00 AM",
            "10:00 AM",
            "11:00 AM",
            "12:00 PM",
            "01:00 PM",
            "02:00 PM",
            "03:00 PM",
            "04:00 PM"});
            this.cmbStartTime.Location = new System.Drawing.Point(190, 298);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(90, 21);
            this.cmbStartTime.TabIndex = 2;
            this.cmbStartTime.SelectedIndexChanged += new System.EventHandler(this.cmbStartTime_SelectedIndexChanged);
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndTime.FormattingEnabled = true;
            this.cmbEndTime.Items.AddRange(new object[] {
            "09:00 AM",
            "10:00 AM",
            "11:00 AM",
            "12:00 PM",
            "01:00 PM",
            "02:00 PM",
            "03:00 PM",
            "04:00 PM",
            "05:00 PM"});
            this.cmbEndTime.Location = new System.Drawing.Point(290, 298);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(90, 21);
            this.cmbEndTime.TabIndex = 3;
            // 
            // btnCheckAvailability
            // 
            this.btnCheckAvailability.Location = new System.Drawing.Point(400, 298);
            this.btnCheckAvailability.Name = "btnCheckAvailability";
            this.btnCheckAvailability.Size = new System.Drawing.Size(120, 23);
            this.btnCheckAvailability.TabIndex = 4;
            this.btnCheckAvailability.Text = "Check Availability";
            this.btnCheckAvailability.UseVisualStyleBackColor = true;
            this.btnCheckAvailability.Click += new System.EventHandler(this.btnCheckAvailability_Click);
            // 
            // ViewAvailabilityForm
            // 
            this.BackgroundImage = global::ClassSync.Properties.Resources.ClassSync__1_;
            this.ClientSize = new System.Drawing.Size(816, 361);
            this.Controls.Add(this.dataGridRooms);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.cmbStartTime);
            this.Controls.Add(this.cmbEndTime);
            this.Controls.Add(this.btnCheckAvailability);
            this.Name = "ViewAvailabilityForm";
            this.Text = "Room Availability";
            this.Load += new System.EventHandler(this.ViewAvailabilityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRooms)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

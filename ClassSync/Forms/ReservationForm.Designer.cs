namespace ClassSync.Forms
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.comboRoom = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.txtPurpose = new System.Windows.Forms.RichTextBox();
            this.txtAttendees = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnViewAvailability = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.comboStartTime = new System.Windows.Forms.ComboBox();
            this.comboEndTime = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboRoom
            // 
            this.comboRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboRoom.FormattingEnabled = true;
            this.comboRoom.Location = new System.Drawing.Point(356, 130);
            this.comboRoom.Name = "comboRoom";
            this.comboRoom.Size = new System.Drawing.Size(226, 25);
            this.comboRoom.TabIndex = 0;
            this.comboRoom.Text = "Select Rooms";
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.datePicker.Location = new System.Drawing.Point(373, 170);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(185, 23);
            this.datePicker.TabIndex = 1;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtPurpose.Location = new System.Drawing.Point(315, 242);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(372, 144);
            this.txtPurpose.TabIndex = 6;
            this.txtPurpose.Text = "What Your Purpose?";
            this.txtPurpose.TextChanged += new System.EventHandler(this.txtPurpose_TextChanged);
            // 
            // txtAttendees
            // 
            this.txtAttendees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAttendees.Location = new System.Drawing.Point(424, 392);
            this.txtAttendees.Name = "txtAttendees";
            this.txtAttendees.Size = new System.Drawing.Size(148, 23);
            this.txtAttendees.TabIndex = 7;
            this.txtAttendees.Text = "Number of Attendees";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnSubmit.Location = new System.Drawing.Point(401, 448);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(171, 35);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnViewAvailability
            // 
            this.btnViewAvailability.Location = new System.Drawing.Point(673, 480);
            this.btnViewAvailability.Name = "btnViewAvailability";
            this.btnViewAvailability.Size = new System.Drawing.Size(131, 23);
            this.btnViewAvailability.TabIndex = 9;
            this.btnViewAvailability.Text = "View Available Rooms";
            this.btnViewAvailability.UseVisualStyleBackColor = true;
            this.btnViewAvailability.Click += new System.EventHandler(this.btnViewAvailability_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.Location = new System.Drawing.Point(673, 448);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(131, 23);
            this.btnViewHistory.TabIndex = 10;
            this.btnViewHistory.Text = "View History";
            this.btnViewHistory.UseVisualStyleBackColor = true;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(174, 111);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // comboStartTime
            // 
            this.comboStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboStartTime.FormattingEnabled = true;
            this.comboStartTime.Location = new System.Drawing.Point(315, 211);
            this.comboStartTime.Name = "comboStartTime";
            this.comboStartTime.Size = new System.Drawing.Size(121, 25);
            this.comboStartTime.TabIndex = 12;
            this.comboStartTime.Text = "Start Time";
            // 
            // comboEndTime
            // 
            this.comboEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.comboEndTime.FormattingEnabled = true;
            this.comboEndTime.Location = new System.Drawing.Point(445, 211);
            this.comboEndTime.Name = "comboEndTime";
            this.comboEndTime.Size = new System.Drawing.Size(137, 25);
            this.comboEndTime.TabIndex = 13;
            this.comboEndTime.Text = "End Time";
            this.comboEndTime.SelectedIndexChanged += new System.EventHandler(this.comboEndTime_SelectedIndexChanged);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClassSync.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(945, 515);
            this.Controls.Add(this.comboEndTime);
            this.Controls.Add(this.comboStartTime);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnViewAvailability);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAttendees);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.comboRoom);
            this.Name = "ReservationForm";
            this.Text = "ReservationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboRoom;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.RichTextBox txtPurpose;
        private System.Windows.Forms.TextBox txtAttendees;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnViewAvailability;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox comboStartTime;
        private System.Windows.Forms.ComboBox comboEndTime;
    }
}
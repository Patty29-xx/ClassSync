namespace ClassSync.Forms
{
    partial class AddRoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblFeatures;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.TextBox txtFeatures;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblFeatures = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.txtFeatures = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblRoomName.Location = new System.Drawing.Point(192, 144);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(136, 25);
            this.lblRoomName.TabIndex = 0;
            this.lblRoomName.Text = "Room Name:";
            this.lblRoomName.Click += new System.EventHandler(this.lblRoomName_Click);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblCapacity.Location = new System.Drawing.Point(187, 197);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(102, 25);
            this.lblCapacity.TabIndex = 2;
            this.lblCapacity.Text = "Capacity:";
            this.lblCapacity.Click += new System.EventHandler(this.lblCapacity_Click);
            // 
            // lblFeatures
            // 
            this.lblFeatures.AutoSize = true;
            this.lblFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lblFeatures.Location = new System.Drawing.Point(192, 246);
            this.lblFeatures.Name = "lblFeatures";
            this.lblFeatures.Size = new System.Drawing.Size(103, 25);
            this.lblFeatures.TabIndex = 4;
            this.lblFeatures.Text = "Features:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtRoomName.Location = new System.Drawing.Point(344, 141);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(216, 31);
            this.txtRoomName.TabIndex = 1;
            this.txtRoomName.TextChanged += new System.EventHandler(this.txtRoomName_TextChanged);
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtCapacity.Location = new System.Drawing.Point(295, 194);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(186, 31);
            this.txtCapacity.TabIndex = 3;
            this.txtCapacity.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // txtFeatures
            // 
            this.txtFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.txtFeatures.Location = new System.Drawing.Point(301, 246);
            this.txtFeatures.Name = "txtFeatures";
            this.txtFeatures.Size = new System.Drawing.Size(315, 31);
            this.txtFeatures.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(426, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(522, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddRoomForm
            // 
            this.BackgroundImage = global::ClassSync.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(945, 515);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.txtRoomName);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.lblFeatures);
            this.Controls.Add(this.txtFeatures);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddRoomForm";
            this.Text = "Add New Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace ClassSync.Forms
{
    partial class AdminDashboard
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRoomList = new System.Windows.Forms.Button();
            this.btnViewAvailability = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(120, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(679, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);

            // btnApprove
            this.btnApprove.Location = new System.Drawing.Point(819, 56);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);

            // btnReject
            this.btnReject.Location = new System.Drawing.Point(819, 85);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(819, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnRoomList
            this.btnRoomList.Location = new System.Drawing.Point(819, 207);
            this.btnRoomList.Name = "btnRoomList";
            this.btnRoomList.Size = new System.Drawing.Size(75, 40);
            this.btnRoomList.TabIndex = 5;
            this.btnRoomList.Text = "Manage Rooms";
            this.btnRoomList.UseVisualStyleBackColor = true;
            this.btnRoomList.Click += new System.EventHandler(this.btnRoomList_Click);

            // btnAddRoom
            this.btnAddRoom.Location = new System.Drawing.Point(819, 253);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 4;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);

            // btnViewAvailability
            this.btnViewAvailability.Location = new System.Drawing.Point(630, 425);
            this.btnViewAvailability.Name = "btnViewAvailability";
            this.btnViewAvailability.Size = new System.Drawing.Size(169, 23);
            this.btnViewAvailability.TabIndex = 6;
            this.btnViewAvailability.Text = "View Available Rooms";
            this.btnViewAvailability.UseVisualStyleBackColor = true;
            this.btnViewAvailability.Click += new System.EventHandler(this.btnViewAvailability_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(819, 396);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // AdminDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Remove these two lines to handle image manually
            // this.BackgroundImage = global::ClassSync.Properties.Resources.ClassSync;
            // this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(957, 554);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewAvailability);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRoomList);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";

            // Attach the Paint event to draw background image with aspect ratio
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminDashboard_Paint);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnRoomList;
        private System.Windows.Forms.Button btnViewAvailability;
        private System.Windows.Forms.Button btnLogout;

        // Paint method to maintain aspect ratio of background image
        private void AdminDashboard_Paint(object sender, PaintEventArgs e)
        {
            Image background = global::ClassSync.Properties.Resources.ClassSync;
            Graphics g = e.Graphics;

            float formAspect = (float)this.ClientSize.Width / this.ClientSize.Height;
            float imageAspect = (float)background.Width / background.Height;

            int drawWidth, drawHeight;
            if (formAspect > imageAspect)
            {
                drawHeight = this.ClientSize.Height;
                drawWidth = (int)(drawHeight * imageAspect);
            }
            else
            {
                drawWidth = this.ClientSize.Width;
                drawHeight = (int)(drawWidth / imageAspect);
            }

            int offsetX = (this.ClientSize.Width - drawWidth) / 2;
            int offsetY = (this.ClientSize.Height - drawHeight) / 2;

            Rectangle destRect = new Rectangle(offsetX, offsetY, drawWidth, drawHeight);
            g.DrawImage(background, destRect);
        }
    }
}

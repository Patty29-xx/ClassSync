namespace ClassSync.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnReserveRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F);
            this.lblWelcome.Location = new System.Drawing.Point(177, 226);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(246, 54);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "ClassSync";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // btnReserveRoom
            // 
            this.btnReserveRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnReserveRoom.Location = new System.Drawing.Point(286, 430);
            this.btnReserveRoom.Name = "btnReserveRoom";
            this.btnReserveRoom.Size = new System.Drawing.Size(402, 56);
            this.btnReserveRoom.TabIndex = 1;
            this.btnReserveRoom.Text = "Reserve a room a now ";
            this.btnReserveRoom.UseVisualStyleBackColor = true;
            this.btnReserveRoom.Click += new System.EventHandler(this.btnReserveRoom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClassSync.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(945, 515);
            this.Controls.Add(this.btnReserveRoom);
            this.Controls.Add(this.lblWelcome);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnReserveRoom;
    }
}
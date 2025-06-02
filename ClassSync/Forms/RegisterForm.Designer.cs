namespace ClassSync.Forms
{
    partial class RegisterForm
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLoginBack = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.btnRegister.Location = new System.Drawing.Point(593, 456);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(6);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(287, 44);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(593, 249);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(290, 31);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Text = "Password";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(593, 194);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(290, 31);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.Text = "Username";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // btnLoginBack
            // 
            this.btnLoginBack.AutoSize = true;
            this.btnLoginBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnLoginBack.LinkColor = System.Drawing.Color.Firebrick;
            this.btnLoginBack.Location = new System.Drawing.Point(709, 430);
            this.btnLoginBack.Name = "btnLoginBack";
            this.btnLoginBack.Size = new System.Drawing.Size(50, 20);
            this.btnLoginBack.TabIndex = 9;
            this.btnLoginBack.TabStop = true;
            this.btnLoginBack.Text = "Login";
            this.btnLoginBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLoginBack_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ClassSync.Properties.Resources.Register;
            this.ClientSize = new System.Drawing.Size(945, 515);
            this.Controls.Add(this.btnLoginBack);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.LinkLabel btnLoginBack;
    }
}
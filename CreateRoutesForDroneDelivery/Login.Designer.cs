namespace CreateRoutesForDroneDelivery
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.PictureBox_Banner = new System.Windows.Forms.PictureBox();
            this.Label_User = new System.Windows.Forms.Label();
            this.Label_Password = new System.Windows.Forms.Label();
            this.TextBox_User = new System.Windows.Forms.TextBox();
            this.LinkLabel_Register = new System.Windows.Forms.LinkLabel();
            this.PictureBox_LoginButton = new System.Windows.Forms.PictureBox();
            this.Label_ErrorMessage = new System.Windows.Forms.Label();
            this.PictureBox_PasswordVisibility = new System.Windows.Forms.PictureBox();
            this.CheckBox_RememberCredentials = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Banner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LoginButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_PasswordVisibility)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Password.Location = new System.Drawing.Point(81, 344);
            this.TextBox_Password.MaxLength = 15;
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.PasswordChar = '●';
            this.TextBox_Password.Size = new System.Drawing.Size(330, 29);
            this.TextBox_Password.TabIndex = 1;
            this.TextBox_Password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_Password_MouseClick);
            this.TextBox_Password.MouseLeave += new System.EventHandler(this.TextBox_Password_MouseLeave);
            // 
            // PictureBox_Banner
            // 
            this.PictureBox_Banner.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Banner.Image")));
            this.PictureBox_Banner.Location = new System.Drawing.Point(51, 47);
            this.PictureBox_Banner.Name = "PictureBox_Banner";
            this.PictureBox_Banner.Size = new System.Drawing.Size(443, 137);
            this.PictureBox_Banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Banner.TabIndex = 1;
            this.PictureBox_Banner.TabStop = false;
            // 
            // Label_User
            // 
            this.Label_User.AutoSize = true;
            this.Label_User.Location = new System.Drawing.Point(77, 244);
            this.Label_User.Name = "Label_User";
            this.Label_User.Size = new System.Drawing.Size(74, 23);
            this.Label_User.TabIndex = 2;
            this.Label_User.Text = "Usuario";
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(77, 318);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(105, 23);
            this.Label_Password.TabIndex = 3;
            this.Label_Password.Text = "Contraseña";
            // 
            // TextBox_User
            // 
            this.TextBox_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_User.Location = new System.Drawing.Point(81, 271);
            this.TextBox_User.Name = "TextBox_User";
            this.TextBox_User.Size = new System.Drawing.Size(375, 29);
            this.TextBox_User.TabIndex = 0;
            this.TextBox_User.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_User_MouseClick);
            this.TextBox_User.MouseLeave += new System.EventHandler(this.TextBox_User_MouseLeave);
            // 
            // LinkLabel_Register
            // 
            this.LinkLabel_Register.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(136)))), ((int)(((byte)(216)))));
            this.LinkLabel_Register.AutoSize = true;
            this.LinkLabel_Register.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabel_Register.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(161)))), ((int)(((byte)(242)))));
            this.LinkLabel_Register.Location = new System.Drawing.Point(135, 530);
            this.LinkLabel_Register.Name = "LinkLabel_Register";
            this.LinkLabel_Register.Size = new System.Drawing.Size(295, 20);
            this.LinkLabel_Register.TabIndex = 5;
            this.LinkLabel_Register.TabStop = true;
            this.LinkLabel_Register.Text = "¿Aún no tienes una cuenta? Regístrate";
            this.LinkLabel_Register.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(109)))), ((int)(((byte)(166)))));
            this.LinkLabel_Register.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_Register_LinkClicked);
            // 
            // PictureBox_LoginButton
            // 
            this.PictureBox_LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox_LoginButton.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_LoginButton.Image")));
            this.PictureBox_LoginButton.Location = new System.Drawing.Point(81, 429);
            this.PictureBox_LoginButton.Name = "PictureBox_LoginButton";
            this.PictureBox_LoginButton.Size = new System.Drawing.Size(375, 36);
            this.PictureBox_LoginButton.TabIndex = 6;
            this.PictureBox_LoginButton.TabStop = false;
            this.PictureBox_LoginButton.Click += new System.EventHandler(this.PictureBox_LoginButton_Click);
            this.PictureBox_LoginButton.MouseLeave += new System.EventHandler(this.PictureBox_LoginButton_MouseLeave);
            this.PictureBox_LoginButton.MouseHover += new System.EventHandler(this.PictureBox_LoginButton_MouseHover);
            // 
            // Label_ErrorMessage
            // 
            this.Label_ErrorMessage.AutoSize = true;
            this.Label_ErrorMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.Label_ErrorMessage.Location = new System.Drawing.Point(104, 476);
            this.Label_ErrorMessage.Name = "Label_ErrorMessage";
            this.Label_ErrorMessage.Size = new System.Drawing.Size(415, 23);
            this.Label_ErrorMessage.TabIndex = 7;
            this.Label_ErrorMessage.Text = "Error al iniciar sesión, verifique sus credenciales";
            this.Label_ErrorMessage.Visible = false;
            // 
            // PictureBox_PasswordVisibility
            // 
            this.PictureBox_PasswordVisibility.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_PasswordVisibility.Image")));
            this.PictureBox_PasswordVisibility.Location = new System.Drawing.Point(432, 345);
            this.PictureBox_PasswordVisibility.Name = "PictureBox_PasswordVisibility";
            this.PictureBox_PasswordVisibility.Size = new System.Drawing.Size(24, 24);
            this.PictureBox_PasswordVisibility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_PasswordVisibility.TabIndex = 8;
            this.PictureBox_PasswordVisibility.TabStop = false;
            this.PictureBox_PasswordVisibility.Click += new System.EventHandler(this.PictureBox_PasswordVisibility_Click);
            // 
            // CheckBox_RememberCredentials
            // 
            this.CheckBox_RememberCredentials.AutoSize = true;
            this.CheckBox_RememberCredentials.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CheckBox_RememberCredentials.Location = new System.Drawing.Point(206, 388);
            this.CheckBox_RememberCredentials.Name = "CheckBox_RememberCredentials";
            this.CheckBox_RememberCredentials.Size = new System.Drawing.Size(147, 28);
            this.CheckBox_RememberCredentials.TabIndex = 9;
            this.CheckBox_RememberCredentials.Text = "Recuérdame";
            this.CheckBox_RememberCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBox_RememberCredentials.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 601);
            this.Controls.Add(this.CheckBox_RememberCredentials);
            this.Controls.Add(this.PictureBox_PasswordVisibility);
            this.Controls.Add(this.Label_ErrorMessage);
            this.Controls.Add(this.PictureBox_LoginButton);
            this.Controls.Add(this.LinkLabel_Register);
            this.Controls.Add(this.TextBox_User);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Label_User);
            this.Controls.Add(this.PictureBox_Banner);
            this.Controls.Add(this.TextBox_Password);
            this.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Banner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_LoginButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_PasswordVisibility)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.PictureBox PictureBox_Banner;
        private System.Windows.Forms.Label Label_User;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.TextBox TextBox_User;
        private System.Windows.Forms.LinkLabel LinkLabel_Register;
        private System.Windows.Forms.PictureBox PictureBox_LoginButton;
        private System.Windows.Forms.Label Label_ErrorMessage;
        private System.Windows.Forms.PictureBox PictureBox_PasswordVisibility;
        private System.Windows.Forms.CheckBox CheckBox_RememberCredentials;
    }
}
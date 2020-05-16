namespace CreateRoutesForDroneDelivery
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.TextBox_User = new System.Windows.Forms.TextBox();
            this.Label_CheckPassword = new System.Windows.Forms.Label();
            this.Label_User = new System.Windows.Forms.Label();
            this.TextBox_CheckPassword = new System.Windows.Forms.TextBox();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.Label_Role = new System.Windows.Forms.Label();
            this.ComboBox_Role = new System.Windows.Forms.ComboBox();
            this.PictureBox_RegisterButton = new System.Windows.Forms.PictureBox();
            this.Label_ErrorMessage = new System.Windows.Forms.Label();
            this.PictureBox_Banner = new System.Windows.Forms.PictureBox();
            this.PictureBox_PasswordVisibility = new System.Windows.Forms.PictureBox();
            this.PictureBox_CheckPasswordVisibility = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_RegisterButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Banner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_PasswordVisibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CheckPasswordVisibility)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_User
            // 
            this.TextBox_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_User.Location = new System.Drawing.Point(74, 278);
            this.TextBox_User.MaxLength = 15;
            this.TextBox_User.Name = "TextBox_User";
            this.TextBox_User.Size = new System.Drawing.Size(375, 29);
            this.TextBox_User.TabIndex = 1;
            // 
            // Label_CheckPassword
            // 
            this.Label_CheckPassword.AutoSize = true;
            this.Label_CheckPassword.Location = new System.Drawing.Point(70, 363);
            this.Label_CheckPassword.Name = "Label_CheckPassword";
            this.Label_CheckPassword.Size = new System.Drawing.Size(168, 23);
            this.Label_CheckPassword.TabIndex = 7;
            this.Label_CheckPassword.Text = "Repetir contraseña";
            // 
            // Label_User
            // 
            this.Label_User.AutoSize = true;
            this.Label_User.Location = new System.Drawing.Point(70, 255);
            this.Label_User.Name = "Label_User";
            this.Label_User.Size = new System.Drawing.Size(74, 23);
            this.Label_User.TabIndex = 6;
            this.Label_User.Text = "Usuario";
            // 
            // TextBox_CheckPassword
            // 
            this.TextBox_CheckPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_CheckPassword.Location = new System.Drawing.Point(74, 386);
            this.TextBox_CheckPassword.MaxLength = 15;
            this.TextBox_CheckPassword.Name = "TextBox_CheckPassword";
            this.TextBox_CheckPassword.PasswordChar = '●';
            this.TextBox_CheckPassword.Size = new System.Drawing.Size(299, 29);
            this.TextBox_CheckPassword.TabIndex = 3;
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Name.Location = new System.Drawing.Point(74, 224);
            this.TextBox_Name.MaxLength = 20;
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(375, 29);
            this.TextBox_Name.TabIndex = 0;
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(70, 309);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(105, 23);
            this.Label_Password.TabIndex = 11;
            this.Label_Password.Text = "Contraseña";
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(70, 201);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(79, 23);
            this.Label_Name.TabIndex = 10;
            this.Label_Name.Text = "Nombre";
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_Password.Location = new System.Drawing.Point(74, 332);
            this.TextBox_Password.MaxLength = 15;
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.PasswordChar = '●';
            this.TextBox_Password.Size = new System.Drawing.Size(299, 29);
            this.TextBox_Password.TabIndex = 2;
            // 
            // Label_Role
            // 
            this.Label_Role.AutoSize = true;
            this.Label_Role.Location = new System.Drawing.Point(70, 417);
            this.Label_Role.Name = "Label_Role";
            this.Label_Role.Size = new System.Drawing.Size(38, 23);
            this.Label_Role.TabIndex = 12;
            this.Label_Role.Text = "Rol";
            // 
            // ComboBox_Role
            // 
            this.ComboBox_Role.AutoCompleteCustomSource.AddRange(new string[] {
            "Administrador",
            "Usuario",
            "Otro"});
            this.ComboBox_Role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Role.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ComboBox_Role.FormattingEnabled = true;
            this.ComboBox_Role.Items.AddRange(new object[] {
            "Administrador",
            "Usuario",
            "Otro"});
            this.ComboBox_Role.Location = new System.Drawing.Point(74, 440);
            this.ComboBox_Role.Name = "ComboBox_Role";
            this.ComboBox_Role.Size = new System.Drawing.Size(215, 30);
            this.ComboBox_Role.TabIndex = 4;
            // 
            // PictureBox_RegisterButton
            // 
            this.PictureBox_RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox_RegisterButton.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_RegisterButton.Image")));
            this.PictureBox_RegisterButton.Location = new System.Drawing.Point(74, 519);
            this.PictureBox_RegisterButton.Name = "PictureBox_RegisterButton";
            this.PictureBox_RegisterButton.Size = new System.Drawing.Size(375, 36);
            this.PictureBox_RegisterButton.TabIndex = 14;
            this.PictureBox_RegisterButton.TabStop = false;
            this.PictureBox_RegisterButton.Click += new System.EventHandler(this.PictureBox_RegisterButton_Click);
            this.PictureBox_RegisterButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_RegisterButton_MouseClick);
            this.PictureBox_RegisterButton.MouseLeave += new System.EventHandler(this.PictureBox_RegisterButton_MouseLeave);
            this.PictureBox_RegisterButton.MouseHover += new System.EventHandler(this.PictureBox_RegisterButton_MouseHover);
            // 
            // Label_ErrorMessage
            // 
            this.Label_ErrorMessage.AutoSize = true;
            this.Label_ErrorMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.Label_ErrorMessage.Location = new System.Drawing.Point(187, 482);
            this.Label_ErrorMessage.Name = "Label_ErrorMessage";
            this.Label_ErrorMessage.Size = new System.Drawing.Size(152, 23);
            this.Label_ErrorMessage.TabIndex = 15;
            this.Label_ErrorMessage.Text = "Mensaje de error";
            this.Label_ErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_ErrorMessage.Visible = false;
            // 
            // PictureBox_Banner
            // 
            this.PictureBox_Banner.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Banner.Image")));
            this.PictureBox_Banner.Location = new System.Drawing.Point(51, 47);
            this.PictureBox_Banner.Name = "PictureBox_Banner";
            this.PictureBox_Banner.Size = new System.Drawing.Size(443, 137);
            this.PictureBox_Banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Banner.TabIndex = 16;
            this.PictureBox_Banner.TabStop = false;
            // 
            // PictureBox_PasswordVisibility
            // 
            this.PictureBox_PasswordVisibility.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_PasswordVisibility.Image")));
            this.PictureBox_PasswordVisibility.Location = new System.Drawing.Point(388, 333);
            this.PictureBox_PasswordVisibility.Name = "PictureBox_PasswordVisibility";
            this.PictureBox_PasswordVisibility.Size = new System.Drawing.Size(24, 24);
            this.PictureBox_PasswordVisibility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_PasswordVisibility.TabIndex = 19;
            this.PictureBox_PasswordVisibility.TabStop = false;
            this.PictureBox_PasswordVisibility.Click += new System.EventHandler(this.PictureBox_PasswordVisibility_Click);
            // 
            // PictureBox_CheckPasswordVisibility
            // 
            this.PictureBox_CheckPasswordVisibility.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_CheckPasswordVisibility.Image")));
            this.PictureBox_CheckPasswordVisibility.Location = new System.Drawing.Point(388, 387);
            this.PictureBox_CheckPasswordVisibility.Name = "PictureBox_CheckPasswordVisibility";
            this.PictureBox_CheckPasswordVisibility.Size = new System.Drawing.Size(24, 24);
            this.PictureBox_CheckPasswordVisibility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_CheckPasswordVisibility.TabIndex = 20;
            this.PictureBox_CheckPasswordVisibility.TabStop = false;
            this.PictureBox_CheckPasswordVisibility.Click += new System.EventHandler(this.PictureBox_CheckPasswordVisibility_Click);
            // 
            // SignUp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 601);
            this.Controls.Add(this.PictureBox_CheckPasswordVisibility);
            this.Controls.Add(this.PictureBox_PasswordVisibility);
            this.Controls.Add(this.PictureBox_Banner);
            this.Controls.Add(this.Label_ErrorMessage);
            this.Controls.Add(this.PictureBox_RegisterButton);
            this.Controls.Add(this.ComboBox_Role);
            this.Controls.Add(this.Label_Role);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.TextBox_User);
            this.Controls.Add(this.Label_CheckPassword);
            this.Controls.Add(this.Label_User);
            this.Controls.Add(this.TextBox_CheckPassword);
            this.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SignUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_RegisterButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Banner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_PasswordVisibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_CheckPasswordVisibility)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBox_User;
        private System.Windows.Forms.Label Label_CheckPassword;
        private System.Windows.Forms.Label Label_User;
        private System.Windows.Forms.TextBox TextBox_CheckPassword;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Label Label_Role;
        private System.Windows.Forms.ComboBox ComboBox_Role;
        private System.Windows.Forms.PictureBox PictureBox_RegisterButton;
        private System.Windows.Forms.Label Label_ErrorMessage;
        private System.Windows.Forms.PictureBox PictureBox_Banner;
        private System.Windows.Forms.PictureBox PictureBox_PasswordVisibility;
        private System.Windows.Forms.PictureBox PictureBox_CheckPasswordVisibility;
    }
}
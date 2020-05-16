namespace CreateRoutesForDroneDelivery
{
    partial class GraphManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphManagement));
            this.ComboBox_Origin = new System.Windows.Forms.ComboBox();
            this.ComboBox_Destination = new System.Windows.Forms.ComboBox();
            this.Label_Origin = new System.Windows.Forms.Label();
            this.Label_Destination = new System.Windows.Forms.Label();
            this.PictureBox_Cancel = new System.Windows.Forms.PictureBox();
            this.PictureBox_OK = new System.Windows.Forms.PictureBox();
            this.Label_Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_OK)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBox_Origin
            // 
            this.ComboBox_Origin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Origin.FormattingEnabled = true;
            this.ComboBox_Origin.Location = new System.Drawing.Point(49, 74);
            this.ComboBox_Origin.MaxDropDownItems = 4;
            this.ComboBox_Origin.Name = "ComboBox_Origin";
            this.ComboBox_Origin.Size = new System.Drawing.Size(310, 30);
            this.ComboBox_Origin.TabIndex = 0;
            this.ComboBox_Origin.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Origin_SelectedIndexChanged);
            // 
            // ComboBox_Destination
            // 
            this.ComboBox_Destination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Destination.FormattingEnabled = true;
            this.ComboBox_Destination.Location = new System.Drawing.Point(414, 74);
            this.ComboBox_Destination.MaxDropDownItems = 4;
            this.ComboBox_Destination.Name = "ComboBox_Destination";
            this.ComboBox_Destination.Size = new System.Drawing.Size(310, 30);
            this.ComboBox_Destination.TabIndex = 1;
            this.ComboBox_Destination.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Destination_SelectedIndexChanged);
            // 
            // Label_Origin
            // 
            this.Label_Origin.AutoSize = true;
            this.Label_Origin.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Origin.Location = new System.Drawing.Point(45, 48);
            this.Label_Origin.Name = "Label_Origin";
            this.Label_Origin.Size = new System.Drawing.Size(67, 23);
            this.Label_Origin.TabIndex = 2;
            this.Label_Origin.Text = "Origen";
            // 
            // Label_Destination
            // 
            this.Label_Destination.AutoSize = true;
            this.Label_Destination.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Destination.Location = new System.Drawing.Point(410, 48);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(75, 23);
            this.Label_Destination.TabIndex = 3;
            this.Label_Destination.Text = "Destino";
            // 
            // PictureBox_Cancel
            // 
            this.PictureBox_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Cancel.Image")));
            this.PictureBox_Cancel.Location = new System.Drawing.Point(340, 190);
            this.PictureBox_Cancel.Name = "PictureBox_Cancel";
            this.PictureBox_Cancel.Size = new System.Drawing.Size(118, 34);
            this.PictureBox_Cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Cancel.TabIndex = 4;
            this.PictureBox_Cancel.TabStop = false;
            this.PictureBox_Cancel.Click += new System.EventHandler(this.PictureBox_Cancel_Click);
            this.PictureBox_Cancel.MouseLeave += new System.EventHandler(this.PictureBox_Cancel_MouseLeave);
            this.PictureBox_Cancel.MouseHover += new System.EventHandler(this.PictureBox_Cancel_MouseHover);
            // 
            // PictureBox_OK
            // 
            this.PictureBox_OK.ErrorImage = null;
            this.PictureBox_OK.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_OK.Image")));
            this.PictureBox_OK.Location = new System.Drawing.Point(266, 141);
            this.PictureBox_OK.Name = "PictureBox_OK";
            this.PictureBox_OK.Size = new System.Drawing.Size(267, 34);
            this.PictureBox_OK.TabIndex = 5;
            this.PictureBox_OK.TabStop = false;
            this.PictureBox_OK.Click += new System.EventHandler(this.PictureBox_OK_Click);
            this.PictureBox_OK.MouseLeave += new System.EventHandler(this.PictureBox_OK_MouseLeave);
            this.PictureBox_OK.MouseHover += new System.EventHandler(this.PictureBox_OK_MouseHover);
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.Location = new System.Drawing.Point(357, 13);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(109, 23);
            this.Label_Message.TabIndex = 6;
            this.Label_Message.Text = "Notification";
            this.Label_Message.Visible = false;
            // 
            // GraphManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 242);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.PictureBox_OK);
            this.Controls.Add(this.PictureBox_Cancel);
            this.Controls.Add(this.Label_Destination);
            this.Controls.Add(this.Label_Origin);
            this.Controls.Add(this.ComboBox_Destination);
            this.Controls.Add(this.ComboBox_Origin);
            this.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GraphManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_OK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBox_Origin;
        private System.Windows.Forms.ComboBox ComboBox_Destination;
        private System.Windows.Forms.Label Label_Origin;
        private System.Windows.Forms.Label Label_Destination;
        private System.Windows.Forms.PictureBox PictureBox_Cancel;
        private System.Windows.Forms.PictureBox PictureBox_OK;
        private System.Windows.Forms.Label Label_Message;
    }
}
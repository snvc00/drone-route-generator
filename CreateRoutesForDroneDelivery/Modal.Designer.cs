namespace CreateRoutesForDroneDelivery
{
    partial class Modal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modal));
            this.Label_Message = new System.Windows.Forms.Label();
            this.PictureBox_Cancel = new System.Windows.Forms.PictureBox();
            this.PictureBox_Accept = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Accept)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Message.Location = new System.Drawing.Point(163, 45);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(48, 23);
            this.Label_Message.TabIndex = 0;
            this.Label_Message.Text = "Path";
            this.Label_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBox_Cancel
            // 
            this.PictureBox_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Cancel.Image")));
            this.PictureBox_Cancel.Location = new System.Drawing.Point(67, 90);
            this.PictureBox_Cancel.Name = "PictureBox_Cancel";
            this.PictureBox_Cancel.Size = new System.Drawing.Size(118, 34);
            this.PictureBox_Cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Cancel.TabIndex = 3;
            this.PictureBox_Cancel.TabStop = false;
            this.PictureBox_Cancel.Click += new System.EventHandler(this.PictureBox_Cancel_Click);
            this.PictureBox_Cancel.MouseLeave += new System.EventHandler(this.PictureBox_Cancel_MouseLeave);
            this.PictureBox_Cancel.MouseHover += new System.EventHandler(this.PictureBox_Cancel_MouseHover);
            // 
            // PictureBox_Accept
            // 
            this.PictureBox_Accept.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Accept.Image")));
            this.PictureBox_Accept.Location = new System.Drawing.Point(223, 90);
            this.PictureBox_Accept.Name = "PictureBox_Accept";
            this.PictureBox_Accept.Size = new System.Drawing.Size(118, 34);
            this.PictureBox_Accept.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Accept.TabIndex = 2;
            this.PictureBox_Accept.TabStop = false;
            this.PictureBox_Accept.Click += new System.EventHandler(this.PictureBox_Accept_Click);
            this.PictureBox_Accept.MouseLeave += new System.EventHandler(this.PictureBox_Accept_MouseLeave);
            this.PictureBox_Accept.MouseHover += new System.EventHandler(this.PictureBox_Accept_MouseHover);
            // 
            // Modal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 152);
            this.Controls.Add(this.PictureBox_Cancel);
            this.Controls.Add(this.PictureBox_Accept);
            this.Controls.Add(this.Label_Message);
            this.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Accept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.PictureBox PictureBox_Cancel;
        private System.Windows.Forms.PictureBox PictureBox_Accept;
    }
}
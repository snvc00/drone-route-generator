namespace CreateRoutesForDroneDelivery
{
    partial class GalleryView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GalleryView));
            this.PictureBox_Map = new System.Windows.Forms.PictureBox();
            this.ImageList_Routes = new System.Windows.Forms.ImageList(this.components);
            this.ListView_Gallery = new System.Windows.Forms.ListView();
            this.Panel_RouteDetails = new System.Windows.Forms.Panel();
            this.Label_RouteDistance = new System.Windows.Forms.Label();
            this.Label_RouteDistanceTitle = new System.Windows.Forms.Label();
            this.Label_CreationDate = new System.Windows.Forms.Label();
            this.Label_CreationDateTitle = new System.Windows.Forms.Label();
            this.Label_FileName = new System.Windows.Forms.Label();
            this.Label_FileNameTitle = new System.Windows.Forms.Label();
            this.Label_Email = new System.Windows.Forms.Label();
            this.Label_Subject = new System.Windows.Forms.Label();
            this.TextBox_Email = new System.Windows.Forms.TextBox();
            this.TextBox_Subject = new System.Windows.Forms.TextBox();
            this.PictureBox_Send = new System.Windows.Forms.PictureBox();
            this.Panel_ShareRoute = new System.Windows.Forms.Panel();
            this.Label_Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Map)).BeginInit();
            this.Panel_RouteDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Send)).BeginInit();
            this.Panel_ShareRoute.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox_Map
            // 
            this.PictureBox_Map.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Map.Image")));
            this.PictureBox_Map.Location = new System.Drawing.Point(68, 23);
            this.PictureBox_Map.Name = "PictureBox_Map";
            this.PictureBox_Map.Size = new System.Drawing.Size(837, 543);
            this.PictureBox_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox_Map.TabIndex = 1;
            this.PictureBox_Map.TabStop = false;
            // 
            // ImageList_Routes
            // 
            this.ImageList_Routes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList_Routes.ImageSize = new System.Drawing.Size(16, 16);
            this.ImageList_Routes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ListView_Gallery
            // 
            this.ListView_Gallery.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.ListView_Gallery.Font = new System.Drawing.Font("Roboto Thin", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListView_Gallery.HideSelection = false;
            this.ListView_Gallery.Location = new System.Drawing.Point(972, 23);
            this.ListView_Gallery.MultiSelect = false;
            this.ListView_Gallery.Name = "ListView_Gallery";
            this.ListView_Gallery.Size = new System.Drawing.Size(314, 543);
            this.ListView_Gallery.TabIndex = 2;
            this.ListView_Gallery.UseCompatibleStateImageBehavior = false;
            this.ListView_Gallery.SelectedIndexChanged += new System.EventHandler(this.ListView_Gallery_SelectedIndexChanged);
            // 
            // Panel_RouteDetails
            // 
            this.Panel_RouteDetails.Controls.Add(this.Label_RouteDistance);
            this.Panel_RouteDetails.Controls.Add(this.Label_RouteDistanceTitle);
            this.Panel_RouteDetails.Controls.Add(this.Label_CreationDate);
            this.Panel_RouteDetails.Controls.Add(this.Label_CreationDateTitle);
            this.Panel_RouteDetails.Controls.Add(this.Label_FileName);
            this.Panel_RouteDetails.Controls.Add(this.Label_FileNameTitle);
            this.Panel_RouteDetails.Location = new System.Drawing.Point(30, 588);
            this.Panel_RouteDetails.Name = "Panel_RouteDetails";
            this.Panel_RouteDetails.Size = new System.Drawing.Size(558, 130);
            this.Panel_RouteDetails.TabIndex = 4;
            this.Panel_RouteDetails.Visible = false;
            // 
            // Label_RouteDistance
            // 
            this.Label_RouteDistance.AutoSize = true;
            this.Label_RouteDistance.Location = new System.Drawing.Point(271, 36);
            this.Label_RouteDistance.Name = "Label_RouteDistance";
            this.Label_RouteDistance.Size = new System.Drawing.Size(55, 23);
            this.Label_RouteDistance.TabIndex = 5;
            this.Label_RouteDistance.Text = "0 KM";
            // 
            // Label_RouteDistanceTitle
            // 
            this.Label_RouteDistanceTitle.AutoSize = true;
            this.Label_RouteDistanceTitle.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_RouteDistanceTitle.Location = new System.Drawing.Point(270, 9);
            this.Label_RouteDistanceTitle.Name = "Label_RouteDistanceTitle";
            this.Label_RouteDistanceTitle.Size = new System.Drawing.Size(179, 23);
            this.Label_RouteDistanceTitle.TabIndex = 4;
            this.Label_RouteDistanceTitle.Text = "Distancia de la ruta:";
            // 
            // Label_CreationDate
            // 
            this.Label_CreationDate.AutoSize = true;
            this.Label_CreationDate.Location = new System.Drawing.Point(12, 36);
            this.Label_CreationDate.Name = "Label_CreationDate";
            this.Label_CreationDate.Size = new System.Drawing.Size(113, 23);
            this.Label_CreationDate.TabIndex = 3;
            this.Label_CreationDate.Text = "fecha y hora";
            // 
            // Label_CreationDateTitle
            // 
            this.Label_CreationDateTitle.AutoSize = true;
            this.Label_CreationDateTitle.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_CreationDateTitle.Location = new System.Drawing.Point(12, 9);
            this.Label_CreationDateTitle.Name = "Label_CreationDateTitle";
            this.Label_CreationDateTitle.Size = new System.Drawing.Size(171, 23);
            this.Label_CreationDateTitle.TabIndex = 2;
            this.Label_CreationDateTitle.Text = "Fecha de creación:";
            // 
            // Label_FileName
            // 
            this.Label_FileName.AutoSize = true;
            this.Label_FileName.Location = new System.Drawing.Point(12, 98);
            this.Label_FileName.Name = "Label_FileName";
            this.Label_FileName.Size = new System.Drawing.Size(71, 23);
            this.Label_FileName.TabIndex = 1;
            this.Label_FileName.Text = "archivo";
            // 
            // Label_FileNameTitle
            // 
            this.Label_FileNameTitle.AutoSize = true;
            this.Label_FileNameTitle.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_FileNameTitle.Location = new System.Drawing.Point(12, 71);
            this.Label_FileNameTitle.Name = "Label_FileNameTitle";
            this.Label_FileNameTitle.Size = new System.Drawing.Size(183, 23);
            this.Label_FileNameTitle.TabIndex = 0;
            this.Label_FileNameTitle.Text = "Nombre del archivo:";
            // 
            // Label_Email
            // 
            this.Label_Email.AutoSize = true;
            this.Label_Email.Location = new System.Drawing.Point(13, 9);
            this.Label_Email.Name = "Label_Email";
            this.Label_Email.Size = new System.Drawing.Size(160, 23);
            this.Label_Email.TabIndex = 0;
            this.Label_Email.Text = "Correo de destino";
            // 
            // Label_Subject
            // 
            this.Label_Subject.AutoSize = true;
            this.Label_Subject.Location = new System.Drawing.Point(13, 68);
            this.Label_Subject.Name = "Label_Subject";
            this.Label_Subject.Size = new System.Drawing.Size(69, 23);
            this.Label_Subject.TabIndex = 1;
            this.Label_Subject.Text = "Asunto";
            // 
            // TextBox_Email
            // 
            this.TextBox_Email.Location = new System.Drawing.Point(17, 36);
            this.TextBox_Email.Name = "TextBox_Email";
            this.TextBox_Email.Size = new System.Drawing.Size(389, 29);
            this.TextBox_Email.TabIndex = 2;
            this.TextBox_Email.Click += new System.EventHandler(this.TextBox_Email_Click);
            this.TextBox_Email.MouseLeave += new System.EventHandler(this.TextBox_Email_MouseLeave);
            // 
            // TextBox_Subject
            // 
            this.TextBox_Subject.Location = new System.Drawing.Point(17, 92);
            this.TextBox_Subject.Name = "TextBox_Subject";
            this.TextBox_Subject.Size = new System.Drawing.Size(389, 29);
            this.TextBox_Subject.TabIndex = 3;
            this.TextBox_Subject.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox_Subject_MouseClick);
            this.TextBox_Subject.MouseLeave += new System.EventHandler(this.TextBox_Subject_MouseLeave);
            // 
            // PictureBox_Send
            // 
            this.PictureBox_Send.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Send.Image")));
            this.PictureBox_Send.Location = new System.Drawing.Point(455, 60);
            this.PictureBox_Send.Name = "PictureBox_Send";
            this.PictureBox_Send.Size = new System.Drawing.Size(267, 34);
            this.PictureBox_Send.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox_Send.TabIndex = 4;
            this.PictureBox_Send.TabStop = false;
            this.PictureBox_Send.Click += new System.EventHandler(this.PictureBox_Send_Click);
            this.PictureBox_Send.MouseLeave += new System.EventHandler(this.PictureBox_Send_MouseLeave);
            this.PictureBox_Send.MouseHover += new System.EventHandler(this.PictureBox_Send_MouseHover);
            // 
            // Panel_ShareRoute
            // 
            this.Panel_ShareRoute.Controls.Add(this.Label_Message);
            this.Panel_ShareRoute.Controls.Add(this.PictureBox_Send);
            this.Panel_ShareRoute.Controls.Add(this.TextBox_Subject);
            this.Panel_ShareRoute.Controls.Add(this.TextBox_Email);
            this.Panel_ShareRoute.Controls.Add(this.Label_Subject);
            this.Panel_ShareRoute.Controls.Add(this.Label_Email);
            this.Panel_ShareRoute.Location = new System.Drawing.Point(594, 588);
            this.Panel_ShareRoute.Name = "Panel_ShareRoute";
            this.Panel_ShareRoute.Size = new System.Drawing.Size(797, 130);
            this.Panel_ShareRoute.TabIndex = 3;
            this.Panel_ShareRoute.Visible = false;
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.ForeColor = System.Drawing.Color.Firebrick;
            this.Label_Message.Location = new System.Drawing.Point(546, 25);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(88, 23);
            this.Label_Message.TabIndex = 5;
            this.Label_Message.Text = "Message";
            this.Label_Message.Visible = false;
            // 
            // GalleryView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1403, 730);
            this.Controls.Add(this.Panel_RouteDetails);
            this.Controls.Add(this.Panel_ShareRoute);
            this.Controls.Add(this.ListView_Gallery);
            this.Controls.Add(this.PictureBox_Map);
            this.Font = new System.Drawing.Font("Roboto", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GalleryView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Map)).EndInit();
            this.Panel_RouteDetails.ResumeLayout(false);
            this.Panel_RouteDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Send)).EndInit();
            this.Panel_ShareRoute.ResumeLayout(false);
            this.Panel_ShareRoute.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Map;
        private System.Windows.Forms.ImageList ImageList_Routes;
        private System.Windows.Forms.ListView ListView_Gallery;
        private System.Windows.Forms.Panel Panel_RouteDetails;
        private System.Windows.Forms.Label Label_Email;
        private System.Windows.Forms.Label Label_Subject;
        private System.Windows.Forms.TextBox TextBox_Email;
        private System.Windows.Forms.TextBox TextBox_Subject;
        private System.Windows.Forms.PictureBox PictureBox_Send;
        private System.Windows.Forms.Panel Panel_ShareRoute;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.Label Label_RouteDistance;
        private System.Windows.Forms.Label Label_RouteDistanceTitle;
        private System.Windows.Forms.Label Label_CreationDate;
        private System.Windows.Forms.Label Label_CreationDateTitle;
        private System.Windows.Forms.Label Label_FileName;
        private System.Windows.Forms.Label Label_FileNameTitle;
    }
}
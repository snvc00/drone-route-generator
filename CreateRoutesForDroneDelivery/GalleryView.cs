using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace CreateRoutesForDroneDelivery
{
    public partial class GalleryView : Form
    {
        readonly User CurrentUser;
        DateTime DisableSendUntil;
        readonly string MessageBody;
        int SelectedRoute;
        List<string> RouteImagePath;
        public bool AvailableContent;

        public GalleryView(User currentUser, string mode)
        {
            InitializeComponent();
            this.AvailableContent = true;

            if (Directory.GetFiles(currentUser.UserFolderPath).ToList().Count < 1)
            {
                Modal notification = new Modal("No hay contenido para mostrar", true);
                notification.ShowDialog();
                this.AvailableContent = false;
            }
            else
            {
                this.CurrentUser = currentUser;
                this.SelectedRoute = 0;
                this.RouteImagePath = new List<string>();

                ConfigureImageList();
                InitializeListView();

                if (RouteImagePath.Count > 0)
                    this.PictureBox_Map.Image = Image.FromFile(RouteImagePath[0]);

                if (mode == "ShareRoute")
                {
                    this.MessageBody = "<div style=\"font - family: Roboto\"><h1>Drone Route Generator</h1><p>Ruta enviada a tráves de <a href=\"https://github.com/snvc00/drone-route-generator\" target=\"_blank\">Drone Route Generator</a></p></div>";
                    InitializeLocallyShareRoute();
                }
                else
                    InitializeLocallyGeneratedRoutes();
            }
        }

        public void InitializeLocallyShareRoute()
        {
            Panel_ShareRoute.Location = new Point((this.Width / 2) - Panel_ShareRoute.Width / 2, Panel_ShareRoute.Location.Y);
            Panel_ShareRoute.Visible = true;
            DisableSendUntil = DateTime.Now;
        }

        public void InitializeLocallyGeneratedRoutes()
        {
            if (RouteImagePath.Count > 0)
            {
                UpdateDetailLabels(0);
                Panel_RouteDetails.Visible = true;
            }
        }

        public void UpdateDetailLabels(int pathIndex)
        { 
            string firstImageFileName = Path.GetFileName(RouteImagePath[pathIndex]);
            Label_FileName.Text = firstImageFileName;
            DateTime creationDate = DateTime.FromFileTime(long.Parse(firstImageFileName.Split('_')[1]));
            Label_CreationDate.Text = creationDate.ToString();
            Label_RouteDistance.Text = firstImageFileName.Split('_')[2].Split('.')[0] + " KM";
        }

        public void ConfigureImageList()
        {
            ImageList_Routes.ImageSize = new Size(250, 200);
            LoadImagesToImageList();
        }

        public void LoadImagesToImageList()
        {
            foreach (string path in Directory.GetFiles(CurrentUser.UserFolderPath))
            {
                ImageList_Routes.Images.Add(Path.GetFileName(path), new Bitmap(path));
                RouteImagePath.Add(Path.GetFullPath(path));
            }
        }

        public void InitializeListView()
        {
            ListView_Gallery.View = View.LargeIcon;
            ListView_Gallery.Columns.Add("ColumnName", 200);
            ListView_Gallery.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            ListView_Gallery.Alignment = ListViewAlignment.SnapToGrid;
            ListView_Gallery.LargeImageList = ImageList_Routes;

            for (int index = 0; index < ImageList_Routes.Images.Count; ++index)
                ListView_Gallery.Items.Add(Path.GetFileName(RouteImagePath[index]), index);
        }

        private bool RunValidations()
        {
            if (TextBox_Email.Text == "")
            {
                ShowMessage("Correo de destino es un campo obligatorio");
                return false;
            }

            if (TextBox_Subject.Text == "")
            {
                ShowMessage("Asunto es un campo obligatorio");
                return false;
            }

            return true;
        }

        private void ShowMessage(string message, string mode = "")
        {
            Label_Message.Text = message;
            Label_Message.Location = new Point((PictureBox_Send.Location.X + PictureBox_Send.Width / 2) - Label_Message.Width / 2, Label_Message.Location.Y);

            if (mode == "success")
                Label_Message.ForeColor = Color.FromArgb(34, 166, 16);
            else
                Label_Message.ForeColor = Color.Firebrick;

            Label_Message.Visible = true;
        }

        //<--   ShareRoute Panel Functionality -->

        private void TextBox_Email_Click(object sender, EventArgs e)
        {
            Label_Email.Font = new Font(Label_Email.Font, FontStyle.Bold);
        }

        private void TextBox_Subject_MouseClick(object sender, MouseEventArgs e)
        {
            Label_Subject.Font = new Font(Label_Subject.Font, FontStyle.Bold);
        }

        private void TextBox_Email_MouseLeave(object sender, EventArgs e)
        {
            Label_Email.Font = new Font(Label_Email.Font, FontStyle.Regular);
        }

        private void TextBox_Subject_MouseLeave(object sender, EventArgs e)
        {
            Label_Subject.Font = new Font(Label_Subject.Font, FontStyle.Regular);
        }

        private void PictureBox_Send_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Send.Image = Image.FromFile($"../../../resources/galleryview/send_route-medium.png");
            this.Cursor = Cursors.Hand;
        }

        private void PictureBox_Send_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Send.Image = Image.FromFile($"../../../resources/galleryview/send_route-light.png");
            this.Cursor = Cursors.Default;
        }

        private void PictureBox_Send_Click(object sender, EventArgs e)
        {
            PictureBox_Send.Image = Image.FromFile($"../../../resources/galleryview/send_route-dark.png");
            this.Cursor = Cursors.WaitCursor;

            if (DisableSendUntil.CompareTo(DateTime.Now) < 1)
            {
                if (RunValidations())
                {
                    DisableSendUntil = DateTime.Now.AddSeconds(30);
                    ShowMessage("Mensaje enviado exitosamente", "success");

                    SMTP.SendEmail(TextBox_Email.Text, TextBox_Subject.Text, MessageBody, RouteImagePath[SelectedRoute]);
                }
            }
            else
            {
                ShowMessage("Disponible: " + DisableSendUntil.ToString());
            }

            this.Cursor = Cursors.Default;
        }

        private void ListView_Gallery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView_Gallery.SelectedIndices.Count > 0)
            {
                this.SelectedRoute = ListView_Gallery.SelectedIndices[0];
                PictureBox_Map.Image = Image.FromFile(RouteImagePath[SelectedRoute]);
                PictureBox_Map.Refresh();
                UpdateDetailLabels(SelectedRoute);
            }
        }
    }
}

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CreateRoutesForDroneDelivery
{
    public partial class MainWindow : Form
    {
        User CurrentUser;
        const int PointDiameter = 20;
        Vertex SelectedVertex;
        bool AbleToPaint;
        bool ExportedRoute;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitalizeLocally(User user)
        {
            this.CurrentUser = user;
            this.ExportedRoute = false;

            if (user != null)
            {
                if (File.Exists(CurrentUser.UserFolderPath + "unsaved.jpeg"))
                {
                    Image unsaved = GetImageCopy(CurrentUser.UserFolderPath + "unsaved.jpeg");
                    PictureBox_Map.Image = unsaved;

                    if (File.Exists(CurrentUser.UserFolderPath + "unsaved.graph"))
                        LoadGraphInformation(CurrentUser.UserFolderPath + "unsaved.graph");
                }

                Label_User.Text = user.Name;
                Label_User.Location = new Point((PictureBox_Logout.Location.X + PictureBox_Logout.Width / 2) - Label_User.Width / 2, Label_User.Location.Y);
                Label_User.Visible = true;
            }

        }

        private Image GetImageCopy(string path)
        {
            using (Image img = Image.FromFile(path))
            {
                Bitmap bmp = new Bitmap(img);
                return bmp;
            }
        }

        private void LoadGraphInformation(string path)
        {
            foreach (string vertexString in File.ReadLines(path))
                this.CurrentUser.DeliveryNetwork.AddVertex(vertexString);
        }

        private bool BelongsToExistingPoint(MouseEventArgs e)
        {
            foreach (Vertex point in CurrentUser.DeliveryNetwork.Graph)
            {
                if (GetDistance(e.Location, point.Position) <= PointDiameter * 1.5)
                {
                    SelectedVertex = point;
                    return true;
                }
            }

            return false;
        }

        public static double GetDistance(Point x, Point y)
        {
            return Math.Sqrt(((x.X - y.X) * (x.X - y.X)) + ((x.Y - y.Y) * (x.Y - y.Y)));
        }

        private void SaveMapChanges(string filename)
        {
            filename += ".jpeg";

            Bitmap map = new Bitmap(PictureBox_Map.Image);

            PictureBox_Map.Image = Image.FromFile("../../../resources/mainwindow/map.png");

            string currentPath = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(CurrentUser.UserFolderPath);

            if (File.Exists(filename))
                File.Delete(filename);

            map.Save(filename, ImageFormat.Jpeg);

            StreamWriter file;

            if (filename.Contains("unsaved"))
            {
                file = new StreamWriter("unsaved.graph");
                SaveGraphInformation(file);
            }
            
            Directory.SetCurrentDirectory(currentPath);
        }

        private void SaveGraphInformation(StreamWriter file)
        { 
            foreach (Vertex vertex in CurrentUser.DeliveryNetwork.Graph)
            {
                file.WriteLine("{0};{1}", vertex.VertexString(), vertex.EdgeString());
            }

            file.Close();
        }

        private void RemoveUnsavedFiles()
        {
            if (File.Exists(CurrentUser.UserFolderPath + "unsaved.jpeg"))
                File.Delete(CurrentUser.UserFolderPath + "unsaved.jpeg");

            if (File.Exists(CurrentUser.UserFolderPath + "unsaved.graph"))
                File.Delete(CurrentUser.UserFolderPath + "unsaved.graph");
        }

        //<--   Click Events    -->

        private void PictureBox_Logout_Click(object sender, EventArgs e)
        {
            PictureBox_Logout.Image = Image.FromFile($"../../../resources/mainwindow/logout-dark.png");
            Label_User.Font = new Font(Label_User.Font, FontStyle.Bold);
            Label_User.BackColor = Color.FromArgb(166, 16, 16);
            Label_User.ForeColor = Color.White;
            this.Refresh();

            if (CurrentUser.DeliveryNetwork.Graph.Count > 0)
            {
                if (CurrentUser.DeliveryNetwork.RouteDistance < 0)
                {
                    SaveMapChanges("unsaved");
                }
                else
                {
                    if (!ExportedRoute)
                    {
                        SaveMapChanges("createdroute_" + DateTime.Now.ToFileTime() + "_" + CurrentUser.DeliveryNetwork.RouteDistance);
                        RemoveUnsavedFiles();
                    }
                }
            }

            this.Close();
        }

        private void PictureBox_Map_MouseClick(object sender, MouseEventArgs e)
        {
            if (BelongsToExistingPoint(e))
            {
                VertexDetails details = new VertexDetails(CurrentUser, e.Location, PictureBox_Map);
                details.InitializeLocally(SelectedVertex);
                details.ShowDialog();
            }
            else
            {
                VertexDetails createVertex = new VertexDetails(CurrentUser, e.Location, PictureBox_Map);
                createVertex.ShowDialog();

                if (AbleToPaint)
                    AbleToPaint = false;

                this.ExportedRoute = false;
            }
        }

        private void PictureBox_ReportBug_Click(object sender, EventArgs e)
        {
            PictureBox_ReportBug.Image = Image.FromFile($"../../../resources/mainwindow/report_bug-dark.png");
            Process.Start("https://github.com/snvc00/drone-route-generator/issues");
        }

        private void PictureBox_About_Click(object sender, EventArgs e)
        {
            PictureBox_About.Image = Image.FromFile($"../../../resources/mainwindow/about-dark.png");
            Process.Start("https://snvc00.github.io/drone-route-generator/");
        }

        private void PictureBox_HowToUse_Click(object sender, EventArgs e)
        {
            PictureBox_HowToUse.Image = Image.FromFile($"../../../resources/mainwindow/how_to_use-dark.png");
            Process.Start("https://snvc00.github.io/drone-route-generator/");
        }

        private void PictureBox_ShareRoute_Click(object sender, EventArgs e)
        {
            this.Hide();
            GalleryView routesGalleryView = new GalleryView(CurrentUser, "ShareRoute");
            if (routesGalleryView.AvailableContent)
                routesGalleryView.ShowDialog();
            this.Show();
        }

        private void PictureBox_ExportRoute_Click(object sender, EventArgs e)
        {
            if (CurrentUser.DeliveryNetwork.RouteDistance != -1)
            {
                SaveMapChanges("createdroute_" + DateTime.Now.ToFileTime() + "_" + CurrentUser.DeliveryNetwork.RouteDistance);
                PictureBox_Map.Image = Image.FromFile("../../../resources/mainwindow/map.png");

                RemoveUnsavedFiles();
                this.CurrentUser.DeliveryNetwork.ClearGraph();

                this.ExportedRoute = true;

                Modal notification = new Modal("Ruta guardada en: " + CurrentUser.UserFolderPath.Substring(8), true);
                notification.ShowDialog();
            }
            else
            {
                Modal notification = new Modal("Antes de intentar exportar genera una ruta", true);
                notification.ShowDialog();
            }
        }

        private void PictureBox_CreatedRoutes_Click(object sender, EventArgs e)
        {
            this.Hide();
            GalleryView routesGalleryView = new GalleryView(CurrentUser, "CreatedRoutes");

            if (routesGalleryView.AvailableContent)
                routesGalleryView.ShowDialog();

            this.Show();
        }

        private void PictureBox_AddConnection_Click(object sender, EventArgs e)
        {
            GraphManagement graph = new GraphManagement(this.CurrentUser, "AddConnection", this.PictureBox_Map);
            graph.ShowDialog();
        }

        private void PictureBox_GenerateRoute_Click(object sender, EventArgs e)
        {
            GraphManagement graph = new GraphManagement(this.CurrentUser, "GenerateRoute", this.PictureBox_Map);
            graph.ShowDialog();
            Modal notification;

            if (graph.State)
                notification = new Modal("La ruta ha sido generada exitosamente", true);
            else
                notification = new Modal("Error al intentar generar la ruta", true);

            this.PictureBox_Map.Refresh();

            notification.ShowDialog();
        }

        private void Label_User_Click(object sender, EventArgs e)
        {
            PictureBox_Logout_Click(sender, e);
        }

        //<--   MouseLeave Events   -->

        private void PictureBox_Logout_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Logout.Image = Image.FromFile($"../../../resources/mainwindow/logout-light.png");
            Label_User.Font = new Font(Label_User.Font, FontStyle.Regular);
            Label_User.BackColor = Color.White;
            Label_User.ForeColor = Color.FromArgb(242, 29, 29);
            Cursor = Cursors.Default;
            this.Refresh();
        }

        private void Label_User_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Logout_MouseLeave(sender, e);
        }

        private void PictureBox_AddConnection_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_AddConnection.Image = Image.FromFile($"../../../resources/mainwindow/add_connection-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_GenerateRoute_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_GenerateRoute.Image = Image.FromFile($"../../../resources/mainwindow/generate_route-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_CreatedRoutes_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_CreatedRoutes.Image = Image.FromFile($"../../../resources/mainwindow/created_routes-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_ExportRoute_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_ExportRoute.Image = Image.FromFile($"../../../resources/mainwindow/export_route-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_ShareRoute_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_ShareRoute.Image = Image.FromFile($"../../../resources/mainwindow/share_route-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_HowToUse_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_HowToUse.Image = Image.FromFile($"../../../resources/mainwindow/how_to_use-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_About_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_About.Image = Image.FromFile($"../../../resources/mainwindow/about-light.png");
            Cursor = Cursors.Default;
        }

        private void PictureBox_ReportBug_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_ReportBug.Image = Image.FromFile($"../../../resources/mainwindow/report_bug-light.png");
            Cursor = Cursors.Default;
        }

        //<--   MouseHover Events   -->

        private void PictureBox_Logout_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Logout.Image = Image.FromFile($"../../../resources/mainwindow/logout-medium.png");
            Label_User.Font = new Font(Label_User.Font, FontStyle.Bold);
            Label_User.BackColor = Color.White;
            Label_User.ForeColor = Color.FromArgb(216, 6, 6);
            Cursor = Cursors.Hand;
            this.Refresh();
        }

        private void Label_User_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Logout_MouseHover(sender, e);
        }

        private void PictureBox_AddConnection_MouseHover(object sender, EventArgs e)
        {
            PictureBox_AddConnection.Image = Image.FromFile($"../../../resources/mainwindow/add_connection-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_GenerateRoute_MouseHover(object sender, EventArgs e)
        {
            PictureBox_GenerateRoute.Image = Image.FromFile($"../../../resources/mainwindow/generate_route-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_CreatedRoutes_MouseHover(object sender, EventArgs e)
        {
            PictureBox_CreatedRoutes.Image = Image.FromFile($"../../../resources/mainwindow/created_routes-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_ExportRoute_MouseHover(object sender, EventArgs e)
        {
            PictureBox_ExportRoute.Image = Image.FromFile($"../../../resources/mainwindow/export_route-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_ShareRoute_MouseHover(object sender, EventArgs e)
        {
            PictureBox_ShareRoute.Image = Image.FromFile($"../../../resources/mainwindow/share_route-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_HowToUse_MouseHover(object sender, EventArgs e)
        {
            PictureBox_HowToUse.Image = Image.FromFile($"../../../resources/mainwindow/how_to_use-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_About_MouseHover(object sender, EventArgs e)
        {
            PictureBox_About.Image = Image.FromFile($"../../../resources/mainwindow/about-medium.png");
            Cursor = Cursors.Hand;
        }

        private void PictureBox_ReportBug_MouseHover(object sender, EventArgs e)
        {
            PictureBox_ReportBug.Image = Image.FromFile($"../../../resources/mainwindow/report_bug-medium.png");
            Cursor = Cursors.Hand;
        }
    }
}

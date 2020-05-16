using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateRoutesForDroneDelivery
{
    public partial class GraphManagement : Form
    {
        User CurrentUser;
        Vertex DisabledToOrigin;
        Vertex DisabledToDestination;
        PictureBox Map;
        string Mode;
        bool IState;

        public GraphManagement(User currentUser, string mode, PictureBox map = null)
        {
            InitializeComponent();
            this.CurrentUser = currentUser;
            this.Mode = mode;
            this.IState = false;

            if (map != null)
                this.Map = map;

            InitializeLocally(Mode);
        }

        public bool State
        {
            get { return this.IState; }
        }

        public void InitializeLocally(string mode)
        {
            UpdateComboBoxOrigin();
            UpdateComboBoxDestination();

            if (mode == "AddConnection")
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/add_connection-light.png");
            else
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/generate_route-light.png");
        }

        public void UpdateComboBoxOrigin()
        {
            ComboBox_Origin.BeginUpdate();
            ComboBox_Origin.Items.AddRange(CurrentUser.DeliveryNetwork.Graph.ToArray());
            ComboBox_Origin.EndUpdate();
        }

        public void UpdateComboBoxDestination()
        {
            ComboBox_Destination.BeginUpdate();
            ComboBox_Destination.Items.AddRange(CurrentUser.DeliveryNetwork.Graph.ToArray());
            ComboBox_Destination.EndUpdate();
        }

        private void GenerateRoute(Vertex origin, Vertex destination)
        {
            if (origin != null && destination != null)
            {
                List<Vertex> path = DijkstraAlgorithm(origin, destination);

                if (path != null)
                    CurrentUser.DeliveryNetwork.SetRoute(path);
                else
                    IState = false;
            }    

            if (CurrentUser.DeliveryNetwork.GeneratedRoute != null)
                GenerateAnimation();
       
            this.Close();
        }

        private void GenerateAnimation()
        { 
            Bitmap newMap = new Bitmap(this.Map.Image);
            double totalWeight = 0;

            for (int i = 0; i < CurrentUser.DeliveryNetwork.GeneratedRoute.Count - 1; ++i)
            {
                if (i == 0)
                    Graphics.FromImage(newMap).FillEllipse(new SolidBrush(Color.Green), CurrentUser.DeliveryNetwork.GeneratedRoute[i].Position.X - 15, CurrentUser.DeliveryNetwork.GeneratedRoute[i].Position.Y - 15, 30, 30);
                                                                                        
                if (i == CurrentUser.DeliveryNetwork.GeneratedRoute.Count - 2)          
                    Graphics.FromImage(newMap).FillEllipse(new SolidBrush(Color.Firebrick), CurrentUser.DeliveryNetwork.GeneratedRoute[i + 1].Position.X - 15, CurrentUser.DeliveryNetwork.GeneratedRoute[i + 1].Position.Y - 15, 30, 30);

                foreach (Edge edge in CurrentUser.DeliveryNetwork.GeneratedRoute[i].Edges)
                {
                    if (edge.Destination.Name == CurrentUser.DeliveryNetwork.GeneratedRoute[i + 1].Name)
                    {
                        Graphics.FromImage(newMap).DrawLine(new Pen(Color.FromArgb(54, 54, 54), 3), CurrentUser.DeliveryNetwork.GeneratedRoute[i].Position, CurrentUser.DeliveryNetwork.GeneratedRoute[i + 1].Position);
                        totalWeight += edge.Distance;
                    }
                }
            }

            CurrentUser.DeliveryNetwork.UpdateDistance(totalWeight);
            Map.Image = newMap;
            Map.Refresh();
        }

        private List<Vertex> DijkstraAlgorithm(Vertex origin, Vertex destination)
        {
            Dijkstra dijkstraInstace = new Dijkstra(this.CurrentUser.DeliveryNetwork, origin);
            dijkstraInstace.DijkstraAlgorithm();
            this.IState = true;

            bool isConnected = dijkstraInstace.IsConnected(destination);

            if (isConnected)
                return dijkstraInstace.BuildPath(destination);
            else
                return null;
        }

        private void AddConnection(Vertex origin, Vertex destination)
        {
            if (origin != null && destination != null)
            {
                if (EdgeExist(origin, destination))
                {
                    ShowMessage("Esta conexión ya existe", Color.Firebrick);
                }
                else
                {
                    double distance = MainWindow.GetDistance(origin.Position, destination.Position);

                    Edge OriginToDestination = new Edge(distance, destination);
                    Edge DestinationToOrigin = new Edge(distance, origin);

                    origin.AddEdge(OriginToDestination);
                    destination.AddEdge(DestinationToOrigin);
                    DrawEdgeInMap(origin.Position, destination.Position);
                    ShowMessage("Conexión agregada exitosamente", Color.FromArgb(34, 166, 16));
                }
            }
            else
            {
                ShowMessage("Origen y destino son campos obligatorios", Color.Firebrick);
            }
        }

        private bool EdgeExist(Vertex origin, Vertex destination)
        {
            foreach (Edge edge in origin.Edges)
                if (edge.Destination.Name == destination.Name)
                    return true;

            return false;
        }

        private void DrawEdgeInMap(Point origin, Point destination)
        {
            Bitmap bmp = new Bitmap(Map.Image);
            Graphics.FromImage(bmp).DrawLine(new Pen(Color.Orange, 3), origin, destination);
            Map.Image = bmp;
        }

        private void ShowMessage(string message, Color color)
        {
            Label_Message.Text = message;
            Label_Message.ForeColor = color;
            Label_Message.Location = new Point((this.Width / 2) - Label_Message.Width / 2, Label_Message.Location.Y);
            Label_Message.Visible = true;
        }

        //<--   MouseClick Events   -->

        private void PictureBox_Cancel_Click(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/graphmanagement/cancel-dark.png");
            this.Close();
        }

        private void PictureBox_OK_Click(object sender, EventArgs e)
        {
            if (Mode == "AddConnection")
                AddConnection((Vertex)ComboBox_Origin.SelectedItem, (Vertex)ComboBox_Destination.SelectedItem);
            else
                GenerateRoute((Vertex)ComboBox_Origin.SelectedItem, (Vertex)ComboBox_Destination.SelectedItem);
        }

        //<--   MouseHover Events   -->

        private void PictureBox_Cancel_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/graphmanagement/cancel-medium.png");
            this.Cursor = Cursors.Hand;
        }

        private void PictureBox_OK_MouseHover(object sender, EventArgs e)
        {
            if (Mode == "AddConnection")
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/add_connection-medium.png");
            else
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/generate_route-medium.png");

            this.Cursor = Cursors.Hand;
        }

        //<--   MouseLeave Events   -->

        private void PictureBox_OK_MouseLeave(object sender, EventArgs e)
        {
            if (Mode == "AddConnection")
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/add_connection-light.png");
            else
                PictureBox_OK.Image = Image.FromFile($"../../../resources/graphmanagement/generate_route-light.png");

            this.Cursor = Cursors.Default;
        }

        private void PictureBox_Cancel_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/graphmanagement/cancel-light.png");
            this.Cursor = Cursors.Default;
        }

        //<--   IndexChanged Events    -->

        private void ComboBox_Origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DisabledToDestination != null)
                ComboBox_Destination.Items.Add(DisabledToDestination);

            DisabledToDestination = (Vertex)ComboBox_Origin.SelectedItem;
            ComboBox_Destination.Items.Remove(DisabledToDestination);
        }

        private void ComboBox_Destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DisabledToOrigin != null)
                ComboBox_Origin.Items.Add(DisabledToOrigin);

            DisabledToOrigin = (Vertex)ComboBox_Destination.SelectedItem;
            ComboBox_Origin.Items.Remove(DisabledToOrigin);
        }
    }
}

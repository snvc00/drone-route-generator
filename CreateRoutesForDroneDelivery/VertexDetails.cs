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
    public partial class VertexDetails : Form
    {
        Vertex CurrentVertex;
        readonly DateTime CreationTime;
        readonly User CurrentUser;
        readonly Point Position;
        readonly PictureBox Map;

        public VertexDetails(User currentUser, Point position, PictureBox map)
        {
            InitializeComponent();
            CreationTime = DateTime.Now;
            this.TextBox_CreationDate.Text = CreationTime.ToString();
            this.CurrentUser = currentUser;
            this.Position = position;
            this.Map = map;
        }

        public void InitializeLocally(Vertex vertex)
        {
            this.CurrentVertex = vertex;
            this.TextBox_Name.Text = CurrentVertex.Name;
            this.TextBox_Address.Text = CurrentVertex.Address;
            this.TextBox_Contact.Text = CurrentVertex.Contact;
            this.TextBox_CreationDate.Text = CurrentVertex.CreationDate.ToString();
            this.ComboBox_Role.SelectedItem = CurrentVertex.Role;
        }

        //<--   Mouse Hover Functionality   -->

        private void PictureBox_Cancel_MouseHover(object sender, EventArgs e) {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/details/cancel-medium.png");
            this.Cursor = Cursors.Hand;
        }

        private void PictureBox_Accept_MouseHover(object sender, EventArgs e) {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/details/accept-medium.png");
            this.Cursor = Cursors.Hand;
        }


        //<--   Mouse Leave Functionality   -->

        private void PictureBox_Cancel_MouseLeave(object sender, EventArgs e) {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/details/cancel-light.png");
            this.Cursor = Cursors.Default;
        }

        private void PictureBox_Accept_MouseLeave(object sender, EventArgs e) {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/details/accept-light.png");
            this.Cursor = Cursors.Default;
        }

        //<--   Mouse Click Functionality   -->

        private void PictureBox_Cancel_Click(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/details/cancel-dark.png");
            this.Close();
        }

        private Vertex ConvertFieldsToVertex()
        {
            return new Vertex(TextBox_Name.Text, TextBox_Address.Text, TextBox_Contact.Text, (string)ComboBox_Role.SelectedItem, CreationTime, Position);
        }

        private bool RunValidations()
        {
            if (TextBox_Name.Text == "")
            {
                ShowErrorMessage("Nombre es un campo necesario");
                return false;
            }

            if (TextBox_Address.Text == "")
            {
                ShowErrorMessage("Dirección es un campo necesario");
                return false;
            }

            if (TextBox_Contact.Text == "")
            {
                ShowErrorMessage("Contacto es un campo necesario");
                return false;
            }

            if ((string)ComboBox_Role.SelectedItem == null || (string)ComboBox_Role.SelectedItem == "")
            {
                ShowErrorMessage("Rol es un campo necesario");
                return false;
            }

            foreach (Vertex point in CurrentUser.DeliveryNetwork.Graph)
            {
                if (point.Name == TextBox_Name.Text)
                {
                    if (CurrentVertex != null)
                    {
                        if (point.Name == CurrentVertex.Name)
                            return true;
                    }

                    ShowErrorMessage("El nombre \"" + point.Name + "\" ya existe");
                    return false;
                }    
            }

            return true;
        }

        private void PictureBox_Accept_Click(object sender, EventArgs e)
        {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/details/accept-dark.png");

            if (CurrentVertex == null)
            {
                if (RunValidations())
                {
                    CurrentUser.DeliveryNetwork.AddVertex(ConvertFieldsToVertex());
                    DrawCircleInMap();
                    this.Close();
                }
            }
            else
            {
                if (RunValidations())
                {
                    CurrentVertex.Update(TextBox_Name.Text, TextBox_Address.Text, TextBox_Contact.Text, (string)ComboBox_Role.SelectedItem);
                    this.Close();
                }
            } 
        }

        public void DrawCircleInMap()
        {
            Bitmap bmp = new Bitmap(Map.Image);
            Graphics.FromImage(bmp).FillEllipse(new SolidBrush(Color.DarkBlue), Position.X - 10, Position.Y - 10, 20, 20);
            Map.Image = bmp;
            Map.Refresh();
        }

        public void ShowErrorMessage(string errorMessage)
        {
            Label_ErrorMessage.Text = errorMessage;
            Label_ErrorMessage.Location = new Point((this.Width / 2) - Label_ErrorMessage.Width / 2, Label_ErrorMessage.Location.Y);
            Label_ErrorMessage.Visible = true;
        }
    }
}

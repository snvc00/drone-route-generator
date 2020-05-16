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
    public partial class Modal : Form
    {
        bool IState;

        public Modal(string message, bool justAcceptButton)
        {
            InitializeComponent();
            InitializeLocally(message, justAcceptButton); // Perfect location for two buttons (67, 90) and (223, 90)
        }

        public bool State
        {
            get { return this.IState; }
        }

        private void InitializeLocally(string message, bool justAcceptButton)
        {
            this.Label_Message.Text = message;
            this.Label_Message.Location = new Point(this.Width / 2 - (Label_Message.Width / 2), Label_Message.Location.Y);

            if (justAcceptButton)
            {
                PictureBox_Cancel.Visible = false;
                PictureBox_Accept.Location = new Point(this.Width / 2 - (PictureBox_Accept.Width / 2), PictureBox_Accept.Location.Y);
            }
        }

        //<--   MouseClick  -->

        private void PictureBox_Accept_Click(object sender, EventArgs e)
        {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/modal/accept-dark.png");
            this.IState = true;
            this.Close();
        }

        private void PictureBox_Cancel_Click(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/modal/cancel-dark.png");
            this.IState = false;
            this.Close();
        }

        //<--   MouseLeave  -->

        private void PictureBox_Cancel_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/modal/cancel-light.png");
            this.Cursor = Cursors.Default;
        }

        private void PictureBox_Accept_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/modal/accept-light.png");
            this.Cursor = Cursors.Default;
        }

        //<--   MouseHover Events   -->

        private void PictureBox_Accept_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Accept.Image = Image.FromFile($"../../../resources/modal/accept-medium.png");
            this.Cursor = Cursors.Hand;
        }
        private void PictureBox_Cancel_MouseHover(object sender, EventArgs e)
        {
            PictureBox_Cancel.Image = Image.FromFile($"../../../resources/modal/cancel-medium.png");
            this.Cursor = Cursors.Hand;
        }
    }
}

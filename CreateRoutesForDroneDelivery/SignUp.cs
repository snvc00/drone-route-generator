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
using System.Security.Cryptography;

namespace CreateRoutesForDroneDelivery
{
    public partial class SignUp : Form
    {
        bool PasswordIsVisible, CheckPasswordIsVisible;
        string ErrorMessage;
        public SignUp()
        {
            InitializeComponent();
            InitializeLocally();
        }

        private void InitializeLocally()
        {
            PasswordIsVisible = false;
            CheckPasswordIsVisible = false;
        }

        private void PictureBox_RegisterButton_MouseHover(object sender, EventArgs e) {
            PictureBox_RegisterButton.Image = Image.FromFile($"../../../resources/signup/signup_medium.png");
        }

        private void PictureBox_RegisterButton_MouseLeave(object sender, EventArgs e) {
            PictureBox_RegisterButton.Image = Image.FromFile($"../../../resources/signup/signup_light.png");
        }

        private void PictureBox_RegisterButton_MouseClick(object sender, MouseEventArgs e) {
            PictureBox_RegisterButton.Image = Image.FromFile($"../../../resources/signup/signup_dark.png");
        }

        private void PictureBox_CheckPasswordVisibility_Click(object sender, EventArgs e)
        {
            if (CheckPasswordIsVisible)
            {
                CheckPasswordIsVisible = false;
                TextBox_CheckPassword.PasswordChar = '●';
                PictureBox_CheckPasswordVisibility.Image = Image.FromFile($"../../../resources/login/show-pass.png");
            }
            else
            {
                CheckPasswordIsVisible = true;
                TextBox_CheckPassword.PasswordChar = '\0';
                PictureBox_CheckPasswordVisibility.Image = Image.FromFile($"../../../resources/login/hide-pass.png");
            }
        }

        private void PictureBox_PasswordVisibility_Click(object sender, EventArgs e)
        {
            if (PasswordIsVisible)
            {
                PasswordIsVisible = false;
                TextBox_Password.PasswordChar = '●';
                PictureBox_PasswordVisibility.Image = Image.FromFile($"../../../resources/login/show-pass.png");
            }
            else
            {
                PasswordIsVisible = true;
                TextBox_Password.PasswordChar = '\0';
                PictureBox_PasswordVisibility.Image = Image.FromFile($"../../../resources/login/hide-pass.png");
            }
        }

        private void CreateUser(string user, string password, string name, string role)
        {
            User usr = new User(user, password, name, role);
            RegisterUser(usr);
        }

        private void RegisterUser(User user)
        {
            StreamWriter wrt = new StreamWriter($"../../../data/credentials.secure", true);
            wrt.WriteLine(Authentication.EncryptUser(user));
            wrt.Close();

        }

        private void PictureBox_RegisterButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (RunVerifications())
            {
                CreateUser(TextBox_User.Text, TextBox_Password.Text, TextBox_Name.Text, (string)ComboBox_Role.SelectedItem);
                Label_ErrorMessage.Text = "¡Bienvenido! Inicia sesión para continuar";
                Label_ErrorMessage.ForeColor = Color.FromArgb(34, 166, 16);
                Label_ErrorMessage.Location = new Point((this.Width / 2) - Label_ErrorMessage.Width / 2, Label_ErrorMessage.Location.Y);
                Label_ErrorMessage.Visible = true;
                this.Refresh();
                Thread.Sleep(1500);
                this.Hide();
                MainWindow sesion = new MainWindow();
                sesion.InitalizeLocally(new User(TextBox_User.Text, TextBox_Password.Text, TextBox_Name.Text, (string)ComboBox_Role.SelectedItem));
                sesion.ShowDialog();
            }
            
            if (ErrorMessage != null)
            {
                Label_ErrorMessage.Text = ErrorMessage;
                Label_ErrorMessage.Location = new Point((this.Width / 2) - Label_ErrorMessage.Width / 2, Label_ErrorMessage.Location.Y);
                Label_ErrorMessage.Visible = true;
            }

            this.Cursor = Cursors.Default;
        }

        private List<string> GetExistingUsers()
        {
            List<string> existingUsers = new List<string>();

            foreach (string line in File.ReadLines($"../../../data/credentials.secure", Encoding.UTF8))
            {
                existingUsers.Add(Authentication.DecryptUser(line).Split('|')[0]);
            }

            return existingUsers.ToList();
        }

        private bool RunVerifications()
        {
            List<string> existingUsers = GetExistingUsers();
            string invalidChars = "|,;:?/!#$%^&*()-+=`~<> ";

            if (existingUsers.Contains(TextBox_User.Text))
            {
                ErrorMessage = "El usuario: " + TextBox_User.Text + " ya existe";
                return false;
            }

            foreach (char c in invalidChars)
            {
                if (TextBox_User.Text.Contains(c))
                {
                    ErrorMessage = "Usuario no puede contener '" + c + "'";
                    return false;
                }
            }

            if (TextBox_Password.Text != TextBox_CheckPassword.Text)
            {
                ErrorMessage = "Contraseñas no coinciden";
                return false;
            }

            if (TextBox_Name.Text.Length < 5)
            {
                ErrorMessage = "Nombre es un campo requerido y debe tener mas de 10 carácteres";
                return false;
            }

            if (TextBox_User.Text.Length < 5)
            {
                ErrorMessage = "Usuario es un campo requerido y debe tener mas de 5 carácteres";
                return false;
            }

            if (TextBox_Password.Text.Length < 7)
            {
                ErrorMessage = "La contraseña es un campo requerido y debe tener mas de 7 carácteres";
                return false;
            }

            if (ComboBox_Role.SelectedItem == null)
            {
                ErrorMessage = "Elegir un rol para el usuario";
                return false;
            }

            return true;
        }
    }
}

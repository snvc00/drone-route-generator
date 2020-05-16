using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateRoutesForDroneDelivery
{
    public partial class Login : Form
    {
        bool PasswordIsVisible;
        string ErrorMessage, LoggedUser;
        public Login()
        {
            InitializeComponent();
            InitializeLocally();
        }

        private void InitializeLocally() {
            PasswordIsVisible = false;
        }

        private void TextBox_User_MouseClick(object sender, MouseEventArgs e) {
            Label_User.Font = new Font(Label_User.Font, FontStyle.Bold);
        }

        private void TextBox_User_MouseLeave(object sender, EventArgs e) {
            Label_User.Font = new Font(Label_User.Font, FontStyle.Regular);
        }

        private void TextBox_Password_MouseClick(object sender, MouseEventArgs e) {
            Label_Password.Font = new Font(Label_Password.Font, FontStyle.Bold);
        }

        private void TextBox_Password_MouseLeave(object sender, EventArgs e) {
            Label_Password.Font = new Font(Label_User.Font, FontStyle.Regular);
        }

        private void PictureBox_LoginButton_MouseHover(object sender, EventArgs e) {
            PictureBox_LoginButton.Image = Image.FromFile($"../../../resources/login/login_medium.png");
        }

        private void PictureBox_LoginButton_MouseLeave(object sender, EventArgs e) {
            PictureBox_LoginButton.Image = Image.FromFile($"../../../resources/login/login_light.png");
        }

        private void PictureBox_LoginButton_Click(object sender, EventArgs e) {
            PictureBox_LoginButton.Image = Image.FromFile($"../../../resources/login/login_dark.png");
            
            if (RunValidations())
            {
                this.Hide();

                if (!CheckBox_RememberCredentials.Checked)
                {
                    TextBox_User.ResetText();
                    TextBox_Password.ResetText();
                }

                MainWindow sesion = new MainWindow();
                sesion.InitalizeLocally(GetUserByUsername(LoggedUser));
                sesion.ShowDialog();
                this.Show();
            }

            if (ErrorMessage != null)
            {
                Label_ErrorMessage.Text = ErrorMessage;
                Label_ErrorMessage.Location = new Point((this.Width / 2) - Label_ErrorMessage.Width / 2, Label_ErrorMessage.Location.Y);
                Label_ErrorMessage.Visible = true;
            }
        }

        private User GetUserByUsername(string username)
        {
            string decrypedUser;

            foreach (string user in File.ReadLines($"../../../data/credentials.secure"))
            {
                decrypedUser = Authentication.DecryptUser(user);

                if (decrypedUser.Split('|')[0] == username)
                    return new User(decrypedUser);
            }

            return null;
        }

        private bool RunValidations()
        {
            if (TextBox_User.Text == "")
            {
                ErrorMessage = "Usuario es un campo requerido";
                return false;
            }

            if (TextBox_Password.Text == "")
            {
                ErrorMessage = "La contraseña es un campo requerido";
                return false;
            }

            Tuple<List<string>, List<string>> UsersAndPasswords = GetExistingUsersAndPasswords();
            int position = 0;

            foreach (string user in UsersAndPasswords.Item1)
            {
                if (user == TextBox_User.Text)
                {
                    if (TextBox_Password.Text == UsersAndPasswords.Item2[position])
                    {
                        LoggedUser = user;
                        return true;
                    }
                }

                ++position;
            }

            ErrorMessage = "El usuario o contraseña no son correctos";
            return false;
        }

        private Tuple<List<string>, List<string>> GetExistingUsersAndPasswords()
        {
            Tuple<List<string>, List<string>> profiles = new Tuple<List<string>, List<string>>(new List<string>(), new List<string>());

            foreach (string line in File.ReadLines($"../../../data/credentials.secure", Encoding.UTF8))
            {
                profiles.Item1.Add(Authentication.DecryptUser(line).Split('|')[0]);
                profiles.Item2.Add(Authentication.DecryptUser(line).Split('|')[1]);
            }

            return profiles;
        }

        private void LinkLabel_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            this.Refresh();

            SignUp SignUpWindow = new SignUp();
            SignUpWindow.ShowDialog();

            this.Visible = true;
            this.Refresh();
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
    }
}

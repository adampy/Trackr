using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class EditAccount : Form {
        public string newUsername;
        public string newPassword;
        private UserType userType;
        public EditAccount(UserType userType, string existingUsername) {
            this.userType = userType;
            InitializeComponent();
            usernameTextbox.Text = existingUsername;
            passwordTextbox1.Enabled = passwordCheckBox.Checked;
            passwordTextbox2.Enabled = passwordCheckBox.Checked;
            usernameTextbox.Enabled = usernameCheckBox.Checked;
        }

        private void EditAccount_Paint(object sender, PaintEventArgs e) {
            int y = passwordCheckBox.Location.Y + 10;
            e.Graphics.DrawLine(Pens.Gray, 0, y, passwordCheckBox.Location.X - 5, y);
            e.Graphics.DrawLine(Pens.Gray, passwordCheckBox.Location.X + passwordCheckBox.Size.Width, y, this.Width, y);

            y = usernameCheckBox.Location.Y + 10;
            e.Graphics.DrawLine(Pens.Gray, 0, y, usernameCheckBox.Location.X - 5, y);
            e.Graphics.DrawLine(Pens.Gray, usernameCheckBox.Location.X + usernameCheckBox.Size.Width, y, this.Width, y);
        }

        private void stateChanged(object sender, EventArgs e) {
            passwordTextbox1.Enabled = passwordCheckBox.Checked;
            passwordTextbox2.Enabled = passwordCheckBox.Checked;
            usernameTextbox.Enabled = usernameCheckBox.Checked;
        }

        async private void submitChangedClick(object sender, EventArgs e) { 
            string password = passwordTextbox1.Text;
            string confirmedPassword = passwordTextbox2.Text;
            string username = usernameTextbox.Text;
            //passwordTextbox1.Text = "";
            //passwordTextbox2.Text = "";

            // Username checks
            if (usernameCheckBox.Checked) {
                if (username == "") {
                    MessageBox.Show("Username field needs filling!");
                    return;
                } else if (username.Contains(":")) {
                    MessageBox.Show("Username cannot contain a colon. Please remove it.");
                } else {
                    bool usernameTaken = await APIHandler.IsUsernameTaken(this.userType, username);
                    if (usernameTaken) {
                        MessageBox.Show("Username has already been taken, please try another!");
                        return;
                    } else {
                        this.newUsername = username;
                    }
                }
            }

            // Password checks
            if (passwordCheckBox.Checked) {
                // Passwords need to be included
                if (password == "" || confirmedPassword == "") {
                    MessageBox.Show("Password fields need filling!");
                    return;
                }
                if (password != confirmedPassword) {
                    MessageBox.Show("Passwords do not match!"); // TODO: Better way of showing this error
                    return;
                }
                if (!User.IsPasswordValid(password)) {
                    MessageBox.Show("Password is not of sufficient complexity!");
                    return;
                }
                // Password is valid at this point
                this.newPassword = password;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

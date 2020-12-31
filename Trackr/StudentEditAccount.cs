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
    public partial class StudentEditAccount : Form {
        public string newUsername;
        public string newPassword;
        public StudentEditAccount(string existingUsername) {
            InitializeComponent();
            usernameTextbox.Text = existingUsername;
            passwordTextbox1.Enabled = checkBox1.Checked;
            passwordTextbox2.Enabled = checkBox1.Checked;
        }

        private void StudentEditAccount_Paint(object sender, PaintEventArgs e) {
            int y = checkBox1.Location.Y + 10;
            e.Graphics.DrawLine(Pens.Gray, 0, y, checkBox1.Location.X - 5, y);
            e.Graphics.DrawLine(Pens.Gray, checkBox1.Location.X + checkBox1.Size.Width, y, this.Width, y);
        }

        private void stateChanged(object sender, EventArgs e) {
            passwordTextbox1.Enabled = checkBox1.Checked;
            passwordTextbox2.Enabled = checkBox1.Checked;
        }

        async private void submitChangedClick(object sender, EventArgs e) { 
            string password = passwordTextbox1.Text;
            string confirmedPassword = passwordTextbox2.Text;
            string username = usernameTextbox.Text;
            //passwordTextbox1.Text = "";
            //passwordTextbox2.Text = "";

            if (username == "") {
                MessageBox.Show("Username field needs filling!");
                return;
            }

            if (checkBox1.Checked) {
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
            }

            // Check the username has not been taken
            if (!await APIHandler.IsUsernameTaken(UserType.Student, username)) {
                this.newUsername = username;
                if (password != "") { 
                    this.newPassword = password; // TODO: Test updating password works
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("Username has already been taken, please try another!");
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public partial class EditAccount : Form {
        /// <summary>
        /// EditAccount allows the editing of a user. The form itself depends on the `userType` provided.
        /// </summary>
        public string newUsername;
        public string newPassword;
        public string newTitle;
        public string newForename;
        public string newSurname;
        private UserType userType;
        public EditAccount(UserType userType, string existingUsername, string forename = "", string surname = "", string title = "") { // 3 optional params are for teachers
            this.userType = userType;
            InitializeComponent();
            usernameTextbox.Text = existingUsername;
            titleTextBox.Text = title;
            forenameTextBox.Text = forename;
            surnameTextBox.Text = surname;
            StatesChanged();

            if (userType == UserType.Student) {
                // Move all items up
                submitChangedButton.Location = new Point(15, 256);
                forenameTextBox.Dispose();
                surnameTextBox.Dispose();
                titleTextBox.Dispose();
                label5.Dispose();
                label6.Dispose();
                label7.Dispose();
                nameCheckBox.Hide(); // Prevents null reference after clicking submit and checking this box's state
                this.Size = new Size(425, 362);
            } else {
            }
        }

        private void stateChanged(object sender, EventArgs e) {
            StatesChanged();
        }
        private void StatesChanged() {
            /// <summary>
            /// Method that updates the states of the textboxes.
            /// </summary>
            passwordTextbox1.Enabled = passwordCheckBox.Checked;
            passwordTextbox2.Enabled = passwordCheckBox.Checked;
            usernameTextbox.Enabled = usernameCheckBox.Checked;
            forenameTextBox.Enabled = nameCheckBox.Checked;
            surnameTextBox.Enabled = nameCheckBox.Checked;
            titleTextBox.Enabled = nameCheckBox.Checked;
        }

        private void EditAccount_Paint(object sender, PaintEventArgs e) {
            CheckBox[] checkBoxes = { passwordCheckBox, usernameCheckBox, nameCheckBox };
            foreach (CheckBox box in checkBoxes) {
                int y = box.Location.Y + 10;
                e.Graphics.DrawLine(Pens.Gray, 0, y, box.Location.X - 5, y);
                e.Graphics.DrawLine(Pens.Gray, box.Location.X + box.Size.Width, y, this.Width, y);
            }
        }

        async private void submitChangedClick(object sender, EventArgs e) { 
            string password = passwordTextbox1.Text;
            string confirmedPassword = passwordTextbox2.Text;
            string username = usernameTextbox.Text;
            string title = titleTextBox.Text;
            string forename = forenameTextBox.Text;
            string surname = surnameTextBox.Text;
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

            // New name checks
            if (nameCheckBox.Checked) {
                if (title == "" || forename == "" || surname == "") {
                    MessageBox.Show("You must not leave any fields blank!");
                    return;
                }
                this.newTitle = title;
                this.newForename = forename;
                this.newSurname = surname;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

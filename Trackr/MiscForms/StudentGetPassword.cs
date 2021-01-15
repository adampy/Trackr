using System;
using System.Windows.Forms;

namespace Trackr {
    public partial class StudentGetPassword : Form {
        /// <summary>
        /// StudentGetPassword allows a student with no password to get one.
        /// No API calls are made in this class, it is only to obtain a new password.
        /// </summary>
        public string passwordResult { get; set; }
        public StudentGetPassword() {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e) {
            string password1 = passwordTextBox.Text;
            string password2 = confirmPasswordTextBox.Text;
            if (password1 != password2 || password1 == "" || password2 == "") {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            if (!User.IsPasswordValid(password1)) {
                MessageBox.Show("Password is not of sufficient complexity!");
                return;
            }
            passwordResult = password1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

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
    public partial class StudentGetPassword : Form {
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

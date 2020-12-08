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
    public partial class AuthenticationScreen : Form {

        Stack panels = new Stack(4); // Make a stack of size 4

        public AuthenticationScreen() {

            InitializeComponent();
            panels.Push(mainPanel);
        }

        private void signInButton_Click(object sender, EventArgs e) {
            panels.Push(signInPanel);
        }

        private void studentSignInClick(object sender, EventArgs e) {
            MessageBox.Show("Student sign in.");
        }

        private void teacherSignInClick(object sender, EventArgs e) {
            MessageBox.Show("Teacher sign in.");
        }

        private void previousPanel(object sender, EventArgs e) {
            panels.Pop();
        }
    }

    static public class PanelHandler {
    }
}

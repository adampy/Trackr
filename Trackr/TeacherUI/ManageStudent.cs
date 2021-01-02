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
    public partial class ManageStudent : Form {
        private Student student;
        public ManageStudent(Student student) {
            InitializeComponent();
            this.student = student;
            usernameLabel.Text = student.GetUsername();
            forenameLabel.Text = student.GetForename();
            surnameLabel.Text = student.GetSurname();
            alpsGradeLabel.Text = student.GetAlpsString();
        }

        private void resetPasswordButton_Click(object sender, EventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to reset " + student.GetForename() + "'s password?", "Reset password confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }
            // Reset password here
            Dictionary<string, string> formData = new Dictionary<string, string> {
                { "password", "true" }
            };
            APIHandler.TeacherEditStudent(student, formData);
            MessageBox.Show(student.GetForename() + "'s password has been reset. Please tell them to select the 'first time sign-in' when they next sign-in.");
        }
    }
}

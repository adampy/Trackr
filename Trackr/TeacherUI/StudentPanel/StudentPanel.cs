using System.Windows.Forms;
using System.Drawing;
using System;

namespace Trackr {
    public class StudentPanel : TeacherFormPanel {
        /// <summary>
        /// Student is a container class that contains all of the data for the students. It contains the list of all students.
        /// It also contains the `searchBox` and a `newStudentButton`.
        /// </summary>
        public StudentPanel(Panel parentPanel) : base(parentPanel) {
            this.Width = parent.Width; // this.parent is defined in TeacherFormPanel

            // newStudentButton
            this.newObjButton.Text = "New student";
            // mainLabel
            this.mainLabel.Text = "Manage students";
            // searchBox
            this.searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            RefreshList();
        }

        public override void OnNewObjButtonClick(object sender, EventArgs e) {
            EditStudent edit = new EditStudent(); // Create a new student
            DialogResult dialog = edit.ShowDialog(this);
            if (dialog != DialogResult.OK) {
                return;
            }
            string username = edit.newUsername;
            string forename = edit.newForename;
            string surname = edit.newSurname;
            int alps = edit.newAlps;

            APIHandler.CreateStudent(forename, surname, username, alps); // TODO: Perhaps make these return a boolean, to denote whether the creation has been succesful or not
            MessageBox.Show(username + "'s account has been created successfully! Please tell them to use the 'first time sign-in' when they try to sign-in.");
            RefreshList();
        }

        async public override void RefreshList() {
            /// <summary>
            /// Executed after opening the manage student tab.
            /// </summary>
            
            // Data
            Student[] students = await APIHandler.GetAllStudents();

            // List
            if (list != null) {
                list.Dispose();
            }
            list = new ListPanel(this.parent.Width, students, typeof(StudentListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }
    }
}

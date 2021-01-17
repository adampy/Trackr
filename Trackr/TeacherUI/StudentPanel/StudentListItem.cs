using System.Windows.Forms;

namespace Trackr {
    public partial class StudentListItem : ListItem {
        /// <summary>
        /// StudentListItem is the ListItem that appears when a teacher views students from the homepage.
        /// </summary>
        private Student student;
        public StudentListItem(Student student) {
            InitializeComponent();
            this.student = student;
            this.studentNameLabel.Text = student.GetFullName();
        }
        private void manageStudentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ManageStudent manage = new ManageStudent(this.student);
            manage.ShowDialog();
            if (manage.studentPanelNeedsRefresh) {
                ParentRefreshList();
            }
        }
    }
}

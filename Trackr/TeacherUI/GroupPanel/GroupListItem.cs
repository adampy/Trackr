using System.Collections.Generic;
using System.Windows.Forms;

namespace Trackr {
    public partial class GroupListItem : ListItem {
        /// <summary>
        /// This is a child of `ListItem` that gets placed into the list of groups that a teacher has.
        /// </summary>
        private Group group;
        public GroupListItem(Group group) {
            InitializeComponent();
            this.group = group;
            this.groupNameLabel.Text = group.GetName();
        }

        private void editLinkLabel_Clicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EditGroup edit = new EditGroup(this.group);
            DialogResult dialog = edit.ShowDialog();
            if (dialog != DialogResult.OK) {
                return;
            }

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"name", edit.newName },
                {"subject", edit.newSubject }
            };

            APIHandler.UpdateGroup(this.group, formData);
            MessageBox.Show("Group has been updated successfully.");
            ParentRefreshList();
        }

        private void deleteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete '" + this.group.GetName() + "'?", "Deletion confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }
            APIHandler.DeleteGroup(this.group);
            MessageBox.Show("Group has been deleted successfully.");
            ParentRefreshList();
        }

        private void viewStudentsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewGroupStudents students = new ViewGroupStudents(this.group);
            DialogResult dialog = students.ShowDialog();
        }
        private void viewMarksLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewMarks marks = new ViewMarks(group);
            marks.ShowDialog();
        }
    }
}

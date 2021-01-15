using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public partial class AssignmentListItem : ListItem {
        /// <summary>
        /// AssignmentListItem is a ListItem that is used when showing the teacher a list of assignments given to their groups.
        /// </summary>
        private Assignment assignment;
        private DateRepresentationPanel datetime;
        public AssignmentListItem(Assignment assignment) {
            InitializeComponent();
            this.assignment = assignment;
            this.assignmentNameLabel.Text = assignment.title;
            this.groupNameLabel.Text = assignment.group.GetName();

            //datetime panel
            datetime = new DateRepresentationPanel(assignment.dateDue, 20.0f, 15.0f, 0); // TODO: Replace student task datetime with new DateRepresentationPanel
            datetime.Location = new Point(550, 1);
            this.Controls.Add(datetime);
        }

        private void editLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EditTask edit = new EditTask(assignment);
            DialogResult dialog = edit.ShowDialog();
            if (dialog != DialogResult.OK) {
                return;
            }
            // Make these local vars to prevent  "marshal-by-reference" classes - https://stackoverflow.com/questions/4178576/accessing-a-member-on-form-may-cause-a-runtime-exception-because-it-is-a-field-o
            int newScore = edit.newScore;
            DateTime newDueDate = edit.newDueDate;

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"title", edit.newTitle },
                {"description", edit.newDescription },
                {"max_score", newScore.ToString()},
                {"date_due", newDueDate.ToString("dd/MM/yyyy|HH:mm") }
            };
            APIHandler.EditAssignment(assignment, formData);
            ((TaskPanel)((ListPanel)this.Parent).Parent).RefreshList(); //TODO: Make all panels (TaskPanel,StudentPanel,GroupPanel,TeacherPanel) have abstract methods of refreshlist
            MessageBox.Show("Edited task successfully!");
        }

        private void deleteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete '" + assignment.title + "'?", "Confirm deletion", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) {
                return;
            }
            APIHandler.DeleteAssignment(assignment);
            ((TaskPanel)((ListPanel)this.Parent).Parent).RefreshList();
        }

        private void provideFeedbackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ProvideFeedback provFbk = new ProvideFeedback(assignment);
            provFbk.ShowDialog();
        }
    }
}

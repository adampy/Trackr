using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class AssignmentListItem : ListItem {
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
            MessageBox.Show("Edit task success!");
            
            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"title", edit.newTitle },
                {"description", edit.newDescription },
                {"max_score", edit.newScore.ToString()},
                {"date_due", edit.newDueDate.ToString("dd/MM/yyyy|HH:mm") }
            };
            APIHandler.EditAssignment(assignment, formData);
            ((TaskPanel)((ListPanel)this.Parent).Parent).RefreshList(); //TODO: Make all panels (TaskPanel,StudentPanel,GroupPanel,TeacherPanel) have abstract methods of refreshlist
        }
    }
}

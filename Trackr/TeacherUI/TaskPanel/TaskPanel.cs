using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace Trackr {
    public class TaskPanel : TeacherFormPanel {
        /// <summary>
        /// TaskPanel is a container class that contains all of the data for the tasks. It contains the list of tasks that a
        /// teacher has assigned. It also contains the `searchBox` and a `newTaskButton`.
        /// </summary>
        public TaskPanel(Panel parentPanel) : base(parentPanel) {
            this.parent = parentPanel;
            this.Width = parent.Width;

            // mainLabel
            mainLabel.Text = "Manage your tasks";
            // newObjButton
            newObjButton.Text = "New task";
            // searchBox
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            RefreshList();
        }

        async public override void OnNewObjButtonClick(object sender, EventArgs e) {
            Group[] teachersGroups = await APIHandler.TeacherGetGroups();
            EditTask newTask = new EditTask(teachersGroups);
            DialogResult dialog = newTask.ShowDialog();
            if (dialog != DialogResult.OK) {
                return;
            }
            // Make these local vars to prevent  "marshal-by-reference" classes - https://stackoverflow.com/questions/4178576/accessing-a-member-on-form-may-cause-a-runtime-exception-because-it-is-a-field-o
            int newScore = newTask.newScore;
            DateTime newDueDate = newTask.newDueDate;

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"title", newTask.newTitle },
                {"description", newTask.newDescription },
                {"max_score", newScore.ToString()},
                {"date_due", newDueDate.ToString("dd/MM/yyyy|HH:mm") }
            };
            APIHandler.CreateAssignment(newTask.newGroup, formData);
            RefreshList();
            MessageBox.Show("Created task successfully!");
        }

        async public override void RefreshList() {
            // Assignments
            Assignment[] assignments = await APIHandler.TeacherGetAssignments();

            // List
            if (list != null) {
                list.Dispose();
            }

            //TODO: SORT `assignments` IN TERMS OF THEIR DATETIME

            list = new ListPanel(this.parent.Width, assignments, typeof(AssignmentListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }
    }
}

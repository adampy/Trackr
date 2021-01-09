using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Trackr {
    public class TaskPanel : Panel {
        private Panel parent;
        private Label taskLabel;
        private SearchBox searchBox;
        private ListPanel list;
        private Button newTaskButton;
        public TaskPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            this.Width = parent.Width;

            // groupLabel
            taskLabel = new Label();
            taskLabel.AutoSize = true;
            taskLabel.Font = new Font("Calibri", 20.0f);
            taskLabel.Location = new Point(150, 0);
            taskLabel.Text = "Manage your tasks";
            taskLabel.BackColor = Color.Transparent;
            this.Controls.Add(taskLabel);

            // newTaskButton
            newTaskButton = new Button();
            newTaskButton.Text = "New task";
            newTaskButton.Font = new Font("Calibri", 12.0f);
            newTaskButton.Location = new Point(5, 3);
            newTaskButton.AutoSize = true;
            newTaskButton.Click += NewTaskButton_Click;
            this.Controls.Add(newTaskButton);

            // searchBox
            searchBox = new SearchBox();
            searchBox.BackColor = Color.Transparent;
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            searchBox.AddTextBoxChangedAction(SearchBoxChanged);
            this.Controls.Add(searchBox);
            RefreshList();
        }
        private void SearchBoxChanged(object sender, EventArgs e) {
            list.MakePanels(searchBox.GetText());
        }

        async private void NewTaskButton_Click(object sender, EventArgs e) {
            Group[] teachersGroups = await APIHandler.TeacherGetGroups();
            EditTask newTask = new EditTask(teachersGroups);
            DialogResult dialog = newTask.ShowDialog();
            if (dialog != DialogResult.OK) {
                return;
            }

            // TODO: CREATE TASK METHODS
        }

        async public void RefreshList() {
            // Assignments
            Assignment[] assignments = await APIHandler.TeacherGetAssignments(); // TODO: CONSIDER GROUP CACHE HERE (IMPLEMENT A HARDREFRESH OPTION)

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

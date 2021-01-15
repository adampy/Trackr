using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace Trackr {
    public class TaskPanel : Panel {
        /// <summary>
        /// TaskPanel is a container class that contains all of the data for the tasks. It contains the list of tasks that a
        /// teacher has assigned. It also contains the `searchBox` and a `newTaskButton`.
        /// </summary>
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
            RefreshList(); //TODO: Make all panels (TaskPanel,StudentPanel,GroupPanel,TeacherPanel) have abstract methods of refreshlist
            MessageBox.Show("Created task successfully!");
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

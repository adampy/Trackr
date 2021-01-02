using System.Collections.Generic;
using System.Windows.Forms;

namespace Trackr {
    public class HomeworkTabController : TabControl {
        private Homework[] allTasks;
        private HomeworkTabPage uncompleted;
        private HomeworkTabPage completed;
        private Dictionary<int, FocussedTaskTab> focussedTasks; // Links the task id to the focussed task tab
        private int previousTabIndex = 0;

        public HomeworkTabController(Homework[] allTasks, int tabIndx = 0) : base() {
            this.focussedTasks = new Dictionary<int, FocussedTaskTab>();
            this.allTasks = allTasks;
            this.UpdateTabs();
            this.SelectedIndex = tabIndx;
            this.Deselecting += this.BeforeNewTabSelected;
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
        }
        public void UpdateTabs(bool disposeCurrentTabs = false, Homework[] newTasks = null) {
            if (newTasks != null) { // If new tasks are given to the tab controller, change the current tasks to those tasks.
                this.allTasks = newTasks;
            }
            CustomList uncompletedTasks = new CustomList(allTasks.Length);
            CustomList completedTasks = new CustomList(allTasks.Length); // Make two new arrays. Having them the same length as tasks makes this adding and accessing both O(1) in time but O(n) in memory
            for (int i = 0; i < allTasks.Length; i++) {
                if (allTasks[i].hasCompleted == false) {
                    uncompletedTasks.Add(allTasks[i]);
                } else {
                    completedTasks.Add(allTasks[i]);
                }
            }
            if (disposeCurrentTabs) {
                // The current tabs are wrong, so provide new data to the current tabs
                uncompleted.FillTabPage(newTaskData: uncompletedTasks);
                completed.FillTabPage(newTaskData: completedTasks);
            } else {
                // The current tabs do not exist, so create them
                uncompleted = new HomeworkTabPage(this, "Uncompleted tasks", uncompletedTasks, taskBorderWidth: 3);
                completed = new HomeworkTabPage(this, "Completed tasks", completedTasks, taskBorderWidth: 3);
                this.TabPages.Add(uncompleted);
                this.TabPages.Add(completed);
            }

        }
        private void BeforeNewTabSelected(object sender, TabControlCancelEventArgs e) {
            /// <summary>
            /// Method that changes the previous tab index.
            /// </summary>
            if (this.SelectedIndex >= 0) {
                this.previousTabIndex = this.SelectedIndex; // TODO: Fix this for occurences where the tab goes back
            }
        }

        public void ChangeToPreviousTab() {
            this.SelectedIndex = this.previousTabIndex;
        }

        public void GoToFocussedTab(Homework task, Feedback feedback) {
            FocussedTaskTab tab;
            bool exists = this.focussedTasks.TryGetValue(task.id, out tab);
            if (exists) {
                this.SelectTab(tab);
            } else {
                tab = new FocussedTaskTab(task, this, feedback: feedback);
                this.focussedTasks.Add(task.id, tab);
                this.TabPages.Add(tab);
                this.SelectTab(tab);
            }
        }
        public void RemoveFocussedTab(Homework task) {
            FocussedTaskTab tab;
            bool exists = this.focussedTasks.TryGetValue(task.id, out tab); // Getting the existing tab
            this.TabPages.Remove(tab);
            this.focussedTasks.Remove(task.id); // Remove from dicts
        }
    }
}

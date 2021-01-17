using System.Collections.Generic;
using System.Windows.Forms;

namespace Trackr {
    public class HomeworkTabController : TabControl {
        /// <summary>
        /// HomeworkTabController controls all the tabs on the student app.
        /// It receives the homeworks from the API and places them into "completed" and "uncompleted" tasks.
        /// </summary>
        private Homework[] allTasks;
        private HomeworkTabPage uncompleted;
        private HomeworkTabPage completed;
        private Dictionary<int, FocussedTaskTab> focussedTasks; // Links the task id to the focussed task tab
        
        public HomeworkTabController(Homework[] allTasks, int tabIndx = 0) : base() {
            this.focussedTasks = new Dictionary<int, FocussedTaskTab>();
            this.allTasks = allTasks;
            this.UpdateTabs();
            this.SelectedIndex = tabIndx;
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
                
                while (this.TabCount > 2) {
                    this.TabPages.RemoveAt(2); // Remove open focussed tabs
                }

            } else {
                // The current tabs do not exist, so create them
                uncompleted = new HomeworkTabPage(this, "Uncompleted tasks", uncompletedTasks, taskBorderWidth: 3);
                completed = new HomeworkTabPage(this, "Completed tasks", completedTasks, taskBorderWidth: 3);
                this.TabPages.Add(uncompleted);
                this.TabPages.Add(completed);
            }

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

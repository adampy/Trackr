using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    public class HomeworkTabPage : TabPage {
        /// <summary>
        /// HomeworkTabPage contains the TabPage that gets placed inside of the HomeworkTabController. It receives `taskData` in the form
        /// of a `CustomList` and it changes these into `HomeworkListItems`.
        /// </summary>
        public CustomList data;
        private HomeworkListItem[] listItems = new HomeworkListItem[0];
        private HomeworkTabController parent;
        private string titleText;
        private bool containsCompletedTasks;

        public HomeworkTabPage(HomeworkTabController parent, bool containsCompletedTasks, CustomList taskData, int taskBorderWidth) {
            this.containsCompletedTasks = containsCompletedTasks;
            if (containsCompletedTasks) {
                this.titleText = "Completed tasks";
            } else {
                this.titleText = "Uncompleted tasks";
            }
            this.data = taskData;
            this.parent = parent;
            this.AutoScroll = true;
            this.BorderStyle = BorderStyle.FixedSingle;

            FillTabPage();

            //https://stackoverflow.com/questions/5489273/how-do-i-disable-the-horizontal-scrollbar-in-a-panel
            this.AutoScroll = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = true;
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height); // Fill background in white
        }

        public void FillTabPage(CustomList newTaskData = null) {
            /// <summary>
            /// Method that converts all of the items in `this.data` into the page. If `newTaskData` is provided, then `this.data = newTaskData`.
            /// </summary>
            if (newTaskData != null) {
                // New tasks have been provided, dispose of the current list items and replace the current data with the new data provided.
                this.data = newTaskData;
                foreach (HomeworkListItem h in this.listItems) {
                    h.Dispose();
                }
            }

            int numberOfHomeworks = this.data.GetLength(); // Because this call is O(n), it can be stored as a var
            if (numberOfHomeworks > 0) {
                Homework[] homeworkToSort = this.data.ToArray<Homework>();
                Homework[] sortedHomework = Algorithms.Sorts.MergeSort(homeworkToSort, ascending: !this.containsCompletedTasks);

                int y = 0;
                this.listItems = new HomeworkListItem[numberOfHomeworks];
                for (int i = 0; i < numberOfHomeworks; i++) {
                    Homework homework = sortedHomework[i];
                    //bool includeBottomBorder = (i != numberOfHomeworks - 1);
                    HomeworkListItem taskListItem = new HomeworkListItem(parent, homework, 2, true);
                    this.listItems[i] = taskListItem;
                    taskListItem.Location = new Point(0, y);
                    y += taskListItem.Height; // Ensure that the item below is actually underneath the previous item 
                    this.Controls.Add(taskListItem);
                }
            }
            this.Text = this.titleText + " (" + numberOfHomeworks.ToString() + ")";
        }
    }
}

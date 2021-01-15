using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    public class HomeworkTabPage : TabPage {
        /// <summary>
        /// HomeworkTabPage contains the TabPage that gets placed inside of the HomeworkTabController. It receives `taskData` in the form
        /// of a `CustomList` and it changes these into `HomeworkListItems`.
        /// </summary>
        public CustomList data;
        private HomeworkListItem[] listItems;
        private HomeworkTabController parent;
        private string titleText;

        public HomeworkTabPage(HomeworkTabController parent, string text, CustomList taskData, int taskBorderWidth) {
            this.titleText = text;
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

            // TODO: Merge sort these in relation to their due date - most recent come first
            int y = 0;
            this.listItems = new HomeworkListItem[this.data.GetLength()]; // TODO: Change all arrays to CustomList type
            for (int i = 0; i < this.data.GetLength(); i++) {
                Homework taskIterable = (Homework)this.data.Get(i);
                bool includeBottomBorder = (i != this.data.GetLength() - 1); // Boolean that denotes the last item in the list. When this is True the bottom border is not included in the ListItem.
                HomeworkListItem taskListItem = new HomeworkListItem(parent, taskIterable, 2, true);
                this.listItems[i] = taskListItem;
                taskListItem.Location = new Point(0, y);
                y += taskListItem.Height; // Ensure that the item below is actually underneath the previous item 
                this.Controls.Add(taskListItem);
            }
            this.Text = this.titleText + " (" + this.data.GetLength().ToString() + ")";

        }
    }
}

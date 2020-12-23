using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public class TaskListItem : UserControl {
        TaskObj task;
        LinkLabel titleLabel;
        Label descriptionLabel;
        bool bottomBorder;
        int bottomBorderWidth;

        public TaskListItem(TaskObj task, int bottomBorderWidth, bool bottomBorder) : base() {
            this.task = task;
            this.AutoSize = true;
            this.bottomBorder = bottomBorder;
            this.bottomBorderWidth = bottomBorderWidth;

            // Title Label
            titleLabel = new LinkLabel();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Corbel", 20.0f, FontStyle.Bold);
            titleLabel.Location = new Point(5, 0);
            titleLabel.Text = task.title;
            titleLabel.BackColor = Color.Transparent;
            this.Controls.Add(titleLabel);

            // Description Label
            descriptionLabel = new Label();
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Corbel", 15.0f);
            descriptionLabel.Location = new Point(5, 40);
            descriptionLabel.Text = task.description;
            descriptionLabel.BackColor = Color.Transparent;
            this.Controls.Add(descriptionLabel);

            this.Height = descriptionLabel.Location.Y + descriptionLabel.Height + 3;
        }
        protected override void OnPaint(PaintEventArgs e) {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Pen pen = new Pen(blackBrush, this.bottomBorderWidth);

            this.Width = this.Parent.Size.Width - 2; // Update width to fill the whole page and remove 2px for the border
            e.Graphics.FillRectangle(whiteBrush, 0, 0, this.Width, this.Height); // Fill background in white
            
            if (this.bottomBorder) {
                e.Graphics.DrawLine(pen, 0, this.Height, this.Width, this.Height);
            }
        }
    }

    public class TaskTabPage : TabPage {
        public TaskObj[] data;
        private Panel[] panels;

        public TaskTabPage(string text, TaskObj[] taskData, int borderWidth) {
            this.Text = text;
            this.data = taskData;
            this.AutoScroll = true;
            this.panels = new Panel[taskData.Length];
            this.BorderStyle = BorderStyle.FixedSingle;

            int y = 0;
            int x = 0;

            for (int i = 0; i < taskData.Length; i++) {
                TaskObj taskIterable = taskData[i];
                bool includeBottomBorder = (i != taskData.Length - 1); // Boolean that denotes the last item in the list. When this is True the bottom border is not included in the ListItem.
                TaskListItem taskListItem = new TaskListItem(taskIterable, 2, true);
                taskListItem.Location = new Point(x, y);
                y += taskListItem.Height; // Ensure that the item below is actually underneath the previous item 
                this.Controls.Add(taskListItem);
            }

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
    }
}

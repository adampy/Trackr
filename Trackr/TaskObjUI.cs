using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {

    public class TaskTabPage : TabPage {
        public CustomList data;
        private Panel[] panels;
        private TabControl parent;

        public TaskTabPage(TabControl parent, string text, CustomList taskData, int taskBorderWidth) {
            this.Text = text;
            this.data = taskData;
            this.parent = parent;
            this.AutoScroll = true;
            this.panels = new Panel[data.GetLength()];
            this.BorderStyle = BorderStyle.FixedSingle;

            int y = 0;
            int x = 0;

            for (int i = 0; i < taskData.GetLength(); i++) {
                TaskObj taskIterable = (TaskObj)taskData.Get(i);
                bool includeBottomBorder = (i != taskData.GetLength() - 1); // Boolean that denotes the last item in the list. When this is True the bottom border is not included in the ListItem.
                TaskListItem taskListItem = new TaskListItem(parent, taskIterable, 2, true);
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

    public class TaskListItem : UserControl {
        private TabControl tabController;
        private TaskObj task;
        private LinkLabel titleLabel;
        private Label groupLabel;
        private Label descriptionLabel;
        private Label dateLabel;
        private Label monthLabel;
        private bool bottomBorder;
        private int bottomBorderWidth;

        public TaskListItem(TabControl tabController, TaskObj task, int bottomBorderWidth, bool bottomBorder) : base() {
            this.tabController = tabController;
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
            titleLabel.Click += OnTitleLabelClick;
            this.Controls.Add(titleLabel);

            // Group Label
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Corbel", 15.0f);
            groupLabel.Location = new Point(5, 35);
            groupLabel.Text = task.group.GetName();
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);

            // Description Label
            descriptionLabel = new Label();
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Corbel", 15.0f);
            descriptionLabel.Location = new Point(300, 20);
            descriptionLabel.Text = task.description;
            descriptionLabel.BackColor = Color.Transparent;
            this.Controls.Add(descriptionLabel);

            // Date Label
            dateLabel = new Label();
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Corbel", 30.0f);
            dateLabel.Location = new Point(650, 0);
            dateLabel.Text = task.dateDue.ToString("dd"); // dd gets the day as a 2 digit number
            dateLabel.BackColor = Color.Transparent;
            this.Controls.Add(dateLabel);

            // Month Label
            monthLabel = new Label();
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Corbel", 20.0f);
            monthLabel.Location = new Point(650, 40);
            monthLabel.Text = task.dateDue.ToString("MMM"); // MMM gets the abbreviated month
            monthLabel.BackColor = Color.Transparent;
            this.Controls.Add(monthLabel);

            this.Height = monthLabel.Location.Y + monthLabel.Height + 3;

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
        private void OnTitleLabelClick(object sender, EventArgs e) {
            tabController.TabPages.Add(new FocussedTaskTab(task));
            tabController.SelectedIndex = tabController.TabPages.Count - 1; // Select the most new tab
        }
    }

    public class FocussedTaskTab : TabPage {
        private TaskObj task;
        private Label titleLabel;
        private Label groupLabel;
        public FocussedTaskTab(TaskObj task) : base() {
            this.task = task;
            this.Text = this.task.title;

            // Title label
            titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Corbel", 18.0f, FontStyle.Bold);
            titleLabel.Location = new Point(10, 50);
            titleLabel.Text = task.title;
            titleLabel.BackColor = Color.Transparent;
            this.Controls.Add(titleLabel);

            // Group Label
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Corbel", 15.0f);
            groupLabel.Location = new Point(10, 70);
            groupLabel.Text = task.group.GetName();
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
        }
    }
}

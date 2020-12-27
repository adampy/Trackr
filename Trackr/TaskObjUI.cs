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
            this.panels = new Panel[data.GetLength()]; // TODO: Change all arrays to CustomList type
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
        private DoneButtonControl doneButton;
        private bool bottomBorder;
        private int bottomBorderWidth;

        public TaskListItem(TabControl tabController, TaskObj task, int bottomBorderWidth, bool bottomBorder) : base() {
            /// <summary>
            /// Constructor method for TaskListItem.
            /// </summary>
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

            // Done Checkbox
            doneButton = new DoneButtonControl("Done?", startingState: this.task.hasCompleted);
            doneButton.AutoSize = true;
            doneButton.Location = new Point(550, 20);
            doneButton.BackColor = Color.Transparent;
            doneButton.AddButtonClickAction(OnDoneButtonClick);
            this.Controls.Add(doneButton);

            this.Height = monthLabel.Location.Y + monthLabel.Height + 3; //Height is changed relative to the lowest component to prevent UserControl taking up more space than necessary

        }
        protected override void OnPaint(PaintEventArgs e) {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Pen pen = new Pen(blackBrush, this.bottomBorderWidth);

            this.Width = this.Parent.Size.Width - 2; // Update width to fill the whole page and remove 2px for the border
            e.Graphics.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height); // Fill background in white

            if (this.bottomBorder) {
                e.Graphics.DrawLine(pen, 0, this.Height, this.Width, this.Height);
            }

        }
        private void OnTitleLabelClick(object sender, EventArgs e) {
            /// <summary>
            /// Method that executes when the title label (blue link label) is clicked.
            /// </summary>
            tabController.TabPages.Add(new FocussedTaskTab(task));
            tabController.SelectedIndex = tabController.TabPages.Count - 1; // Select the most new tab
        }
        private void OnDoneButtonClick(object sender, EventArgs e) {
            MessageBox.Show("Hello");
        }
    }

    public class FocussedTaskTab : TabPage {
        private TaskObj task;
        private Label titleLabel;
        private Label groupLabel;
        private RemoveTabButton removeTab;

        private class RemoveTabButton : Button {
            /// <summary>
            /// Private class, wrapped inside `FocussedTaskTab` which removes the FocussedTaskTab.
            /// </summary>
            public RemoveTabButton() : base(){
                this.Text = "back";
                this.BackColor = Color.White;
                this.AutoSize = true;
            }

            protected override void OnPaint(PaintEventArgs pevent) {
                base.OnPaint(pevent);
            }
        }

        public FocussedTaskTab(TaskObj task) : base() {
            this.task = task;
            this.Text = this.task.title;
            this.BorderStyle = BorderStyle.FixedSingle; // Add border

            // Remove tab button
            removeTab = new RemoveTabButton();
            removeTab.AutoSize = true;
            removeTab.Location = new Point(this.Width - 50, 20);
            this.Controls.Add(removeTab);

            // Title label
            titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Corbel", 24.0f, FontStyle.Bold);
            titleLabel.Location = new Point(10, 20);
            titleLabel.Text = task.title;
            titleLabel.BackColor = Color.Transparent;
            this.Controls.Add(titleLabel);

            // Group label
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Corbel", 15.0f);
            groupLabel.Location = new Point(10, 50);
            groupLabel.Text = task.group.GetName();
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);

            // Done button
            // TODO: Finish this tab
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
        }
    }

    public class DoneButtonControl : UserControl {
        private Label lbl;
        private Button btn;
        private bool isChecked;
        public DoneButtonControl(string labelText, bool startingState) : base() {
            /// <summary>
            /// Constructor method for DoneButtonControl. A label with text `labelText`, and a button with state `startingState` is drawn.
            /// </summary>
            lbl = new Label();
            lbl.Location = new Point(13, 23);
            lbl.Font = new Font("Corbel", 12.0f);
            lbl.AutoSize = true;
            lbl.Text = labelText;
            this.Controls.Add(lbl);

            btn = new Button();
            btn.AutoSize = true;
            btn.Location = new Point(0, 0);
            if (startingState) {
                btn.BackColor = Color.Green;
            } else {
                btn.BackColor = Color.Red;
            }
            btn.Click += (obj, e) => OnButtonClick(obj, e);
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btn);

            this.Height = lbl.Location.Y + lbl.Size.Height; //Height is changed to prevent this UserControl taking up more space than necessary
        }
        protected void OnButtonClick(object sender, EventArgs e) {
            /// <summary>
            /// Executes when this.btn is clicked. The whole control is redrawn at the end of this procedure.
            /// </summary>
            isChecked = !isChecked; // Flip the checked state
            this.Invalidate();
        }
        public void AddButtonClickAction(Action<object, EventArgs> procedure) {
            /// <summary>
            /// A method that allows procedures to be added to this.btn.Click (because this.btn is private)
            /// </summary>
            this.btn.Click += (obj, e) => procedure(obj, e);
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height); // Fill background in white
            if (isChecked) {
                btn.BackColor = Color.Green;
            } else {
                btn.BackColor = Color.Red;
            }
        }
    }
}

using System;
using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    public class HomeworkListItem : UserControl {
        private HomeworkTabController tabController;
        private Homework task;
        private LinkLabel titleLabel;
        private Label groupLabel;
        private Label descriptionLabel;
        private Label dateLabel;
        private Label monthLabel;
        private Label overdueLabel;
        private DoneButtonControl doneButton;
        private bool bottomBorder;
        private int bottomBorderWidth;

        public HomeworkListItem(HomeworkTabController tabController, Homework task, int bottomBorderWidth, bool bottomBorder) : base() {
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
            titleLabel.Font = new Font("Calibri", 20.0f, FontStyle.Bold);
            titleLabel.Location = new Point(5, 0);
            titleLabel.Text = task.title;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Click += OnTitleLabelClick;
            this.Controls.Add(titleLabel);

            // Group Label
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Calibri", 15.0f);
            groupLabel.Location = new Point(5, 35);
            groupLabel.Text = task.group.GetName();
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);

            // Description Label
            descriptionLabel = new Label();
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Calibri", 15.0f);
            descriptionLabel.Location = new Point(300, 30);
            descriptionLabel.Text = HomeworkListItem.ReduceText(task.description, 25);
            descriptionLabel.BackColor = Color.Transparent;
            this.Controls.Add(descriptionLabel);

            if (task.dateDue < DateTime.UtcNow && !task.hasCompleted) {
                overdueLabel = new Label();
                overdueLabel.Text = "Overdue!!!";
                overdueLabel.BackColor = Color.Red;
                overdueLabel.Font = new Font("Calibri", 15.0f, FontStyle.Bold);
                overdueLabel.Location = new Point(300, 0);
                overdueLabel.AutoSize = true;
                overdueLabel.TextAlign = ContentAlignment.TopCenter;
                this.Controls.Add(overdueLabel);
            }

            // Date Label
            dateLabel = new Label();
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Calibri", 30.0f);
            dateLabel.Location = new Point(650, 0);
            dateLabel.Text = task.dateDue.ToString("dd"); // dd gets the day as a 2 digit number
            dateLabel.BackColor = Color.Transparent;
            this.Controls.Add(dateLabel);

            // Month Label
            monthLabel = new Label();
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Calibri", 20.0f);
            monthLabel.Location = new Point(650, 45);
            monthLabel.Text = task.dateDue.ToString("MMM"); // MMM gets the abbreviated month
            monthLabel.BackColor = Color.Transparent;
            this.Controls.Add(monthLabel);

            // Done Checkbox
            doneButton = new DoneButtonControl("Done?", startingState: this.task.hasCompleted);
            doneButton.AutoSize = true;
            doneButton.Location = new Point(550, 20);
            doneButton.BackColor = Color.Transparent;
            doneButton.AddButtonClickAction(this.OnDoneButtonClick);
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
        async private void OnTitleLabelClick(object sender, EventArgs e) { // Make this method async as it will get the marks from the API
            /// <summary>
            /// Method that executes when the title label (blue link label) is clicked.
            /// </summary>
            Feedback potentialFeedback = await APIHandler.GetFeedback(this.task);
            tabController.GoToFocussedTab(task, potentialFeedback);
        }
        private void OnDoneButtonClick(object sender, EventArgs e) {
            bool current = this.task.hasCompleted;
            this.task.UpdateHomeworkStatus(!current);
            MessageBox.Show("Updated!");
            int currentTabIndex = tabController.SelectedIndex;
            tabController.UpdateTabs(disposeCurrentTabs: true); // The current tabs are incorrect, but the data is the same
            tabController.SelectedIndex = currentTabIndex; // Ensures the program stays on the same tab
        }

        public static string ReduceText(string text, int length, char seperator = ' ') {
            /// <summary>
            /// Decreases the length of `text` to lower than or equal to `length` by splitting it at an occurence of a `seperator`, which is " " by default.
            /// A "..." is appended to the end of the string after this length reduction.
            /// </summary>

            int sepIndx = -1;
            for (int i = text.Length - 1; i >= 0; i--) {
                // Traverse through the string backwards to find the last occuring `seperator`
                if (text[i] == seperator && i <= length) { // -3 for the ... at the end
                    sepIndx = i;
                    break;
                }
            }
            return text.Substring(0, sepIndx + 1) + "...";
        }
    }
}

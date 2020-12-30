using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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

    public class HomeworkTabPage : TabPage {
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

    public class FocussedTaskTab : TabPage {
        private Homework task;
        private Label titleLabel;
        private Label groupLabel;
        private Label groupSubjectLabel;
        private Label taskDescriptionLabel;
        private Label dueInLabel;
        private Label removeTabLabel;
        private Feedback feedback;
        private FeedbackPanel feedbackPanel;
        private RemoveTabButton removeTab;
        private HomeworkTabController tabController;

        private class RemoveTabButton : Button {
            /// <summary>
            /// Private class, wrapped inside `FocussedTaskTab` which removes the FocussedTaskTab.
            /// </summary>
            
            private HomeworkTabController tabController;
            private FocussedTaskTab parentTab;
            public RemoveTabButton(FocussedTaskTab parentTab, HomeworkTabController tabController) : base(){
                this.BackColor = Color.White;
                this.AutoSize = true;
                this.tabController = tabController;
                this.parentTab = parentTab;

                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Cursor = Cursors.Hand;
                this.BackgroundImage = global::Trackr.Properties.Resources.blackCross;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Size = new Size(60, 60);
            }

            protected override void OnPaint(PaintEventArgs pevent) {
                base.OnPaint(pevent);
            }

            protected override void OnClick(EventArgs e) {
                base.OnClick(e);
                tabController.RemoveFocussedTab(parentTab.task);
                tabController.ChangeToPreviousTab();
            }
        }

        private class FeedbackPanel : Panel {
            /// <summary>
            /// Private class wrapped inside of FocussedTaskTab which contains all of the feedback items. Mostly for code maintainability.
            /// </summary>
            private Feedback feedback;
            private Label mainLabel;
            private Label feedbackLabel;
            private Label scoreLabel;
            public FeedbackPanel(Feedback feedback) : base() {
                this.feedback = feedback;
                this.AutoSize = true;
                this.BackColor = Color.Transparent;

                // Main label
                mainLabel = new Label();
                mainLabel.AutoSize = true;
                mainLabel.Text = "Feedback from " + feedback.task.group.GetTeacher().DisplayName();
                mainLabel.Font = new Font("Calibri", 18.0f, FontStyle.Bold);
                this.Controls.Add(mainLabel);

                // Feedback label
                feedbackLabel = new Label();
                feedbackLabel.AutoSize = true;
                feedbackLabel.Text = "Feedback from " + feedback.GetFeedback();
                feedbackLabel.Font = new Font("Calibri", 14.0f);
                feedbackLabel.Location = new Point(0, 25);
                this.Controls.Add(feedbackLabel);

                // Score label
                scoreLabel = new Label();
                scoreLabel.AutoSize = true;
                scoreLabel.Text = "Marks: " + feedback.GetScore().ToString() + "/" + feedback.task.maxScore.ToString();
                scoreLabel.Font = new Font("Calibri", 14.0f, FontStyle.Bold);
                scoreLabel.Location = new Point(500, 0);
                this.Controls.Add(scoreLabel);
            }
            protected override void OnPaint(PaintEventArgs e) {
                base.OnPaint(e);
            }
        }

        public FocussedTaskTab(Homework task, HomeworkTabController tabController, Feedback feedback = null) : base() {
            this.tabController = tabController;
            this.task = task;
            this.feedback = feedback;
            this.Text = this.task.title;
            this.BorderStyle = BorderStyle.FixedSingle; // Add border

            // Title label
            titleLabel = new Label();
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Calibri", 18.0f, FontStyle.Bold);
            titleLabel.Location = new Point(10, 0);
            titleLabel.Text = task.title;
            titleLabel.BackColor = Color.Transparent;
            this.Controls.Add(titleLabel);

            // Group label
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Calibri", 14.0f);
            groupLabel.Location = new Point(10, 30);
            groupLabel.Text = "• Class: " + task.group.GetName();
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);

            // Group subject label
            groupSubjectLabel = new Label();
            groupSubjectLabel.AutoSize = true;
            groupSubjectLabel.Font = new Font("Calibri", 14.0f, FontStyle.Italic);
            groupSubjectLabel.Location = new Point(10, 55);
            groupSubjectLabel.Text = "• Subject: " + task.group.GetSubject();
            groupSubjectLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupSubjectLabel);

            // Due-in label
            dueInLabel = new Label();
            dueInLabel.AutoSize = true;
            dueInLabel.Font = new Font("Calibri", 18.0f, FontStyle.Underline);
            dueInLabel.Location = new Point(300, 0);
            dueInLabel.Text = "Due in: " + task.dateDue.ToString("d MMMM yyyy");
            dueInLabel.BackColor = Color.Transparent;
            this.Controls.Add(dueInLabel);

            // Task description label
            taskDescriptionLabel = new Label();
            taskDescriptionLabel.AutoSize = true;
            taskDescriptionLabel.Font = new Font("Calibri", 14.0f);
            taskDescriptionLabel.Location = new Point(10, 90);
            taskDescriptionLabel.Text = "This is a fake description of a task so that I can understand where I need to start the line wrapping. This is a fake description of a task so that I can understand where I need to start the line wrapping. This is a fake description of a task so that I can understand where I need to start the line wrapping.";//task.description;
            taskDescriptionLabel.BackColor = Color.Transparent;
            taskDescriptionLabel.MaximumSize = new Size(650, 200);
            this.Controls.Add(taskDescriptionLabel);

            // Remove tab button
            removeTab = new RemoveTabButton(this, tabController);
            removeTab.AutoSize = true;
            removeTab.Location = new Point(650, 5);
            this.Controls.Add(removeTab);

            // Remove tab label
            removeTabLabel = new Label();
            removeTabLabel.Text = "Remove tab";
            removeTabLabel.AutoSize = true;
            removeTabLabel.Location = new Point(638, 69);
            removeTabLabel.BackColor = Color.Transparent;
            this.Controls.Add(this.removeTabLabel);

            if (this.feedback.Exists()) {
                feedbackPanel = new FeedbackPanel(this.feedback);
                
                feedbackPanel.Location = new Point(10, 215);
                feedbackPanel.Width = tabController.Size.Width;
                this.Controls.Add(feedbackPanel);
            }

        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);

            if (this.feedback.Exists()) {
                e.Graphics.DrawLine(Pens.Black, 0, 210, tabController.Size.Width, 210);
            }
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
            lbl.Font = new Font("Calibri", 12.0f);
            lbl.AutoSize = true;
            lbl.Text = labelText;
            this.Controls.Add(lbl);

            this.isChecked = startingState; // This sets the colour of the Button - colour change is performed inside of this.OnPaint
            btn = new Button();
            btn.AutoSize = true;
            btn.Location = new Point(0, 0);
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
                btn.BackColor = Color.Red; // TODO: Change this from a colored block to a tick
            }
        }
    }
}

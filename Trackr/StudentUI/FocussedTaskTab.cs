using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Math;

namespace Trackr {
    public class FocussedTaskTab : TabPage {
        /// <summary>
        /// FocussedTaskTab takes in a `Homework` and a `HomeworkTabController` and adds this new TabTage to the controller.
        /// </summary>
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
            public RemoveTabButton(FocussedTaskTab parentTab, HomeworkTabController tabController) : base() {
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
                mainLabel.Text = "Feedback from " + feedback.task.group.teacher.DisplayName();
                mainLabel.Font = new Font("Calibri", 18.0f, FontStyle.Bold);
                this.Controls.Add(mainLabel);

                // Feedback label
                feedbackLabel = new Label();
                feedbackLabel.AutoSize = true;
                feedbackLabel.Text = feedback.feedback;
                feedbackLabel.Font = new Font("Calibri", 12.0f);
                feedbackLabel.Location = new Point(0, 25);
                feedbackLabel.MaximumSize = new Size(700, 100);
                this.Controls.Add(feedbackLabel);

                // Score label
                double scorePercentage = feedback.score * 100 / feedback.task.maxScore;
                scoreLabel = new Label();
                scoreLabel.AutoSize = true;
                scoreLabel.Text = "Marks: " + feedback.score.ToString() + "/" + feedback.task.maxScore.ToString() + " (" + Math.Round(scorePercentage, 1) + "%)";
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
            groupLabel.Text = "• Class: " + task.group.name;
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);

            // Group subject label
            groupSubjectLabel = new Label();
            groupSubjectLabel.AutoSize = true;
            groupSubjectLabel.Font = new Font("Calibri", 14.0f, FontStyle.Italic);
            groupSubjectLabel.Location = new Point(10, 55);
            groupSubjectLabel.Text = "• Subject: " + task.group.subject;
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
            taskDescriptionLabel.Text = task.description;
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
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public partial class TeacherMainForm : Form {
        private Teacher user;
        private Panel currentPanel;
        private StudentPanel studentPanel;
        private GroupPanel groupPanel;
        private TaskPanel taskPanel;

        public TeacherMainForm(Teacher user) {
            InitializeComponent();
            this.Show();
            this.user = user;
            DecorateForm();

            this.FormClosed += (obj, args) => { Application.Exit(); }; // Anonymous function that closes the whole application if this form is closed
        }
        private void DecorateForm() {
            /// <summary>
            /// Procedure that makes the form nice - changes text according to this.user.
            /// </summary>
            this.Text = "Trackr - " + user.GetUsername();
            this.nameLabel.Text = user.DisplayName();
        }
        async private void editAccountMenuItemClick(object sender, EventArgs e) {
            EditAccount edit = new EditAccount(UserType.Teacher, existingUsername: user.GetUsername());
            var dialog = edit.ShowDialog(); // Block any events occurring on the main form
            if (dialog == DialogResult.OK) {
                // Validation passed -> edit account

                if (edit.newUsername != null || edit.newPassword != null) { // Then a request is necessary
                    if (edit.newUsername != null) { // Then change the username
                        this.user.SetUsername(edit.newUsername); // NO API CALLS MADE IN THIS METHOD
                        DecorateForm();
                    }
                    bool done = await APIHandler.EditAccountCredentials(UserType.Teacher, newUsername: edit.newUsername, newPassword: edit.newPassword); // edit.newPassword and edit.newUsername may be null
                    MessageBox.Show("Your edits have been saved!");
                }
            }
        }
        private void AddPanel(Panel panel) {
            /// <summary>
            /// Uses polymorphism to add a new panel.
            /// </summary>
            if (this.currentPanel != null) {
                if (this.currentPanel == panel) {
                    return;
                }
                this.currentPanel.Hide();
            }

            panel.Location = new Point(1, 1);
            panel.Dock = DockStyle.Fill;

            if (this.contentsPanel.Controls.Contains(label3)) {
                this.contentsPanel.Controls.Remove(label3); // Remove help label
            }
            this.contentsPanel.Controls.Add(panel);
            this.currentPanel = panel;
            this.currentPanel.Show();
            this.currentPanel.BringToFront();
        }

        private void studentLinkLabelClick(object sender, LinkLabelLinkClickedEventArgs e) {
            if (this.studentPanel == null) {
                this.studentPanel = new StudentPanel(contentsPanel);
            }
            AddPanel(this.studentPanel);
        }
        private void groupsLinkLabelClick(object sender, LinkLabelLinkClickedEventArgs e) {
            if (this.groupPanel == null) {
                this.groupPanel = new GroupPanel(contentsPanel);
            }
            AddPanel(this.groupPanel);
        }
        private void taskLinkLabelClick(object sender, LinkLabelLinkClickedEventArgs e) {
            if (this.taskPanel == null) {
                this.taskPanel = new TaskPanel(contentsPanel);
            }
            AddPanel(this.taskPanel);
        }
        
        private void refreshButtonClick(object sender, EventArgs e) {
            if (this.studentPanel != null)
                this.studentPanel.Hide();
            if (this.groupPanel != null)
                this.groupPanel.Hide();
            if (this.taskPanel != null)
                this.taskPanel.Hide();

            this.studentPanel = null;
            this.groupPanel = null;
            this.taskPanel = null;

            if (!this.contentsPanel.Controls.Contains(label3)) {
                this.contentsPanel.Controls.Add(label3); // Remove help label
            }
        }
    }
}

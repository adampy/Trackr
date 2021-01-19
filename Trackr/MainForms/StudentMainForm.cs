using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class StudentMainForm : Form {
        private Student user;
        private HomeworkTabController tabController;

        public StudentMainForm(Student user) {
            InitializeComponent();
            this.Show();
            this.FormClosed += (obj, args) => { Application.Exit(); }; // Anonymous function that closes the whole application if this form is closed

            // Aesthetics
            this.user = user;
            DecorateForm();
        }

        private void DecorateForm() {
            /// <summary>
            /// Procedure that makes the form nice e.g. changes the alps label
            /// </summary>
            this.Text  = "Trackr - " +  this.user.username;
            this.nameLabel.Text = this.user.DisplayName() + "!";
            this.alpsLabel.Text = user.GetAlpsString();
        }

        async private void OnRefreshButtonClick(object sender, EventArgs e) {
            refreshButton.Enabled = false; // Disable refresh button and show loading
            loadingLabel.Show();
            loadingLabel.Text = "Loading your homework, please wait...";
            progressBar.Show();
            label3.Show();
            tabController.Hide();

            Homework[] tasks = await APIHandler.GetHomework(student: user, groupHardRefresh: true);
            tabController.UpdateTabs(disposeCurrentTabs: true, newTasks: tasks); // Provide new data to the tab controller

            this.user = await APIHandler.GetStudent(id: this.user.id); // Update student
            DecorateForm(); // Update the form accordingly (e.g. new ALPs grade, username)
            // TODO: Show error to re-sign-in if a teacher changes username whilst student using the program
            
            refreshButton.Enabled = true;
            loadingLabel.Hide();
            progressBar.Hide();
            label3.Hide();
            tabController.Show();
        }

        async private void editAccountClick(object sender, EventArgs e) {
            EditAccount edit = new EditAccount(UserType.Student, existingUsername: user.username);
            var dialog = edit.ShowDialog(); // Block any events occurring on the main form
            if (dialog == DialogResult.OK) {
                // Validation passed -> edit account

                if (edit.newUsername != null || edit.newPassword != null) { // Then a request is necessary
                    if (edit.newUsername != null) { // Then change the username
                        this.user.SetUsername(edit.newUsername); // NO API CALLS MADE IN THIS METHOD
                        this.Text = "Trackr - " + edit.newUsername;
                    }
                    bool done = await APIHandler.EditAccountCredentials(UserType.Student, newUsername: edit.newUsername, newPassword: edit.newPassword); // edit.newPassword and edit.newUsername may be null
                    MessageBox.Show("Your edits have saved!");
                }
            }
        }

        async private void FormLoaded(object sender, EventArgs e) {
            /// <summary>
            /// Allows async code to be executed when starting the form. This is async to prevent blocking of the UI thread.
            /// </summary>

            Homework[] tasks = await APIHandler.GetHomework(student: user);
            // HomeworkTabController
            tabController = new HomeworkTabController(tasks);
            tabController.Location = new Point(10, 56);
            tabController.Font = new Font("Calibri", 12.0f);
            tabController.SelectedIndex = 0;
            tabController.Size = new Size(740, 395);
            this.Controls.Add(tabController);

            loadingLabel.Hide();
            progressBar.Hide();
            label3.Hide();
            label1.Show();
            label2.Show();
            alpsLabel.Show();
            nameLabel.Show();
            refreshButton.Show();
            menuStrip1.Show();
        }
    }
}

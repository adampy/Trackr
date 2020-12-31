using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.Text += this.user.GetUsername();
            this.nameLabel.Text = this.user.DisplayName() + "!";

            Task<Homework[]> task = Task.Run<Homework[]>(async () => await APIHandler.GetHomework(student: user)); // Running async code from a sync method by using `Task`
            Homework[] tasks = task.Result;

            // HomeworkTabController
            tabController = new HomeworkTabController(tasks);
            tabController.Location = new Point(10, 56);
            tabController.Font = new Font("Calibri", 12.0f);
            tabController.SelectedIndex = 0;
            tabController.Size = new Size(740, 363);
            this.Controls.Add(tabController);
        }

        private void OnRefreshButtonClick(object sender, EventArgs e) {
            Task<Homework[]> task = Task.Run<Homework[]>(async () => await APIHandler.GetHomework(student: user, groupHardRefresh: true));
            Homework[] tasks = task.Result;
            tabController.UpdateTabs(disposeCurrentTabs: true, newTasks: tasks); // Provide new data to the tab controller
        }

        async private void editAccountClick(object sender, EventArgs e) {
            StudentEditAccount edit = new StudentEditAccount(existingUsername: user.GetUsername());
            var dialog = edit.ShowDialog(); // Block any events occurring on the main form
            if (dialog == DialogResult.OK) {
                // Validation passed -> edit account
                
                this.user.SetUsername(edit.newUsername); // NO API CALLS MADE IN THIS METHOD
                this.Text = "Trackr - " + edit.newUsername;

                bool done;
                if (edit.newPassword != null) {
                    done = await APIHandler.EditStudent(newUsername: edit.newUsername, newPassword: edit.newPassword);
                } else {
                    done = await APIHandler.EditStudent(newUsername: edit.newUsername);
                }

                MessageBox.Show("Updated!");
            } else {
                MessageBox.Show("Failed!");
            }
        }
    }
}

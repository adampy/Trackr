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
        Student user;

        public StudentMainForm(Student user) {
            Task<TaskObj[]> task = Task.Run<TaskObj[]>(async () => await APIHandler.GetTasks(student: user)); // Running async code from a sync method by using `Task`
            TaskObj[] tasks = task.Result;

            InitializeComponent();
            this.Show();
            this.FormClosed += (obj, args) => { Application.Exit(); }; // Anonymous function that closes the whole application if this form is closed

            // Aesthetics
            this.user = user;
            this.Text += this.user.GetUsername();
            this.nameLabel.Text = this.user.DisplayName() + "!";

            CustomList uncompletedTasks = new CustomList(tasks.Length);
            CustomList completedTasks = new CustomList(tasks.Length); // Make two new arrays. Having them the same length as tasks makes this adding and accessing both O(1) in time but O(n) in memory
            for (int i = 0; i < tasks.Length; i++) {
                if (tasks[i].hasCompleted == false) {
                    uncompletedTasks.Add(tasks[i]);
                } else {
                    completedTasks.Add(tasks[i]);
                }
            }
            TaskTabPage uncompleted = new TaskTabPage(tabControl1, "Uncompleted tasks", uncompletedTasks, taskBorderWidth: 3);
            TaskTabPage completed = new TaskTabPage(tabControl1, "Completed tasks", completedTasks, taskBorderWidth: 3);
            tabControl1.TabPages.Add(uncompleted);
            tabControl1.TabPages.Add(completed);
            tabControl1.Font = new Font("Corbel", 8.0f);
        }
    }
}

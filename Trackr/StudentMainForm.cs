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

            TaskTabPage uncompleted = new TaskTabPage("Uncompleted tasks", tasks, Color.FromArgb(255, 87, 87));
            tabControl1.TabPages.Add(uncompleted);
        }
    }
}

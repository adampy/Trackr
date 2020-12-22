using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public class TaskControl : UserControl {
        TaskObj task;
        Label mainLabel;
        public TaskControl(TaskObj task) : base() {
            this.task = task;

            this.AutoSize = true;
            this.Height = 50;

            mainLabel = new Label();
            mainLabel.Text = task.TaskRepresentation();
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Corbel", 15.0f);
            mainLabel.Location = new Point(0, 0);
            this.Controls.Add(mainLabel);
        }
    }

    public class TaskTabPage : TabPage {
        public TaskObj[] data;
        private Panel[] panels;
        public TaskTabPage(string text, TaskObj[] taskData, Color color) {
            this.Text = text;
            this.data = taskData;
            this.BackColor = color;
            this.AutoScroll = true;
            this.panels = new Panel[taskData.Length];

            int y = 0;
            int x = 0;
            int dy = 50;
            foreach (TaskObj i in taskData) {
                TaskControl taskControl = new TaskControl(i);
                taskControl.Location = new Point(x, y);
                y += dy; 
                this.Controls.Add(taskControl);
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
        }
    }
}

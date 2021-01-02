using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Trackr {
    class TaskPanel : Panel {
        private Panel parent;
        private Label taskLabel;

        public TaskPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            taskLabel = new Label();
            taskLabel.Text = "Task panel!";
            taskLabel.AutoSize = true;
            taskLabel.Location = new Point(100, 100);
            this.Controls.Add(taskLabel);
        }
    }
}

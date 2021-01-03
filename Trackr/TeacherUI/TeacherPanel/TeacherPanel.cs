using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    class TeacherPanel : Panel {
        private Panel parent;
        private Label teacherLabel;
        public TeacherPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            teacherLabel = new Label();
            teacherLabel.Text = "Teacher panel!";
            teacherLabel.AutoSize = true;
            teacherLabel.Location = new Point(100, 100);
            this.Controls.Add(teacherLabel);
        }
    }
}

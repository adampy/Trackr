using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    class TeacherPanel : Panel {
        private Panel parent;
        private Label teacherLabel;
        private Label teacherDescriptionLabel;
        public TeacherPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;

            // teacherLabel
            teacherLabel = new Label();
            teacherLabel.AutoSize = true;
            teacherLabel.Font = new Font("Calibri", 20.0f);
            teacherLabel.Location = new Point(150, 0);
            teacherLabel.Text = "Manage teachers";
            teacherLabel.BackColor = Color.Transparent;
            this.Controls.Add(teacherLabel);

            // teacherDescriptionLabel
            teacherDescriptionLabel = new Label();
            teacherDescriptionLabel.AutoSize = true;
            teacherDescriptionLabel.Font = new Font("Calibri", 10.0f);
            teacherDescriptionLabel.Location = new Point(10, 40);
            teacherDescriptionLabel.Text = "Because you are a teacher, you can create teacher accounts - but cannot edit them. You can also reset a teachers password to a random string of characters, so they can log on again if they have lost access to their account.";
            teacherDescriptionLabel.BackColor = Color.Transparent;
            this.Controls.Add(teacherDescriptionLabel);
        }
    }
}

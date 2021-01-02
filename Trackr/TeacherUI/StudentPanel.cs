using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Trackr {
    class StudentPanel : Panel {
        private Panel parent;
        private Label allStudentsLabel;
        private TextBox studentSearchBox;
        private Label studentSearchLabel;
        private ListPanel list;
        public StudentPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            this.Width = parent.Width;
            // allStudentsLabel
            allStudentsLabel = new Label();
            allStudentsLabel.AutoSize = true;
            allStudentsLabel.Font = new Font("Calibri", 20.0f);
            allStudentsLabel.Location = new Point(180, 0);
            allStudentsLabel.Text = "Manage students";
            allStudentsLabel.BackColor = Color.Transparent;
            this.Controls.Add(allStudentsLabel);

            // studentSearchLabel
            studentSearchLabel = new Label();
            studentSearchLabel.AutoSize = true;
            studentSearchLabel.Font = new Font("Calibri", 10.0f);
            studentSearchLabel.Location = new Point(this.Width - 150, 0);
            studentSearchLabel.Text = "Search";
            studentSearchLabel.BackColor = Color.Transparent;
            this.Controls.Add(studentSearchLabel);

            // studentSearchBox
            studentSearchBox = new TextBox();
            studentSearchBox.Font = new Font("Calibri", 10.0f);
            studentSearchBox.Location = new Point(this.Width - 100, 0);
            studentSearchBox.Width = 100;
            studentSearchBox.TextChanged += (obj, e) => { list.MakePanels(studentSearchBox.Text); }; // Anonymous function that runs when the search box is changed
            this.Controls.Add(studentSearchBox);

            // list
            Task<Student[]> task = Task.Run<Student[]>(async () => await APIHandler.GetAllStudents()); // Running async code from a sync method by using `Task`
            Student[] students = task.Result;
            
            //list = new StudentListPanel(students);
            list = new ListPanel(this.parent.Width, students, typeof(StudentListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }
    }
}

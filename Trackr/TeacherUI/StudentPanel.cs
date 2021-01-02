using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System;

namespace Trackr {
    class StudentPanel : Panel {
        private Panel parent;
        private Label allStudentsLabel;
        private TextBox studentSearchBox;
        private Label studentSearchLabel;
        private ListPanel list;
        private SearchBox searchBox;
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

            // searchBox
            searchBox = new SearchBox();
            searchBox.BackColor = Color.Transparent;
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            searchBox.AddTextBoxChangedAction(SearchBoxChanged);
            this.Controls.Add(searchBox);

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
        private void SearchBoxChanged(object sender, EventArgs e) {
            list.MakePanels(searchBox.GetText());
        }
    }
}

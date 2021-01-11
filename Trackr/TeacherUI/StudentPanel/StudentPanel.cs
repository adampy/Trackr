using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System;

namespace Trackr {
    public class StudentPanel : Panel {
        private Panel parent;
        private Label allStudentsLabel;
        private ListPanel list;
        private SearchBox searchBox;
        private Button newStudentButton;
        public StudentPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            this.Width = parent.Width;
            // allStudentsLabel
            allStudentsLabel = new Label();
            allStudentsLabel.AutoSize = true;
            allStudentsLabel.Font = new Font("Calibri", 20.0f);
            allStudentsLabel.Location = new Point(180, 0);
            allStudentsLabel.Text = "Manage all students";
            allStudentsLabel.BackColor = Color.Transparent;
            this.Controls.Add(allStudentsLabel);

            // newStudentButton
            newStudentButton = new Button();
            newStudentButton.Text = "New student";
            newStudentButton.Font = new Font("Calibri", 12.0f);
            newStudentButton.Location = new Point(5, 3);
            newStudentButton.AutoSize = true;
            newStudentButton.Click += NewStudentButton_Click;
            this.Controls.Add(newStudentButton);

            // searchBox
            searchBox = new SearchBox();
            searchBox.BackColor = Color.Transparent;
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            searchBox.AddTextBoxChangedAction(SearchBoxChanged);
            this.Controls.Add(searchBox);
            RefreshList();
        }

        private void NewStudentButton_Click(object sender, EventArgs e) {
            EditStudent edit = new EditStudent(); // Create a new student
            DialogResult dialog = edit.ShowDialog(this);
            if (dialog != DialogResult.OK) {
                return;
            }
            string username = edit.newUsername;
            string forename = edit.newForename;
            string surname = edit.newSurname;
            int alps = edit.newAlps;

            APIHandler.CreateStudent(forename, surname, username, alps); // TODO: Perhaps make these return a boolean, to denote whether the creation has been succesful or not
            MessageBox.Show(username + "'s account has been created successfully! Please tell them to use the 'first time sign-in' when they try to sign-in.");
            RefreshList();
        }

        private void SearchBoxChanged(object sender, EventArgs e) {
            list.MakePanels(searchBox.GetText());
        }
        async public void RefreshList() {
            /// <summary>
            /// Executed after opening the manage student tab.
            /// </summary>
            
            // Data
            Student[] students = await APIHandler.GetAllStudents();

            // List
            if (list != null) {
                list.Dispose();
            }
            list = new ListPanel(this.parent.Width, students, typeof(StudentListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }
    }
}

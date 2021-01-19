using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public partial class ViewGroupStudents : Form {
        /// <summary>
        /// ViewGroupStudents is a form used to add and remove students from a group.
        /// </summary>
        private Group group;
        private BindingList<Student> allNonGroupStudents = new BindingList<Student>(); // TODO: Change these to CustomList
        private BindingList<Student> groupStudents = new BindingList<Student>(); // BindingLists allows data changed in the program, to be updated in the form using event handlers.
        private Dictionary<Label, Student> labelStudentLinker = new Dictionary<Label, Student>();
        private List<Label> currentStudentNameLabels = new List<Label>();
        public ViewGroupStudents(Group group) {
            InitializeComponent();
            this.group = group;
            this.Text += group.name;
            label1.Text = group.name + "'s students";
            GetGroupStudents();
            GetAllNonGroupStudents();

            // StudentList data
            groupStudents.ListChanged += FillStudentPanel;

            // ComboBox data
            BindingSource comboBoxBind = new BindingSource();
            comboBoxBind.DataSource = this.allNonGroupStudents;
            comboBoxBind.ListChanged += FillStudentPanel;
            studentComboBox.DataSource = comboBoxBind;
            studentComboBox.DisplayMember = "fullName";
            studentComboBox.ValueMember = "fullName";

            //https://stackoverflow.com/questions/5489273/how-do-i-disable-the-horizontal-scrollbar-in-a-panel
            studentNamePanel.AutoScroll = false;
            studentNamePanel.HorizontalScroll.Visible = false;
            studentNamePanel.HorizontalScroll.Enabled = false;
            studentNamePanel.HorizontalScroll.Maximum = 0;
            studentNamePanel.AutoScroll = true;
        }
        async private void GetGroupStudents() {
            Student[] students = await APIHandler.GetGroupStudents(group);
            foreach (Student student in students) {
                groupStudents.Add(student);
            }
            
        }
        async private void GetAllNonGroupStudents() {
            Student[] students = await APIHandler.GetAllStudents();

            for (int i = 0; i < students.Length; i++) {
                Student student = students[i];
                
                // If student isnt in the group, then add them to the non group
                bool found = false;
                foreach (Student groupStudent in this.groupStudents) {
                    found = found || groupStudent.id == student.id;
                }

                if (!found) {  // Student is not already in the group
                    this.allNonGroupStudents.Add(student);
                }
            }
        }
        private void FillStudentPanel(object sender, ListChangedEventArgs e) {
            foreach (Label lbl in this.currentStudentNameLabels) {
                lbl.Hide();
                lbl.Dispose();
            }
            this.currentStudentNameLabels = new List<Label>();

            int y = 5;
            for (int i = 0; i < this.groupStudents.Count; i++) { 
                Student student = (Student)this.groupStudents[i];
                Label lbl = new Label();
                lbl.Text = "• " + student.fullName;
                lbl.Font = new Font("Calibri", 20.0f, FontStyle.Italic);
                lbl.AutoSize = true;
                lbl.Location = new Point(5, y);
                lbl.MouseEnter += OnStudentLabelHover;
                lbl.MouseLeave += OnStudentLabelDeHover;
                lbl.Click += OnStudentLabelClick;
                lbl.Cursor = Cursors.Hand;
                y += lbl.Height + 20;
                studentNamePanel.Controls.Add(lbl);
                this.labelStudentLinker.Add(lbl, student);
                this.currentStudentNameLabels.Add(lbl);
            }
        }
        private void OnStudentLabelHover(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Red;
        }
        private void OnStudentLabelDeHover(object sender, EventArgs e) {
            ((Label)sender).ForeColor = Color.Black;
        }
        private void OnStudentLabelClick(object sender, EventArgs e) {
            Label lbl = (Label)sender;
            Student student = this.labelStudentLinker[lbl];
            DialogResult dialog = MessageBox.Show("Are you sure you want to remove '" + student.forename + "' from '" + group.name + "'?", "Remove confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }

            APIHandler.RemoveStudentFromGroup(student, this.group);
            groupStudents.Remove(student);
            allNonGroupStudents.Add(student);
        }
        private void addStudentButton_Click(object sender, EventArgs e) {
            if (studentComboBox.SelectedIndex == -1) {
                MessageBox.Show("You must choose a valid student to add to the group.");
                return;
            }
            Student student = (Student)studentComboBox.SelectedItem;
            
            APIHandler.AddStudentToGroup(student, this.group);
            groupStudents.Add(student);
            allNonGroupStudents.Remove(student);
        } 
    }
}

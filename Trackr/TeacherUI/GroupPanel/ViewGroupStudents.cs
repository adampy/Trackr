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
    public partial class ViewGroupStudents : Form {
        private Group group;
        private BindingList<Student> allNonGroupStudents = new BindingList<Student>(); // TODO: Change these to CustomList
        private BindingList<Student> groupStudents = new BindingList<Student>();
        private Dictionary<Label, Student> labelStudentLinker = new Dictionary<Label, Student>();
        public ViewGroupStudents(Group group) {
            InitializeComponent();
            this.group = group;
            this.Text += group.GetName();
            label1.Text = group.GetName() + "'s students";
            GetGroupStudents(); // This procedure also calls FillStudentPanel
            GetAllNonGroupStudents(); // This procedure also fills the combobox
            studentComboBox.DataSource = this.allNonGroupStudents;
            studentComboBox.DisplayMember = "fullName";
            studentComboBox.ValueMember = "fullName";
        }
        async private void GetGroupStudents() {
            Student[] students = await APIHandler.GetGroupStudents(group);
            foreach (Student student in students) {
                groupStudents.Add(student);
            }
            FillStudentPanel(groupStudents);
        }
        async private void GetAllNonGroupStudents() {
            Student[] students = await APIHandler.GetAllStudents();

            foreach (Student student in students) {
                // If student isnt in the group, then add them to the non group
                bool found = false;
                foreach (Student groupStudent in this.groupStudents) {
                    found = found || groupStudent.GetId() == student.GetId();
                }

                if (!found) {  // Student is not already in the group
                    this.allNonGroupStudents.Add(student);
                }
            }
        }
        private void FillStudentPanel(BindingList<Student> studentsToAdd) {
            foreach (Control ctrl in studentNamePanel.Controls) {
                studentNamePanel.Controls.Remove(ctrl); // Remove all olds labels
            }

            int y = 5;
            for (int i = 0; i < studentsToAdd.Count; i++) { 
                Student student = (Student)studentsToAdd[i];
                Label lbl = new Label();
                lbl.Text = student.GetFullName();
                lbl.Font = new Font("Calibri", 20.0f);
                lbl.AutoSize = true;
                lbl.Location = new Point(5, y);
                lbl.MouseEnter += OnStudentLabelHover;
                lbl.MouseLeave += OnStudentLabelDeHover;
                lbl.Click += OnStudentLabelClick;
                lbl.Cursor = Cursors.Hand;
                y += lbl.Height + 5;
                studentNamePanel.Controls.Add(lbl);
                this.labelStudentLinker.Add(lbl, student);
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
            DialogResult dialog = MessageBox.Show("Are you sure you want to remove '" + student.GetForename() + "' from '" + group.GetName() + "'?", "Remove confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }

            //APIHandler.RemoveStudentFromGroup(student, this.group);
            groupStudents.Remove(student);
            allNonGroupStudents.Add(student);
            FillStudentPanel(groupStudents);
        }
        private void addStudentButton_Click(object sender, EventArgs e) {
            if (studentComboBox.SelectedIndex == -1) {
                MessageBox.Show("You must choose a valid student to add to the group.");
                return;
            }
            Student student = (Student)studentComboBox.SelectedItem;
            //APIHandler.AddStudentToGroup(student, this.group); // TODO: Remove and test these lines
            allNonGroupStudents.Remove(student);
            groupStudents.Add(student);
            FillStudentPanel(groupStudents); // Update the panel
        }
    }
}

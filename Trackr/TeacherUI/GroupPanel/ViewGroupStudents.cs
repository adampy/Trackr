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
        private Student[] allStudents; // TODO: Change these to CustomList
        private Student[] groupStudents;
        private Dictionary<Label, Student> labelStudentLinker = new Dictionary<Label, Student>();
        public ViewGroupStudents(Group group) {
            InitializeComponent();
            this.group = group;
            this.Text += group.GetName();
            label1.Text = group.GetName() + "'s students";
            GetGroupStudents(); // This procedure also calls FillStudentPanel
            GetAllStudents();
        }
        async private void GetGroupStudents() {
            this.groupStudents = await APIHandler.GetGroupStudents(group);
            FillStudentPanel();
        }
        async private void GetAllStudents() {
            this.allStudents = await APIHandler.GetAllStudents();
        }
        private void FillStudentPanel() {
            int y = 0;
            foreach (Student student in this.groupStudents) {
                Label lbl = new Label();
                lbl.Text = student.GetFullName();
                lbl.Font = new Font("Calibri", 20.0f);
                lbl.AutoSize = true;
                lbl.Location = new Point(0, y);
                y += lbl.Height + 5;
                studentNamePanel.Controls.Add(lbl); // TODO: FINISH THIS
            }
        }
    }
}

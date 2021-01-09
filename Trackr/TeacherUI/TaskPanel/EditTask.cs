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
    public partial class EditTask : Form {
        private Assignment assignment;
        public string newTitle;
        public string newDescription;
        public int newScore;
        public DateTime newDueDate;
        public Group newGroup;
        private Group[] groups;
        
        public EditTask(Group[] groups) {
            /// <summary>
            /// This constructor is used when creating an assignment.
            /// </summary>
            InitializeComponent();
            this.Text = "Create task";
            label2.Text = "Create new task";
            editTaskButton.Text = "Save new task";

            DateTime defaultTime = DateTime.Now;
            dueDatePicker.MinDate = defaultTime;
            dueDatePicker.Value = defaultTime;
            assignedcomboBox1.DataSource = this.groups;
            assignedcomboBox1.DisplayMember = "name";
        }
        public EditTask(Assignment assignment) {
            /// <summary>
            /// This constructor is used when editing an assignment.
            /// </summary>
            InitializeComponent();
            this.assignment = assignment;
            newTitle = assignment.title;
            newDescription = assignment.description;
            newScore = assignment.maxScore;
            newDueDate = assignment.dateDue;

            titleTextBox.Text = newTitle;
            descriptionTextBox.Text = newDescription;
            maxScoreTextBox.Text = newScore.ToString();
            dueDatePicker.Value = newDueDate;
            //dueDatePicker.MinDate = DateTime.Now;
            assignedcomboBox1.Text = assignment.group.GetName();
            assignedcomboBox1.Enabled = false;
        }

        private void editTaskButton_Click(object sender, EventArgs e) {
            newTitle = titleTextBox.Text;
            newDescription = descriptionTextBox.Text;
            newDueDate = dueDatePicker.Value;
            
            bool validScore = Int32.TryParse(maxScoreTextBox.Text, out newScore);
            
            if (newTitle == "" || newDescription == "") {
                MessageBox.Show("All fields must be entered.");
                return;
            }

            if (assignedcomboBox1.Enabled && assignedcomboBox1.SelectedIndex == -1) { //TODO:TEST THIS HERE MAK SURE IT WORKS
                MessageBox.Show("You must assign the task to a group.");
                return;
            } else {
                newGroup = (Group)assignedcomboBox1.SelectedItem;
            }

            if (!validScore) {
                MessageBox.Show("Maximum score must be an integer (whole number).");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

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
    public partial class ProvideFeedback : Form {
        private Student[] students;
        private Student currentStudent;
        private Assignment assignment;
        public ProvideFeedback(Assignment assignment) {
            InitializeComponent();

            this.assignment = assignment;
            label2.Text = "You're providing feedback to '" + assignment.group.GetName() + "' for '" + assignment.title + "'.";
            maxScoreLabel.Text = "/" + assignment.maxScore.ToString();
            students = Task.Run(async () => await APIHandler.GetGroupStudents(assignment.group)).Result;
            studentComboBox.DataSource = students;
            studentComboBox.DisplayMember = "fullName";
            studentComboBox.ValueMember = "fullName";

        }

        async private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (assignment == null) {
                return;
            }
            currentStudent = (Student)studentComboBox.SelectedItem;
            Feedback fbk = await APIHandler.TeacherGetFeedback(currentStudent, assignment);
            if (fbk.Exists()) {
                feedbackTextBox.Text = fbk.GetFeedback();
                scoreTextBox.Text = fbk.GetScore().ToString();
            } else {
                feedbackTextBox.Text = "";
                scoreTextBox.Text = "";
            }
        }
        private void sendFeedbackButtonClick(object sender, EventArgs e) {
            string feedback = feedbackTextBox.Text; // TODO: Validate lengths
            int score = -1;
            if (!Int32.TryParse(scoreTextBox.Text, out score)) {
                MessageBox.Show("Score must be an integer.");
                return;
            }
            if (score > assignment.maxScore) {
                MessageBox.Show("You cannot have a score higher than the maximum score.");
                return;
            }

            APIHandler.GiveFeedback(currentStudent, assignment, score, feedback);
            MessageBox.Show("Feedback provided!");
        }
    }
}

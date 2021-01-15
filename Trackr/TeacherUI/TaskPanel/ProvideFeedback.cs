using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class ProvideFeedback : Form {
        /// <summary>
        /// ProvideFeedback is a form that allows teachers to provide feedback to a list of students (in the group) for the given `assignment`.
        /// </summary>
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
            string feedback = feedbackTextBox.Text;
            int score = -1;
            if (!Int32.TryParse(scoreTextBox.Text, out score)) {
                MessageBox.Show("Score must be an integer.");
                return;
            }
            if (score > assignment.maxScore) {
                MessageBox.Show("You cannot have a score higher than the maximum score.");
                return;
            }
            if (feedback.Length > 511) {
                MessageBox.Show("Your feedback must be shorter. Please shorten it and try again.");
                return;
            }

            APIHandler.GiveFeedback(currentStudent, assignment, score, feedback);
            MessageBox.Show("Feedback provided!");
        }
    }
}

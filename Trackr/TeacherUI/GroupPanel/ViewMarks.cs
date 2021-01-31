using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class ViewMarks : Form {
        /// <summary>
        /// This is the window that allows a teacher to view marks for a group. It retreives the marks, students, and tasks
        /// and shows a colouring system relative to the ALPS grade of the student.
        /// </summary>
        private Group group;
        private Student[] students; // Class used to store data retrieved from API
        private Assignment[] tasks; // Class used to store data retrieved from API
        private AbstractMark[] marks; // Class used to store data retrieved from API
        private Dictionary<StudentTask, AbstractMark> studentTaskMarkLinker = new Dictionary<StudentTask, AbstractMark>(); // This dictionary links the studentID + taskID with the AbstractMark to improve performance
        private Dictionary<int, Student> studentIdToStudent = new Dictionary<int, Student>(); // Converter
        private Dictionary<int, Assignment> taskIdToTask = new Dictionary<int, Assignment>(); // Converter
        private AbstractMark[,] markGrid; // This is used for getting the data for the grid
        private bool dataGridInitialised = false;

        public ViewMarks(Group group) {
            /// <summary>
            /// Constructor for ViewMarks
            /// </summary>
            InitializeComponent();
            this.group = group;
            this.Text = "Trackr - Viewing '" + this.group.name + "'s marks";
            groupNameLabel.Text = this.group.name;
            
            // dataGrid configuration
            dataGrid.Hide();
            dataGrid.VirtualMode = true; // Turning on virtual mode, and implementing handlers myself increases performance - https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/implementing-virtual-mode-wf-datagridview-control?view=netframeworkdesktop-4.8
            dataGrid.CellValueNeeded += this.CellValueNeeded;
            dataGrid.CellToolTipTextNeeded += this.CellToolTipTextNeeded;
            dataGrid.CellValueChanged += this.CellValueChanged;
            dataGrid.TopLeftHeaderCell.Value = "Student \\ Task"; // When executed, \\ => \
            dataGrid.DefaultCellStyle.SelectionBackColor = Color.Transparent;

            // progressBar configuration
            progressBar.Show();
            progressBar.Value = 1;
            
            // Get data, and process it
            GetStudents();
            GetTasks();
            GetMarks();
        }

        async private void ProgressBarIncrement() {
            progressBar.Value += 33;
            if (progressBar.Value == 100) {
                await Task.Delay(1000);

                ProcessData();
                progressBar.Hide();
                loadingLabel.Hide();
                dataGrid.Show();
            }
        }

        private struct StudentTask {
            public int studentId;
            public int taskId;
        };

        async private void GetStudents() {
            this.students = await APIHandler.GetGroupStudents(group);
            foreach (Student student in this.students) {
                this.studentIdToStudent[student.id] = student;
            }
            ProgressBarIncrement();
        }
        async private void GetTasks() {
            this.tasks = await APIHandler.TeacherGetGroupTasks(group);
            foreach (Assignment task in this.tasks) {
                this.taskIdToTask[task.id] = task;
            }
            ProgressBarIncrement();
        }
        async private void GetMarks() {
            this.marks = await APIHandler.GetGroupMarks(group);
            foreach (AbstractMark mark in this.marks) {
                StudentTask key = new StudentTask() { studentId = mark.GetStudentId(), taskId = mark.GetTaskId() };
                studentTaskMarkLinker[key] = mark;
            }
            ProgressBarIncrement();
        }
        private void ProcessData() {
            dataGrid.ColumnCount = this.tasks.Length;
            dataGrid.RowCount = this.students.Length;
            this.markGrid = new AbstractMark[dataGrid.ColumnCount, dataGrid.RowCount]; // Used to store references to each mark - making the tooltips work

            for (int i = 0; i  < this.tasks.Length; i++) {
                dataGrid.Columns[i].HeaderCell.Value = this.tasks[i].title;
                dataGrid.Columns[i].ReadOnly = false;
            }

            for (int i = 0; i < this.students.Length; i++) {
                Student student = this.students[i];
                dataGrid.Rows[i].HeaderCell.Value = student.fullName;

                for (int j = 0; j < this.tasks.Length; j++) {
                    Assignment task = this.tasks[j];
                    StudentTask key = new StudentTask() { studentId = student.id, taskId = task.id };

                    AbstractMark mark;
                    bool exists = studentTaskMarkLinker.TryGetValue(key, out mark);
                    if (exists) {
                        this.markGrid[j, i] = mark;
                    } else {
                        this.markGrid[j, i] = new AbstractMark(student.id, task.id); // Add an empty mark
                    }
                    // The tooltip should not be set here because it can cause performance issues - https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/add-tooltips-to-individual-cells-in-a-wf-datagridview-control?view=netframeworkdesktop-4.8#robust-programming
                }
            }
            this.dataGridInitialised = true;
        }

        #region DataCell handlers
        private void CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e) {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1) {
                return;
            }
            AbstractMark mark = this.markGrid[e.ColumnIndex, e.RowIndex];
            if (mark != null) {
                Assignment assignment = taskIdToTask[mark.GetTaskId()];
                Student student = studentIdToStudent[mark.GetStudentId()];
                e.ToolTipText = "Score: " + mark.GetScore().ToString() + "\nOut of: " + assignment.maxScore + "\nALPs grade: " + student.GetAlpsString() + "\nFeedback provided: " + mark.GetFeedback();
            } else {
                e.ToolTipText = "Feedback not yet provided";
            }
        }
        private void CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1) {
                return;
            }
            AbstractMark mark = this.markGrid[e.ColumnIndex, e.RowIndex];
            DataGridViewCell cell = dataGrid[e.ColumnIndex, e.RowIndex];

            if (mark.HasMarked()) {
                e.Value = mark.GetScoreString();

                int maxScore = this.taskIdToTask[mark.GetTaskId()].maxScore;
                Student student = this.studentIdToStudent[mark.GetStudentId()];
                cell.Style.BackColor = ScoreGrade(mark, maxScore, student);
            } else {
                cell.Style.BackColor = Color.Gray;
                e.Value = "N/A";
            }
        }
        private void CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (!this.dataGridInitialised || e.ColumnIndex <= -1 || e.RowIndex <= -1) {
                return;
            }

            DataGridViewCell cell = dataGrid[e.ColumnIndex, e.RowIndex];
            AbstractMark mark = this.markGrid[e.ColumnIndex, e.RowIndex];
            Assignment task = this.taskIdToTask[mark.GetTaskId()];
            Student student = this.studentIdToStudent[mark.GetStudentId()];

            string newValue = cell.EditedFormattedValue.ToString();
            int newScore = 0;
            bool isDigit = Int32.TryParse(newValue, out newScore);
            if (!isDigit || newScore < 0 || newScore > task.maxScore) {
                return;
            }

            // Changed mark from N/A
            if (mark.GetFeedback() == null) {
                mark.UpdateFeedback("No feedback given."); // NO API CALLS MADE IN THIS METHOD
            }
            mark.UpdateScore(newScore); // NO API CALLS MADE IN THIS METHOD

            this.markGrid[e.ColumnIndex, e.RowIndex] = mark; // Update cell data
            cell.Style.BackColor = ScoreGrade(mark, task.maxScore, student);
            APIHandler.GiveFeedback(student, task, newScore, mark.GetFeedback());
        }
        #endregion

        #region Mathematical formulae
        public static Color ScoreGrade(AbstractMark mark, int maxScore, Student student) {
            /// <summary>
            /// Returns a cell colour for a `mark`. The ALPS grade of `student` is used.
            /// </summary>
            
            // Get prerequesites
            float percentage = (float)mark.GetScore() / (float)maxScore; // Convert to floats to avoid integer division - https://stackoverflow.com/questions/37641472/how-do-i-calculate-a-percentage-of-a-number-in-c
            float adjustedAlps = (float)student.alps / 100f;

            float diff = adjustedAlps - percentage;
            if (diff > 0.4) {
                return Color.Red;
            } else if (diff > 0.25) {
                return Color.Orange;
            } else {
                return Color.Green;
            }
        }
        /*public static int[] InconsistentVals(float[] values, float multiplier = 1) {
            float sum = 0;
            foreach (float v in values) {
                sum += v;
            }
            float mean = sum / values.Length;

            double fractionTop = 0;
            foreach (float v in values) {
                fractionTop += Math.Pow(v - mean, 2);
            }
            double standardDeviation = Math.Sqrt(fractionTop / values.Length);

            CustomList indexes = new CustomList();
            for (int i = 0; i < values.Length; i++) {
                float v = values[i];
                double upperBound = multiplier * mean + standardDeviation;
                double lowerBound = multiplier * mean - standardDeviation;
                if (!(v >= lowerBound && v <= upperBound)) {
                    indexes.Add(i);
                }
            }
            return indexes.ToArray<int>();
        } TODO: Delete this*/
        #endregion
    }
}

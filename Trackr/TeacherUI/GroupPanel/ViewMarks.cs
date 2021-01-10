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
    public partial class ViewMarks : Form {
        private Group group;
        private Student[] students; // Class used to store data retrieved from API
        private Assignment[] tasks; // Class used to store data retrieved from API
        private AbstractMark[] marks; // Class used to store data retrieved from API
        private Dictionary<StudentTask, AbstractMark> studentTaskMarkLinker = new Dictionary<StudentTask, AbstractMark>(); // This dictionary links the studentID + taskID with the AbstractMark to improve performance
        private Dictionary<int, Student> studentIdToStudent = new Dictionary<int, Student>(); // Converter
        private Dictionary<int, Assignment> taskIdToTask = new Dictionary<int, Assignment>(); // Converter
        private AbstractMark[,] markGrid; // This is used for getting the data for the grid

        public ViewMarks(Group group) {
            InitializeComponent();
            this.group = group;
            groupNameLabel.Text = this.group.GetName();
            
            // dataGrid configuration
            dataGrid.Hide();
            dataGrid.VirtualMode = true; // Turning on virtual mode, and implementing handlers myself increases performance - https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/implementing-virtual-mode-wf-datagridview-control?view=netframeworkdesktop-4.8
            dataGrid.CellValueNeeded += this.CellValueNeeded;
            dataGrid.CellToolTipTextNeeded += this.CellToolTipTextNeeded;
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
                this.studentIdToStudent[student.GetId()] = student;
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
            }

            for (int i = 0; i < this.students.Length; i++) {
                Student student = this.students[i];
                dataGrid.Rows[i].HeaderCell.Value = student.GetFullName();

                for (int j = 0; j < this.tasks.Length; j++) {
                    Assignment task = this.tasks[j];
                    StudentTask key = new StudentTask() { studentId = student.GetId(), taskId = task.id };
                    AbstractMark mark = studentTaskMarkLinker[key];

                    this.markGrid[j, i] = mark;
                    // The tooltip should not be set here because it can cause performance issues - https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/add-tooltips-to-individual-cells-in-a-wf-datagridview-control?view=netframeworkdesktop-4.8#robust-programming
                }

                

            }
        }

        #region DataCell handlers
        private void CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e) {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1) {
                return;
            }
            AbstractMark mark = this.markGrid[e.ColumnIndex, e.RowIndex];
            e.ToolTipText = mark.GetFeedback();
        }
        private void CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            if (e.RowIndex <= -1 || e.ColumnIndex <= -1) {
                return;
            }
            AbstractMark mark = this.markGrid[e.ColumnIndex, e.RowIndex];
            DataGridViewCell cell = dataGrid[e.ColumnIndex, e.RowIndex];

            e.Value = mark.GetScoreString();
            if (mark.HasMarked()) {
                int maxScore = this.taskIdToTask[mark.GetTaskId()].maxScore;
                float percentage = (float)mark.GetScore() / (float)maxScore; // Convert to floats to avoid integer division - https://stackoverflow.com/questions/37641472/how-do-i-calculate-a-percentage-of-a-number-in-c
                Student student = this.studentIdToStudent[mark.GetStudentId()];
                float adjustedAlps = (float)student.GetAlps() / 100f;

                cell.Style.BackColor = ScoreGrade(percentage, adjustedAlps);
            } else {
                cell.Style.BackColor = Color.Gray;
            }

        }
        #endregion

        #region Mathematical formulae
        public static Color ScoreGrade(float markPercentage, float adjustedAlps) {
            float diff = adjustedAlps - markPercentage;
            if (diff > 0.4) {
                return Color.Red;
            } else if (diff > 0.25) {
                return Color.Orange;
            } else {
                return Color.Green;
            }
        }
        public static int[] InconsistentVals(float[] values, float multiplier = 1) {
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
                double upperBound = standardDeviation + multiplier * mean;
                double lowerBound = standardDeviation - multiplier * mean;
                if (!(v >= lowerBound && v <= upperBound)) {
                    indexes.Add(i);
                }
            }
            return indexes.ToArray<int>();
        } // TODO: Implement this?
        #endregion
    }
}

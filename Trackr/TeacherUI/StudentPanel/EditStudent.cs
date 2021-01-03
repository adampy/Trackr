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
    public partial class EditStudent : Form {
        private Student student;
        private Dictionary<string, int> alpsConverter = new Dictionary<string, int> {
            {"A*/A", 80 },
            {"A", 75 },
            {"B", 65 },
            {"B/C", 60},
            {"C", 55 },
            {"C/D", 50 },
            {"D", 45 }
        };
        public string newUsername;
        public string newForename;
        public string newSurname;
        public int newAlps;
        public bool isNewUsername;
        public EditStudent() {
            /// <summary>
            /// This constructor is used when creating a new student.
            /// </summary>
            InitializeComponent();
            alpsComboBox.Items.AddRange(alpsConverter.Keys.ToArray());
            isNewUsername = true;
            label1.Text = "Create new student";
            editStudentButton.Text = "Save student";
            this.Text = "Create student";
        }

        public EditStudent(Student student) {
            /// <summary>
            /// This constructor is used when editing a student.
            /// </summary>
            InitializeComponent();
            this.student = student;
            alpsComboBox.Items.AddRange(alpsConverter.Keys.ToArray());
            newUsername = student.GetUsername();
            newForename = student.GetForename();
            newSurname = student.GetSurname();
            newAlps = student.GetAlps();

            usernameTextBox.Text = newUsername;
            forenameTextBox.Text = newForename;
            surnameTextBox.Text = newSurname;
            alpsComboBox.SelectedItem = student.GetAlpsString();
        }

        async private void editStudentButton_Click(object sender, EventArgs e) {
            newUsername = usernameTextBox.Text;
            newForename = forenameTextBox.Text;
            newSurname = surnameTextBox.Text;
            if (alpsComboBox.SelectedIndex == -1 || newUsername == "" || newForename == "" || newSurname == "") {
                MessageBox.Show("All fields must be entered, including the ALPs grade combobox.");
                return;
            }

            newAlps = alpsConverter[alpsComboBox.SelectedItem.ToString()];
            
            if (student != null) {
                isNewUsername = newUsername != student.GetUsername(); // If the username has changed
            }

            if ((isNewUsername && !await APIHandler.IsUsernameTaken(UserType.Student, newUsername)) || !isNewUsername) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                MessageBox.Show("This username has already been taken, please try another.");
                return;
            }
        }
    }
}

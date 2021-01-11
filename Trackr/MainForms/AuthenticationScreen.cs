using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http; // TODO: Change these fonts to calibri

namespace Trackr {
    public enum UserType {
        Student = 0,
        Teacher = 1
    }

    public partial class AuthenticationScreen : Form {

        PanelStack panels = new PanelStack(4); // Make a stack of size 4
        bool closedByProgram = false; // false if not closed by program and true if the program has closed the window
        
        public AuthenticationScreen() {
            InitializeComponent();
            panels.SetPreviousPanelButton(backButton);
            panels.Push(mainPanel);
            passwordMatchingLabel.Hide();
            usernameAvaliableLabel.Hide();
            this.FormClosed += (obj, args) => { if (!closedByProgram) { Application.Exit(); } }; // Anonymous function that closes the whole application if this form is closed
        }
        public void SetSoftClose() {
            this.Close();
        }

        private void flushTextBoxes() {
            ///<summary>
            ///Subroutine that empties all of the textboxes across all forms.
            ///</summary>

            // Sign-in form
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";

            // Registration form
            forenameTextBox.Text = "";
            surnameTextBox.Text = "";
            passwordRegistrationTextBox.Text = "";
            confirmPasswordRegistrationTextbox.Text = "";
            passwordMatchingLabel.Hide();
            usernameRegistrationTextBox.Text = "";
            titleTextBox.Text = "";
            //adminCodeTextBox.Text = ""; // TODO: remove this line if not needed?
            usernameAvaliableLabel.Hide();
        }
        
        async private void authScreenLoad(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that sends a simple GET request to the root of the API to ensure it is not sleeping. This route also checks for internet connection on the device.
            /// </summary>
            try {
                HttpResponseMessage response = await WebRequestHandler.GET("/");
                if (!response.IsSuccessStatusCode) {
                    MessageBox.Show("An unexpected error has occured within the API, please try again later", "API error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (HttpRequestException) {
                MessageBox.Show("No internet connection avaliable: please connect to the internet and try again.", "Internet connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }
        private void signInClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine run when the sign in button is pressed on the start menu.
            /// </summary>
            panels.Push(signInPanel);
        }
        private void registerButtonClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that is executed when the register button on the first panel is pressed.
            /// </summary>
            panels.Push(registrationPanel);
        }
        private void previousPanel(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that executes when the back button is clicked. It pops the topmost panel from the stack.
            /// </summary>
            panels.Pop();
            flushTextBoxes(); // Remove any data kept in the textboxes
        }
        async private void studentSignInClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that is executed when a student wants to sign into the program.
            /// It sends a GET request to the API to try and obtain student details.
            /// </summary>

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            flushTextBoxes();

            if (checkBox1.Checked) {
                if (username == "") {
                    MessageBox.Show("Username cannot be left blank!");
                    return;
                }
                StudentGetPassword passwordForm = new StudentGetPassword();
                var dialog = passwordForm.ShowDialog();
                if (dialog == DialogResult.OK) {
                    password = passwordForm.passwordResult;
                } else {
                    MessageBox.Show("An error has occurred, please try again.");
                    return;
                }

                // Send request to API to change password of `username` to `password`
                try {
                    await APIHandler.ResetPassword(username, password);
                    string newCredentials = WebRequestHandler.ConvertToBase64(username + ":" + password);
                    WebRequestHandler.SetAuthorizationHeader(newCredentials);

                    Student student = await APIHandler.GetStudent(username: username); // Get the student with username `username` from the API
                    closedByProgram = true; // Set boolean to prevent Application.Exit() call
                    this.Close(); // Close current form
                    FormController.studentMain = new StudentMainForm(student); // Open the new form
                } catch (HttpStatusUnauthorized) {
                    MessageBox.Show("Your account already has a password - please ask a teacher to reset your password.");
                    return;
                }

            } else {
                if (username == "" || password == "") {
                    MessageBox.Show("Username or password cannot be left blank!"); //TODO: Does this need a messagebox? Nicer way of showing error?
                    return; // Do not execute more of the subroutine
                }

                string credentials = WebRequestHandler.ConvertToBase64(username + ":" + password);
                APIHandler.SetAuthorizationHeader(credentials);
                if (await APIHandler.IsUserValid(UserType.Student, username, password)) {
                    Student student = await APIHandler.GetStudent(username: username); // Get the student with username `username` from the API
                    closedByProgram = true; // Set boolean to prevent Application.Exit() call
                    this.Close(); // Close current form
                    FormController.studentMain = new StudentMainForm(student); // Open the new form
                } else {
                    MessageBox.Show("Your account doesn't exist.");
                }
            }
        }
        async private void teacherSignInClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that signs a teacher into their account. It sends GET /teacher/<username>?username=True
            /// </summary>

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            flushTextBoxes();

            if (checkBox1.Checked == true) {
                MessageBox.Show("Teachers cannot use the first time sign-in feature, and should enter their password.");
                return;
            }

            if (username == "" || password == "") {
                MessageBox.Show("Username or password cannot be left blank!");
                return; // Do not execute more of the subroutine
            }

            string credentials = WebRequestHandler.ConvertToBase64(username + ":" + password);
            APIHandler.SetAuthorizationHeader(credentials);
            if (await APIHandler.IsUserValid(UserType.Teacher, username, password)){
                Teacher teacher = await APIHandler.GetTeacher(username: username);
                closedByProgram = true; // Set boolean to prevent Application.Exit() call
                this.Close(); // Close current form
                FormController.teacherMain = new TeacherMainForm(teacher); // Open the new form
            } else {
                MessageBox.Show("Your account doesn't exist.");
            }
        }
        async private void teacherRegisterButtonCick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that is executed when the register button is pressed after the teacher registration
            /// form has been completed. This method ensures that all values are != "", before checking passwords
            /// are matching. The adminCode may be correct and a MessageBox is shown when this occurs.
            /// </summary>
            string forename = forenameTextBox.Text;
            string surname = surnameTextBox.Text;
            string password = passwordRegistrationTextBox.Text;
            string confirmedPassword = confirmPasswordRegistrationTextbox.Text;
            string title = titleTextBox.Text;
            string adminCode = adminCodeTextBox.Text;
            string username = usernameRegistrationTextBox.Text;

            if (forename == "" || surname == "" || password == "" || confirmedPassword == "" || title == "" || adminCode == "" || adminCode == "") {
                MessageBox.Show("All values must be entered");
                return;
            }

            if (password != confirmedPassword) {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (!User.IsPasswordValid(password)) {
                MessageBox.Show("The password is not strong enough. It must have:\nlength of 8\n1 or more uppercase letters\n1 or more lowercase letters\n1 or more digits.");
                return;
            }

            try {
                Teacher teacher = await APIHandler.MakeTeacher(forename, surname, username, password, title, adminCode: adminCode);
                MessageBox.Show("Success: " + teacher.DisplayName() + " " + teacher.GetUsername());
                flushTextBoxes();
            } catch (HttpStatusUnauthorized) {
                MessageBox.Show("Incorrect admin code entered.");
                }
        }
        async private void usernameAvaliableButtonClick(object sender, EventArgs e) {
            string adminCode = adminCodeTextBox.Text;
            string username = usernameRegistrationTextBox.Text;
            if (adminCode == "" || username == "") {
                MessageBox.Show("Enter the admin code, and/or a username, before you can check if a username is avaliable!");
                return;
            }

            try {
                bool taken = await APIHandler.IsUsernameTaken(UserType.Teacher, username, adminCode: adminCode);
                if (!taken) {
                    usernameAvaliableLabel.Text = "Username avaliable!";
                    usernameAvaliableLabel.ForeColor = Color.Green;
                } else {
                    usernameAvaliableLabel.Text = "Username not avaliable, please try another.";
                    usernameAvaliableLabel.ForeColor = Color.Red;
                }
                usernameAvaliableLabel.Show();
            }
            catch (HttpStatusUnauthorized) {
                MessageBox.Show("Incorrect admin code entered.");
            }
        }
        private void passwordChanged(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that runs when confirmPasswordTextBox.Text is changed, it verifies that the passwords match
            /// </summary>

            if (passwordRegistrationTextBox.Text != "") {
                if (confirmPasswordRegistrationTextbox.Text == passwordRegistrationTextBox.Text) {
                    passwordMatchingLabel.Text = "Passwords match!";
                    passwordMatchingLabel.ForeColor = Color.Green;
                } else {
                    passwordMatchingLabel.Text = "Passwords do not match!";
                    passwordMatchingLabel.ForeColor = Color.Red;
                }
                passwordMatchingLabel.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            passwordTextBox.Enabled = !checkBox1.Checked;
            passwordTextBox.Text = "";
        }
    }
}

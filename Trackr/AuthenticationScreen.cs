using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;

namespace Trackr {
    public partial class AuthenticationScreen : Form {

        Stack panels = new Stack(4); // Make a stack of size 4

        public AuthenticationScreen() {

            InitializeComponent();
            panels.Push(mainPanel);
            panels.SetPreviousPanelButton(backButton);
            passwordMatchingLabel.Hide();
            usernameAvaliableLabel.Hide();
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

            if (username == "" || password == "") {
                MessageBox.Show("Username or password cannot be left blank!"); //TODO: Does this need a messagebox? Nicer way of showing error?
                return; // Do not execute more of the subroutine
            }

            string credentials = WebRequestHandler.ConvertToBase64(username + ":" + password);
            APIHandler.SetAuthorizationHeader(credentials);
            try {
                Student student = await APIHandler.GetStudent(username: username); // Get the student with username `username` from the API
                FormController.studentMain = new StudentMainForm(student); // Open the new form
                
            } catch (HttpStatusUnauthorized) {
                MessageBox.Show("Your account doesn't exist.");
            } catch (HttpStatusNotFound) {
                // This catch runs if the account is valid, but of the wrong type, e.g. student clicked teacher
                MessageBox.Show("Your account is not a student, please click login as a teacher instead.");
            }
        }
        async private void teacherSignInClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that signs a teacher into their account. It sends GET /teacher/<username>?username=True
            /// </summary>

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            flushTextBoxes();

            if (username == "" || password == "") {
                MessageBox.Show("Username or password cannot be left blank!");
                return; // Do not execute more of the subroutine
            }

            string credentials = WebRequestHandler.ConvertToBase64(username + ":" + password);
            APIHandler.SetAuthorizationHeader(credentials);
            try {
                Teacher teacher = await APIHandler.GetTeacher(username: username);
                MessageBox.Show(teacher.GetUsername() + ":" + teacher.DisplayName());
            } catch (HttpStatusUnauthorized) {
                MessageBox.Show("Your account doesn't exist.");
            } catch (HttpStatusNotFound) {
                MessageBox.Show("Your account is not a teacher, please click login as a student instead.");
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
            flushTextBoxes();

            if (forename == "" || surname == "" || password == "" || confirmedPassword == "" || title == "" || adminCode == "" || adminCode == "") {
                MessageBox.Show("All values must be entered");
            }

            if (password != confirmedPassword) {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // TODO: Make password criteria to check if a password is secure enough
            try {
                Teacher teacher = await APIHandler.MakeTeacher(forename, surname, username, password, title, adminCode: adminCode);
                MessageBox.Show("Success: " + teacher.DisplayName() + " " + teacher.GetUsername());
            } catch (HttpStatusUnauthorized) {
                MessageBox.Show("Incorrect admin code entered.");
            } catch (HttpRequestException exception) {
                throw exception;
            }
        }
        async private void usernameAvaliableButtonClick(object sender, EventArgs e) {
            string adminCode = adminCodeTextBox.Text;
            if (adminCode == "") {
                MessageBox.Show("Enter the admin code before you can check if a username is avaliable!");
                return;
            }

            string username = usernameRegistrationTextBox.Text;
            try {
                bool taken = await APIHandler.IsTeacherUsernameTaken(username, adminCode);
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
    }
}

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
        }
        private void flushTextBoxes() {
            ///<summary>
            ///Subroutine that empties all of the textboxes across all forms.
            ///</summary>
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
        async private void authScreenLoad(object sender, EventArgs e) {
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
            panels.Push(signInPanel);
        }
        private void registerButtonClick(object sender, EventArgs e) {
            panels.Push(registrationPanel);
        }
        private void previousPanel(object sender, EventArgs e) {
            panels.Pop();
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
                MessageBox.Show("Success!");
            } catch (HttpStatusUnauthorized) {
                MessageBox.Show("Your account doesn't exist.");
            }
        }
        async private void teacherSignInClick(object sender, EventArgs e) {
            /// <summary>
            /// Subroutine that signs a teacher into their account. It sends GET /teacher/<username>?username=True
            /// </summary>

            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            flushTextBoxes();

            string credentials = WebRequestHandler.ConvertToBase64(username + ":" + password);

            WebRequestHandler.SetAuthorizationHeader(credentials);
            HttpResponseMessage response = await WebRequestHandler.GET("/teacher/" + username + "?username=True");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Success: " + await response.Content.ReadAsStringAsync());
            } else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
                MessageBox.Show("Your account not exists.");
            } else {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }
        private void teacherRegisterButtonCick(object sender, EventArgs e) {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trackr {
    public partial class ManageStudent : Form {
        /// <summary>
        /// ManageStudent allows a teacher to edit a student's account. All API calls are made here.
        /// </summary>
        private Student student;
        public bool studentPanelNeedsRefresh = false;
        public ManageStudent(Student student) {
            InitializeComponent();
            this.student = student;
            usernameLabel.Text = student.username;
            forenameLabel.Text = student.forename;
            surnameLabel.Text = student.surname;
            alpsGradeLabel.Text = student.GetAlpsString();
        }

        private void resetPasswordButton_Click(object sender, EventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to reset " + student.forename + "'s password?", "Reset password confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }
            // Reset password here
            Dictionary<string, string> formData = new Dictionary<string, string> {
                { "password", "true" }
            };
            APIHandler.TeacherEditStudent(student, formData);
            MessageBox.Show(student.forename + "'s password has been reset. Please tell them to select the 'first time sign-in' when they next sign-in.");
        }

        private void deleteStudentButton_Click(object sender, EventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete " + student.forename + "'s account?", "Delete account confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }
            // Delete account
            APIHandler.TeacherDeleteStudentAccount(student);
            MessageBox.Show(student.forename + "'s account has been deleted.");
            this.studentPanelNeedsRefresh = true;
            this.Close();
        }

        private void editStudentButton_Click(object sender, EventArgs e) {
            EditStudent edit = new EditStudent(student);
            DialogResult dialog = edit.ShowDialog(this);
            if (dialog != DialogResult.OK) {
                return;
            } else {
                // Make this local var to prevent "marshal-by-reference" classes - https://stackoverflow.com/questions/4178576/accessing-a-member-on-form-may-cause-a-runtime-exception-because-it-is-a-field-o
                int newAlps = edit.newAlps;
                Dictionary<string, string> formData = new Dictionary<string, string> {
                    { "forename", edit.newForename },
                    { "surname", edit.newSurname },
                    { "alps", newAlps.ToString() },
                };

                if (edit.isNewUsername) {
                    formData.Add("username", edit.newUsername);
                }

                APIHandler.UpdateStudent(student, formData);
                MessageBox.Show(edit.newForename + "'s account has been edited.");
                this.studentPanelNeedsRefresh = true;
                this.Close();
            }
        }
    }
}

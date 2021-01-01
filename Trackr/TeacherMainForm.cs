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
    public partial class TeacherMainForm : Form {
        private Teacher user;
        public TeacherMainForm(Teacher user) {
            InitializeComponent();
            this.Show();

            this.user = user;
            this.Text = "Trackr - " + user.GetUsername();
            this.nameLabel.Text = user.DisplayName();
            
            this.FormClosed += (obj, args) => { Application.Exit(); }; // Anonymous function that closes the whole application if this form is closed
        }

        async private void editAccountMenuItemClick(object sender, EventArgs e) {
            TeacherEditAccount edit = new TeacherEditAccount(existingUsername: user.GetUsername());
            var dialog = edit.ShowDialog(); // Block any events occurring on the main form
            if (dialog == DialogResult.OK) {
                // Validation passed -> edit account

                if (edit.newUsername != null || edit.newPassword != null) { // Then a request is necessary
                    if (edit.newUsername != null) { // Then change the username
                        this.user.SetUsername(edit.newUsername); // NO API CALLS MADE IN THIS METHOD
                        this.Text = "Trackr - " + edit.newUsername;
                    }
                    bool done = await APIHandler.EditAccount(UserType.Teacher, newUsername: edit.newUsername, newPassword: edit.newPassword); // edit.newPassword and edit.newUsername may be null
                    MessageBox.Show("Your edits have saved!");
                }
            }
        }
    }
}

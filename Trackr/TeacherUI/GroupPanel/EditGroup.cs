using System;
using System.Windows.Forms;

namespace Trackr {
    public partial class EditGroup : Form {
        private Group group;

        public string newName;
        public string newSubject;
        public EditGroup() {
            /// <summary>
            /// This constructor is used when creating a group.
            /// </summary>
            InitializeComponent();
            this.Text = "Create group";
            label2.Text = "Create new group";
            editGroupButton.Text = "Save new group";
        }
        public EditGroup(Group group) {
            /// <summary>
            /// This constructor is used when editing a group.
            /// </summary>
            InitializeComponent();
            this.group = group;
            newName = group.GetName();
            newSubject = group.GetSubject();

            nameTextBox.Text = newName;
            subjectTextBox.Text = newSubject;
        }

        private void editGroupButton_Click(object sender, EventArgs e) {
            newName = nameTextBox.Text;
            newSubject = subjectTextBox.Text;
            if (newName == "" || newSubject == "") {
                MessageBox.Show("All fields must be entered.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

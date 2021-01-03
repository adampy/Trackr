using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Trackr {
    public class GroupPanel : Panel {
        private Panel parent;
        private Label groupLabel;
        private SearchBox searchBox;
        private ListPanel list;
        private Button newGroupButton;
        public GroupPanel(Panel parentPanel) : base() {
            this.parent = parentPanel;
            this.Width = parent.Width;
            // groupLabel
            groupLabel = new Label();
            groupLabel.AutoSize = true;
            groupLabel.Font = new Font("Calibri", 20.0f);
            groupLabel.Location = new Point(180, 0);
            groupLabel.Text = "Manage groups";
            groupLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupLabel);
            
            
            // newStudentButton
            newGroupButton = new Button();
            newGroupButton.Text = "New class";
            newGroupButton.Font = new Font("Calibri", 12.0f);
            newGroupButton.Location = new Point(5, 3);
            newGroupButton.AutoSize = true;
            newGroupButton.Click += NewGroupButton_Click;
            this.Controls.Add(newGroupButton);

            // searchBox
            searchBox = new SearchBox();
            searchBox.BackColor = Color.Transparent;
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            searchBox.AddTextBoxChangedAction(SearchBoxChanged);
            this.Controls.Add(searchBox);
            RefreshList();
        }
        private void SearchBoxChanged(object sender, EventArgs e) {
            list.MakePanels(searchBox.GetText());
        }

        private void NewGroupButton_Click(object sender, EventArgs e) {
            EditGroup newG = new EditGroup(); // Create a new student
            DialogResult dialog = newG.ShowDialog(this);
            if (dialog != DialogResult.OK) {
                return;
            }

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"name", newG.newName },
                {"subject", newG.newSubject }
            };
            APIHandler.CreateGroup(formData);
            RefreshList();
        }

        async public void RefreshList() {
            // Groups
            Group[] groups = await APIHandler.TeacherGetGroups();

            // List
            if (list != null) {
                list.Dispose();
            }

            list = new ListPanel(this.parent.Width, groups, typeof(GroupListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }
    }
}

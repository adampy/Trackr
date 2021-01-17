using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace Trackr {
    public class GroupPanel : TeacherFormPanel {
        /// <summary>
        /// GroupPanel is a container class that contains all of the data for the groups. It contains the list of groups that a
        /// teacher is part of. It also contains the `searchBox` and a `newGroupButton`.
        /// </summary>
        public GroupPanel(Panel parentPanel) : base(parentPanel) {
            this.parent = parentPanel;
            this.Width = parent.Width;

            // mainLabel
            mainLabel.Location = new Point(150, 0);
            mainLabel.Text = "Manage your groups";
            // newObjButton
            newObjButton.Text = "New class";
            // searchBox
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            RefreshList();
        }

        public override void OnNewObjButtonClick(object sender, EventArgs e) {
            EditGroup newG = new EditGroup(); // Create a new group
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

        async public override void RefreshList() {
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

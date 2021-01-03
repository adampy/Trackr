using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System;

namespace Trackr {
    public class GroupPanel : Panel {
        private Panel parent;
        private Label groupLabel;
        private SearchBox searchBox;
        private ListPanel list;
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

        private void RefreshList() {
            // list
            Task<Group[]> task = Task.Run<Group[]>(async () => await APIHandler.TeacherGetGroups()); // Running async code from a sync method by using `Task`
            Group[] groups = task.Result;

            //list = new StudentListPanel(students);
            list = new ListPanel(this.parent.Width, groups, typeof(GroupListItem));
            list.Location = new Point(0, 35);
            list.Width = this.parent.Width;
            list.Height = this.parent.Height - 35;
            this.Controls.Add(list);
        }

    }
}

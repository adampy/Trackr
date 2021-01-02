using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace Trackr {
    class GroupPanel : Panel {
        private Panel parent;
        private Label groupLabel;
        private Label groupSearchLabel;
        private TextBox groupSearchBox;
        private ListPanel list;
        private Teacher user;
        public GroupPanel(Panel parentPanel, Teacher user) : base() {
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

            // groupSearchLabel
            groupSearchLabel = new Label();
            groupSearchLabel.AutoSize = true;
            groupSearchLabel.Font = new Font("Calibri", 10.0f);
            groupSearchLabel.Location = new Point(this.Width - 150, 0);
            groupSearchLabel.Text = "Search";
            groupSearchLabel.BackColor = Color.Transparent;
            this.Controls.Add(groupSearchLabel);

            // groupSearchBox
            groupSearchBox = new TextBox();
            groupSearchBox.Font = new Font("Calibri", 10.0f);
            groupSearchBox.Location = new Point(this.Width - 100, 0);
            groupSearchBox.Width = 100;
            groupSearchBox.TextChanged += (obj, e) => { list.MakePanels(groupSearchBox.Text); }; // Anonymous function that runs when the search box is changed
            this.Controls.Add(groupSearchBox);

            // list
            Task<Group[]> task = Task.Run<Group[]>(async () => await APIHandler.TeacherGetGroups(teacher: this.user)); // Running async code from a sync method by using `Task`
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

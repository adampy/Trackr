using System.Windows.Forms;
using System.Drawing;
using System;

namespace Trackr {
    public class ListPanel : Panel {
        /// <summary>
        /// ListPanel creates a list of given type, `t`. `listItems` contain the panels, and has type UserControl because all panels
        /// (AssignmentListItem, StudentListItem, GroupListItem) all inherit UserControl - this is called polymorphism.
        /// </summary>
        private dynamic[] data; // data
        private UserControl[] listItems; // actual panels
        private Type typeOfListItem;
        private Label noItemsLabel;
        
        public ListPanel(int width, dynamic[] data, Type t) : base() {
            this.data = data;
            this.typeOfListItem = t;
            this.Width = width;

            //https://stackoverflow.com/questions/5489273/how-do-i-disable-the-horizontal-scrollbar-in-a-panel
            this.AutoScroll = false;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Maximum = 0;
            this.AutoScroll = true;

            // noItemsLabel
            noItemsLabel = new Label();
            noItemsLabel.Text = "No results found...";
            noItemsLabel.AutoSize = true;
            noItemsLabel.Font = new Font("Calibri", 20.0f, FontStyle.Italic);
            noItemsLabel.ForeColor = Color.Gray;
            noItemsLabel.Anchor = AnchorStyles.Top;
            this.Controls.Add(noItemsLabel);
            noItemsLabel.Hide();

            MakePanels();
        }
        public void MakePanels(string mustContain = "") {
            if (listItems != null) {
                foreach (UserControl listItem in listItems) {
                    if (listItem != null) {
                        this.Controls.Remove(listItem);
                        listItem.Dispose();
                    }
                }
            }

            /// <summary>
            /// Adds panels such that all panels contain `thatContain`. If `thatContain` == "" then all the panels are aded.
            /// </summary>
            if (this.typeOfListItem == typeof(StudentListItem)) {
                listItems = new StudentListItem[this.data.Length];
            } else if (this.typeOfListItem == typeof(GroupListItem)) {
                listItems = new GroupListItem[this.data.Length];
            } else if (this.typeOfListItem == typeof(AssignmentListItem)) {
                listItems = new AssignmentListItem[this.data.Length];
            }

            int y = 0;
            for (int i = 0; i < this.data.Length; i++) {
                var obj = this.data[i];
                bool success = false;

                UserControl listItem = new UserControl();
                if (this.typeOfListItem == typeof(StudentListItem) && ((Student)obj).fullName.ToLower().Contains(mustContain.ToLower())) {
                    listItem = new StudentListItem(obj);
                    success = true;
                } else if (this.typeOfListItem == typeof(GroupListItem) && ((Group)obj).name.ToLower().Contains(mustContain.ToLower())) {
                    listItem = new GroupListItem(obj);
                    success = true;
                } else if (this.typeOfListItem == typeof(AssignmentListItem) && ((Assignment)obj).title.ToLower().Contains(mustContain.ToLower())) {
                    listItem = new AssignmentListItem(obj);
                    success = true;
                }

                if (success) {
                    listItems[i] = listItem; // Add to list of items
                    listItem.Location = new Point(0, y);
                    listItem.Width = this.Width;
                    y += listItem.Height - 1; // -1 for the border
                    this.Controls.Add(listItem);
                }
            }

            if (y == 0) { // No items added
                noItemsLabel.Show();
                noItemsLabel.BringToFront();
            } else {
                noItemsLabel.Hide();
            }
        }
    }
}

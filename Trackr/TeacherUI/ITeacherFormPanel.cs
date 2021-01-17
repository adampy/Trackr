using System.Windows.Forms;
using System.Drawing;
using System;

namespace Trackr {
    public interface ITeacherFormPanel {
        /// Interface that outlines a teacher form panel, displayed to the teacher. Any TeacherFormPanel must have a list, searchbox, and new object button.
        /// Base functionality for this interface is described inside TeacherFormPanel.
        /// </summary>
        public Panel parent { get; set; }
        public Label mainLabel { get; set; }
        public SearchBox searchBox { get; set; }
        public ListPanel list { get; set; }
        public Button newObjButton { get; set; }

        public abstract void RefreshList();
        public abstract void OnNewObjButtonClick(object sender, EventArgs e);
        public void SearchBoxChanged(object sender, EventArgs e);
    }
    public abstract class TeacherFormPanel : Panel, ITeacherFormPanel { // Dual inheritance - interface and parent class
        public Panel parent { get; set; }
        public Label mainLabel { get; set; }
        public SearchBox searchBox { get; set; }
        public ListPanel list { get; set; }
        public Button newObjButton { get; set; }
        public virtual void RefreshList() { } // Virtual modifier means it can be overriden if necessary
        public virtual void OnNewObjButtonClick(object sender, EventArgs e) { }
        public virtual void SearchBoxChanged(object sender, EventArgs e) { 
            list.MakePanels(searchBox.GetText());
        }
        public TeacherFormPanel(Panel parent) {
            this.parent = parent;
            
            // Searchbox
            this.searchBox = new SearchBox();
            searchBox.BackColor = Color.Transparent;
            searchBox.Location = new Point(this.Width - searchBox.Width - 5, 3);
            searchBox.AddTextBoxChangedAction(SearchBoxChanged);
            this.Controls.Add(searchBox);
            RefreshList();

            // mainLabel
            mainLabel = new Label();
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Calibri", 20.0f);
            mainLabel.Location = new Point(180, 0);
            mainLabel.BackColor = Color.Transparent;
            this.Controls.Add(mainLabel);

            // newObjButton
            newObjButton = new Button();
            newObjButton.Font = new Font("Calibri", 12.0f);
            newObjButton.Location = new Point(5, 3);
            newObjButton.AutoSize = true;
            newObjButton.Click += OnNewObjButtonClick;
            this.Controls.Add(newObjButton);
        }
    }
}

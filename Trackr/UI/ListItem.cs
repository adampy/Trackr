using System.Windows.Forms;
using System.Drawing;

namespace Trackr {
    public class ListItem : UserControl {
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.DrawLine(Pens.Black, 0, 0, this.Width, 0);
            e.Graphics.DrawLine(Pens.Black, 0, this.Height - 1, this.Width, this.Height - 1);
        }
        protected void ParentRefreshList() {
            /// <sumamry>
            /// Method that every listitem has, that allows the teacherpanel list to be refreshed.
            /// </sumamry>
            ((TeacherFormPanel)((ListPanel)this.Parent).Parent).RefreshList();
        }
    }
}

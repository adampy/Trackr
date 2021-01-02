using System.Windows.Forms;
using System.Drawing;
using System;

namespace Trackr {
    public class ListItem : UserControl {
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.DrawLine(Pens.Black, 0, 0, this.Width, 0);
            e.Graphics.DrawLine(Pens.Black, 0, this.Height - 1, this.Width, this.Height - 1);
        }
    }
}

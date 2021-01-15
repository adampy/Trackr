using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public class DoneButtonControl : UserControl {
        /// <summary>
        /// DoneButtonControl is placed on every list item of students homeworks, it simply acts as a button.
        /// Actions are added when `AddButtonClickAction` is used.
        /// </summary>
        private Label lbl;
        private Button btn;
        private bool isChecked;
        public DoneButtonControl(string labelText, bool startingState) : base() {
            /// <summary>
            /// Constructor method for DoneButtonControl. A label with text `labelText`, and a button with state `startingState` is drawn.
            /// </summary>
            lbl = new Label();
            lbl.Location = new Point(0, 23);
            lbl.Font = new Font("Calibri", 12.0f);
            lbl.AutoSize = true;
            lbl.Text = labelText;
            this.Controls.Add(lbl);

            this.isChecked = startingState; // This sets the colour of the Button - colour change is performed inside of this.OnPaint
            btn = new Button();
            btn.AutoSize = true;
            btn.Location = new Point(13, 0);
            btn.Click += (obj, e) => OnButtonClick(obj, e);
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(20, 20);
            this.Controls.Add(btn);

            this.Height = lbl.Location.Y + lbl.Size.Height; //Height is changed to prevent this UserControl taking up more space than necessary
        }
        protected void OnButtonClick(object sender, EventArgs e) {
            /// <summary>
            /// Executes when this.btn is clicked. The whole control is redrawn at the end of this procedure.
            /// </summary>
            isChecked = !isChecked; // Flip the checked state
            this.Invalidate();
        }
        public void AddButtonClickAction(Action<object, EventArgs> procedure) {
            /// <summary>
            /// A method that allows procedures to be added to this.btn.Click (because this.btn is private)
            /// </summary>
            this.btn.Click += (obj, e) => procedure(obj, e);
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height); // Fill background in white
            if (isChecked) {
                btn.BackColor = Color.Green;
            } else {
                btn.BackColor = Color.Red; // TODO: Change this from a colored block to a tick
            }
        }
    }
}

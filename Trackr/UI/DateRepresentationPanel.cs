using System;
using System.Drawing;
using System.Windows.Forms;

namespace Trackr {
    public partial class DateRepresentationPanel : UserControl {
        /// <summary>
        /// DateRepresentationPanel shows a datetime in a specific way, according to the program design.
        /// dateSize = font size of the date number
        /// monthSize = font size of the month string
        /// spacing = space between the bottom of the date and top of the month.
        /// </summary>
        private DateTime datetime;
        public DateRepresentationPanel(DateTime datetime, float dateSize, float monthSize, int spacing) {
            InitializeComponent();
            this.datetime = datetime;
            this.AutoSize = true;
            this.BackColor = Color.Transparent;
            // Date Label
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Calibri", dateSize);
            dateLabel.Location = new Point(0, 0);
            dateLabel.Text = this.datetime.ToString("dd"); // dd gets the day as a 2 digit number
            dateLabel.BackColor = Color.Transparent;
            this.Controls.Add(dateLabel);

            // Month Label
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Calibri", monthSize);
            monthLabel.Location = new Point(3, dateLabel.Location.Y + dateLabel.Height + spacing);
            monthLabel.Text = this.datetime.ToString("MMM"); // MMM gets the abbreviated month
            monthLabel.BackColor = Color.Transparent;
            this.Controls.Add(monthLabel);

            this.Height = monthLabel.Location.Y + monthLabel.Height;
            this.Width = monthLabel.Width;
        }
    }
}

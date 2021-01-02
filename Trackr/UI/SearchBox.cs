using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr {
    public partial class SearchBox : UserControl {
        public SearchBox() {
            InitializeComponent();
        }
        public void AddTextBoxChangedAction(Action<object, EventArgs> procedure) {
            /// <summary>
            /// A method that allows procedures to be added to this.textBox1.TextChanged
            /// </summary>
            this.textBox1.TextChanged += (obj, e) => procedure(obj, e);
        }
        public string GetText() {
            return this.textBox1.Text;
        }
    }
}

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
    public partial class GroupListItem : ListItem {
        private Group group;
        public GroupListItem(Group group) {
            InitializeComponent();
            this.group = group;
            this.groupNameLabel.Text = group.GetName();
        }
    }
}

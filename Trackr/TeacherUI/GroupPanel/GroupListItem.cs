﻿using System;
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

        private void editLinkLabel_Clicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EditGroup edit = new EditGroup(this.group);
            DialogResult dialog = edit.ShowDialog();
            if (dialog != DialogResult.OK) {
                return;
            }

            Dictionary<string, string> formData = new Dictionary<string, string> {
                {"name", edit.newName },
                {"subject", edit.newSubject }
            };

            APIHandler.UpdateGroup(this.group, formData);
            MessageBox.Show("Group has been updated successfully.");
            ((GroupPanel)((ListPanel)this.Parent).Parent).RefreshList(); // TODO: Remove all parent and this.parent references and change to something like this
        }

        private void deleteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete '" + this.group.GetName() + "'?", "Deletion confirmation", MessageBoxButtons.YesNo);
            if (dialog != DialogResult.Yes) {
                return;
            }
            APIHandler.DeleteGroup(this.group);
            MessageBox.Show("Group has been deleted successfully.");
            ((GroupPanel)((ListPanel)this.Parent).Parent).RefreshList();
        }

        private void viewStudentsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ViewGroupStudents students = new ViewGroupStudents(this.group);
            DialogResult dialog = students.ShowDialog();
        }
    }
}
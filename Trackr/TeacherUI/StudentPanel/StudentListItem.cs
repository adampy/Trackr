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
    public partial class StudentListItem : ListItem {
        private Student student;
        public StudentListItem(Student student) {
            InitializeComponent();
            this.student = student;
            this.studentNameLabel.Text = student.GetFullName();
        }
        private void manageStudentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            ManageStudent manage = new ManageStudent(this.student);
            manage.ShowDialog();
            if (manage.studentPanelNeedsRefresh) {
                ((StudentPanel)((ListPanel)this.Parent).Parent).RefreshList(); // TODO: Remove all parent and this.parent references and change to something like this
            }
        }
    }
}
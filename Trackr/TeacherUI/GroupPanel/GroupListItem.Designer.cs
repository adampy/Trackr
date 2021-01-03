namespace Trackr {
    partial class GroupListItem {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupNameLabel = new System.Windows.Forms.Label();
            this.editLinkLabel = new System.Windows.Forms.LinkLabel();
            this.deleteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.viewStudentsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // groupNameLabel
            // 
            this.groupNameLabel.AutoSize = true;
            this.groupNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.groupNameLabel.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNameLabel.Location = new System.Drawing.Point(3, 12);
            this.groupNameLabel.Name = "groupNameLabel";
            this.groupNameLabel.Size = new System.Drawing.Size(147, 33);
            this.groupNameLabel.TabIndex = 1;
            this.groupNameLabel.Text = "groupName";
            // 
            // editLinkLabel
            // 
            this.editLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.editLinkLabel.AutoSize = true;
            this.editLinkLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editLinkLabel.LinkColor = System.Drawing.Color.Green;
            this.editLinkLabel.Location = new System.Drawing.Point(434, 18);
            this.editLinkLabel.Name = "editLinkLabel";
            this.editLinkLabel.Size = new System.Drawing.Size(47, 26);
            this.editLinkLabel.TabIndex = 2;
            this.editLinkLabel.TabStop = true;
            this.editLinkLabel.Text = "Edit";
            this.editLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editLinkLabel_Clicked);
            // 
            // deleteLinkLabel
            // 
            this.deleteLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.deleteLinkLabel.AutoSize = true;
            this.deleteLinkLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteLinkLabel.LinkColor = System.Drawing.Color.Red;
            this.deleteLinkLabel.Location = new System.Drawing.Point(487, 18);
            this.deleteLinkLabel.Name = "deleteLinkLabel";
            this.deleteLinkLabel.Size = new System.Drawing.Size(68, 26);
            this.deleteLinkLabel.TabIndex = 3;
            this.deleteLinkLabel.TabStop = true;
            this.deleteLinkLabel.Text = "Delete";
            this.deleteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteLinkLabel_LinkClicked);
            // 
            // viewStudentsLinkLabel
            // 
            this.viewStudentsLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.viewStudentsLinkLabel.AutoSize = true;
            this.viewStudentsLinkLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewStudentsLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.viewStudentsLinkLabel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.viewStudentsLinkLabel.Location = new System.Drawing.Point(296, 18);
            this.viewStudentsLinkLabel.Name = "viewStudentsLinkLabel";
            this.viewStudentsLinkLabel.Size = new System.Drawing.Size(132, 26);
            this.viewStudentsLinkLabel.TabIndex = 4;
            this.viewStudentsLinkLabel.TabStop = true;
            this.viewStudentsLinkLabel.Text = "View students";
            this.viewStudentsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.viewStudentsLinkLabel_LinkClicked);
            // 
            // GroupListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewStudentsLinkLabel);
            this.Controls.Add(this.deleteLinkLabel);
            this.Controls.Add(this.editLinkLabel);
            this.Controls.Add(this.groupNameLabel);
            this.Name = "GroupListItem";
            this.Size = new System.Drawing.Size(889, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.LinkLabel editLinkLabel;
        private System.Windows.Forms.LinkLabel deleteLinkLabel;
        private System.Windows.Forms.LinkLabel viewStudentsLinkLabel;
    }
}

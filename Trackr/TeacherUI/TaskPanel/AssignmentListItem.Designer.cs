namespace Trackr {
    partial class AssignmentListItem {
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
            this.assignmentNameLabel = new System.Windows.Forms.Label();
            this.groupNameLabel = new System.Windows.Forms.Label();
            this.provideFeedbackLinkLabel = new System.Windows.Forms.LinkLabel();
            this.deleteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.editLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // assignmentNameLabel
            // 
            this.assignmentNameLabel.AutoSize = true;
            this.assignmentNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.assignmentNameLabel.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignmentNameLabel.Location = new System.Drawing.Point(3, 4);
            this.assignmentNameLabel.Name = "assignmentNameLabel";
            this.assignmentNameLabel.Size = new System.Drawing.Size(191, 29);
            this.assignmentNameLabel.TabIndex = 1;
            this.assignmentNameLabel.Text = "assignmentName";
            // 
            // groupNameLabel
            // 
            this.groupNameLabel.AutoSize = true;
            this.groupNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.groupNameLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupNameLabel.Location = new System.Drawing.Point(4, 33);
            this.groupNameLabel.Name = "groupNameLabel";
            this.groupNameLabel.Size = new System.Drawing.Size(85, 19);
            this.groupNameLabel.TabIndex = 2;
            this.groupNameLabel.Text = "groupName";
            // 
            // provideFeedbackLinkLabel
            // 
            this.provideFeedbackLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.provideFeedbackLinkLabel.AutoSize = true;
            this.provideFeedbackLinkLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provideFeedbackLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.provideFeedbackLinkLabel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.provideFeedbackLinkLabel.Location = new System.Drawing.Point(297, 19);
            this.provideFeedbackLinkLabel.Name = "provideFeedbackLinkLabel";
            this.provideFeedbackLinkLabel.Size = new System.Drawing.Size(125, 19);
            this.provideFeedbackLinkLabel.TabIndex = 7;
            this.provideFeedbackLinkLabel.TabStop = true;
            this.provideFeedbackLinkLabel.Text = "Provide feedback";
            // 
            // deleteLinkLabel
            // 
            this.deleteLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.deleteLinkLabel.AutoSize = true;
            this.deleteLinkLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteLinkLabel.LinkColor = System.Drawing.Color.Red;
            this.deleteLinkLabel.Location = new System.Drawing.Point(461, 19);
            this.deleteLinkLabel.Name = "deleteLinkLabel";
            this.deleteLinkLabel.Size = new System.Drawing.Size(54, 19);
            this.deleteLinkLabel.TabIndex = 6;
            this.deleteLinkLabel.TabStop = true;
            this.deleteLinkLabel.Text = "Delete";
            // 
            // editLinkLabel
            // 
            this.editLinkLabel.ActiveLinkColor = System.Drawing.Color.Red;
            this.editLinkLabel.AutoSize = true;
            this.editLinkLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLinkLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editLinkLabel.LinkColor = System.Drawing.Color.Green;
            this.editLinkLabel.Location = new System.Drawing.Point(423, 19);
            this.editLinkLabel.Name = "editLinkLabel";
            this.editLinkLabel.Size = new System.Drawing.Size(37, 19);
            this.editLinkLabel.TabIndex = 5;
            this.editLinkLabel.TabStop = true;
            this.editLinkLabel.Text = "Edit";
            this.editLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editLinkLabel_LinkClicked);
            // 
            // AssignmentListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.provideFeedbackLinkLabel);
            this.Controls.Add(this.deleteLinkLabel);
            this.Controls.Add(this.editLinkLabel);
            this.Controls.Add(this.groupNameLabel);
            this.Controls.Add(this.assignmentNameLabel);
            this.Name = "AssignmentListItem";
            this.Size = new System.Drawing.Size(889, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label assignmentNameLabel;
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.LinkLabel provideFeedbackLinkLabel;
        private System.Windows.Forms.LinkLabel deleteLinkLabel;
        private System.Windows.Forms.LinkLabel editLinkLabel;
    }
}

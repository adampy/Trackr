namespace Trackr {
    partial class StudentListItem {
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
            this.studentNameLabel = new System.Windows.Forms.Label();
            this.manageStudentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // studentNameLabel
            // 
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.studentNameLabel.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNameLabel.Location = new System.Drawing.Point(3, 12);
            this.studentNameLabel.Name = "studentNameLabel";
            this.studentNameLabel.Size = new System.Drawing.Size(166, 33);
            this.studentNameLabel.TabIndex = 0;
            this.studentNameLabel.Text = "studentName";
            // 
            // manageStudentLinkLabel
            // 
            this.manageStudentLinkLabel.AutoSize = true;
            this.manageStudentLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.manageStudentLinkLabel.Font = new System.Drawing.Font("Calibri", 20.25F);
            this.manageStudentLinkLabel.Location = new System.Drawing.Point(370, 12);
            this.manageStudentLinkLabel.Name = "manageStudentLinkLabel";
            this.manageStudentLinkLabel.Size = new System.Drawing.Size(194, 33);
            this.manageStudentLinkLabel.TabIndex = 1;
            this.manageStudentLinkLabel.TabStop = true;
            this.manageStudentLinkLabel.Text = "Manage student";
            this.manageStudentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.manageStudentLinkLabel_LinkClicked);
            // 
            // StudentListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.manageStudentLinkLabel);
            this.Controls.Add(this.studentNameLabel);
            this.Name = "StudentListItem";
            this.Size = new System.Drawing.Size(889, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label studentNameLabel;
        private System.Windows.Forms.LinkLabel manageStudentLinkLabel;
    }
}

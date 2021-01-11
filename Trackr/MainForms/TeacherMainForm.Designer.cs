namespace Trackr {
    partial class TeacherMainForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherMainForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.groupsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.tasksLinkLabel = new System.Windows.Forms.LinkLabel();
            this.studentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.contentsPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.selectionPanel.SuspendLayout();
            this.contentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Corbel", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(377, 9);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(228, 39);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "SAMPLE NAME";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Corbel Light", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome back,";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editAccountToolStripMenuItem
            // 
            this.editAccountToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.editAccountToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            this.editAccountToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.editAccountToolStripMenuItem.Text = "Edit account";
            this.editAccountToolStripMenuItem.Click += new System.EventHandler(this.editAccountMenuItemClick);
            // 
            // selectionPanel
            // 
            this.selectionPanel.Controls.Add(this.groupsLinkLabel);
            this.selectionPanel.Controls.Add(this.tasksLinkLabel);
            this.selectionPanel.Controls.Add(this.studentLinkLabel);
            this.selectionPanel.Controls.Add(this.label2);
            this.selectionPanel.Location = new System.Drawing.Point(13, 62);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(174, 376);
            this.selectionPanel.TabIndex = 5;
            // 
            // groupsLinkLabel
            // 
            this.groupsLinkLabel.AutoSize = true;
            this.groupsLinkLabel.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupsLinkLabel.Location = new System.Drawing.Point(11, 130);
            this.groupsLinkLabel.Name = "groupsLinkLabel";
            this.groupsLinkLabel.Size = new System.Drawing.Size(96, 33);
            this.groupsLinkLabel.TabIndex = 4;
            this.groupsLinkLabel.TabStop = true;
            this.groupsLinkLabel.Text = "Classes";
            this.groupsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.groupsLinkLabelClick);
            // 
            // tasksLinkLabel
            // 
            this.tasksLinkLabel.AutoSize = true;
            this.tasksLinkLabel.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tasksLinkLabel.Location = new System.Drawing.Point(11, 200);
            this.tasksLinkLabel.Name = "tasksLinkLabel";
            this.tasksLinkLabel.Size = new System.Drawing.Size(157, 33);
            this.tasksLinkLabel.TabIndex = 3;
            this.tasksLinkLabel.TabStop = true;
            this.tasksLinkLabel.Text = "Assignments";
            this.tasksLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.taskLinkLabelClick);
            // 
            // studentLinkLabel
            // 
            this.studentLinkLabel.AutoSize = true;
            this.studentLinkLabel.Font = new System.Drawing.Font("Corbel", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLinkLabel.Location = new System.Drawing.Point(11, 60);
            this.studentLinkLabel.Name = "studentLinkLabel";
            this.studentLinkLabel.Size = new System.Drawing.Size(114, 33);
            this.studentLinkLabel.TabIndex = 1;
            this.studentLinkLabel.TabStop = true;
            this.studentLinkLabel.Text = "Students";
            this.studentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.studentLinkLabelClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Manage...";
            // 
            // contentsPanel
            // 
            this.contentsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentsPanel.Controls.Add(this.label3);
            this.contentsPanel.Location = new System.Drawing.Point(193, 62);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(595, 376);
            this.contentsPanel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(580, 58);
            this.label3.TabIndex = 1;
            this.label3.Text = "Choose a tab on the left-hand side and the contents of that\r\ntab will move into t" +
    "his area.";
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.Transparent;
            this.refreshButton.BackgroundImage = global::Trackr.Properties.Resources.refreshButton;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(717, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 60);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButtonClick);
            // 
            // TeacherMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.contentsPanel);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeacherMainForm";
            this.Text = "TeacherMainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.contentsPanel.ResumeLayout(false);
            this.contentsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editAccountToolStripMenuItem;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel contentsPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel groupsLinkLabel;
        private System.Windows.Forms.LinkLabel tasksLinkLabel;
        private System.Windows.Forms.LinkLabel studentLinkLabel;
        private System.Windows.Forms.Button refreshButton;
    }
}
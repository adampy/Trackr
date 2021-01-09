namespace Trackr {
    partial class EditGroup {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGroup));
            this.label2 = new System.Windows.Forms.Label();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editGroupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 21.75F);
            this.label2.Location = new System.Drawing.Point(78, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "Edit group details";
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.subjectTextBox.Location = new System.Drawing.Point(99, 100);
            this.subjectTextBox.MaxLength = 30;
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(276, 26);
            this.subjectTextBox.TabIndex = 2;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.nameTextBox.Location = new System.Drawing.Point(99, 60);
            this.nameTextBox.MaxLength = 30;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(276, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name";
            // 
            // editGroupButton
            // 
            this.editGroupButton.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.editGroupButton.Location = new System.Drawing.Point(15, 137);
            this.editGroupButton.Name = "editGroupButton";
            this.editGroupButton.Size = new System.Drawing.Size(360, 38);
            this.editGroupButton.TabIndex = 3;
            this.editGroupButton.Text = "Save changes";
            this.editGroupButton.UseVisualStyleBackColor = true;
            this.editGroupButton.Click += new System.EventHandler(this.editGroupButton_Click);
            // 
            // EditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 187);
            this.Controls.Add(this.editGroupButton);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditGroup";
            this.Text = "Edit group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editGroupButton;
    }
}
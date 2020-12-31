namespace Trackr {
    partial class StudentGetPassword {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentGetPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel Light", 14.25F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "You have currently not got a password, please set a new one.\r\n";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(11, 93);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.Size = new System.Drawing.Size(293, 30);
            this.passwordTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(13, 162);
            this.confirmPasswordTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.PasswordChar = '•';
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(293, 30);
            this.confirmPasswordTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Confirm Password";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(13, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(293, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "Set new password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StudentGetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudentGetPassword";
            this.Text = "Trackr - MV16 Homework Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
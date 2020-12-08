namespace Trackr
{
    partial class AuthenticationScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationScreen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.studentSignInLabel = new System.Windows.Forms.Label();
            this.teacherSignInLabel = new System.Windows.Forms.Label();
            this.signInPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.signInMainLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.signInPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trackr";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel Light", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "MV16 Homework Tracker";
            // 
            // signInButton
            // 
            this.signInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signInButton.Font = new System.Drawing.Font("Corbel Light", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.Location = new System.Drawing.Point(205, 148);
            this.signInButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(351, 114);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Sign-in";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registerButton.Font = new System.Drawing.Font("Corbel Light", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.Location = new System.Drawing.Point(205, 270);
            this.registerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(351, 114);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.AccessibleName = "";
            this.mainPanel.Controls.Add(this.signInButton);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.registerButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Location = new System.Drawing.Point(12, 12);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(757, 432);
            this.mainPanel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(717, 59);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sign-in as a                   or a                  ?";
            this.label3.Click += new System.EventHandler(this.previousPanel);
            // 
            // studentSignInLabel
            // 
            this.studentSignInLabel.AutoSize = true;
            this.studentSignInLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentSignInLabel.Font = new System.Drawing.Font("Corbel", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentSignInLabel.Location = new System.Drawing.Point(259, 363);
            this.studentSignInLabel.Name = "studentSignInLabel";
            this.studentSignInLabel.Size = new System.Drawing.Size(186, 59);
            this.studentSignInLabel.TabIndex = 1;
            this.studentSignInLabel.Text = "student";
            this.studentSignInLabel.Click += new System.EventHandler(this.studentSignInClick);
            // 
            // teacherSignInLabel
            // 
            this.teacherSignInLabel.AutoSize = true;
            this.teacherSignInLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.teacherSignInLabel.Font = new System.Drawing.Font("Corbel", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherSignInLabel.Location = new System.Drawing.Point(542, 363);
            this.teacherSignInLabel.Name = "teacherSignInLabel";
            this.teacherSignInLabel.Size = new System.Drawing.Size(183, 59);
            this.teacherSignInLabel.TabIndex = 2;
            this.teacherSignInLabel.Text = "teacher";
            this.teacherSignInLabel.Click += new System.EventHandler(this.teacherSignInClick);
            // 
            // signInPanel
            // 
            this.signInPanel.Controls.Add(this.passwordTextBox);
            this.signInPanel.Controls.Add(this.usernameTextBox);
            this.signInPanel.Controls.Add(this.label5);
            this.signInPanel.Controls.Add(this.label4);
            this.signInPanel.Controls.Add(this.signInMainLabel);
            this.signInPanel.Controls.Add(this.backButton);
            this.signInPanel.Controls.Add(this.teacherSignInLabel);
            this.signInPanel.Controls.Add(this.studentSignInLabel);
            this.signInPanel.Controls.Add(this.label3);
            this.signInPanel.Location = new System.Drawing.Point(10, 11);
            this.signInPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(759, 433);
            this.signInPanel.TabIndex = 4;
            // 
            // backButton
            // 
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(13, 15);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(67, 62);
            this.backButton.TabIndex = 3;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.previousPanel);
            // 
            // signInMainLabel
            // 
            this.signInMainLabel.AutoSize = true;
            this.signInMainLabel.Font = new System.Drawing.Font("Corbel", 28.2F);
            this.signInMainLabel.Location = new System.Drawing.Point(277, 6);
            this.signInMainLabel.Name = "signInMainLabel";
            this.signInMainLabel.Size = new System.Drawing.Size(171, 59);
            this.signInMainLabel.TabIndex = 4;
            this.signInMainLabel.Text = "Sign in!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 37);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Corbel", 18F);
            this.usernameTextBox.Location = new System.Drawing.Point(40, 148);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(669, 44);
            this.usernameTextBox.TabIndex = 7;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Corbel", 18F);
            this.passwordTextBox.Location = new System.Drawing.Point(40, 266);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.Size = new System.Drawing.Size(669, 44);
            this.passwordTextBox.TabIndex = 8;
            // 
            // AuthenticationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 455);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.signInPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(801, 502);
            this.MinimumSize = new System.Drawing.Size(801, 502);
            this.Name = "AuthenticationScreen";
            this.Text = "Trackr - MV16 Homework Tracker";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label studentSignInLabel;
        private System.Windows.Forms.Label teacherSignInLabel;
        private System.Windows.Forms.Panel signInPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label signInMainLabel;
    }
}


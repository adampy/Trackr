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
            this.signInPanel = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.studentSignInLinkLabel = new System.Windows.Forms.LinkLabel();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.signInMainLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.registrationPanel = new System.Windows.Forms.Panel();
            this.usernameAvaliableButton = new System.Windows.Forms.Button();
            this.usernameAvaliableLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.adminCodeTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.usernameRegistrationTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.passwordMatchingLabel = new System.Windows.Forms.Label();
            this.teacherRegisterButton = new System.Windows.Forms.Button();
            this.confirmPasswordRegistrationTextbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.passwordRegistrationTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.forenameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.signInPanel.SuspendLayout();
            this.registrationPanel.SuspendLayout();
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
            this.signInButton.Click += new System.EventHandler(this.signInClick);
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
            this.registerButton.Click += new System.EventHandler(this.registerButtonClick);
            // 
            // mainPanel
            // 
            this.mainPanel.AccessibleName = "";
            this.mainPanel.Controls.Add(this.signInButton);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.registerButton);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Location = new System.Drawing.Point(11, 10);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(757, 441);
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
            // signInPanel
            // 
            this.signInPanel.Controls.Add(this.linkLabel1);
            this.signInPanel.Controls.Add(this.studentSignInLinkLabel);
            this.signInPanel.Controls.Add(this.passwordTextBox);
            this.signInPanel.Controls.Add(this.usernameTextBox);
            this.signInPanel.Controls.Add(this.label5);
            this.signInPanel.Controls.Add(this.label4);
            this.signInPanel.Controls.Add(this.signInMainLabel);
            this.signInPanel.Controls.Add(this.label3);
            this.signInPanel.Location = new System.Drawing.Point(9, 7);
            this.signInPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInPanel.Name = "signInPanel";
            this.signInPanel.Size = new System.Drawing.Size(759, 443);
            this.signInPanel.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Corbel", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.linkLabel1.Location = new System.Drawing.Point(541, 363);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(183, 59);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "teacher";
            this.linkLabel1.Click += new System.EventHandler(this.teacherSignInClick);
            // 
            // studentSignInLinkLabel
            // 
            this.studentSignInLinkLabel.AutoSize = true;
            this.studentSignInLinkLabel.Font = new System.Drawing.Font("Corbel", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.studentSignInLinkLabel.Location = new System.Drawing.Point(259, 363);
            this.studentSignInLinkLabel.Name = "studentSignInLinkLabel";
            this.studentSignInLinkLabel.Size = new System.Drawing.Size(186, 59);
            this.studentSignInLinkLabel.TabIndex = 9;
            this.studentSignInLinkLabel.TabStop = true;
            this.studentSignInLinkLabel.Text = "student";
            this.studentSignInLinkLabel.Click += new System.EventHandler(this.studentSignInClick);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(40, 223);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '•';
            this.passwordTextBox.Size = new System.Drawing.Size(669, 36);
            this.passwordTextBox.TabIndex = 8;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(40, 103);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(669, 36);
            this.usernameTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 29);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Username";
            // 
            // signInMainLabel
            // 
            this.signInMainLabel.AutoSize = true;
            this.signInMainLabel.Font = new System.Drawing.Font("Corbel", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInMainLabel.Location = new System.Drawing.Point(293, 6);
            this.signInMainLabel.Name = "signInMainLabel";
            this.signInMainLabel.Size = new System.Drawing.Size(156, 53);
            this.signInMainLabel.TabIndex = 4;
            this.signInMainLabel.Text = "Sign in!";
            // 
            // backButton
            // 
            this.backButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backButton.BackgroundImage")));
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Location = new System.Drawing.Point(13, 14);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(67, 62);
            this.backButton.TabIndex = 3;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.previousPanel);
            // 
            // registrationPanel
            // 
            this.registrationPanel.Controls.Add(this.usernameAvaliableButton);
            this.registrationPanel.Controls.Add(this.usernameAvaliableLabel);
            this.registrationPanel.Controls.Add(this.label13);
            this.registrationPanel.Controls.Add(this.adminCodeTextBox);
            this.registrationPanel.Controls.Add(this.titleTextBox);
            this.registrationPanel.Controls.Add(this.label12);
            this.registrationPanel.Controls.Add(this.usernameRegistrationTextBox);
            this.registrationPanel.Controls.Add(this.label11);
            this.registrationPanel.Controls.Add(this.passwordMatchingLabel);
            this.registrationPanel.Controls.Add(this.teacherRegisterButton);
            this.registrationPanel.Controls.Add(this.confirmPasswordRegistrationTextbox);
            this.registrationPanel.Controls.Add(this.label10);
            this.registrationPanel.Controls.Add(this.passwordRegistrationTextBox);
            this.registrationPanel.Controls.Add(this.label9);
            this.registrationPanel.Controls.Add(this.surnameTextBox);
            this.registrationPanel.Controls.Add(this.forenameTextBox);
            this.registrationPanel.Controls.Add(this.label6);
            this.registrationPanel.Controls.Add(this.label7);
            this.registrationPanel.Controls.Add(this.label8);
            this.registrationPanel.Location = new System.Drawing.Point(12, 11);
            this.registrationPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.registrationPanel.Name = "registrationPanel";
            this.registrationPanel.Size = new System.Drawing.Size(759, 433);
            this.registrationPanel.TabIndex = 9;
            // 
            // usernameAvaliableButton
            // 
            this.usernameAvaliableButton.Font = new System.Drawing.Font("Corbel", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameAvaliableButton.Location = new System.Drawing.Point(560, 191);
            this.usernameAvaliableButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameAvaliableButton.Name = "usernameAvaliableButton";
            this.usernameAvaliableButton.Size = new System.Drawing.Size(151, 31);
            this.usernameAvaliableButton.TabIndex = 22;
            this.usernameAvaliableButton.Text = "Check avaliability";
            this.usernameAvaliableButton.UseVisualStyleBackColor = true;
            this.usernameAvaliableButton.Click += new System.EventHandler(this.usernameAvaliableButtonClick);
            // 
            // usernameAvaliableLabel
            // 
            this.usernameAvaliableLabel.AutoSize = true;
            this.usernameAvaliableLabel.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameAvaliableLabel.ForeColor = System.Drawing.Color.Green;
            this.usernameAvaliableLabel.Location = new System.Drawing.Point(129, 174);
            this.usernameAvaliableLabel.Name = "usernameAvaliableLabel";
            this.usernameAvaliableLabel.Size = new System.Drawing.Size(126, 17);
            this.usernameAvaliableLabel.TabIndex = 21;
            this.usernameAvaliableLabel.Text = "Username avaliable!";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(597, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 23);
            this.label13.TabIndex = 19;
            this.label13.Text = "Admin code";
            // 
            // adminCodeTextBox
            // 
            this.adminCodeTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminCodeTextBox.Location = new System.Drawing.Point(597, 33);
            this.adminCodeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminCodeTextBox.Name = "adminCodeTextBox";
            this.adminCodeTextBox.Size = new System.Drawing.Size(109, 29);
            this.adminCodeTextBox.TabIndex = 13;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(37, 245);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(669, 29);
            this.titleTextBox.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(33, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 23);
            this.label12.TabIndex = 17;
            this.label12.Text = "Title";
            // 
            // usernameRegistrationTextBox
            // 
            this.usernameRegistrationTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameRegistrationTextBox.Location = new System.Drawing.Point(37, 191);
            this.usernameRegistrationTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameRegistrationTextBox.Name = "usernameRegistrationTextBox";
            this.usernameRegistrationTextBox.Size = new System.Drawing.Size(516, 29);
            this.usernameRegistrationTextBox.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Username";
            // 
            // passwordMatchingLabel
            // 
            this.passwordMatchingLabel.AutoSize = true;
            this.passwordMatchingLabel.Font = new System.Drawing.Font("Corbel", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordMatchingLabel.Location = new System.Drawing.Point(193, 334);
            this.passwordMatchingLabel.Name = "passwordMatchingLabel";
            this.passwordMatchingLabel.Size = new System.Drawing.Size(115, 17);
            this.passwordMatchingLabel.TabIndex = 14;
            this.passwordMatchingLabel.Text = "Passwords match!";
            // 
            // teacherRegisterButton
            // 
            this.teacherRegisterButton.Font = new System.Drawing.Font("Corbel Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherRegisterButton.Location = new System.Drawing.Point(37, 388);
            this.teacherRegisterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.teacherRegisterButton.Name = "teacherRegisterButton";
            this.teacherRegisterButton.Size = new System.Drawing.Size(669, 46);
            this.teacherRegisterButton.TabIndex = 13;
            this.teacherRegisterButton.Text = "Register now!";
            this.teacherRegisterButton.UseVisualStyleBackColor = true;
            this.teacherRegisterButton.Click += new System.EventHandler(this.teacherRegisterButtonCick);
            // 
            // confirmPasswordRegistrationTextbox
            // 
            this.confirmPasswordRegistrationTextbox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordRegistrationTextbox.Location = new System.Drawing.Point(37, 351);
            this.confirmPasswordRegistrationTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmPasswordRegistrationTextbox.Name = "confirmPasswordRegistrationTextbox";
            this.confirmPasswordRegistrationTextbox.PasswordChar = '•';
            this.confirmPasswordRegistrationTextbox.Size = new System.Drawing.Size(669, 29);
            this.confirmPasswordRegistrationTextbox.TabIndex = 12;
            this.confirmPasswordRegistrationTextbox.TextChanged += new System.EventHandler(this.passwordChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(33, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "Confirm password";
            // 
            // passwordRegistrationTextBox
            // 
            this.passwordRegistrationTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRegistrationTextBox.Location = new System.Drawing.Point(37, 298);
            this.passwordRegistrationTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordRegistrationTextBox.Name = "passwordRegistrationTextBox";
            this.passwordRegistrationTextBox.PasswordChar = '•';
            this.passwordRegistrationTextBox.Size = new System.Drawing.Size(669, 29);
            this.passwordRegistrationTextBox.TabIndex = 11;
            this.passwordRegistrationTextBox.TextChanged += new System.EventHandler(this.passwordChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(33, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 23);
            this.label9.TabIndex = 9;
            this.label9.Text = "Password";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTextBox.Location = new System.Drawing.Point(37, 139);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(669, 29);
            this.surnameTextBox.TabIndex = 8;
            // 
            // forenameTextBox
            // 
            this.forenameTextBox.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forenameTextBox.Location = new System.Drawing.Point(37, 89);
            this.forenameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.forenameTextBox.Name = "forenameTextBox";
            this.forenameTextBox.Size = new System.Drawing.Size(669, 29);
            this.forenameTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Surname";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Forename";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Corbel", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(81, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(474, 53);
            this.label8.TabIndex = 4;
            this.label8.Text = "Teacher registration form";
            // 
            // AuthenticationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 452);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.registrationPanel);
            this.Controls.Add(this.signInPanel);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(801, 499);
            this.MinimumSize = new System.Drawing.Size(801, 499);
            this.Name = "AuthenticationScreen";
            this.Text = "Trackr - MV16 Homework Tracker";
            this.Load += new System.EventHandler(this.authScreenLoad);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.signInPanel.ResumeLayout(false);
            this.signInPanel.PerformLayout();
            this.registrationPanel.ResumeLayout(false);
            this.registrationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel signInPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label signInMainLabel;
        private System.Windows.Forms.Panel registrationPanel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox forenameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel studentSignInLinkLabel;
        private System.Windows.Forms.Button teacherRegisterButton;
        private System.Windows.Forms.TextBox confirmPasswordRegistrationTextbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox passwordRegistrationTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label passwordMatchingLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox usernameRegistrationTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox adminCodeTextBox;
        private System.Windows.Forms.Button usernameAvaliableButton;
        private System.Windows.Forms.Label usernameAvaliableLabel;
    }
}


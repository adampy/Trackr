namespace Trackr {
    partial class EditAccount {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordTextbox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameCheckBox = new System.Windows.Forms.CheckBox();
            this.passwordTextbox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.submitChangedButton = new System.Windows.Forms.Button();
            this.passwordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit your account!";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.usernameTextbox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.usernameTextbox.Location = new System.Drawing.Point(156, 95);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(241, 26);
            this.usernameTextbox.TabIndex = 2;
            // 
            // passwordTextbox1
            // 
            this.passwordTextbox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.passwordTextbox1.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.passwordTextbox1.Location = new System.Drawing.Point(156, 170);
            this.passwordTextbox1.Name = "passwordTextbox1";
            this.passwordTextbox1.PasswordChar = '•';
            this.passwordTextbox1.Size = new System.Drawing.Size(241, 26);
            this.passwordTextbox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // usernameCheckBox
            // 
            this.usernameCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usernameCheckBox.AutoSize = true;
            this.usernameCheckBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.usernameCheckBox.Location = new System.Drawing.Point(135, 57);
            this.usernameCheckBox.Name = "usernameCheckBox";
            this.usernameCheckBox.Size = new System.Drawing.Size(118, 22);
            this.usernameCheckBox.TabIndex = 4;
            this.usernameCheckBox.Text = "New username";
            this.usernameCheckBox.UseVisualStyleBackColor = true;
            this.usernameCheckBox.CheckedChanged += new System.EventHandler(this.stateChanged);
            // 
            // passwordTextbox2
            // 
            this.passwordTextbox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.passwordTextbox2.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.passwordTextbox2.Location = new System.Drawing.Point(156, 218);
            this.passwordTextbox2.Name = "passwordTextbox2";
            this.passwordTextbox2.PasswordChar = '•';
            this.passwordTextbox2.Size = new System.Drawing.Size(241, 26);
            this.passwordTextbox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Confirm Password";
            // 
            // submitChangedButton
            // 
            this.submitChangedButton.Font = new System.Drawing.Font("Corbel Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitChangedButton.Location = new System.Drawing.Point(15, 256);
            this.submitChangedButton.Name = "submitChangedButton";
            this.submitChangedButton.Size = new System.Drawing.Size(382, 55);
            this.submitChangedButton.TabIndex = 9;
            this.submitChangedButton.Text = "Submit your changes!";
            this.submitChangedButton.UseVisualStyleBackColor = true;
            this.submitChangedButton.Click += new System.EventHandler(this.submitChangedClick);
            // 
            // passwordCheckBox
            // 
            this.passwordCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordCheckBox.AutoSize = true;
            this.passwordCheckBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.passwordCheckBox.Location = new System.Drawing.Point(135, 135);
            this.passwordCheckBox.Name = "passwordCheckBox";
            this.passwordCheckBox.Size = new System.Drawing.Size(117, 22);
            this.passwordCheckBox.TabIndex = 4;
            this.passwordCheckBox.Text = "New password";
            this.passwordCheckBox.UseVisualStyleBackColor = true;
            this.passwordCheckBox.CheckedChanged += new System.EventHandler(this.stateChanged);
            // 
            // StudentEditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 323);
            this.Controls.Add(this.submitChangedButton);
            this.Controls.Add(this.passwordTextbox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passwordCheckBox);
            this.Controls.Add(this.usernameCheckBox);
            this.Controls.Add(this.passwordTextbox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StudentEditAccount";
            this.Text = "Trackr - Edit account";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditAccount_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox usernameCheckBox;
        private System.Windows.Forms.TextBox passwordTextbox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button submitChangedButton;
        private System.Windows.Forms.CheckBox passwordCheckBox;
    }
}
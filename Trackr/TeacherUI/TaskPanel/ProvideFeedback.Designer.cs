namespace Trackr {
    partial class ProvideFeedback {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvideFeedback));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.studentComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.feedbackTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.maxScoreLabel = new System.Windows.Forms.Label();
            this.sendFeedbackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 21.75F);
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provide feedback";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SAMPLETEXT";
            // 
            // studentComboBox
            // 
            this.studentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.studentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.studentComboBox.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.studentComboBox.FormattingEnabled = true;
            this.studentComboBox.Location = new System.Drawing.Point(119, 77);
            this.studentComboBox.Name = "studentComboBox";
            this.studentComboBox.Size = new System.Drawing.Size(513, 34);
            this.studentComboBox.TabIndex = 2;
            this.studentComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Student";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Feedback";
            // 
            // feedbackTextBox
            // 
            this.feedbackTextBox.AcceptsReturn = true;
            this.feedbackTextBox.AcceptsTab = true;
            this.feedbackTextBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.feedbackTextBox.Location = new System.Drawing.Point(119, 147);
            this.feedbackTextBox.MaxLength = 511;
            this.feedbackTextBox.Multiline = true;
            this.feedbackTextBox.Name = "feedbackTextBox";
            this.feedbackTextBox.Size = new System.Drawing.Size(513, 112);
            this.feedbackTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.label5.Location = new System.Drawing.Point(12, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "Score";
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.scoreTextBox.Location = new System.Drawing.Point(119, 274);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(86, 26);
            this.scoreTextBox.TabIndex = 7;
            // 
            // maxScoreLabel
            // 
            this.maxScoreLabel.AutoSize = true;
            this.maxScoreLabel.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.maxScoreLabel.Location = new System.Drawing.Point(211, 274);
            this.maxScoreLabel.Name = "maxScoreLabel";
            this.maxScoreLabel.Size = new System.Drawing.Size(33, 26);
            this.maxScoreLabel.TabIndex = 8;
            this.maxScoreLabel.Text = "/N";
            // 
            // sendFeedbackButton
            // 
            this.sendFeedbackButton.Font = new System.Drawing.Font("Corbel", 15.75F);
            this.sendFeedbackButton.Location = new System.Drawing.Point(12, 322);
            this.sendFeedbackButton.Name = "sendFeedbackButton";
            this.sendFeedbackButton.Size = new System.Drawing.Size(619, 39);
            this.sendFeedbackButton.TabIndex = 9;
            this.sendFeedbackButton.Text = "Send feedback";
            this.sendFeedbackButton.UseVisualStyleBackColor = true;
            this.sendFeedbackButton.Click += new System.EventHandler(this.sendFeedbackButtonClick);
            // 
            // ProvideFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 373);
            this.Controls.Add(this.sendFeedbackButton);
            this.Controls.Add(this.maxScoreLabel);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.feedbackTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.studentComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProvideFeedback";
            this.Text = "Trackr - Provide feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox studentComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox feedbackTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scoreTextBox;
        private System.Windows.Forms.Label maxScoreLabel;
        private System.Windows.Forms.Button sendFeedbackButton;
    }
}
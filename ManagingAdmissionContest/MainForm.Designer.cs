namespace ManagingAdmissionContest
{
    partial class MainForm
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
            this.formButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.publishResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.budgetFinanced = new System.Windows.Forms.TextBox();
            this.feePayer = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formButton
            // 
            this.formButton.Location = new System.Drawing.Point(356, 90);
            this.formButton.Margin = new System.Windows.Forms.Padding(2);
            this.formButton.Name = "formButton";
            this.formButton.Size = new System.Drawing.Size(56, 19);
            this.formButton.TabIndex = 0;
            this.formButton.Text = "Form";
            this.formButton.UseVisualStyleBackColor = true;
            this.formButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 1;
            this.button2.Text = "File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // publishResults
            // 
            this.publishResults.Location = new System.Drawing.Point(58, 89);
            this.publishResults.Name = "publishResults";
            this.publishResults.Size = new System.Drawing.Size(96, 19);
            this.publishResults.TabIndex = 2;
            this.publishResults.Text = "Publish Results";
            this.publishResults.UseVisualStyleBackColor = true;
            this.publishResults.Click += new System.EventHandler(this.publishResults_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Budget-financed:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.feePayer);
            this.groupBox1.Controls.Add(this.budgetFinanced);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.publishResults);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(291, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Limits for results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fee-payer:";
            // 
            // budgetFinanced
            // 
            this.budgetFinanced.Location = new System.Drawing.Point(100, 23);
            this.budgetFinanced.Name = "budgetFinanced";
            this.budgetFinanced.Size = new System.Drawing.Size(54, 20);
            this.budgetFinanced.TabIndex = 5;
            this.budgetFinanced.TextChanged += new System.EventHandler(this.budgetFinanced_TextChanged);
            // 
            // feePayer
            // 
            this.feePayer.Location = new System.Drawing.Point(100, 52);
            this.feePayer.Name = "feePayer";
            this.feePayer.Size = new System.Drawing.Size(54, 20);
            this.feePayer.TabIndex = 6;
            this.feePayer.TextChanged += new System.EventHandler(this.feePayer_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.formButton);
            this.Name = "MainForm";
            this.Text = "Managing Faculty Admission Contest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button formButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button publishResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox feePayer;
        private System.Windows.Forms.TextBox budgetFinanced;
        private System.Windows.Forms.Label label2;

    }
}


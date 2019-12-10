namespace MainScreen
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGroceries = new System.Windows.Forms.ListBox();
            this.lbNonpaid = new System.Windows.Forms.ListBox();
            this.lbComplaints = new System.Windows.Forms.ListBox();
            this.lbStudentClean = new System.Windows.Forms.Label();
            this.lbStudentGarbage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cleaner this week:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(12, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Garbage disposal this week:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(431, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Groceries:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(431, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Complaints:";
            // 
            // lbGroceries
            // 
            this.lbGroceries.FormattingEnabled = true;
            this.lbGroceries.Location = new System.Drawing.Point(436, 66);
            this.lbGroceries.Name = "lbGroceries";
            this.lbGroceries.Size = new System.Drawing.Size(517, 225);
            this.lbGroceries.TabIndex = 4;
            this.lbGroceries.SelectedIndexChanged += new System.EventHandler(this.x);
            // 
            // lbNonpaid
            // 
            this.lbNonpaid.FormattingEnabled = true;
            this.lbNonpaid.Location = new System.Drawing.Point(959, 66);
            this.lbNonpaid.Name = "lbNonpaid";
            this.lbNonpaid.Size = new System.Drawing.Size(182, 225);
            this.lbNonpaid.TabIndex = 5;
            // 
            // lbComplaints
            // 
            this.lbComplaints.FormattingEnabled = true;
            this.lbComplaints.Location = new System.Drawing.Point(436, 329);
            this.lbComplaints.Name = "lbComplaints";
            this.lbComplaints.Size = new System.Drawing.Size(705, 251);
            this.lbComplaints.TabIndex = 6;
            // 
            // lbStudentClean
            // 
            this.lbStudentClean.AutoSize = true;
            this.lbStudentClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbStudentClean.Location = new System.Drawing.Point(132, 163);
            this.lbStudentClean.Name = "lbStudentClean";
            this.lbStudentClean.Size = new System.Drawing.Size(71, 26);
            this.lbStudentClean.TabIndex = 7;
            this.lbStudentClean.Text = "Name";
            // 
            // lbStudentGarbage
            // 
            this.lbStudentGarbage.AutoSize = true;
            this.lbStudentGarbage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbStudentGarbage.Location = new System.Drawing.Point(132, 454);
            this.lbStudentGarbage.Name = "lbStudentGarbage";
            this.lbStudentGarbage.Size = new System.Drawing.Size(71, 26);
            this.lbStudentGarbage.TabIndex = 8;
            this.lbStudentGarbage.Text = "Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 594);
            this.Controls.Add(this.lbStudentGarbage);
            this.Controls.Add(this.lbStudentClean);
            this.Controls.Add(this.lbComplaints);
            this.Controls.Add(this.lbNonpaid);
            this.Controls.Add(this.lbGroceries);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbGroceries;
        private System.Windows.Forms.ListBox lbNonpaid;
        private System.Windows.Forms.ListBox lbComplaints;
        private System.Windows.Forms.Label lbStudentClean;
        private System.Windows.Forms.Label lbStudentGarbage;
    }
}


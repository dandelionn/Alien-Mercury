namespace SharedDoc
{
    partial class ReplaceDialog
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
            this.txtBoxFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxReplace = new System.Windows.Forms.TextBox();
            this.buttonFindAndReplace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxFind
            // 
            this.txtBoxFind.Location = new System.Drawing.Point(26, 31);
            this.txtBoxFind.Name = "txtBoxFind";
            this.txtBoxFind.Size = new System.Drawing.Size(291, 20);
            this.txtBoxFind.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text to find";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Replace with";
            // 
            // txtBoxReplace
            // 
            this.txtBoxReplace.Location = new System.Drawing.Point(26, 91);
            this.txtBoxReplace.Name = "txtBoxReplace";
            this.txtBoxReplace.Size = new System.Drawing.Size(291, 20);
            this.txtBoxReplace.TabIndex = 3;
            // 
            // buttonFindAndReplace
            // 
            this.buttonFindAndReplace.Location = new System.Drawing.Point(89, 125);
            this.buttonFindAndReplace.Name = "buttonFindAndReplace";
            this.buttonFindAndReplace.Size = new System.Drawing.Size(163, 23);
            this.buttonFindAndReplace.TabIndex = 4;
            this.buttonFindAndReplace.Text = "Find and replace";
            this.buttonFindAndReplace.UseVisualStyleBackColor = true;
            this.buttonFindAndReplace.Click += new System.EventHandler(this.buttonFindAndReplace_Click);
            // 
            // ReplaceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(345, 160);
            this.Controls.Add(this.buttonFindAndReplace);
            this.Controls.Add(this.txtBoxReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Replace";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxReplace;
        private System.Windows.Forms.Button buttonFindAndReplace;
    }
}
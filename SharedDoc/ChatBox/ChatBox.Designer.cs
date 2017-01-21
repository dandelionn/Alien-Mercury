﻿namespace ChatBox
{
    partial class ChatBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.editMessageBox = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.messageBox = new MessageBox.MessageBox();
            this.SuspendLayout();
            // 
            // editMessageBox
            // 
            this.editMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editMessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.editMessageBox.Location = new System.Drawing.Point(0, 371);
            this.editMessageBox.Name = "editMessageBox";
            this.editMessageBox.Size = new System.Drawing.Size(384, 76);
            this.editMessageBox.TabIndex = 1;
            this.editMessageBox.Text = "";
            this.editMessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editMessageBox_KeyDown);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSend.Location = new System.Drawing.Point(384, 371);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(43, 76);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.Location = new System.Drawing.Point(0, 0);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(427, 371);
            this.messageBox.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.editMessageBox);
            this.Controls.Add(this.messageBox);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(427, 447);
            this.ResumeLayout(false);

        }

        #endregion

        private MessageBox.MessageBox messageBox;
        private System.Windows.Forms.RichTextBox editMessageBox;
        private System.Windows.Forms.Button buttonSend;
    }
}

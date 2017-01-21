namespace SharedDoc
{
    partial class SemaphoreBar
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
            this.buttonColor = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonLock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonColor.Enabled = false;
            this.buttonColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(3, 137);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(34, 84);
            this.buttonColor.TabIndex = 3;
            this.buttonColor.UseVisualStyleBackColor = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConnect.BackgroundImage = global::SharedDoc.Properties.Resources.connect;
            this.buttonConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConnect.Location = new System.Drawing.Point(3, 293);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(35, 79);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.BackgroundImage = global::SharedDoc.Properties.Resources.Unlock;
            this.buttonUnlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUnlock.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonUnlock.FlatAppearance.BorderSize = 0;
            this.buttonUnlock.Location = new System.Drawing.Point(3, 80);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(35, 37);
            this.buttonUnlock.TabIndex = 2;
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // buttonLock
            // 
            this.buttonLock.BackgroundImage = global::SharedDoc.Properties.Resources.Lock;
            this.buttonLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLock.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonLock.FlatAppearance.BorderSize = 0;
            this.buttonLock.Location = new System.Drawing.Point(3, 25);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(35, 37);
            this.buttonLock.TabIndex = 1;
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // SemaphoreBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.buttonLock);
            this.Name = "SemaphoreBar";
            this.Size = new System.Drawing.Size(40, 444);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button buttonConnect;
    }
}

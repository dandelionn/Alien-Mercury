namespace CodeEditor
{
    partial class CodeEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditor));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.advancedVScrollbar1 = new AdvancedVScrollbar.AdvancedVScrollbar();
            this.advancedHScrollbar1 = new AdvancedHScrollbar.AdvancedHScrollbar();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(136, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(289, 334);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.HScroll += new System.EventHandler(this.richTextBox1_HScroll);
            this.richTextBox1.VScroll += new System.EventHandler(this.richTextBox1_VScroll);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(411, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 17);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox2.BackColor = System.Drawing.Color.MediumPurple;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox2.Location = new System.Drawing.Point(3, 0);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox2.Size = new System.Drawing.Size(37, 331);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            this.richTextBox2.WordWrap = false;
            this.richTextBox2.VScroll += new System.EventHandler(this.richTextBox2_VScroll);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox3.Location = new System.Drawing.Point(22, -1);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox3.Size = new System.Drawing.Size(130, 335);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            this.richTextBox3.WordWrap = false;
            this.richTextBox3.VScroll += new System.EventHandler(this.richTextBox3_VScroll);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(3, 310);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 24);
            this.textBox1.TabIndex = 5;
            // 
            // advancedVScrollbar1
            // 
            this.advancedVScrollbar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedVScrollbar1.ChannelBorderColor = System.Drawing.Color.Empty;
            this.advancedVScrollbar1.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.advancedVScrollbar1.DownArrow = ((System.Drawing.Image)(resources.GetObject("advancedVScrollbar1.DownArrow")));
            this.advancedVScrollbar1.Location = new System.Drawing.Point(401, -1);
            this.advancedVScrollbar1.Maximum = 0;
            this.advancedVScrollbar1.Minimum = 0;
            this.advancedVScrollbar1.Name = "advancedVScrollbar1";
            this.advancedVScrollbar1.Size = new System.Drawing.Size(24, 312);
            this.advancedVScrollbar1.TabIndex = 7;
            this.advancedVScrollbar1.ThumbBottom = null;
            this.advancedVScrollbar1.ThumbBottomSpan = null;
            this.advancedVScrollbar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.advancedVScrollbar1.ThumbMiddle = null;
            this.advancedVScrollbar1.ThumbPosition = 0;
            this.advancedVScrollbar1.ThumbTop = null;
            this.advancedVScrollbar1.ThumbTopSpan = null;
            this.advancedVScrollbar1.UpArrow = ((System.Drawing.Image)(resources.GetObject("advancedVScrollbar1.UpArrow")));
            // 
            // advancedHScrollbar1
            // 
            this.advancedHScrollbar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedHScrollbar1.ChannelBorderColor = System.Drawing.Color.Empty;
            this.advancedHScrollbar1.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.advancedHScrollbar1.LeftArrow = ((System.Drawing.Image)(resources.GetObject("advancedHScrollbar1.LeftArrow")));
            this.advancedHScrollbar1.Location = new System.Drawing.Point(136, 310);
            this.advancedHScrollbar1.Maximum = 0;
            this.advancedHScrollbar1.Minimum = 0;
            this.advancedHScrollbar1.Name = "advancedHScrollbar1";
            this.advancedHScrollbar1.RightArrow = ((System.Drawing.Image)(resources.GetObject("advancedHScrollbar1.RightArrow")));
            this.advancedHScrollbar1.Size = new System.Drawing.Size(269, 24);
            this.advancedHScrollbar1.TabIndex = 8;
            this.advancedHScrollbar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.advancedHScrollbar1.ThumbLeft = null;
            this.advancedHScrollbar1.ThumbLeftSpan = null;
            this.advancedHScrollbar1.ThumbMiddle = null;
            this.advancedHScrollbar1.ThumbPosition = 0;
            this.advancedHScrollbar1.ThumbRight = null;
            this.advancedHScrollbar1.ThumbRightSpan = null;
            // 
            // CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advancedVScrollbar1);
            this.Controls.Add(this.advancedHScrollbar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Name = "CodeEditor";
            this.Size = new System.Drawing.Size(425, 334);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.TextBox textBox1;
        private AdvancedVScrollbar.AdvancedVScrollbar advancedVScrollbar1;
        private AdvancedHScrollbar.AdvancedHScrollbar advancedHScrollbar1;
    }
}

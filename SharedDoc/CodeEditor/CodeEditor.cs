using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeEditor
{  
    public partial class CodeEditor: UserControl
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        ScrollingManager _scrollingManager;

        public CodeEditor()
        {
            InitializeComponent();
            PrepareComponents();

            this.AllowDrop = true;
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(this.richTextBox1_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(this.richTextBox1_DragDrop);
            this.DragEnter += new DragEventHandler(this.richTextBox1_DragEnter);
            this.DragDrop += new DragEventHandler(this.richTextBox1_DragDrop);
        }

        public RichTextBox GetEditor()
        {
            return richTextBox1;
        }

        public List<RichTextBox> GetEditableComponents()
        {
            return new List<RichTextBox>() { richTextBox1, richTextBox2, richTextBox3 };
        }

        private void PrepareComponents()
        {
            LayoutAdjuster layoutAdjuster = new LayoutAdjuster();
            layoutAdjuster.SetRichTextBoxes(richTextBox1, richTextBox2, richTextBox3);
            layoutAdjuster.SetScrollbars(advancedHScrollbar1, advancedVScrollbar1);
            layoutAdjuster.SetTextBox(textBox1);
            layoutAdjuster.SetButton(button1);

            layoutAdjuster.Adjust();

            _scrollingManager = new ScrollingManager();
            _scrollingManager.SetRichTextBoxes(richTextBox1, richTextBox2, richTextBox3);
            _scrollingManager.SetScrollbars(advancedHScrollbar1, advancedVScrollbar1);

            advancedHScrollbar1.RegisterHandle(richTextBox1.Handle);
            advancedHScrollbar1.RegisterRichTextBoxes(richTextBox1);

            advancedVScrollbar1.RegisterHandle(richTextBox1.Handle);
            advancedVScrollbar1.RegisterHandle(richTextBox2.Handle);
            advancedVScrollbar1.RegisterHandle(richTextBox3.Handle);

            advancedVScrollbar1.RegisterRichTextBoxes(richTextBox1);
            advancedVScrollbar1.RegisterRichTextBoxes(richTextBox2);
            advancedVScrollbar1.RegisterRichTextBoxes(richTextBox3);
        }

        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            richTextBox3.Text = LineCounter.UpdateLineNumber(LineCounter.GetLineNumber(richTextBox3),
                             LineCounter.GetLineNumber(richTextBox1), richTextBox3.Text);

            richTextBox2.Text = LineCounter.UpdatePartner(LineCounter.GetLineNumber(richTextBox2),
                             LineCounter.GetLineNumber(richTextBox1), richTextBox2.Text);

            _scrollingManager.ScrollHorizontally();
            _scrollingManager.ScrollVertically();
        }

        private void richTextBox1_HScroll(object sender, System.EventArgs e)
        {
            if (!advancedHScrollbar1.isScrolling)
            {
                _scrollingManager.ScrollHorizontally();
            }
            else
            {
                advancedHScrollbar1.isScrolling = false;
            }
        }
   
        bool _isScrolling3;
        bool _isScrolling2;
        bool _isScrolling1;

        private void richTextBox1_VScroll(object sender, System.EventArgs e)
        {
            if (!advancedVScrollbar1.isScrolling)
            {
                if (_isScrolling3 != true && _isScrolling2 != true)
                {
                    _isScrolling1 = true;
                    _scrollingManager.ScrollVertically();
                    _isScrolling1 = false;
                }
            }
            else
            {
                advancedVScrollbar1.isScrolling = false;
            }
        }

        private void richTextBox3_VScroll(object sender, EventArgs e)
        {
            if (_isScrolling1 != true && _isScrolling2 !=true)
            {
                _isScrolling3 = true;
                _scrollingManager.ScrollAdiacent(richTextBox3, Orientation.Vertical);
               
                _isScrolling3 = false;
            }
        }

        private void richTextBox2_VScroll(object sender, EventArgs e)
        {
            if (_isScrolling1 != true && _isScrolling3 != true)
            {
                _isScrolling2 = true;
                _scrollingManager.ScrollAdiacent(richTextBox2, Orientation.Vertical);
                _isScrolling2 = false;
            }
        }


        private void richTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            object filename = e.Data.GetData("FileDrop");
            if (filename != null)
            {
                var list = filename as string[];

                if (list != null && !string.IsNullOrWhiteSpace(list[0]))
                {
                    richTextBox1.Clear();
                    richTextBox1.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                }
            }
        }
    }
}

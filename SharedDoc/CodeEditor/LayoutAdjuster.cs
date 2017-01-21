using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CodeEditor
{
    public class LayoutAdjuster
    {
        private TextBox _textBox1;
        private RichTextBox _richTextBox1;
        private RichTextBox _richTextBox2;
        private RichTextBox _richTextBox3;
        private AdvancedHScrollbar.AdvancedHScrollbar _hiddingBlock;
        private AdvancedHScrollbar.AdvancedHScrollbar _advancedHScrollbar1;
        private AdvancedVScrollbar.AdvancedVScrollbar _advancedVScrollbar1;
        private Button _button1;

        public void SetRichTextBoxes(RichTextBox richTextBox1, RichTextBox richTextBox2, RichTextBox richTextBox3)
        {
            _richTextBox1 = richTextBox1;
            _richTextBox2 = richTextBox2;
            _richTextBox3 = richTextBox3;
        }

        public void SetTextBox(TextBox textBox)
        {
            _textBox1 = textBox;
        }

        public void SetButton(Button button)
        {
            _button1 = button;
        }

        public void SetScrollbars(AdvancedHScrollbar.AdvancedHScrollbar advancedHScrollbar1, AdvancedVScrollbar.AdvancedVScrollbar advancedVScrollbar1)
        {
            _advancedHScrollbar1 = advancedHScrollbar1;
            _advancedVScrollbar1 = advancedVScrollbar1;
        }

        public void SetHiddingBlock(AdvancedHScrollbar.AdvancedHScrollbar hiddingBlock)
        {
            _hiddingBlock = hiddingBlock;
        }

        public void Adjust()
        {
            AdjustRichTextBox1Size();
            AdjustRichTextBox2Size();
            AdjustRichTextBox3Size();
            AdjustHScrollbarLocation();
            AdjustVScrollbarLocation();

            _advancedHScrollbar1.BringToFront();
            _advancedVScrollbar1.BringToFront();
           

            AdjustButtonSizeAndLocation();
            AdjustTextBoxSizeAndLocation();
            _button1.BringToFront();
        }

        private void AdjustHiddingBlockLocation()
        {
            _hiddingBlock.Location = new Point(0, _richTextBox3.Location.Y + _richTextBox3.Height - SystemInformation.HorizontalScrollBarHeight);
            _hiddingBlock.Width = _richTextBox3.Width - SystemInformation.VerticalScrollBarWidth;
        }

        private void AdjustRichTextBox1Size()
        {
            _richTextBox1.Height -= _advancedHScrollbar1.Height - SystemInformation.HorizontalScrollBarHeight;
            _richTextBox1.Width -= _advancedVScrollbar1.Width - SystemInformation.VerticalScrollBarWidth;
        }
        private void AdjustRichTextBox2Size()
        {
            _richTextBox2.Height = _richTextBox1.Height;
            //_richTextBox2.Width -= _advancedVScrollbar1.Width - SystemInformation.VerticalScrollBarWidth;
        }
        private void AdjustRichTextBox3Size()
        {
            _richTextBox3.Height = _richTextBox1.Height;
            //_richTextBox3.Width -= _advancedVScrollbar1.Width - SystemInformation.VerticalScrollBarWidth;
        }
        private void AdjustHScrollbarLocation()
        {
            _advancedHScrollbar1.Location = new Point(_richTextBox1.Location.X, _richTextBox1.Location.Y + _richTextBox1.Height - SystemInformation.HorizontalScrollBarHeight);
            _advancedHScrollbar1.Width = _richTextBox1.Width - SystemInformation.HorizontalScrollBarHeight;
        }
        private void AdjustVScrollbarLocation()
        {
            _advancedVScrollbar1.Location = new Point(_richTextBox1.Location.X + _richTextBox1.Width - SystemInformation.VerticalScrollBarWidth, _richTextBox1.Location.Y);
            _advancedVScrollbar1.Height = _richTextBox1.Height - SystemInformation.VerticalScrollBarWidth;
        }
        private void AdjustButtonSizeAndLocation()
        {
            _button1.Location = new Point(_textBox1.Width + _advancedHScrollbar1.Width, _advancedVScrollbar1.Height);
            _button1.Size = new Size(_advancedHScrollbar1.Height, _advancedVScrollbar1.Width);
        }
        private void AdjustTextBoxSizeAndLocation()
        {
            _textBox1.Location = new Point(0, _richTextBox1.Location.Y + _richTextBox1.Height - SystemInformation.HorizontalScrollBarHeight);
            _textBox1.Size = new Size(_richTextBox1.Location.X, _advancedHScrollbar1.Height);
        }
    }
}

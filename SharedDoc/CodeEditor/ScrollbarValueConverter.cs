using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditor
{
    public static class ScrollbarValueConverter
    {
        
        public static int ConvertValueToStandardVertical(RichTextBox richTextBox, int value)
        {
            return value * richTextBox.Font.Height;
        }

        public static int ConvertValueToStandardHorizontal(RichTextBox richTextBox, int value)
        {
            return (int)((double)value * (((double)richTextBox.Font.Height / 2.0)));
        }


        public static int ConvertValueToCustomHorizontal(RichTextBox richTextBox, int value, int nMin, int nMax, AdvancedHScrollbar.AdvancedHScrollbar scrollbar)
        {
            int totalTextWidth = LineCounter.ComputeTextWidth(richTextBox);

            if (totalTextWidth > richTextBox.Width)
            {
                //there is no such  thing as richTextBox.Font.Width so i consider it richTextBox.Font.Height/2
                double clientHeight = richTextBox.Width - SystemInformation.VerticalScrollBarWidth;
                double fontWidth = (double)richTextBox.Font.Height / 2;
                int extra = (int)(clientHeight / fontWidth);
                scrollbar.Maximum = (int) Math.Round(totalTextWidth / fontWidth, 0) - extra;
                scrollbar.ThumbPosition = (int)(value / fontWidth);
            }

            return scrollbar.ThumbPosition;
        }

        public static int ConvertValueToCustomVertical(RichTextBox richTextBox, int value, int nMin, int nMax, AdvancedVScrollbar.AdvancedVScrollbar scrollbar)
        {
            int nrOfVisibleLines = LineCounter.ComputeVisibleLines(richTextBox);
            int nrOfLines = LineCounter.GetLineNumber(richTextBox);

            if (nrOfLines > nrOfVisibleLines)
            {
                scrollbar.Maximum = nrOfLines - nrOfVisibleLines;
                scrollbar.ThumbPosition = value / richTextBox.Font.Height;
            }

            return scrollbar.ThumbPosition;
        }
    }
}

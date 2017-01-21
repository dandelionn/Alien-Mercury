using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedVScrollbar
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

        public static int ConvertValueToCustomVertical(RichTextBox richTextBox, int value, int nMin, int nMax, AdvancedVScrollbar scrollbar)
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

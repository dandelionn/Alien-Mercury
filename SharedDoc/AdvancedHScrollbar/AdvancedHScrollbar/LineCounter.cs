using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedHScrollbar
{
    public static class LineCounter
    {
        public static int ComputeVisibleLines(RichTextBox richTextBox)
        {
            int height = TextRenderer.MeasureText(richTextBox.Text, richTextBox.Font).Height;
            //rate = visible height / Total height.

            int ClientHeight = richTextBox.Height - SystemInformation.HorizontalScrollBarHeight;
            float rate = (1.0f * ClientHeight) / height;
            //Get visible lines.

            int visibleLines = (int)(richTextBox.Lines.Length * rate);

            return visibleLines;
        }

        public static int ComputeTextWidth(RichTextBox  richTextBox)
        {
            int textWidth = TextRenderer.MeasureText(richTextBox.Text, richTextBox.Font).Width;

            return textWidth;
        }

        private static int NumberOfLines(string s)
        {
            int count = 0;
            int position = 0;
            while ((position = s.IndexOf('\n', position)) != -1)
            {
                count++;
                position++;
            }

            return count + 1;
        }

        public static int GetLineNumber(RichTextBox richTextBox)
        {
            return NumberOfLines(richTextBox.Text);
        }

        public static string StupidUpdateLineNumber(int previousLineNumber, int currentLineNumber, string lineNumberEditor)
        {
            lineNumberEditor = "";
            for (int i = 1; i <= currentLineNumber; i++)
            {
                if (i == 1)
                {
                    lineNumberEditor += i.ToString();
                }
                else
                {
                    lineNumberEditor += "\n" + i.ToString();
                }
            }

            return lineNumberEditor;
        }
        public static string UpdateLineNumber(int previousLineNumber, int currentLineNumber, string lineNumberEditor)
        {
            if (previousLineNumber > currentLineNumber)
            {
                int count = 0;
                int index;

                for (index = lineNumberEditor.Length - 1; count < (previousLineNumber - currentLineNumber); index--)
                {
                    if (lineNumberEditor.ElementAt(index) == '\n')
                    {
                        count++;
                    }
                }

                lineNumberEditor = lineNumberEditor.Remove(index + 1);
            }
            else
            {

                for (previousLineNumber++; previousLineNumber <= currentLineNumber; previousLineNumber++)
                {
                    if (lineNumberEditor.Length == 0)
                    {
                        lineNumberEditor += (previousLineNumber - 1).ToString();
                    }
                    else
                    {
                        lineNumberEditor += "\n" + previousLineNumber.ToString();
                    }
                }
            }

            return lineNumberEditor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public class FontModifier
    {
        public void SetCmbFontFamilies(ToolStripComboBox comboBox)
        {
            List<string> fontfamilies = new List<string>();

            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                fontfamilies.Add(fontFamily.Name);
            }

            fontfamilies.Sort();
            comboBox.Items.AddRange(fontfamilies.Cast<object>().ToArray());
        }

        public void SetCmbFontSize(ToolStripComboBox comboBox)
        {
            List<float> fontSizes = new List<float>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            comboBox.Items.AddRange(fontSizes.Cast<object>().ToArray());
        }

        public void ChangeFont(TabControl tabControl, ToolStripComboBox cmbBoxFontFamily, ToolStripComboBox cmbBoxFontSize)
        {
            if (tabControl.Controls.Count > 1)
            {
                List<RichTextBox> editableComponents = (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditableComponents();

                if (cmbBoxFontFamily.Text != "" && cmbBoxFontSize.Text != "")
                {
                    foreach(RichTextBox component in editableComponents)
                    {
                        component.Font = new Font(cmbBoxFontFamily.Text, float.Parse(cmbBoxFontSize.Text));
                    }               
                }
            }
        }

        public void UpdateFontCmbBoxes(TabControlEx.TabControlEx tabControl, ToolStripComboBox cmbBoxFontFamily, ToolStripComboBox cmbBoxFontSize)
        {
            if (tabControl.SelectedTab != tabControl.PlusButton)
            {
                RichTextBox richTextBox = (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();

                cmbBoxFontFamily.Text = richTextBox.Font.Name;
                cmbBoxFontSize.Text = richTextBox.Font.SizeInPoints.ToString();
            }
        }
    }
}

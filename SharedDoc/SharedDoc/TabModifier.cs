
using System.Drawing;
using System.Windows.Forms;

namespace SharedDoc
{
    public class TabModifier
    {
        public string CleanTabTitle(string text)
        {
            return text.TrimEnd(' ');
        }

        private int ComputeTextWidth(string text, Font font)
        {
            int textWidth = TextRenderer.MeasureText(text, font).Width;

            return textWidth;
        }

        public string CreateTabTitle(string title, int buttonAreaWidth, Font font)
        {
            int textWidth = ComputeTextWidth(title, font);
            int titleWidth = textWidth;

            while (textWidth + buttonAreaWidth > titleWidth)
            {
                title += " ";
                titleWidth = ComputeTextWidth(title, font);
            }

            return title;
        }

        public TabPage AddNewTabPage(TabControlEx.TabControlEx tabControl)
        {
            TabPage tabPage = new TabPage();

            CodeEditor.CodeEditor codeEditor = new CodeEditor.CodeEditor();
            codeEditor.Dock = DockStyle.Fill;

            tabPage.Controls.Add(codeEditor);

            
            tabControl.TabPages.Add(tabPage);
            tabControl.TabPages.RemoveAt(tabControl.TabCount - 2);
            tabControl.AddPlusButtonTabPage();

            return tabPage;
        }

        public void AddEmptyTabPage(TabControlEx.TabControlEx tabControl)
        {
            TabPage tabPage;

            tabPage = AddNewTabPage(tabControl);
            tabPage.Text = CreateTabTitle("Untitled", 15, tabControl.Font);
        }
    }
}

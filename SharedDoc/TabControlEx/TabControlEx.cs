
using System.Drawing;
using System.Windows.Forms;

namespace TabControlEx
{
    public delegate bool RemoveTabPage(int index);
    public delegate void AddTabPage(TabControlEx tabControl); 

    public partial class TabControlEx: TabControl
    {        
        public RemoveTabPage OnRemoveTabPage;
        public AddTabPage AddTabPage; 

        public TabPage PlusButton;

        public TabControlEx(): base()
        {
            OnRemoveTabPage = null;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            InitializeComponent();

            AddPlusButtonTabPage();
        }

        public void AddPlusButtonTabPage()
        {
           PlusButton = new TabPage();
           TabPages.Add(PlusButton);
           DeselectTab(TabCount - 1);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.TabPages[e.Index] != PlusButton)
            {
                PaintTabTitle(e);
                PaintTabCloseButton(e);
            }
            else
            {
                PaintPlusButton(e);
            }
        }

        public void PaintPlusButton(DrawItemEventArgs e)
        {
            Rectangle r = GetPlusButtonArea(e.Index);

            e.Graphics.DrawImage(Images.PlusButtonBlue, r);
        }


        public void PaintTabTitle(DrawItemEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);

            e.Graphics.DrawString(TabPages[e.Index].Text, this.Font, brush, new PointF(e.Bounds.X, e.Bounds.Y + 4));
        }

        public void PaintTabCloseButton(DrawItemEventArgs e)
        {
            Rectangle r = GetButtonArea(e.Index);

            e.Graphics.DrawImage(Images.CloseButtonGreen, r);
        }

        private Rectangle GetPlusButtonArea(int index)
        {
            Rectangle r = GetTabRect(index);
            r.Offset(14, 1);
            r.Width = 15;
            r.Height = 15;

            return r;
        }

        private Rectangle GetButtonArea(int index)
        {      
            Rectangle area = GetTabRect(index);
            area.Offset(area.Width - 15, 3);
            area.Width = 12;
            area.Height = 12;

            return area;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if(!PlusTabClick(e))
            {
                OtherTabClick(e);
            }   
        }

        private void OtherTabClick(MouseEventArgs e)
        {
            Point p = e.Location;
            Rectangle r;

            for (int i = 0; i < TabCount - 1; i++)
            {
                r = GetButtonArea(i);

                if (r.Contains(p))
                {
                    CloseTab(i);
                }
            }
        }

        private bool PlusTabClick(MouseEventArgs e)
        {
            Point p = e.Location;
            Rectangle r = GetTabRect(TabCount - 1);

            if (r.Contains(p))
            {
                AddTabPage(this);
                return true;
            }

            return false;
        }

        public void CloseTab(int i)
        {
            if (OnRemoveTabPage != null)
            {
                bool closed = OnRemoveTabPage(i);
                if (!closed)
                    return;
            }

            TabPages.Remove(TabPages[i]);
        }
    }
}

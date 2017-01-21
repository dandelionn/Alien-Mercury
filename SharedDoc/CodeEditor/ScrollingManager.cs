using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditor
{
    public enum SBOrientation : int
    {
        SB_HORZ = 0x0,
        SB_VERT = 0x1,
        SB_CTL = 0x2,
        SB_BOTH = 0x3
    }

    public enum ScrollBarType : uint
    {
        SbHorz = 0,
        SbVert = 1,
        SbCtl = 2,
        SbBoth = 3
    }
 
    [Serializable, StructLayout(LayoutKind.Sequential)]
    struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }

    enum SCROLLINFOFLAGS
    {
        SIF_RANGE = 1,
        SIF_PAGE = 2,
        SIF_POS = 4,
        SIF_DISABLENOSCROLL = 8,
        SIF_TRACKPOS = 16,
        SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS
    }

    public enum ScrollBarCommands
    {
        SB_LINEUP = 0,
        SB_LINELEFT = 0,
        SB_LINEDOWN = 1,
        SB_LINERIGHT = 1,
        SB_PAGEUP = 2,
        SB_PAGELEFT = 2,
        SB_PAGEDOWN = 3,
        SB_PAGERIGHT = 3,
        SB_THUMBPOSITION = 4,
        SB_THUMBTRACK = 5,
        SB_TOP = 6,
        SB_LEFT = 6,
        SB_BOTTOM = 7,
        SB_RIGHT = 7,
        SB_ENDSCROLL = 8
    }

    public enum Message : uint
    {
        WM_VSCROLL = 0x0115,
        WM_HSCROLL = 0x114
    }

    public class ScrollingManager
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        [DllImport("user32.dll")]
        static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO
        lpsi, bool fRedraw);
        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private RichTextBox _richTextBox1;
        private RichTextBox _richTextBox2;
        private RichTextBox _richTextBox3;
        private AdvancedHScrollbar.AdvancedHScrollbar _advancedHScrollbar1;
        private AdvancedVScrollbar.AdvancedVScrollbar _advancedVScrollbar1;

        public void SetScrollbars(AdvancedHScrollbar.AdvancedHScrollbar advancedHScrollbar1, AdvancedVScrollbar.AdvancedVScrollbar advancedVScrollbar1)
        {
            _advancedHScrollbar1 = advancedHScrollbar1;
            _advancedVScrollbar1 = advancedVScrollbar1;
        }

        public void SetRichTextBoxes(RichTextBox richTextBox1, RichTextBox richTextBox2, RichTextBox richTextBox3)
        {
            _richTextBox1 = richTextBox1;
            _richTextBox2 = richTextBox2;
            _richTextBox3 = richTextBox3;
        }

     

        private void SetScrollingInfo(IntPtr handle, Orientation orientation, int value)
        {
            int nPos = value;
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(handle, (uint)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
        
        private SCROLLINFO GetScrollInfo(RichTextBox richTextBox)
        {
            SCROLLINFO scrollinfo = new SCROLLINFO();
            scrollinfo.cbSize = (uint)Marshal.SizeOf(typeof(SCROLLINFO));
            scrollinfo.fMask = (uint)Convert.ToInt32(SCROLLINFOFLAGS.SIF_ALL);
            GetScrollInfo(richTextBox.Handle, (int)ScrollBarType.SbVert, ref scrollinfo);

            return scrollinfo;
        }

        public void ScrollVertically()
        {
            SCROLLINFO scrollinfo = GetScrollInfo(_richTextBox1);

            ScrollbarValueConverter.ConvertValueToCustomVertical(_richTextBox1, scrollinfo.nTrackPos, scrollinfo.nMin, scrollinfo.nMax, _advancedVScrollbar1);

            ScrollPartners(scrollinfo, _richTextBox2, _richTextBox3);
        }

        public void ScrollAdiacent(RichTextBox richTextBox, Orientation orientation)
        {
            SCROLLINFO scrollinfo = GetScrollInfo(richTextBox);

            if (orientation == Orientation.Vertical)
            {
                ScrollbarValueConverter.ConvertValueToCustomVertical(_richTextBox1, scrollinfo.nTrackPos, scrollinfo.nMin, scrollinfo.nMax, _advancedVScrollbar1);
            }
            else
            {
                ScrollbarValueConverter.ConvertValueToCustomHorizontal(_richTextBox1, scrollinfo.nTrackPos, scrollinfo.nMin, scrollinfo.nMax, _advancedHScrollbar1);
            }

            if (richTextBox == _richTextBox3)
            {
                ScrollPartners(scrollinfo, _richTextBox1, _richTextBox2);
            }
            else
            {
                ScrollPartners(scrollinfo, _richTextBox1, _richTextBox3);
            }
        }

        private void ScrollPartners(SCROLLINFO scrollinfo, RichTextBox partner1, RichTextBox partner2)
        {
            SetScrollInfo(partner1.Handle,(int) Orientation.Vertical, ref scrollinfo, true);
            SetScrollInfo(partner2.Handle, (int) Orientation.Vertical, ref scrollinfo, true);

            SetScrollingInfo(partner1.Handle, Orientation.Vertical, scrollinfo.nTrackPos);
            SetScrollingInfo(partner2.Handle, Orientation.Vertical, scrollinfo.nTrackPos);
        }

        public void ScrollHorizontally()
        {
            SCROLLINFO scrollinfo = GetScrollInfo(_richTextBox1);

            ScrollbarValueConverter.ConvertValueToCustomHorizontal(_richTextBox1, scrollinfo.nTrackPos, scrollinfo.nMin, scrollinfo.nMax, _advancedHScrollbar1);
        }
    }
}

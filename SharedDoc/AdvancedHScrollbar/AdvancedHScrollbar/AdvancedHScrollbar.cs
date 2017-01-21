using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdvancedHScrollbar
{
    public partial class AdvancedHScrollbar : UserControl
    {
        protected Image _imgLeftArrow;
        protected Color _colorChannel;
        protected Color _colorChannelBorder;
        protected Color _colorThumb;
        protected Image _imgThumbRight;
        protected Image _imgThumbRightSpan;
        protected Image _imgThumbMiddle;
        protected Image _imgThumbLeftSpan;
        protected Image _imgThumbLeft;
        protected Image _imgRightArrow;

        private int _trackPosition;
        private int _thumbPosition;
        private int _minimum;
        private int _maximum;

        public bool isScrolling;

        private bool _mouseDown;
        private bool _thumbDragging;
        private double _clickPoint;
        private double _distance;
        private int _clickRightDistance;
        private int _clickLeftDistance;


        private double _channelWidth;
        private double _unit;
        private double _thumbWidth;
        private double _thumbLeftPos;
        private bool _arrowClicked;


        List<IntPtr> _handle;
        List<RichTextBox> _richTextBox;

        public AdvancedHScrollbar()
        {
            _handle = new List<IntPtr>();
            _richTextBox = new List<RichTextBox>();

            InitializeComponent();

            MouseDown += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseDown);
            MouseMove += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseMove);
            MouseUp += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseUp);
            MouseWheel += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseWheel);
            MouseClick += new System.Windows.Forms.MouseEventHandler(AdvancedScrollbar_MouseClick);

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            LeftArrow = ImageResource.leftarrowblue;
            RightArrow = ImageResource.rightarrowblue;
        }

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
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
        private void SetScrollingInfo(IntPtr handle, Orientation orientation, int value)
        {
            isScrolling = true;

            int nPos = ScrollbarValueConverter.ConvertValueToStandardHorizontal(_richTextBox[0], ThumbPosition);

            //int nPos = value;
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(handle, (uint) Message.WM_HSCROLL, new IntPtr(wParam), new IntPtr(0));
        }

        public void RegisterRichTextBoxes(RichTextBox richTextBox)
        {
            _richTextBox.Add(richTextBox);
        }

        public void RegisterHandle(IntPtr handle)
        {
            _handle.Add(handle);
        }
        private void UpdateRegisteredHandlesScroll()
        {
            foreach(IntPtr handle in _handle)
            {
                SetScrollingInfo(handle, Orientation.Horizontal, ThumbPosition);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Behaviour"),
                           Description("Minimum")]
        public int Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                            DefaultValue(false), Category("Behaviour"),
                            Description("Maximum")]
        public int Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                            DefaultValue(false), Category("Behaviour"),
                            Description("Thumb Position")]
        public int ThumbPosition
        {
            get { return _thumbPosition; }
            set { _thumbPosition = value; Invalidate(); }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Skin"),
                           Description("Channel Color")]
        public Color ChannelColor
        {
            get { return _colorChannel; }
            set { _colorChannel = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                           DefaultValue(false), Category("Skin"),
                           Description("Thumb Color")]
        public Color ThumbColor
        {
            get { return _colorThumb; }
            set { _colorThumb = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Channel Color")]
        public Color ChannelBorderColor
        {
            get { return _colorChannelBorder; }
            set { _colorChannelBorder = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                        DefaultValue(false), Category("Skin"),
                        Description("Up Arrow Image")]
        public Image LeftArrow
        {
            get { return _imgLeftArrow; }
            set { _imgLeftArrow = value; }
        }


        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Down Arrow Image")]
        public Image RightArrow
        {
            get { return _imgRightArrow; }
            set { _imgRightArrow = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Thumb Top Image")]
        public Image ThumbLeft
        {
            get { return _imgThumbRight; }
            set { _imgThumbRight = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                         DefaultValue(false), Category("Skin"),
                         Description("Thumb Top Span Image")]
        public Image ThumbLeftSpan
        {
            get { return _imgThumbRightSpan; }
            set { _imgThumbRightSpan = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                  DefaultValue(false), Category("Skin"),
                  Description("Thumb Arrow Image")]
        public Image ThumbMiddle
        {
            get { return _imgThumbMiddle; }
            set { _imgThumbMiddle = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                          DefaultValue(false), Category("Skin"),
                          Description("Thumb Bottom Span Image")]
        public Image ThumbRightSpan
        {
            get { return _imgThumbLeftSpan; }
            set { _imgThumbLeftSpan = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true),
                        DefaultValue(false), Category("Skin"),
                        Description("Thumb Bottom Image")]

        public Image ThumbRight
        {
            get { return _imgThumbLeft; }
            set { _imgThumbLeft = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            ComputeDimensions();
            DrawLeftRightArrows(e);
            DrawChannelBorders(e);
            DrawThumbControl(e);

            base.OnPaint(e);
        }
        private void DrawChannelBorders(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(ChannelBorderColor), LeftArrow.Width, 0, this.Width - RightArrow.Width - LeftArrow.Width, 1);
            e.Graphics.FillRectangle(new SolidBrush(ChannelBorderColor), LeftArrow.Width, this.Width - 1, this.Width - RightArrow.Width - LeftArrow.Width, 1);
            e.Graphics.FillRectangle(new SolidBrush(ChannelColor), LeftArrow.Width, 1, this.Width - RightArrow.Width - LeftArrow.Width, this.Height - 2);

        }
        private void DrawLeftRightArrows(PaintEventArgs e)
        {
            if (LeftArrow != null)
            {
                e.Graphics.DrawImage(LeftArrow, 0, 0, LeftArrow.Width, this.Height);
            }
            if (RightArrow != null)
            {
                e.Graphics.DrawImage(RightArrow, this.Width - RightArrow.Width, 0, RightArrow.Width, this.Height);
            }
        }
        private void AdvancedScrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = this.PointToClient(Cursor.Position);
            ComputeDimensions();

            bool value = ThumbRectClicked(point);
            if (!value)
            {
                _arrowClicked = true;
                value = LeftArrowRectClicked(point);

                if (!value)
                {
                    RightArrowRectClicked(point);
                }
            }
        }
        private bool ThumbRectClicked(Point point)
        {
            Rectangle thumbrect = new Rectangle(LeftArrow.Width + (int)_thumbLeftPos, 1, (int)_thumbWidth, this.Height - 2);

            if (thumbrect.Contains(point))
            {
                _clickPoint = point.X;
                _mouseDown = true;
                return true;
            }
            return false;
        }
        private bool LeftArrowRectClicked(Point point)
        {
            Rectangle leftarrowrect = new Rectangle(0, 0, LeftArrow.Width, this.Height);
            if (leftarrowrect.Contains(point))
            {
                if (ThumbPosition > Minimum)
                {
                    ThumbPosition--;
                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }

                return true;
            }

            return false;
        }
        private bool RightArrowRectClicked(Point point)
        {
            Rectangle rightarrowrect = new Rectangle(LeftArrow.Width + (int)_channelWidth, 0, RightArrow.Width, this.Height);
            if (rightarrowrect.Contains(point))
            {

                if (ThumbPosition < Maximum)
                {
                    ThumbPosition++;
                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }
                return true;
            }
            return false;
        }
        private void AdvancedScrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
            _thumbDragging = false;
            _arrowClicked = false;
        }

        private void FigureOutPosition()
        {
            ComputeUnit();

            double value = _distance / _unit;

            int steps = (int)value;
            if (Math.Abs(value - (int)value) > 0.5)
            {
                if (value > 0)
                {
                    steps += 1;
                }
                else
                {
                    steps -= 1;
                }
            }

            ThumbPosition += steps;
            if (ThumbPosition > Maximum)
            {
                steps -= Math.Abs(Math.Abs(ThumbPosition) - Math.Abs(Maximum));
                ThumbPosition = Maximum;
            }

            if (ThumbPosition < Minimum)
            {
                steps += Math.Abs(Math.Abs(ThumbPosition) - Math.Abs(Minimum));
                ThumbPosition = Minimum;
            }

            _clickPoint += (steps * _unit);
            _distance -= (steps * _unit);
        }
        private void AdvancedScrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown == true)
            {
                _thumbDragging = true;
            }

            if (_thumbDragging)
            {
                Point ptPoint = this.PointToClient(Cursor.Position);
                MoveThumb(ptPoint.X);
            }
        }
        private void MoveThumb(int x)
        {
            ComputeDimensions();
            _distance = x - _clickPoint;

            if ((int)(_thumbLeftPos + _distance) >= 0)
            {
                if (!((int)(_thumbLeftPos + _distance + _thumbWidth) <= _channelWidth))
                {
                    _distance = _channelWidth - _thumbWidth - _thumbLeftPos;
                }
            }
            else
            {
                _distance = -_thumbLeftPos;
            }

            FigureOutPosition();
            Invalidate();
            UpdateRegisteredHandlesScroll();
        }
        private void DrawThumbControl(PaintEventArgs e)
        {
            if (_mouseDown == false)
            {
                e.Graphics.FillRectangle(new SolidBrush(_colorThumb), LeftArrow.Width + (int)_thumbLeftPos, 1, (int)_thumbWidth, this.Height - 2);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(_colorThumb), LeftArrow.Width + (int)(_thumbLeftPos + _distance), 1, (int)_thumbWidth, this.Height - 2);
            }
        }
        private void ComputeUnit()
        {
            _unit = _channelWidth / (Maximum + 100); // 20 units for thumb
        }
        private void ComputeDimensions()
        {
            _channelWidth = this.Width - LeftArrow.Width - RightArrow.Width;
            _thumbWidth = 100 * _channelWidth / (Maximum + 100);

            if (Maximum == 0)
            {
                _thumbLeftPos = 0;
            }
            else
            {
                _thumbLeftPos = (int)(ThumbPosition * (_channelWidth - _thumbWidth) / Maximum);
            }
        }

        private void AdvancedScrollbar_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                ThumbPosition += 3;
                if (ThumbPosition > Maximum)
                {
                    ThumbPosition = Maximum;
                }
            }
            else
            {
                ThumbPosition -= 3;
                if (ThumbPosition < Minimum)
                {
                    ThumbPosition = Minimum;
                }
            }

            Invalidate();
            UpdateRegisteredHandlesScroll();
        }
        private void AdvancedScrollbar_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_mouseDown)
            {
                ComputeDimensions();
                Point point = this.PointToClient(Cursor.Position);
                Rectangle thumbrect = new Rectangle(LeftArrow.Width, 1, (int)_channelWidth, this.Height - 2);
                if (thumbrect.Contains(point))
                {
                    _clickPoint = point.X;

                    if (LeftArrow.Width + _channelWidth - _thumbWidth >= point.X)
                    {
                        _distance = point.X - LeftArrow.Width - _thumbLeftPos;
                    }
                    else
                    {
                        _distance = LeftArrow.Width + _channelWidth - _thumbWidth;
                    }

                    FigureOutPosition();
                    Invalidate();
                    UpdateRegisteredHandlesScroll();
                }
            }
        }
    }
}

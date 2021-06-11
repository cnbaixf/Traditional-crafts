using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ControlLibrary
{
    [DefaultEvent("Click")]
    public partial class MyButton1 : Button
    {
        #region attribute

        /// <summary>
        /// 圆角值
        /// </summary>
        private int _CornerRadius = 2;

        /// <summary>
        /// 内容边距间隔
        /// </summary>
        private int _Margin = 4;

        /// <summary>
        /// 图标大小
        /// </summary>
        private Size _ImageSize = new Size(16, 16);

        /// <summary>
        /// 控件的状态
        /// </summary>
        private EnumControlState _ControlState;

        /// <summary>
        /// 控件默认状态下的边框宽度
        /// </summary>
        private int _DefaultBorderWidth = 1;

        /// <summary>
        /// 控件高亮状态下的边框宽度
        /// </summary>
        private int _HighLightBorderWidth = 1;

        /// <summary>
        /// 控件焦点状态下的边框宽度
        /// </summary>
        private int _FocusedBorderWidth = 1;

        /// <summary>
        /// 控件高亮状态下的背景色
        /// </summary>
        private Color _HighLightBackColor = Color.Transparent;

        /// <summary>
        /// 控件焦点状态下的背景色
        /// </summary>
        private Color _FocusedBackColor = Color.Transparent;

        /// <summary>
        /// 控件默认状态下的边框色
        /// </summary>
        private Color _DefaultBorderColor = Color.Black;

        /// <summary>
        /// 控件高亮状态下的边框色
        /// </summary>
        private Color _HighLightBorderColor = Color.Black;

        /// <summary>
        /// 控件焦点状态下的边框色
        /// </summary>
        private Color _FocusedBorderColor = Color.Black;

        #endregion

        #region Initializes
        /// <summary>
        /// 构造函数
        /// </summary>
        public MyButton1()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            _ControlState = EnumControlState.Default;
            base.TextImageRelation = TextImageRelation.ImageBeforeText;
            Size = new Size(100, 28);
            ResetRegion();
        }
        #endregion

        #region Properties

        [Category("Properties")]
        [Description("圆角的半径值")]
        [DefaultValue(2)]
        public int CornerRadius
        {
            get { return _CornerRadius; }
            set
            {
                _CornerRadius = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("图标大小")]
        [DefaultValue(typeof(Size), "16,16")]
        public Size ImageSize
        {
            get { return _ImageSize; }
            set { _ImageSize = value; Invalidate(); }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("图标")]
        public new Image Image
        {
            get { return base.Image; }
            set
            {
                base.Image = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("图标和文本的相对位置")]
        [DefaultValue(typeof(TextImageRelation), "ImageBeforeText")]
        public new TextImageRelation TextImageRelation
        {
            get { return base.TextImageRelation; }
            set { base.TextImageRelation = value; }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("背景色")]
        public new Color DefaultBackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("高亮背景色")]
        public Color HighLightBackColor
        {
            get { return _HighLightBackColor; }
            set
            {
                _HighLightBackColor = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("焦点背景色")]
        public Color FocusedBackColor
        {
            get { return _FocusedBackColor; }
            set
            {
                _FocusedBackColor = value;
                Invalidate();
            }
        }
        [Category("Properties")]
        [Browsable(true)]
        [Description("边框色")]
        public Color DefaultBorderColor
        {
            get { return _DefaultBorderColor; }
            set { _DefaultBorderColor = value; }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("高亮边框色")]
        public Color HighLightBorderColor
        {
            get { return _HighLightBorderColor; }
            set
            {
                _HighLightBorderColor = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("焦点边框色")]
        public Color FocusedBorderColor
        {
            get { return _FocusedBorderColor; }
            set
            {
                _FocusedBorderColor = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("文本对齐方式")]
        public new ContentAlignment TextAlign
        {
            get { return base.TextAlign; }
            set { base.TextAlign = value; }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("图标对齐方式")]
        public new ContentAlignment ImageAlign
        {
            get { return base.ImageAlign; }
            set
            {
                base.ImageAlign = value;
            }

        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("默认状态边框宽度")]
        [DefaultValue(1)]
        public int DefaultBorderWidth
        {
            get { return _DefaultBorderWidth; }
            set
            {
                _DefaultBorderWidth = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("高亮状态边框宽度")]
        [DefaultValue(1)]
        public int HighLightBorderWidth
        {
            get { return _HighLightBorderWidth; }
            set
            {
                _HighLightBorderWidth = value;
                Invalidate();
            }
        }

        [Category("Properties")]
        [Browsable(true)]
        [Description("焦点状态边框宽度")]
        [DefaultValue(1)]
        public int FocusedBorderWidth
        {
            get { return _FocusedBorderWidth; }
            set
            {
                _FocusedBorderWidth = value;
                Invalidate();
            }
        }

        #endregion

        #region Override methods
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _ControlState = EnumControlState.HeightLight;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _ControlState = EnumControlState.Focused;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _ControlState = EnumControlState.Default;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                _ControlState = EnumControlState.HeightLight;
                Invalidate();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space)
            {
                _ControlState = EnumControlState.Focused;
                Invalidate();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Space)
            {
                _ControlState = EnumControlState.Default;
                Invalidate();
                OnClick(e);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _ControlState = EnumControlState.HeightLight;
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _ControlState = EnumControlState.Default;
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResetRegion();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ResetRegion();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            ResetRegion();
            Graphics g = e.Graphics;
            DrawBackGround(g);
            DrawContent(g);
        }

        #endregion


        #region Private methods
        /// <summary>
        /// 绘制背景和边框等
        /// </summary>
        /// <param name="g">The Graphics.</param>
        private void DrawBackGround(Graphics g)
        {
            GDIHelper.InitializeGraphics(g);
            Rectangle rect = new Rectangle(1, 1, Width - 3, Height - 3);
            RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
            switch (_ControlState)
            {
                case EnumControlState.Default:
                    if (FlatStyle != FlatStyle.Flat)
                    {
                        GDIHelper.FillRoundRectangle(g, roundRect, DefaultBackColor);
                        GDIHelper.DrawPathBorder(g, roundRect, new Pen(_DefaultBorderColor, _DefaultBorderWidth));
                    }
                    break;
                case EnumControlState.HeightLight:
                    GDIHelper.FillRoundRectangle(g, roundRect, _HighLightBackColor);
                    GDIHelper.DrawPathBorder(g, roundRect, new Pen(_HighLightBorderColor, _HighLightBorderWidth));
                    break;
                case EnumControlState.Focused:
                    GDIHelper.FillRoundRectangle(g, roundRect, _FocusedBackColor);
                    GDIHelper.DrawPathBorder(g, roundRect, new Pen(_FocusedBorderColor, _FocusedBorderWidth));
                    GDIHelper.DrawPathInnerBorder(g, roundRect, _FocusedBorderColor, 1);
                    break;
            }
        }

        /// <summary>
        /// 绘制按钮的内容：图标和文字
        /// </summary>
        /// <param name="g"></param>
        private void DrawContent(Graphics g)
        {
            Rectangle imageRect;
            Rectangle textRect;
            CalculateRect(out imageRect, out textRect);
            if (Image != null)
            {
                g.DrawImage(Image, imageRect, 0, 0, _ImageSize.Width, _ImageSize.Height, GraphicsUnit.Pixel);
            }

            Color forceColor = Enabled ? ForeColor : Color.Black;
            TextRenderer.DrawText(g, Text, Font, textRect, forceColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        /// <summary>
        /// 计算图标和文字的区域
        /// </summary>
        /// <param name="imageRect"></param>
        /// <param name="textRect"></param>
        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (Image == null)
            {
                textRect = new Rectangle(
                   _Margin,
                   _Margin,
                   Width - _Margin * 2,
                   Height - _Margin * 2);
                return;
            }
            Size textSize = TextRenderer.MeasureText(Text, Font);
            int textMaxWidth = Width - _ImageSize.Width - _Margin * 3;
            int textWidth = textSize.Width >= textMaxWidth ? textMaxWidth : textSize.Width;
            int contentWidth = _Margin + _ImageSize.Width + textWidth;
            switch (TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    imageRect = new Rectangle(
                        _Margin,
                        (Height - _ImageSize.Height) / 2,
                        _ImageSize.Width,
                        _ImageSize.Height);
                    textRect = new Rectangle(
                        _Margin,
                        _Margin,
                        Width - _Margin * 2,
                        Height);
                    break;
                case TextImageRelation.ImageAboveText:
                    imageRect = new Rectangle(
                        (Width - _ImageSize.Width) / 2,
                        _Margin,
                        _ImageSize.Width,
                        _ImageSize.Height);
                    textRect = new Rectangle(
                        _Margin,
                        imageRect.Bottom,
                        Width - _Margin * 2,
                        Height - imageRect.Bottom - _Margin);
                    break;
                case TextImageRelation.ImageBeforeText:
                    imageRect = new Rectangle(
                        (Width - contentWidth) / 2,
                        (Height - _ImageSize.Height) / 2,
                        _ImageSize.Width,
                        _ImageSize.Height);
                    textRect = new Rectangle(
                        imageRect.Right + _Margin,
                        _Margin,
                        textWidth,
                        Height - _Margin * 2);
                    break;
                case TextImageRelation.TextAboveImage:
                    imageRect = new Rectangle(
                        (Width - _ImageSize.Width) / 2,
                        Height - _ImageSize.Height - _Margin,
                        _ImageSize.Width,
                        _ImageSize.Height);
                    textRect = new Rectangle(
                        _Margin,
                        _Margin,
                        Width - _Margin * 2,
                        Height - imageRect.Y - _Margin);
                    break;
                case TextImageRelation.TextBeforeImage:
                    imageRect = new Rectangle(
                        (Width + contentWidth) / 2 - _ImageSize.Width,
                        (Height - _ImageSize.Height) / 2,
                        _ImageSize.Width,
                        _ImageSize.Height);
                    textRect = new Rectangle(
                        (Width - contentWidth) / 2,
                        _Margin,
                        textWidth,
                        Height - _Margin * 2);
                    break;
            }

            if (RightToLeft == RightToLeft.Yes)
            {
                imageRect.X = Width - imageRect.Right;
                textRect.X = Width - textRect.Right;
            }
        }

        /// <summary>
        /// 设置控件的形状
        /// </summary>
        private void ResetRegion()
        {
            if (_CornerRadius > 0)
            {
                Rectangle rect = new Rectangle(Point.Empty, Size);
                RoundRectangle roundRect = new RoundRectangle(rect, new CornerRadius(_CornerRadius));
                if (Region != null)
                    Region.Dispose();
                Region = new Region(roundRect.ToGraphicsBezierPath());
            }
        }


        #endregion

    }
}

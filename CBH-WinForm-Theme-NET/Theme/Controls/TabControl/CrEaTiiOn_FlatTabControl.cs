using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_FlatTabControl : TabControl
    {
        private int hoverIndex = -1;
        private Color _themeColor = Color.FromArgb(250, 36, 38);

        public CrEaTiiOn_FlatTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 40);
            TabPageColor = Color.Transparent;
            TabPageForeColor = Color.Black;
        }

        public Color ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                Invalidate();
            }
        }

        public Color TabPageColor { get; set; } = Color.White;

        public Color TabPageForeColor { get; set; } = Color.Black;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            for (int i = 0; i < TabCount; i++)
            {
                if (GetTabRect(i).Contains(e.Location))
                {
                    hoverIndex = i;
                    Invalidate();
                    break;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hoverIndex = -1;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);
                if (i == SelectedIndex || i == hoverIndex)
                {
                    using (SolidBrush brush = new SolidBrush(i == SelectedIndex ? _themeColor : Color.FromArgb(250, 36, 38)))
                    {
                        graphics.FillRectangle(brush, tabRect.X + 3, tabRect.Bottom - 3, tabRect.Width - 6, 3);
                    }
                }

                using (SolidBrush brush = new SolidBrush(TabPageColor))
                {
                    Rectangle tabPageRect = tabRect;
                    tabPageRect.Inflate(-3, -3);
                    graphics.FillRectangle(brush, tabPageRect);
                }

                using (SolidBrush brush = new SolidBrush(TabPageForeColor))
                {
                    StringFormat stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    graphics.DrawString(TabPages[i].Text.ToUpper(), Font, brush, tabRect, stringFormat);
                }
            }
        }
    }
}
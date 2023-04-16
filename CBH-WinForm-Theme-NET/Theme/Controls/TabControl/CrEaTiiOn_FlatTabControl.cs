using CBH_Ultimate_Theme_Library.Theme.Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_FlatTabControl : TabControl
    {
        private int enterIndex;
        private bool enterFlag = false;
        private Color _themeColor = Color.FromArgb(250, 36, 38);
        public CrEaTiiOn_FlatTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12F);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 40);
            TabPageColor = Color.Transparent;
            ThemeColor = Color.FromArgb(250, 36, 38);
            TabPageForeColor = Color.White;
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

        private Color _tabPageColor = Color.White;
        public Color TabPageColor
        {
            get { return _tabPageColor; }
            set
            {
                _tabPageColor = value;
                Invalidate();
            }
        }

        private Color _tabPageForeColor = Color.Black;
        public Color TabPageForeColor
        {
            get { return _tabPageForeColor; }
            set
            {
                _tabPageForeColor = value;
                Invalidate();
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            enterFlag = true;
            for (int i = 0; i < TabCount; i++)
            {
                var tempRect = GetTabRect(i);
                if (tempRect.Contains(e.Location))
                {
                    enterIndex = i;
                }
            }
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            enterFlag = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            for (int i = 0; i < TabCount; i++)
            {
                if (i == SelectedIndex)
                {
                    graphics.FillRectangle(new SolidBrush(_themeColor), GetTabRect(i).X + 3, ItemSize.Height - 3, ItemSize.Width - 6, 3);
                    graphics.DrawString(TabPages[i].Text.ToUpper(), Font, new SolidBrush(_themeColor), GetTabRect(i), StringAlign.Center);
                }
                else
                {
                    if (i == enterIndex && enterFlag)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 36, 38)), GetTabRect(i).X + 3, ItemSize.Height - 3, ItemSize.Width - 6, 3);
                    }

                    graphics.DrawString(TabPages[i].Text.ToUpper(), Font, new SolidBrush(Color.Black), GetTabRect(i), StringAlign.Center);
                }
            }

            for (int i = 0; i < TabCount; i++)
            {
                if (i == SelectedIndex)
                {
                    graphics.FillRectangle(new SolidBrush(_themeColor), GetTabRect(i).X + 3, ItemSize.Height - 3, ItemSize.Width - 6, 3);
                    graphics.DrawString(TabPages[i].Text.ToUpper(), Font, new SolidBrush(_themeColor), GetTabRect(i), StringAlign.Center);
                }
                else
                {
                    if (i == enterIndex && enterFlag)
                    {
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 36, 38)), GetTabRect(i).X + 3, ItemSize.Height - 3, ItemSize.Width - 6, 3);
                    }

                    // Draw the TabPage background color
                    Rectangle rect = GetTabRect(i);
                    rect.Inflate(-3, -3);
                    using (SolidBrush brush = new SolidBrush(_tabPageColor))
                    {
                        graphics.FillRectangle(brush, rect);
                    }

                    graphics.DrawString(TabPages[i].Text.ToUpper(), Font, new SolidBrush(_tabPageForeColor), GetTabRect(i), StringAlign.Center);
                }
            }
        }
    }
}
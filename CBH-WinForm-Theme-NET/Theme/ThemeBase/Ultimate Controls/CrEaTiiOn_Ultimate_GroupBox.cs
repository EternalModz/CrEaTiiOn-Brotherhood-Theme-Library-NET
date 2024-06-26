﻿#region Imports
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace CBH.Ultimate.Controls
{
    public sealed class CrEaTiiOn_Ultimate_GroupBox : GroupBox
    {
        private Color _backgroundColor = Color.FromArgb(15, 15, 15);
        private Color _titleBackColor = Color.FromArgb(15, 15, 15);
        private Color _titleForeColor = Color.White;
        private Font _titleFont;
        private int _radius = 20;

        [Category("CrEaTiiOn")]
        public Color TitleBackColor { get => _titleBackColor; set { _titleBackColor = value; Invalidate(); } }
        [Category("CrEaTiiOn")]
        public Color TitleForeColor { get => _titleForeColor; set { _titleForeColor = value; Invalidate(); } }
        [Category("CrEaTiiOn")]
        public Font TitleFont { get => _titleFont; set { _titleFont = value; Invalidate(); } }
        [Category("CrEaTiiOn")]
        public int Radius { get => _radius; set { _radius = value; Invalidate(); } }
        [Category("CrEaTiiOn")]
        public Color BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; Invalidate(); } }

        public CrEaTiiOn_Ultimate_GroupBox()
        {
            DoubleBuffered = true;
            TitleFont = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius - 1, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius - 1, rect.Y + rect.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw control background
            using (var path = GetFigurePath(ClientRectangle, Radius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Fill background
                if (_backgroundColor != Color.Transparent)
                {
                    using (var brush = new SolidBrush(_backgroundColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                // Draw title background
                var titleRect = new Rectangle(0, 0, ClientRectangle.Width, _titleFont.Height + Padding.Bottom + Padding.Top);
                using (var titlePath = GetFigurePath(titleRect, Radius))
                {
                    using (var titleBrush = new SolidBrush(_titleBackColor))
                    {
                        e.Graphics.FillPath(titleBrush, titlePath);
                    }
                }

                // Draw title text
                TextRenderer.DrawText(e.Graphics, Text, _titleFont, titleRect, _titleForeColor);
            }
        }
    }
}
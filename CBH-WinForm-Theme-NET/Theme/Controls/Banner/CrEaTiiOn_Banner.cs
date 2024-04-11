using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_Banner : Control
    {
        private PixelOffsetMode _pixelOffsetType = PixelOffsetMode.HighQuality;
        private TextRenderingHint _textRenderingType = TextRenderingHint.ClearTypeGridFit;

        public CrEaTiiOn_Banner()
        {
            Size = new Size(100, 20);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            BannerColor = Color.FromArgb(15, 15, 15);
        }

        public Color BorderColor { get; set; }
        public Color BannerColor { get; set; }

        public PixelOffsetMode PixelOffsetType
        {
            get => _pixelOffsetType;
            set { _pixelOffsetType = value; Invalidate(); }
        }

        public TextRenderingHint TextRenderingType
        {
            get => _textRenderingType;
            set { _textRenderingType = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawBanner(e.Graphics);
            DrawText(e.Graphics);
        }

        private void DrawBanner(Graphics graphics)
        {
            var list = new[]
            {
                new Point(0, Height / 10 * 5),
                new Point(Height / 10, Height / 10 * 4),
                new Point(Height / 10 * 2, Height / 10 * 3),
                new Point(Height / 10 * 3, Height / 10 * 2),
                new Point(Height / 10 * 4, Height / 10),
                new Point(Height / 10 * 5, 0),
                new Point(Width - Height / 10 * 5, 0),
                new Point(Width - Height / 10 * 4, Height / 10),
                new Point(Width - Height / 10 * 3, Height / 10 * 2),
                new Point(Width - Height / 10 * 2, Height / 10 * 3),
                new Point(Width - Height / 10, Height / 10 * 4),
                new Point(Width, Height / 10 * 5),
                new Point(Width - Height / 10, Height / 10 * 6),
                new Point(Width - Height / 10 * 2, Height / 10 * 7),
                new Point(Width - Height / 10 * 3, Height / 10 * 8),
                new Point(Width - Height / 10 * 4, Height / 10 * 9),
                new Point(Width - Height / 10 * 5, Height / 10 * 10),
                new Point(Height / 10 * 5, Height / 10 * 10),
                new Point(Height / 10 * 4, Height / 10 * 9),
                new Point(Height / 10 * 3, Height / 10 * 8),
                new Point(Height / 10 * 2, Height / 10 * 7),
                new Point(Height / 10, Height / 10 * 6),
                new Point(0, Height / 10 * 5)
            };
            using (var brush = new SolidBrush(BannerColor))
            {
                graphics.FillPolygon(brush, list);
            }
        }

        private void DrawText(Graphics graphics)
        {
            using (var font = new Font(FontFamily.GenericSansSerif, Height / 4))
            using (var brush = new SolidBrush(ForeColor))
            {
                var stringFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                graphics.TextRenderingHint = TextRenderingType;
                graphics.DrawString(Text, font, brush, ClientRectangle, stringFormat);
            }
        }
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CBH.Controls
{
    public enum GradientDirection
    {
        Vertical,
        Horizontal
    }

    public class CrEaTiiOn_GradientGroupBox : Control
    {
        private int cornerRadius = 10;
        private string headerText = "Header";
        private Color headerGradientStart = Color.FromArgb(64, 64, 64);
        private Color headerGradientEnd = Color.FromArgb(32, 32, 32);
        private GradientDirection headerGradientDirection = GradientDirection.Vertical;

        public int CornerRadius
        {
            get { return cornerRadius; }
            set { cornerRadius = value; Invalidate(); }
        }

        public string HeaderText
        {
            get { return headerText; }
            set { headerText = value; Invalidate(); }
        }

        public Color HeaderGradientStart
        {
            get { return headerGradientStart; }
            set { headerGradientStart = value; Invalidate(); }
        }

        public Color HeaderGradientEnd
        {
            get { return headerGradientEnd; }
            set { headerGradientEnd = value; Invalidate(); }
        }

        public GradientDirection HeaderGradientDirection
        {
            get { return headerGradientDirection; }
            set { headerGradientDirection = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw header gradient
            Rectangle headerRect = new Rectangle(0, 0, Width, 30);
            LinearGradientMode gradientMode = headerGradientDirection == GradientDirection.Vertical ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            using (LinearGradientBrush brush = new LinearGradientBrush(headerRect, headerGradientStart, headerGradientEnd, gradientMode))
            {
                e.Graphics.FillRectangle(brush, headerRect);
            }

            // Draw header text
            using (Font font = new Font(Font.FontFamily, 12f, FontStyle.Bold))
            {
                SizeF textSize = e.Graphics.MeasureString(headerText, font);
                PointF textPoint = new PointF((Width - textSize.Width) / 2, (headerRect.Height - textSize.Height) / 2);
                e.Graphics.DrawString(headerText, font, Brushes.White, textPoint);
            }

            // Draw rounded corners
            GraphicsPath path = new GraphicsPath();
            int radius = cornerRadius;
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddLine(radius, 0, Width - radius, 0);
            path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddLine(Width, radius, Width, Height - radius);
            path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(Width - radius, Height, radius, Height);
            path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(0, Height - radius, 0, radius);
            path.CloseFigure();

            Region = new Region(path);
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_BarTabControl : TabControl
    {
        // Color properties for customization
        public Color BackgroundColor { get; set; } = Color.FromArgb(15, 15, 15);
        public Color TextColor { get; set; } = Color.White;
        public Color AccentColor { get; set; } = Color.FromArgb(250, 36, 38);

        public CrEaTiiOn_BarTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 136);
            Alignment = TabAlignment.Left;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            // Only repaint if there are tabs
            if (TabCount == 0)
                return;

            // Draw each tab
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);

                if (i == SelectedIndex)
                {
                    DrawSelectedTab(g, tabRect);
                }
                else
                {
                    DrawUnselectedTab(g, tabRect);
                }
            }
        }

        private void DrawSelectedTab(Graphics g, Rectangle tabRect)
        {
            // Fill background
            using (Brush bgBrush = new SolidBrush(AccentColor))
            {
                g.FillRectangle(bgBrush, tabRect);
            }

            // Draw gradient background for selected tab
            Rectangle selectedTabRect = new Rectangle(tabRect.X - 2, tabRect.Y - 2, tabRect.Width + 3, tabRect.Height - 1);
            using (LinearGradientBrush lgBrush = new LinearGradientBrush(selectedTabRect, Color.Black, Color.Black, 90f))
            {
                ColorBlend blend = new ColorBlend();
                blend.Colors = new Color[] { AccentColor, AccentColor, AccentColor };
                blend.Positions = new float[] { 0f, 0.5f, 1f };
                lgBrush.InterpolationColors = blend;

                g.FillRectangle(lgBrush, selectedTabRect);
            }

            // Draw arrow
            g.SmoothingMode = SmoothingMode.HighQuality;
            Point[] points = {
                new Point(tabRect.Right - 3, tabRect.Y + 20),
                new Point(tabRect.Right + 4, tabRect.Y + 14),
                new Point(tabRect.Right + 4, tabRect.Y + 27)
            };
            g.DrawLines(new Pen(AccentColor), points);

            // Drawing tab text and images
            if (SelectedIndex >= 0 && SelectedIndex < TabPages.Count)
            {
                if (ImageList != null && ImageList.Images[TabPages[SelectedIndex].ImageIndex] != null)
                {
                    g.DrawImage(ImageList.Images[TabPages[SelectedIndex].ImageIndex], new Point(selectedTabRect.X + 8, selectedTabRect.Y + 6));
                }
                g.DrawString("  " + TabPages[SelectedIndex].Text, Font, new SolidBrush(TextColor), selectedTabRect, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            }
        }

        private void DrawUnselectedTab(Graphics g, Rectangle tabRect)
        {
            // Fill background
            Rectangle unselectedTabRect = new Rectangle(tabRect.X - 2, tabRect.Y - 2, tabRect.Width + 3, tabRect.Height - 1);
            g.FillRectangle(new SolidBrush(BackgroundColor), unselectedTabRect);
            g.DrawLine(new Pen(BackgroundColor), tabRect.Right, tabRect.Top, tabRect.Right, tabRect.Bottom);

            // Drawing tab text and images
            if (SelectedIndex >= 0 && SelectedIndex < TabPages.Count)
            {
                if (ImageList != null && ImageList.Images[TabPages[SelectedIndex].ImageIndex] != null)
                {
                    g.DrawImage(ImageList.Images[TabPages[SelectedIndex].ImageIndex], new Point(tabRect.X + 8, tabRect.Y + 6));
                }
                g.DrawString(TabPages[SelectedIndex].Text, Font, new SolidBrush(TextColor), tabRect, new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
            }
        }
    }
}
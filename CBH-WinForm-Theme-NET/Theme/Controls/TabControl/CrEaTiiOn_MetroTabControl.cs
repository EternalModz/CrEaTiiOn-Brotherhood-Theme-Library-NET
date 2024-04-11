using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_MetroTabControl : TabControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private Color accentColor = Color.FromArgb(250, 36, 38);

        // Property to customize the accent color
        public Color AccentColor
        {
            get { return accentColor; }
            set
            {
                accentColor = value;
                Invalidate(); // Redraw control when accent color changes
            }
        }

        public CrEaTiiOn_MetroTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ItemSize = new Size(0, 34);
            Padding = new Point(24, 0);
            Font = new Font("Segoe UI", 12);
            Alignment = TabAlignment.Top; // Moved setting Alignment to constructor for consistency
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            G.Clear(Parent.BackColor);

            for (int i = 0; i < TabCount; i++) // Removed unnecessary -1 in the loop condition
            {
                Rectangle mainRect = GetTabRect(i);
                Color fontColor = Color.White; // Font color can be set directly

                if (i == SelectedIndex)
                {
                    G.DrawLine(new Pen(AccentColor), new Point(mainRect.X - 2, mainRect.Height - 1), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height - 1));
                    G.DrawLine(new Pen(AccentColor), new Point(mainRect.X - 2, mainRect.Height), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height));
                }
                else
                {
                    G.DrawLine(new Pen(AccentColor), new Point(mainRect.X - 2, mainRect.Height - 1), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height - 1));
                    G.DrawLine(new Pen(AccentColor), new Point(mainRect.X - 2, mainRect.Height), new Point(mainRect.X + mainRect.Width - 2, mainRect.Height));
                }

                if (i != 0)
                {
                    G.DrawLine(new Pen(AccentColor), new Point(mainRect.X - 4, mainRect.Height - 7), new Point(mainRect.X + 4, mainRect.Y + 6));
                }

                int titleX = (mainRect.Location.X + mainRect.Width / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Width / 2));
                int titleY = (mainRect.Location.Y + mainRect.Height / 2) - Convert.ToInt32((G.MeasureString(TabPages[i].Text, Font).Height / 2));
                G.DrawString(TabPages[i].Text, Font, new SolidBrush(fontColor), new Point(titleX, titleY));

                try
                {
                    TabPages[i].BackColor = Parent.BackColor;
                }
                catch
                {
                    // Handle exceptions
                }
            }

            // Set region for rounded corners
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }
    }
}
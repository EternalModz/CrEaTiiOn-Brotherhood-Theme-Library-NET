using System;
using System.Drawing;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_TabControl : TabControl
    {
        // Color properties for customization
        public Color TabColor { get; set; } = Color.FromArgb(15, 15, 15);
        public Color TabTextColor { get; set; } = Color.LightGray;
        public Color SelectedTabColor { get; set; } = Color.FromArgb(25, 25, 25);
        public Color SelectedTabTextColor { get; set; } = Color.White;
        public Color SelectedTabLineColor { get; set; } = Color.FromArgb(250, 36, 38);
        public Color ControlBackgroundColor { get; set; } = Color.FromArgb(15, 15, 15);

        // Property to enable/disable line selection mode
        public bool LineSelectionMode { get; set; } = false;

        public CrEaTiiOn_TabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(150, 30); // Adjust tab size as needed
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Iterate through each tab to draw custom appearance
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle tabRect = GetTabRect(i);
                bool isSelected = SelectedIndex == i;

                // Draw background color
                using (SolidBrush brush = new SolidBrush(isSelected ? SelectedTabColor : TabColor))
                {
                    e.Graphics.FillRectangle(brush, tabRect);
                }

                // Draw tab text
                string tabText = TabPages[i].Text;
                Color textColor = isSelected ? SelectedTabTextColor : TabTextColor; // Use TabTextColor for selected tab
                using (SolidBrush brush = new SolidBrush(textColor))
                {
                    e.Graphics.DrawString(tabText, Font, brush, tabRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }

                // Draw line under the selected tab if LineSelectionMode is enabled
                if (isSelected && LineSelectionMode)
                {
                    using (Pen pen = new Pen(SelectedTabLineColor, 2)) // Use SelectedTabLineColor property
                    {
                        e.Graphics.DrawLine(pen, tabRect.Left, tabRect.Bottom - 2, tabRect.Right, tabRect.Bottom - 2);
                    }
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // Fill control background with specified color
            using (SolidBrush brush = new SolidBrush(ControlBackgroundColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}
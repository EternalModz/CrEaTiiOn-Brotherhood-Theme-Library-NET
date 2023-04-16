#region Imports
using CBH_Ultimate_Theme_Library;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
#endregion

namespace CBH.Controls
{
    public class CrEaTiiOn_ModernGroupBox : ThemeContainer154
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

        public CrEaTiiOn_ModernGroupBox()
        {
            ControlMode = true;
            Header = 26;
            TextColor = Color.White;
            Size = new Size(205, 120);
            Font = new Font("Segoe UI", 8);
            CornerRadius = 15;
            LBlendColor = Color.FromArgb(250, 36, 38);
            GroupBoxBackColor = Color.FromArgb(15, 15, 15);
        }

        private Color _groupBoxBackColor = Color.FromArgb(15, 15, 15);
        public Color GroupBoxBackColor
        {
            get { return _groupBoxBackColor; }
            set { _groupBoxBackColor = value; Invalidate(); }
        }

        protected override void ColorHook()
        {
        }

        private Color _ForeColor;
        public Color TextColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

        private int _cornerRadius;
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; }
        }

        private Color _lBlendColor;
        public Color LBlendColor
        {
            get { return _lBlendColor; }
            set { _lBlendColor = value; }
        }

        protected override void PaintHook()
        {
            ColorBlend LBlend = new ColorBlend();
            ColorBlend LBlend2 = new ColorBlend();

            LBlend.Positions = new float[] {
                0f,
                0.15f,
                0.85f,
                1f
            };

            LBlend2.Positions = new float[] {
                0f,
                0.15f,
                0.5f,
                0.85f,
                1f
            };

            LBlend.Colors = new Color[] {
                Color.Transparent,
                LBlendColor,
                LBlendColor,
                Color.Transparent
            };

            LBlend2.Colors = new Color[] {
                Color.Transparent,
                Color.FromArgb(10, 10, 10),
                LBlendColor,
                Color.FromArgb(10, 10, 10),
                Color.Transparent
            };

            G.Clear(_groupBoxBackColor);

            if (Text == null)
            {
            }
            else
            {
                DrawGradient(LBlend, 0, 23, Width, 1, 0f);
                DrawGradient(LBlend2, 0, 24, Width, 1, 0f);
            }

            G.DrawLine(new Pen(_groupBoxBackColor), 1, 1, Width - 2, 1);

            DrawText(new SolidBrush(TextColor), HorizontalAlignment.Center, 0, 0);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, CornerRadius, CornerRadius));
        }
    }
}
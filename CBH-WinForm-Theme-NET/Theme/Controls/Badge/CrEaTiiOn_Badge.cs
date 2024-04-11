#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CBH.Controls
{
    #region CrEaTiiOn_Badge

    public class CrEaTiiOnBadge : Control
    {
        #region Variables

        private int _value = 0;
        private int _maximum = 99;
        private Color _borderColor = Color.FromArgb(250, 36, 38);
        private Color _bgColorA = Color.FromArgb(15, 15, 15);
        private Color _bgColorB = Color.FromArgb(15, 15, 15);

        #endregion

        #region Properties

        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > _maximum)
                    value = _maximum;

                _value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _maximum;
            set
            {
                if (value < 0)
                    value = 0;

                _maximum = value;
                if (_value > _maximum)
                    _value = _maximum;

                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public Color BGColorA
        {
            get => _bgColorA;
            set { _bgColorA = value; Invalidate(); }
        }

        public Color BGColorB
        {
            get => _bgColorB;
            set { _bgColorB = value; Invalidate(); }
        }

        #endregion

        public CrEaTiiOnBadge()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 8, FontStyle.Bold);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = Width = Math.Max(20, Math.Max(Width, Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            string displayString = _value.ToString();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(Width - 2, Height - 2)), _bgColorA, _bgColorB, 90f))
            {
                // Fills the body with LGB gradient
                g.FillEllipse(lgb, new Rectangle(new Point(1, 1), new Size(Width - 3, Height - 3)));
            }

            // Draw border
            using (Pen borderPen = new Pen(_borderColor))
            {
                g.DrawEllipse(borderPen, new Rectangle(new Point(1, 1), new Size(Width - 3, Height - 3)));
            }

            g.DrawString(displayString, Font, new SolidBrush(ForeColor), new Rectangle(1, 1, Width - 2, Height - 2), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }
    }

    #endregion
}
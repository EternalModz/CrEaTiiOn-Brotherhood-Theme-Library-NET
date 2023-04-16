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

        private int _Value = 0;
        private int _Maximum = 99;
        private Color _BorderColor = Color.FromArgb(250, 36, 38);
        private Color _BGColorA = Color.FromArgb(15, 15, 15);
        private Color _BGColorB = Color.FromArgb(15, 15, 15);

        #endregion

        #region Properties

        public int Value
        {
            get
            {
                if (_Value == 0)
                {
                    return 0;
                }

                return _Value;
            }
            set
            {
                if (value > _Maximum)
                {
                    value = _Maximum;
                }

                _Value = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get => _Maximum;
            set
            {
                if (value < _Value)
                {
                    _Value = value;
                }

                _Maximum = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => _BorderColor;
            set { _BorderColor = value; Invalidate(); }
        }

        public Color BGColorA
        {
            get => _BGColorA;
            set { _BGColorA = value; Invalidate(); }
        }

        public Color BGColorB
        {
            get => _BGColorB;
            set { _BGColorB = value; Invalidate(); }
        }

        #endregion

        public CrEaTiiOnBadge()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
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
            Graphics _G = e.Graphics;
            string myString = _Value.ToString();
            _G.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush LGB = new LinearGradientBrush(new Rectangle(new Point(0, 0), new Size(Width - 2, Height - 2)), _BGColorA, _BGColorB, 90f);

            // Fills the body with LGB gradient
            _G.FillEllipse(LGB, new Rectangle(new Point(1, 1), new Size(Width - 3, Height - 3)));
            // Draw border
            _G.DrawEllipse(new Pen(_BorderColor), new Rectangle(new Point(1, 1), new Size(Width - 3, Height - 3)));
            _G.DrawString(myString, Font, new SolidBrush(ForeColor), new Rectangle(1, 1, Width - 2, Height - 2), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
            e.Dispose();
        }

    }

    #endregion
}

#region Imports
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace CBH.Ultimate.Controls
{
    public class CrEaTiiOn_Ultimate_GradientLabel : Label
    {
        private Color _firstColor = Color.FromArgb(250, 36, 38);
        private Color _secondColor = Color.FromArgb(75, 75, 75);

        [Category("CrEaTiiOn")]
        public string CustomText { get { return Text; } set { Text = value; } }

        [Category("CrEaTiiOn")]
        public override Font Font { get => base.Font; set { base.Font = value; } }

        [Category("CrEaTiiOn")]
        public Color FirstColor
        {
            get => _firstColor;
            set { _firstColor = value; Invalidate(); }
        }

        [Category("CrEaTiiOn")]
        public Color SecondColor
        {
            get => _secondColor;
            set { _secondColor = value; Invalidate(); }
        }

        public CrEaTiiOn_Ultimate_GradientLabel()
        {
            // Double buffer for smoother drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a linear gradient brush
            using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, Width, Height + 5), _firstColor, _secondColor, LinearGradientMode.Horizontal))
            {
                // Draw string using gradient brush
                e.Graphics.DrawString(CustomText, Font, brush, 0, 0);
            }
        }
    }
}
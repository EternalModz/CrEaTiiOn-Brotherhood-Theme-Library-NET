using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_Slider : Control
    {
        private Rectangle barRectangle;
        private bool onHandle;
        private int barThickness = 4;
        private int bigStepIncrement = 10;
        private int max = 100;
        private int percentage = 50;
        private Color filledColor = Color.FromArgb(250, 36, 38);
        private Color knobColor = Color.Gray;

        public CrEaTiiOn_Slider()
        {
            base.Size = new Size(250, 20);
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            barRectangle = new Rectangle(base.Height / 2 + 1, 1, base.Width - base.Height, base.Height - 1);
            Cursor = Cursors.Hand;
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The bar thickness")]
        public int BarThickness
        {
            get => barThickness;
            set
            {
                barThickness = value;
                base.Invalidate();
            }
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The filled color")]
        public Color FilledColor
        {
            get => filledColor;
            set
            {
                filledColor = value;
                base.Invalidate();
            }
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The knob color")]
        public Color KnobColor
        {
            get => knobColor;
            set
            {
                knobColor = value;
                base.Invalidate();
            }
        }

        public event EventHandler Scroll;

        protected virtual void OnScroll()
        {
            Scroll?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int num = Percentage * (base.Width - base.Height) / Max;

            if (e.X > num - base.Height / 2 && e.X < num + base.Height / 2)
            {
                onHandle = true;
                return;
            }

            if (e.X < num - base.Height / 2)
            {
                Percentage -= BigStepIncrement;
                if (Percentage < 0)
                {
                    Percentage = 0;
                }
                base.Invalidate();
                return;
            }

            if (e.X > num + base.Height / 2)
            {
                Percentage += BigStepIncrement;
                if (Percentage > Max)
                {
                    Percentage = Max;
                }
                base.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (onHandle)
            {
                Percentage = (int)Math.Round(Max * e.X / (double)base.Width);
                if (Percentage < 0)
                {
                    Percentage = 0;
                }
                if (Percentage > Max)
                {
                    Percentage = Max;
                }
                base.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            onHandle = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int num = Percentage * (base.Width - base.Height) / Max;
            int knobRadius = base.Height / 2;

            g.Clear(BackColor);

            // Draw filled part of the slider
            g.FillRectangle(new SolidBrush(FilledColor), knobRadius / 2, base.Height / 2 - BarThickness / 2, num, BarThickness);

            // Draw knob
            int knobX = knobRadius / 2 + num;
            int knobY = base.Height / 2 - knobRadius / 2;
            g.FillEllipse(new SolidBrush(KnobColor), knobX, knobY, knobRadius, knobRadius);
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The increment increased or decreased when not clicking in the handle")]
        public int BigStepIncrement
        {
            get => bigStepIncrement;
            set
            {
                bigStepIncrement = value;
                base.Invalidate();
            }
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The default percentage")]
        public int Percentage
        {
            get => percentage;
            set
            {
                percentage = value;
                OnScroll();
                base.Invalidate();
            }
        }

        [Category("CrEaTiiOn")]
        [Browsable(true)]
        [Description("The max percentage")]
        public int Max
        {
            get => max;
            set
            {
                max = value;
                OnScroll();
                base.Invalidate();
            }
        }
    }
}

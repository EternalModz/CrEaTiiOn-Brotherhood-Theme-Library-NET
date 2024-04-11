using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CBH_WinForm_Theme_Library_NET
{
    internal class CrEaTiiOn_RadioButton : Control
    {
        private bool isChecked;

        // Properties for customization
        public Color HighlightColor { get; set; }
        public Color BaseColor { get; set; }
        public Color InnerRingColor { get; set; }
        public string Text { get; set; }

        // Property for checked state
        public bool Checked
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value && value)
                {
                    // Uncheck other radio buttons in the same container
                    UncheckOtherRadioButtons();
                }

                isChecked = value;
                Invalidate();
            }
        }

        // Constructor
        public CrEaTiiOn_RadioButton()
        {
            // Default color values
            HighlightColor = Color.FromArgb(250, 36, 38);
            BaseColor = Color.FromArgb(15, 15, 15);
            InnerRingColor = Color.White;

            // Default size and checked state
            Size = new Size(190, 20);
            isChecked = false;

            // Default text
            Text = "RadioButton";
        }

        // Override for painting the control
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Determine the color based on the checked state
            Color currentColor = isChecked ? HighlightColor : BaseColor;

            // Draw the main filled circle
            using (var brush = new SolidBrush(currentColor))
            {
                // Draw a filled circle with anti-aliasing
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(brush, 0, 0, Height - 1, Height - 1);
            }

            if (isChecked)
            {
                // Draw the inner filled circle when checked
                using (var brush = new SolidBrush(InnerRingColor))
                {
                    // Draw a filled ellipse for the inner circle
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(brush, 4, 4, Height - 9, Height - 9);
                }
            }

            using (var textBrush = new SolidBrush(ForeColor))
            {
                // Adjusted the gap between text and circles
                e.Graphics.DrawString(Text, Font, textBrush, Height + 5, (Height - Font.Height) / 2);
            }
        }

        // Override for handling click events
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            // Toggle the checked state on click
            Checked = !Checked;
        }

        // Uncheck other radio buttons in the same container
        private void UncheckOtherRadioButtons()
        {
            // Get the parent container
            Control container = Parent;

            // Check if the container is not null and is a Form or Panel, adjust as needed
            while (container != null && !(container is Form || container is Panel))
            {
                container = container.Parent;
            }

            // If a valid container is found, uncheck other radio buttons
            if (container != null)
            {
                foreach (var control in container.Controls.OfType<CrEaTiiOn_RadioButton>())
                {
                    if (control != this)
                    {
                        control.Checked = false;
                    }
                }
            }
        }
    }
}

#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace CBH.Controls
{
    #region CrEaTiiOn_ModernTabPage

    public class CrEaTiiOn_ModernTabPage : TabControl
    {
        public SmoothingMode SmoothingType { get; set; } = SmoothingMode.HighSpeed;
        public CompositingQuality CompositingQualityType { get; set; } = CompositingQuality.HighSpeed;
        public CompositingMode CompositingType { get; set; } = CompositingMode.SourceOver;
        public InterpolationMode InterpolationType { get; set; } = InterpolationMode.HighQualityBicubic;
        public StringAlignment StringType { get; set; } = StringAlignment.Near;
        public Color FrameColor { get; set; } = Color.FromArgb(20, 20, 20);
        public Color PageColor { get; set; } = Color.FromArgb(20, 20, 20);
        public Color ActiveForeColor { get; set; } = Color.FromArgb(250, 36, 38);
        public Color NormalForeColor { get; set; } = Color.White;
        public Color ControlBackColor { get; set; } = Color.FromArgb(15, 15, 15);
        public Color LineColor { get; set; } = Color.FromArgb(250, 36, 38);
        public Color ActiveTabColor { get; set; } = Color.FromArgb(15, 15, 15);
        public Color TabColor { get; set; } = Color.FromArgb(20, 20, 20);
        public Color ActiveLineTabColor { get; set; } = Color.FromArgb(250, 36, 38);
        public Color LineTabColor { get; set; } = Color.FromArgb(20, 20, 20);

        public CrEaTiiOn_ModernTabPage()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 135);
            DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is CrEaTiiOn_ModernTabPage)
            {
                foreach (Control control in Controls)
                {
                    if (control is CrEaTiiOn_ModernTabPage tabPage)
                    {
                        tabPage.BackColor = FrameColor;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(FrameColor);
                    graphics.SmoothingMode = SmoothingType;
                    graphics.CompositingQuality = CompositingQualityType;
                    graphics.CompositingMode = CompositingType;

                    // Draw tab selector background
                    graphics.FillRectangle(new SolidBrush(ControlBackColor), new Rectangle(-5, 0, ItemSize.Height + 4, Height));
                    // Draw vertical line at the end of the tab selector rectangle
                    graphics.DrawLine(new Pen(LineColor), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

                    for (int tabIndex = 0; tabIndex < TabCount; tabIndex++)
                    {
                        Rectangle tabRect = GetTabRect(tabIndex);

                        if (tabIndex == SelectedIndex)
                        {
                            Rectangle tabHighlighter = new Rectangle(tabRect.X - 2, tabRect.Y - (tabIndex == 0 ? 1 : 1), 4, tabRect.Height - 7);

                            // Draw background of the selected tab
                            graphics.FillRectangle(new SolidBrush(ActiveTabColor), tabRect.X, tabRect.Y, tabRect.Width - 4, tabRect.Height + 3);
                            // Draw a tab highlighter on the background of the selected tab
                            graphics.FillRectangle(new SolidBrush(ActiveLineTabColor), tabHighlighter);
                            // Draw tab text
                            graphics.DrawString(TabPages[tabIndex].Text, Font, new SolidBrush(ActiveForeColor), new Rectangle(tabRect.Left + 40, tabRect.Top + 8, tabRect.Width - 40, tabRect.Height), new StringFormat { Alignment = StringType });

                            if (ImageList != null && TabPages[tabIndex].ImageIndex != -1)
                            {
                                graphics.DrawImage(ImageList.Images[TabPages[tabIndex].ImageIndex], tabRect.X + 9, tabRect.Y + 6, 24, 24);
                            }
                        }
                        else
                        {
                            Rectangle tabHighlighter = new Rectangle(tabRect.X - 2, tabRect.Y - (tabIndex == 0 ? 1 : 1), 4, tabRect.Height - 7);

                            // Draw background of the tab
                            graphics.FillRectangle(new SolidBrush(TabColor), tabRect.X, tabRect.Y, tabRect.Width - 4, tabRect.Height + 3);
                            // Draw a tab highlighter on the background of the tab
                            graphics.FillRectangle(new SolidBrush(LineTabColor), tabHighlighter);

                            graphics.DrawString(TabPages[tabIndex].Text, Font, new SolidBrush(NormalForeColor), new Rectangle(tabRect.Left + 40, tabRect.Top + 8, tabRect.Width - 40, tabRect.Height), new StringFormat { Alignment = StringType });

                            if (ImageList != null && TabPages[tabIndex].ImageIndex != -1)
                            {
                                graphics.DrawImage(ImageList.Images[TabPages[tabIndex].ImageIndex], tabRect.X + 9, tabRect.Y + 6, 24, 24);
                            }
                        }
                    }
                }

                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.InterpolationMode = InterpolationType;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.DrawImage(bitmap, 0, 0);
            }

            foreach (TabPage page in TabPages)
            {
                page.BackColor = PageColor;
            }
        }
    }

    #endregion
}
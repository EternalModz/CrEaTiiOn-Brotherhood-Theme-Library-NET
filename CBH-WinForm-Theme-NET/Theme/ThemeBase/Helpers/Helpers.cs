#region Imports
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace CBH_Ultimate_Theme_Library.Theme.Helpers
{
    #region Transparent
    public class Transparenter
    {
        public static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }
    }
    #endregion 

    #region Draw Helpers
    public static class DrawHelper
    {
        public static GraphicsPath CreateRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2));
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);

            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }
        public static GraphicsPath CreateUpRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2) + 1);
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, 2, 0, 90);

            gp.AddLine(x + width, y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2) + 1, radius * 2, 1, 90, 90);

            gp.AddLine(x, y + height, x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }
        public static GraphicsPath CreateLeftRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y);
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);

            gp.AddLine(x + width, y + 0, x + width, y + height);
            gp.AddArc(x + width - (radius * 2), y + height - (1), radius * 2, 1, 0, 90);

            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);

            gp.AddLine(x, y + height - (radius * 2), x, y + radius);
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            gp.CloseFigure();
            return gp;
        }
        public static Color BlendColor(Color backgroundColor, Color frontColor)
        {
            double ratio = 0 / 255d;
            double invRatio = 1d - ratio;
            int r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            int g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            int b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(r, g, b);
        }

        public static Color BackColor = ColorTranslator.FromHtml("#dadcdf");//bcbfc4
        public static Color DarkBackColor = ColorTranslator.FromHtml("#90949a");
        public static Color LightBackColor = ColorTranslator.FromHtml("#F5F5F5");
    }
    #endregion

    #region String Alignment Helpers
    public static class StringAlign
    {
        /// <summary>
        /// 左上
        /// </summary>
        public static StringFormat TopLeft { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 中上
        /// </summary>
        public static StringFormat TopCenter { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 右上
        /// </summary>
        public static StringFormat TopRight { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 左中
        /// </summary>
        public static StringFormat Left { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 正中
        /// </summary>
        public static StringFormat Center { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 右中
        /// </summary>
        public static StringFormat Right { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 左下
        /// </summary>
        public static StringFormat BottomLeft { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far }; }
        /// <summary>
        /// 中下
        /// </summary>
        public static StringFormat BottomCenter { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far }; }
        /// <summary>
        /// 右下
        /// </summary>
        public static StringFormat BottomRight { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far }; }
    }
    #endregion

    #region External Utilities
    internal class Adjustments
    {

        //Default FontFamily that will be used throughout the entire theme
        public static readonly FontFamily DefaultFontFamily = new FontFamily("Segoe UI");

        //Roundness of the corners of most controls. Higher = more circular
        public static readonly int Roundness = 4;

    }

    internal class DrawingHelper
    {

        public enum RoundingStyle
        {
            All,
            Top,
            Bottom,
            Left,
            Right
        }

        public GraphicsPath RoundRect(Rectangle rect, int slope, RoundingStyle style = RoundingStyle.All)
        {

            GraphicsPath gp = new GraphicsPath();
            int arcWidth = slope * 2;

            switch (style)
            {
                case RoundingStyle.All:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Top:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddLine(new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X, rect.Y + rect.Height));
                    break;
                case RoundingStyle.Bottom:
                    gp.AddLine(new Point(rect.X, rect.Y), new Point(rect.X + rect.Width, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Left:
                    gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180F, 90F);
                    gp.AddLine(new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90F, 90F);
                    break;
                case RoundingStyle.Right:
                    gp.AddLine(new Point(rect.X, rect.Y + rect.Height), new Point(rect.X, rect.Y));
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90F, 90F);
                    gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0F, 90F);
                    break;
            }

            gp.CloseAllFigures();

            return gp;

        }

        public enum ColorAdjustmentType
        {
            Lighten,
            Darken
        }

        public Color AdjustColor(Color c, int intensity, ColorAdjustmentType adjustment, bool keepAlpha = true)
        {

            int r = 0;
            int g = 0;
            int b = 0;

            if (intensity < 1)
            {
                intensity = 1;
            }
            else if (intensity > 255)
            {
                intensity = 255;
            }

            if (adjustment == ColorAdjustmentType.Lighten)
            {
                r = Convert.ToInt32(IncrementValue(c.R, intensity));
                g = Convert.ToInt32(IncrementValue(c.G, intensity));
                b = Convert.ToInt32(IncrementValue(c.B, intensity));
            }
            else
            {
                r = Convert.ToInt32(DecrementValue(c.R, intensity));
                g = Convert.ToInt32(DecrementValue(c.G, intensity));
                b = Convert.ToInt32(DecrementValue(c.B, intensity));
            }

            if (keepAlpha)
            {
                return Color.FromArgb(c.A, r, g, b);
            }
            else
            {
                return Color.FromArgb(255, r, g, b);
            }


        }

        private object IncrementValue(int initialValue, int intensity, int maximum = 255)
        {
            if (initialValue + intensity < maximum)
            {
                return initialValue + intensity;
            }
            else
            {
                return maximum;
            }
        }

        private object DecrementValue(int initialValue, int intensity, int minimum = 0)
        {
            if (initialValue - intensity > minimum)
            {
                return initialValue - intensity;
            }
            else
            {
                return minimum;
            }
        }

    }

    internal class MultiLineHandler
    {

        public List<string> GetLines(Graphics g, string str, Font font, int maxLength)
        {

            List<string> result = new List<string>();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            str = str.Replace("\r", "").Replace("\n", "");

            string[] words = null;
            if (str.Contains(" "))
            {
                words = str.Replace(Environment.NewLine, null).Split(' ');
            }
            else
            {
                result.Add(str);
                return result;
            }

            for (var i = 0; i < words.Length; i++)
            {

                if (i == words.Length - 1)
                {
                    if (g.MeasureString(sb.ToString() + " " + words[i], font).Width < maxLength)
                    {
                        sb.Append(words[i]);
                        result.Add(sb.ToString());
                    }
                    else
                    {
                        result.Add(sb.ToString());
                        result.Add(words[i]);
                    }
                }
                else if (g.MeasureString(sb.ToString() + " " + words[i], font).Width > maxLength)
                {
                    result.Add(sb.ToString());
                    sb.Clear();
                    sb.Append(words[i] + " ");
                }
                else
                {
                    sb.Append(words[i] + " ");
                }

            }

            return result;

        }

    }
    #endregion

    #region External Helpers
    static class Drawing
    {

        public static GraphicsPath RoundRect(Rectangle rect, int slope)
        {
            GraphicsPath gp = new GraphicsPath();
            int arcWidth = slope * 2;
            gp.AddArc(new Rectangle(rect.X, rect.Y, arcWidth, arcWidth), -180, 90);
            gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Y, arcWidth, arcWidth), -90, 90);
            gp.AddArc(new Rectangle(rect.Width - arcWidth + rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 0, 90);
            gp.AddArc(new Rectangle(rect.X, rect.Height - arcWidth + rect.Y, arcWidth, arcWidth), 90, 90);
            gp.CloseAllFigures();
            return gp;
        }

    }

    public static class Prevent
    {

        public static void Prevents(Graphics g, int w, int h)
        {
            string txt = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("VGhlbWUlMjBjcmVhdGVkJTIwYnklMjBIYXdrJTIwSEY=")).Replace("%20", " ");
            Size txtSize = new Size(Convert.ToInt32(g.MeasureString(txt, new Font("Segoe UI", 8)).Width), Convert.ToInt32(g.MeasureString(txt, new Font("Segoe UI", 8)).Height));
            g.DrawString(txt, new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(15, 15, 15)), new Point(w - txtSize.Width - 6, h - txtSize.Height - 4));
        }

    }
    #endregion

    #region Theme Containers
    [ToolboxItem(false)]
    public class ASCThemeContainer : ContainerControl
    {

        private int moveHeight = 38;
        private bool formCanMove = false;
        private int mouseX;
        private int mouseY;
        private bool overExit;

        private bool overMin;
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }

        public ASCThemeContainer()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Dock = DockStyle.Fill;
            Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Italic);
            BackColor = Color.FromArgb(15, 15, 15);
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
            if (Parent.FindForm().TransparencyKey == null)
                Parent.FindForm().TransparencyKey = Color.Fuchsia;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.Clear(Parent.FindForm().TransparencyKey);

            int slope = 8;

            Rectangle mainRect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath mainPath = Drawing.RoundRect(mainRect, slope);
            G.FillPath(new SolidBrush(BackColor), mainPath);
            G.DrawPath(new Pen(Color.FromArgb(30, 35, 45)), mainPath);
            G.FillPath(new SolidBrush(Color.FromArgb(30, 30, 40)), Drawing.RoundRect(new Rectangle(0, 0, Width - 1, moveHeight - slope), slope));
            G.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 40)), new Rectangle(0, moveHeight - (slope * 2), Width - 1, slope * 2));
            G.DrawLine(new Pen(Color.FromArgb(60, 60, 60)), new Point(1, moveHeight), new Point(Width - 2, moveHeight));
            G.SmoothingMode = SmoothingMode.HighQuality;

            int textX = 6;
            int textY = (moveHeight / 2) - Convert.ToInt32((G.MeasureString(Text, Font).Height / 2)) + 1;
            Size textSize = new Size(Convert.ToInt32(G.MeasureString(Text, Font).Width), Convert.ToInt32(G.MeasureString(Text, Font).Height));
            Rectangle textRect = new Rectangle(textX, textY, textSize.Width, textSize.Height);
            LinearGradientBrush textBrush = new LinearGradientBrush(textRect, Color.FromArgb(185, 190, 195), Color.FromArgb(125, 125, 125), 90f);
            G.DrawString(Text, Font, textBrush, new Point(textX, textY));

            if (overExit)
            {
                G.DrawString("r", new Font("Marlett", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(25, 100, 140)), new Point(Width - 27, 11));
            }
            else
            {
                G.DrawString("r", new Font("Marlett", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(205, 210, 215)), new Point(Width - 27, 11));
            }
            if (overMin)
            {
                G.DrawString("0", new Font("Marlett", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(25, 100, 140)), new Point(Width - 47, 10));
            }
            else
            {
                G.DrawString("0", new Font("Marlett", 12, FontStyle.Bold), new SolidBrush(Color.FromArgb(205, 210, 215)), new Point(Width - 47, 10));
            }

            if (DesignMode)

                Prevent.Prevents(G, Width, Height);

        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (formCanMove == true)
            {
                Parent.FindForm().Location = new Point(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }

            if (e.Y > 11 && e.Y < 24)
            {
                if (e.X > Width - 23 && e.X < Width - 10)
                    overExit = true;
                else
                    overExit = false;
                if (e.X > Width - 44 && e.X < Width - 31)
                    overMin = true;
                else
                    overMin = false;
            }
            else
            {
                overExit = false;
                overMin = false;
            }

            Invalidate();

        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            mouseX = e.X;
            mouseY = e.Y;

            if (e.Y <= moveHeight && overExit == false && overMin == false)
                formCanMove = true;

            if (overExit)
            {
                Parent.FindForm().Close();
            }
            else if (overMin)
            {
                Parent.FindForm().WindowState = FormWindowState.Minimized;
                overExit = false;
                overMin = false;
            }
            else
            {
                Focus();
            }

            Invalidate();

        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);
            formCanMove = false;
        }

    }
    #endregion
}
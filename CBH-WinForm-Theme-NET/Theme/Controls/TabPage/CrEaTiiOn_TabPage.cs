using System;
using System.Drawing;
using System.Windows.Forms;

namespace CBH.Controls
{
    public class CrEaTiiOn_TabPage : TabControl
    {
        private Color _squareColor = Color.FromArgb(250, 36, 38);
        private bool _showOuterBorders = false;

        public CrEaTiiOn_TabPage()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 115);
            Alignment = TabAlignment.Left;
        }

        public Color SquareColor
        {
            get { return _squareColor; }
            set
            {
                _squareColor = value;
                Invalidate();
            }
        }

        public bool ShowOuterBorders
        {
            get { return _showOuterBorders; }
            set
            {
                _showOuterBorders = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Only repaint if there are tabs
            if (TabCount == 0)
                return;

            using (Bitmap bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.FromArgb(20, 20, 20));

                    for (int i = 0; i < TabCount; i++)
                    {
                        Rectangle tabRect = GetTabRect(i);
                        Rectangle tabRectWithBorders = new Rectangle(new Point(tabRect.Location.X - 2, tabRect.Location.Y - 2), new Size(tabRect.Width + 3, tabRect.Height - 1));
                        Rectangle textRectangle = new Rectangle(tabRectWithBorders.Location.X + 20, tabRectWithBorders.Location.Y, tabRectWithBorders.Width - 20, tabRectWithBorders.Height);

                        if (i == SelectedIndex)
                        {
                            graphics.FillRectangle(new SolidBrush(_squareColor), new Rectangle(tabRectWithBorders.Location, new Size(9, tabRectWithBorders.Height)));

                            if (ImageList != null && ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                graphics.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textRectangle.Location.X + 8, textRectangle.Location.Y + 6));
                            }

                            graphics.DrawString("      " + TabPages[i].Text, Font, Brushes.White, textRectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                        else
                        {
                            if (ImageList != null && ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                graphics.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textRectangle.Location.X + 8, textRectangle.Location.Y + 6));
                            }

                            graphics.DrawString(TabPages[i].Text, Font, Brushes.White, textRectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }

                        if (_showOuterBorders)
                        {
                            graphics.DrawRectangle(Pens.White, tabRectWithBorders);
                        }
                    }
                }

                e.Graphics.DrawImage(bitmap, 0, 0);
            }
        }
    }
}
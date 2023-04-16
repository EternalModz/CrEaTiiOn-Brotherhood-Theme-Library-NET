using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CrEaTiiOn_Panel : Panel
{
    private int _cornerRadius = 5;
    private Color _gradientColor1 = Color.FromArgb(15, 15, 15);
    private Color _gradientColor2 = Color.FromArgb(15, 15, 15);
    private LinearGradientMode _gradientMode = LinearGradientMode.Vertical;
    private float[] _gradientPositions = new float[] { 0.0f, 1.0f };

    public int CornerRadius
    {
        get { return _cornerRadius; }
        set
        {
            _cornerRadius = value;
            Invalidate();
        }
    }

    public Color GradientColor1
    {
        get { return _gradientColor1; }
        set
        {
            _gradientColor1 = value;
            Invalidate();
        }
    }

    public Color GradientColor2
    {
        get { return _gradientColor2; }
        set
        {
            _gradientColor2 = value;
            Invalidate();
        }
    }

    public LinearGradientMode GradientMode
    {
        get { return _gradientMode; }
        set
        {
            _gradientMode = value;
            Invalidate();
        }
    }

    public float[] GradientPositions
    {
        get { return _gradientPositions; }
        set
        {
            _gradientPositions = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        RectangleF rect = new RectangleF(0, 0, Width, Height);
        using (GraphicsPath path = GetRoundedRect(rect, _cornerRadius))
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, _gradientColor1, _gradientColor2, _gradientMode))
            {
                brush.InterpolationColors = new ColorBlend
                {
                    Colors = new Color[] { _gradientColor1, _gradientColor2 },
                    Positions = _gradientPositions
                };
                e.Graphics.FillPath(brush, path);
            }
        }
    }

    private GraphicsPath GetRoundedRect(RectangleF rect, float cornerRadius)
    {
        GraphicsPath roundedRect = new GraphicsPath();
        roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
        roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
        roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
        roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Bottom - cornerRadius * 2);
        roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
        roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
        roundedRect.AddArc(rect.X, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
        roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
        roundedRect.CloseFigure();
        return roundedRect;
    }
}

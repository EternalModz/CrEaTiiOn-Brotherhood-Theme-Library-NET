#region Imports


#endregion

namespace CBH.Controls
{
    #region Label3

    public class CrEaTiiOn_ModernLabel : System.Windows.Forms.Label
    {
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public CrEaTiiOn_ModernLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Font = new("Segoe UI", 8);
            ForeColor = Color.LightGray;
            BackColor = Color.Transparent;
            Text = Text;
        }
    }

    #endregion
}
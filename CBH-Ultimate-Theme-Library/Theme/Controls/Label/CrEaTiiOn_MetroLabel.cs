namespace CBH.Controls
{
    public class CrEaTiiOn_MetroLabel : Label
    {
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        public CrEaTiiOn_MetroLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Font = new Font("Segoe UI", 10);
            ForeColor = Color.White;
            BackColor = Color.Transparent;
            Text = Text;
        }
    }
}
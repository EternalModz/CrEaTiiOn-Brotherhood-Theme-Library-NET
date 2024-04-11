#region Imports
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
#endregion

namespace CBH.Controls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class CrEaTiiOn_ComboBox : UserControl
    {
        // Fields
        private Color backColor = Color.FromArgb(20, 20, 20);
        private Color iconColor = Color.FromArgb(250, 36, 38);
        private Color listBackColor = Color.FromArgb(15, 15, 15);
        private Color listTextColor = Color.Silver;
        private Color borderColor = Color.FromArgb(250, 36, 38);
        private int borderSize = 1;

        // Items
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        // Events
        public event EventHandler OnSelectedIndexChanged;

        // Constructor
        public CrEaTiiOn_ComboBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Initialize controls
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();

            // Set control properties
            this.SuspendLayout();

            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cmbList.TextChanged += ComboBox_TextChanged;

            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += Icon_Click;
            btnIcon.Paint += Icon_Paint;

            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10F);
            lblText.Click += Surface_Click;
            lblText.MouseEnter += Surface_MouseEnter;
            lblText.MouseLeave += Surface_MouseLeave;

            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            base.BackColor = borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        // Properties
        [Category("CrEaTiiOn")]
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }

        [Category("CrEaTiiOn")]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }

        [Category("CrEaTiiOn")]
        public Color ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }

        [Category("CrEaTiiOn")]
        public Color ListTextColor
        {
            get { return listTextColor; }
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }

        [Category("CrEaTiiOn")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }

        [Category("CrEaTiiOn")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Padding = new Padding(borderSize);
                AdjustComboBoxDimensions();
            }
        }

        // Other properties remain as they are...

        // Private methods
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }

        // Event methods
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged?.Invoke(sender, e);
            lblText.Text = cmbList.Text;
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        // Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
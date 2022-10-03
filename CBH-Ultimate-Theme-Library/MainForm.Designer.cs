namespace CBH_Ultimate_Theme_Library
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CBH.Controls.CrEaTiiOn_ExtendedFileSystemWatcher extendedFileSystemWatcher1;
        private CBH.Controls.CrEaTiiOn_ControlBox crEaTiiOn_ControlBox1;
        private Zeroit.CBH.Controls.CrEaTiiOn_FlatControlBox crEaTiiOn_FlatControlBox1;
    }
}
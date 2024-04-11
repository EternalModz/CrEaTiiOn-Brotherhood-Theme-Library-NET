using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CBH_WinForm_Theme_Library_NET
{
    public class CrEaTiiOn_Form : Form
    {
        #region SYSTEM THEME STATUS
        private class SystemTheme
        {
            public static int Status()  //  0 : dark theme  / 1 : light theme / -1 : AppsUseLightTheme could not be found
            {
                string keyName = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
                try { return (int)Registry.GetValue(keyName, "AppsUseLightTheme", -1); }
                catch { return -1; }
            }
        }
        #endregion

        #region Properties
        private SystemMode systemMode;

        [Category("Misc")]
        public SystemMode SystemAdaptiveMode
        {
            get { return systemMode; }
            set
            {
                systemMode = value;
                ApplyTheme();
            }
        }

        public enum SystemMode
        {
            Dark,
            Light,
            System
        }
        #endregion

        #region Constructor
        public CrEaTiiOn_Form()
        {
            // Set the initial theme based on the system theme
            SystemAdaptiveMode = SystemMode.System;

            // Subscribe to the system theme change event
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;

            // Check if the form is in design mode before applying changes
            if (!DesignMode)
            {
                // Allow the form to be dragged from the title bar only during runtime
                MouseDown += Form_MouseDown;
            }
        }
        #endregion

        #region Theme Methods
        private void ApplyTheme()
        {
            switch (SystemAdaptiveMode)
            {
                case SystemMode.Dark:
                    SetDarkMode(true);
                    break;

                case SystemMode.Light:
                    SetDarkMode(false);
                    break;

                case SystemMode.System:
                    SetDarkMode(SystemTheme.Status() == 0);
                    break;
            }
        }

        private void SetDarkMode(bool enable)
        {
            DarkTitle.ChangeTitleBarToDark(Handle, enable);

            if (enable)
            {
                BackColor = Color.FromArgb(32, 32, 32);
                ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                BackColor = Color.FromArgb(255, 255, 255);
                ForeColor = Color.FromArgb(0, 0, 0);
            }

            // Refresh the form to apply changes
            Invalidate();
        }
        #endregion

        #region Event Handlers
        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General)
            {
                // System theme setting changed, update the form color
                ApplyTheme();
            }
        }

        // Event handler to handle form dragging during runtime
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region PInvoke
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        #endregion

        #region Windows Default Location Handling
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // If StartPosition is set to WindowsDefaultLocation and not in design mode, adjust the location
            if (StartPosition == FormStartPosition.WindowsDefaultLocation && !DesignMode)
            {
                base.SetBoundsCore(x, y, width, height, specified);
                CenterToScreen();
            }
            else
            {
                base.SetBoundsCore(x, y, width, height, specified);
            }
        }
        #endregion
    }

    internal static class DarkTitle
    {
        [DllImport("DwmApi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        internal static void ChangeTitleBarToDark(IntPtr handle, bool enable)
        {
            var attributes = enable ? new[] { 1 } : new[] { 0 };

            DwmSetWindowAttribute(handle, 19, attributes, 4);
            DwmSetWindowAttribute(handle, 20, attributes, 4);
        }
    }
}
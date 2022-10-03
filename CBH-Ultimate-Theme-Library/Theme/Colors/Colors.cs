using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBH_Ultimate_Theme_Library.Theme.Colors
{
    #region CrownColors

    public sealed class CrownColors
    {
        public Color GreyBackground { get; set; }

        public Color HeaderBackground { get; set; }

        public Color BlueBackground { get; set; }

        public Color DarkBlueBackground { get; set; }

        public Color DarkBackground { get; set; }

        public Color MediumBackground { get; set; }

        public Color LightBackground { get; set; }

        public Color LighterBackground { get; set; }

        public Color LightestBackground { get; set; }

        public Color LightBorder { get; set; }

        public Color DarkBorder { get; set; }

        public Color LightText { get; set; }

        public Color DisabledText { get; set; }

        public Color BlueHighlight { get; set; }

        public Color BlueSelection { get; set; }

        public Color GreyHighlight { get; set; }

        public Color GreySelection { get; set; }

        public Color DarkGreySelection { get; set; }

        public Color DarkBlueBorder { get; set; }

        public Color LightBlueBorder { get; set; }

        public Color ActiveControl { get; set; }
    }

    #endregion

    #region HopeColors

    public static class HopeColors
    {
        public static Color DefaultColor = ColorTranslator.FromHtml("#ffffff");

        public static Color PrimaryColor = ColorTranslator.FromHtml("#409eff");
        public static Color LightPrimary = ColorTranslator.FromHtml("#5cadff");
        public static Color DarkPrimary = ColorTranslator.FromHtml("#2b85e4");

        public static Color Success = ColorTranslator.FromHtml("#67c23a");
        public static Color Warning = ColorTranslator.FromHtml("#e6a23c");
        public static Color Danger = ColorTranslator.FromHtml("#f56c6c");
        public static Color Info = ColorTranslator.FromHtml("#909399");

        public static Color MainText = ColorTranslator.FromHtml("#303133");
        public static Color RegularText = ColorTranslator.FromHtml("#606266");
        public static Color SecondaryText = ColorTranslator.FromHtml("#909399");
        public static Color PlaceholderText = ColorTranslator.FromHtml("#c0c4cc");

        public static Color OneLevelBorder = ColorTranslator.FromHtml("#dcdfe6");
        public static Color TwoLevelBorder = ColorTranslator.FromHtml("#e4e7ed");
        public static Color ThreeLevelBorder = ColorTranslator.FromHtml("#ebeef5");
        public static Color FourLevelBorder = ColorTranslator.FromHtml("#f2f6fc");
    }

    #endregion

    #region PoisonColors

    public sealed class PoisonColors
    {
        public static Color Black => Color.FromArgb(0, 0, 0);

        public static Color White => Color.FromArgb(255, 255, 255);

        public static Color Silver => Color.FromArgb(85, 85, 85);

        public static Color Blue => Color.FromArgb(0, 174, 219);

        public static Color Green => Color.FromArgb(0, 177, 89);

        public static Color Lime => Color.FromArgb(142, 188, 0);

        public static Color Teal => Color.FromArgb(0, 170, 173);

        public static Color Orange => Color.FromArgb(243, 119, 53);

        public static Color Brown => Color.FromArgb(165, 81, 0);

        public static Color Pink => Color.FromArgb(231, 113, 189);

        public static Color Magenta => Color.FromArgb(255, 0, 148);

        public static Color Purple => Color.FromArgb(124, 65, 153);

        public static Color Red => Color.FromArgb(209, 17, 65);

        public static Color Yellow => Color.FromArgb(255, 196, 37);

        private static Color _custom = Color.FromArgb(225, 195, 143);

        public static Color Custom
        {
            get => _custom;
            set => _custom = value;
        }
    }

    #endregion

    #region RoyalColors

    public static class RoyalColors
    {
        private static Color foreColor = Color.FromArgb(31, 31, 31);
        public static Color ForeColor
        {
            get => foreColor;
            set => foreColor = value;
        }

        private static Color backColor = Color.FromArgb(243, 243, 243);
        public static Color BackColor
        {
            get => backColor;
            set => backColor = value;
        }

        private static Color borderColor = Color.FromArgb(180, 180, 180);
        public static Color BorderColor
        {
            get => borderColor;
            set => borderColor = value;
        }

        private static Color hotTrackColor = Color.FromArgb(221, 221, 221);
        public static Color HotTrackColor
        {
            get => hotTrackColor;
            set => hotTrackColor = value;
        }

        private static Color accentColor = Color.FromArgb(51, 102, 255);
        public static Color AccentColor
        {
            get => accentColor;
            set => accentColor = value;
        }

        private static Color pressedForeColor = Color.White;
        public static Color PressedForeColor
        {
            get => pressedForeColor;
            set => pressedForeColor = value;
        }

        private static Color pressedBackColor = accentColor;
        public static Color PressedBackColor
        {
            get => pressedBackColor;
            set => pressedBackColor = value;
        }
    }

    #endregion
}

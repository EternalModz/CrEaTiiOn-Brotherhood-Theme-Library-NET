# CrEaTiiOn-Brotherhood-Official-C-Theme
The official WinForms theme for CrEaTiiOn Brotherhood &amp; UltimateCraft

# What does the theme include?
The theme includes many controls to make modern and fabulous looking UIs. Each component has been checked and tested for optimal performance. The theme includes over 100 controls. Each one has been fine tuned to match the color flow of CrEaTiiOn Brotherhood and UltimateCraft. Different types of controls are sorted by name and have been categorized by visual appearance.

# Coloring system
- Our default accent color is red, RGB: 250, 36, 38
- For background colors, we use different shades of dark gray
- Text coloring is usualy white or something close to white

# Updates and bugs
The theme will be updated a lot in the future. Since it is in it’s early stages, there may be some inconsistencies and problems. Make sure to let me know if you have any questions or if you have any bugs to report. There’s also a GitHub issues tab where you can request for bug fixes and give feedback.

# Supported .NET versions
The theme supports C# 9+. Any version of .NET that supports C# 9+ will work with the theme. .NET Core and .NET Standard 6.0+ versions also work well with the theme. For .NET Framework, the CPROJ file must be edited. .NET Framework does not support C# 9+ by default. So the CPROJ file must be edited so that the solution supports higher versions of the language.

Steps for adding updating the CPROJ file (for .NET Framework ONLY)

Step 1: Locate the CPROJ file in the solution folder of the project that you want to use the theme in.

Step 2: Open the CPROJ filein a text editor such as the Notepad.

Step 3: Locate the first line under the base project and paste in the code below.

Step 4: Save the file and your done!

Here is the code that is needed for the CPROJ.
```XML
 <PropertyGroup>
   <LangVersion>10</LangVersion>
 </PropertyGroup>
```

This is how it should look.
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <LangVersion>10</LangVersion>
```

Keep in mind that C# 9 is the minimum version that is needed for the theme to work. The "10" in the code above can be changed to another C# version number as long as it is C# 9 or higher.

# How to use the theme
It’s quite simple to get the theme up and running. As long as the project supports C# 10 and above, it should work. 

Step 1: Download the latest version of the theme.
Step 2: Unpack the ZIP file and extract it to the desktop or to any location where it can be found easily.
Step 3: Open the extracted folder and locate the folder with the name “Theme.”
Step 4: Copy that folder or drag and drop it inside of the visual studio project. NOTE: It must be inserted into the project folder using Visual Studio itself. Dropping the folder without using Visual Studio may break the project or cause the theme to not work.
Step 5: Build and rebuild the project in Visual Studio.
Step 6: Open or create a new WinForm and navigate to the toolbox, the new controls should automatically show up towards the top. 

That’s it, you're done! Enjoy using the theme :)

# How to round the corners
Add in the following code to round corners of any controls or WinForms

```C#
[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
private static extern IntPtr CreateRoundRectRgn
(
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // width of ellipse
        int nHeightEllipse // height of ellipse
);

this.FormBorderStyle = FormBorderStyle.None;
Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
```

# Information
This theme is made up of many other themes out there. Some components have been built from scratch and some of them have been imported from other themes. It is only fair that everyone gets proper credit. The credits have been listed below.

# Credits
- Creation of the theme and lead developer: EternalModz (CrEaTiiOn_Eternal)
- Gradient controls and ultimate theme components: Zac (CrEaTiiOn_Zac)
- Secondary developer and tester / supporter: LordVirus (CrEaTiiOn_Virus)
- Secondary developer and tester / supporter: Sinful (CrEaTiiOn_Sinful)
- External support: MayhemModding (CrEaTiiOn_MM)
- External support: Phobia (CrEaTiiOn_Phobia)
- External support: Skull (CrEaTiiOn_Skull)
- Controls and helpers: N-a-r-w-i-n, MetroSetUI
- Controls and helpers: drakonia, Flat-UI-Midnight
- Controls and helpers: TheKronks, KUI
- Controls and helpers: RobinPerris, DarkUI
- Controls and helpers: HAWK & LordVirus, Predator-Controls
- Controls and helpers: Sgridev, DarkUIReborn
- Controls and helpers: TessaroBruno, Noos-UI
- Controls and helpers: gytis-ivaskevicius, LimitlessUI
- Controls and helpers: HuJinguang, CxFlatUI
- Controls and helpers: xmymagic, MagicUI
- Controls and helpers: Sipaa, Sipaa-Framework
- Controls and helpers: RJCodeAdvance, many repositories 
- Controls and helpers: zeroitdev, Zeroit.Framework.UIThemes
- Controls and helpers: RickyDivjakovski, XanderUI
- Controls and helpers: ponie, SkeetUI
- Controls and helpers: 0xLaileb, FC-UI
- Controls and helpers: Taiizor, ReaLTaiizor
- Controls and helpers: aalitor, AltoComtrols
- Controls and helpers: NetDimension, WinForms-ModernUI
- Controls and helpers: AshishKilmist, MetroFramework

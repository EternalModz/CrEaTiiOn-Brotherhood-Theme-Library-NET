# CrEaTiiOn-Brotherhood-Theme-Library-NET
This is the official Windows Forms theme for CrEaTiiOn Brotherhood &amp; the Crimson Modding Team.

# What does the theme include?
The theme includes many controls to make modern and fabulous-looking GUIs. Each component has been checked and tested for optimal performance. The theme includes over 50+ controls. Each one has been fine-tuned to match the color flow of CrEaTiiOn Brotherhood and the Crimson Modding Team. Different types of controls are sorted by name and have been categorized by visual appearance.

# Coloring system
- Our default accent color is red, ```RGB: 250, 36, 38```
- For background colors, we use different shades of dark gray.
- Text coloring is usually white or something close to it.

# Updates and bugs
The theme will be updated frequently in the future. Since it is in its early stages, there will be some inconsistencies and problems. Make sure to let me know if you have any questions or if you have any bugs to report. Also, feel free to create a pull request if you'd like to help fix/improve the theme. There’s also a GitHub issues tab where you can request bug fixes and give feedback.

# Supported .NET versions
The theme supports C# 9+. Any version of .NET that supports C# 9+ will work with the theme. .NET Core and .NET Standard 6.0+ versions also work well with the theme. For .NET Framework, the CPROJ file must be edited for the theme to work. The .NET Framework does not support C# 9+ by default. So the CPROJ file must be edited so that the solution supports higher versions of the language.

Steps for updating the CPROJ file (for .NET Framework ONLY)

- Step 1: Locate the CPROJ file in the solution folder of the project that you want to use the theme in.
- Step 2: Open the CPROJ file in a text editor such as the Notepad.
- Step 3: Locate the first line under the base project and paste in the code below.
- Step 4: Save the file and your done!

Here is the code that is needed for the CPROJ.
```xml
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

Step 1: Download the latest version of the theme. *This can be found in the "Releases" section.

Step 2: Unpack the .zip or .7z file and extract it to the desktop or to any location where it can be found easily.

Step 3: Open the extracted folder and locate the folder with the name “Theme.”

Step 4: Copy that folder or drag and drop it inside of the Visual Studio project. *It must be inserted into the project folder using Visual Studio itself. Dropping the folder without using Visual Studio may break the project or cause the theme to not work.*

Step 5: Build/rebuild the project in Visual Studio.

Step 6: Open or create a new WinForm and navigate to the toolbox, the new controls should automatically show up towards the top. 

That’s it, you're done! Enjoy using the theme :)

# How to use the new CrEaTiiOn_Form
The theme now has a custom form control. Simply change the form mode under the namespace to switch to the CrEaTiiOn one. This new form includes features such as Dark Mode support for WinForms.

It should look something like this:
```cs
public partial class mainForm : CrEaTiiOn_Form
```

# Supported Visual Studio Versions
Visual Studio 2022 and 2019 have worked well with the theme. The theme has not been tested on lower versions but feel free to try it out yourself.

# Information
This theme is made up of many other themes out there. Some components have been built from scratch and some of them have been imported from other themes. It is only fair that everyone gets proper credit. The credits have been listed below.

# Theme Credits
- **Lead Developer and Theme Creation:** EternalModz (CrEaTiiOn_Eternal)
- **Ultimate Theme Components and Gradient Controls:** Zac (CrEaTiiOn_Zac)

## Secondary Developers and Testers/Supporters
- LordVirus (CrEaTiiOn_Virus)
- Sinful (CrEaTiiOn_Sinful)

## External Support
- MayhemModding (CrEaTiiOn_MM)
- Phobia (CrEaTiiOn_Phobia)
- Skull (CrEaTiiOn_Skull)

# Controls and Helpers
- N-a-r-w-i-n, MetroSetUI
- drakonia, Flat-UI-Midnight
- TheKronks, KUI
- RobinPerris, DarkUI
- HAWK & LordVirus, Predator-Controls
- Sgridev, DarkUIReborn
- TessaroBruno, Noos-UI
- gytis-ivaskevicius, LimitlessUI
- HuJinguang, CxFlatUI
- xmymagic, MagicUI
- Sipaa, Sipaa-Framework
- RJCodeAdvance, many repositories 
- zeroitdev, Zeroit.Framework.UIThemes
- RickyDivjakovski, XanderUI
- ponie, SkeetUI
- 0xLaileb, FC-UI
- Taiizor, ReaLTaiizor
- aalitor, AltoComtrols
- NetDimension, WinForms-ModernUI
- AshishKilmist, MetroFramework

# Forms
- Aldaviva, DarkNet
- MicaForEveryone

# Color Picker Controls
- HappyGromper, ColorPickerLibrary

# Special Thanks
- PhoenixARC
- Miku-666
- May/MattNL (MNL)

Thanks to everyone who helped and supported me during the development stages of this project!

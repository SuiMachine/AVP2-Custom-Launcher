Aliens vs. Predator 2 - Custom Launcher
============
A custom launcher for Aliens vs. Predator 2, written in C# (with widescreen fix written in C++ and elements of ASM)

Features
--------
  * Contains all of the main features of original launcher (except a host server option).
  * Allows to easily enable and disable Windowed Mode.
  * Supports custom screen resolutions.
  * Built in aspect ratio hack for easy access to widescreen resolutions.
  * Built in FOV changer, tied directly to aspect ratio hack (calculated as the most common Horizontal+ FOV).
  
Requirements
-------
 * Aliens vs. Predator 2 patched to [1.0.9.6](http://pcgamingwiki.com/wiki/Aliens_versus_Predator_2#Patches) with Singleplayer Map Update and Multiplayer Map Update installed.
 * Windows Vista / 7 / 8 / 10
 * [Microsoft .NET Framework 4.5](https://www.microsoft.com/en-US/download/details.aspx?id=30653)
 * [Visual C++ Redistributable for Visual Studio 2015](https://www.microsoft.com/en-US/download/details.aspx?id=48145) 32-bit
 * Administrator rights on the system (due to writting to memory of other program / injecting DLL libraries etc.)
  
Installation
-------
Patch the game if you haven't already. Download the program from [releases page](https://github.com/SuiMachine/AVP2-Custom-Launcher/releases). Copy it to AVP2 directory. To get rid of annoying question from Windows about download files, right click on **AVP_CustomLauncher.exe**, and choose Properties. In the General tab, click Unlock. 

**Note**: For the program to work properly, Administrator rights may be required (especially for Widescreen hack). You can set it in Compatibility Options.

**Note 2**: For running the game on resolutions wider than 2048px you'll need "special" D3DIM700.DLL by jackfuste. It can be found in ***Over2048pxFix*** directory. Just move it to main directory and hope it works (cause sometimes it seems it doesn't).

Credits
-------
* [SuicideMachine](http://www.twitch.tv/suimachine/)
* evolution536 - who wrote the DLL injector class
* Cless - who wrote the trainer class

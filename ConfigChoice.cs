﻿using System;
using System.Windows.Forms;
using System.IO;

namespace AVP_CustomLauncher
{
    public partial class ConfigChoice : Form
    {
        private const string autoexecFile = "autoexec.cfg";

        public ConfigChoice()
        {
            InitializeComponent();
        }

        private void B_Low_Click(object sender, EventArgs e)
        {
            string outputLow = "\"FARZ\" \"10000.000000\"\n\"NUMCONSOLELINES\" \"0\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Alien\"\n\"VS_SPRITES_NOZ\" \"128\"\n\"CARDDESC\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MouseInvertYAxis\" \"0\"\n\"MODELWARBLE\" \"0\"\n\"DETAILTEXTURESCALE\" \"1.0\"\n\"AutoswitchWeapons\" \"1\"\n\"MAXMODELSHADOWS\" \"0\"\n\"LIGHTMODELSPRITES\" \"1\"\n\"DynamicLightSetting\" \"2.000000\"\n\"VS_PARTICLESYSTEMS\" \"128\"\n\"FOGENABLE\" \"0\"\n\"ScreenFlash\" \"1.000000\"\n\"HeadCanting\" \"1\"\n\"ENVPANSPEED\" \"0.000500\"\n\"MODELLOD\" \"2.000000\"\n\"LowViolence\" \"0\"\n\"OPTIMIZESURFACES\" \"1.0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"VS_SPRITES\" \"512\"\n\"OrientOverlay\" \"1\"\n\"ScalingMenus\" \"1\"\n\"LIGHTMAP\" \"1\"\n\"Renderer\" \"G??wny v sterownik ekranu\"\n\"DetailLevel\" \"0\"\n\"VS_POLYGRIDS_TRANSLUCENT\" \"32\"\n\"MouseSensitivity\" \"7.000000\"\n\"SATURATE\" \"1\"\n\"Sound16Bit\" \"1\"\n\"FastTurnRate\" \"2.300000\"\n\"BITDEPTH\" \"32\"\n\"ClipSpeed\" \"1000.0\"\n\"VS_MODELS_CHROMAKEY\" \"512\"\n\"VS_POLYGRIDS\" \"32\"\n\"FixTJunc\" \"0\"\n\"SCREENWIDTH\" \"640\"\n\"Trilinear\" \"0\"\n\"RENDERDLL\" \"d3d.ren\"\n\"MASTERPALETTEMODE\" \"1.000000\"\n\"MaxWorldPoliesToDraw\" \"50000\"\n\"SpecialFX\" \"2.000000\"\n\"RATEENABLE\" \"2\"\n\"VS_WORLDMODELS_CHROMAKEY\" \"256\"\n\"modeldist1\" \"150.000000\"\n\"UpdateRateInitted\" \"1\"\n\"32BITTEXTURES\" \"0\"\n\"GAMMA\" \"1.000000\"\n\"BulletHoles\" \"100.000000\"\n\"modeldist2\" \"250.000000\"\n\"ObjectiveMessages\" \"1\"\n\"MuzzleLight\" \"0\"\n\"EnableHints\" \"1\"\n\"NumRuns\" \"105.000000\"\n\"DRAWSKY\" \"1\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"VS_CANVASES\" \"32\"\n\"modeldist3\" \"350.000000\"\n\"DETAILTEXTURES\" \"0\"\n\"enabledevice\" \"##mouse\"\n\"UseJoystick\" \"0\"\n\"VS_CANVASES_TRANSLUCENT\" \"128\"\n\"MultipassGouraud\" \"1\"\n\"IgnoreTaunts\" \"0\"\n\"PickupIconDuration\" \"5.000000\"\n\"ENVMAPENABLE\" \"0\"\n\"EnvMapWorld\" \"0\"\n\"MusicVolume\" \"50.000000\"\n\"maxswvoices\" \"32.000000\"\n\"VS_LINESYSTEMS\" \"128\"\n\"multiplayer\" \"0\"\n\"FORCECLEAR\" \"1\"\n\"FASTLIGHT\" \"0\"\n\"SoundVolume\" \"100.000000\"\n\"INPUTRATE\" \"0.000000\"\n\"POLYGRIDS\" \"1.000000\"\n\"VS_MODELS\" \"256\"\n\"GROUPOFFSET0\" \"2\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GROUPOFFSET1\" \"2\"\n\"EnableSky\" \"0\"\n\"globaldetail\" \"2.000000\"\n\"GROUPOFFSET2\" \"2\"\n\"NEARZ\" \"4.000000\"\n\"SFXVolume\" \"60.000000\"\n\"InvertHack\" \"0\"\n\"musictype\" \"ima\"\n\"GROUPOFFSET3\" \"2\"\n\"PVWeapons\" \"0.000000\"\n\"MODELSHADOWALPHA\" \"96\"\n\"TextureDetail\" \"2.000000\"\n\"CONSOLEALPHA\" \"0.65\"\n\"VS_WORLDMODELS_TRANSLUCENT\" \"256\"\n\"GROUPOFFSET4\" \"2\"\n\"MouseInvertY\" \"0\"\n\"GROUPOFFSET5\" \"2\"\n\"VS_LIGHTS\" \"64\"\n\"UPDATERATE\" \"19\"\n\"GroupOffset6\" \"0\"\n\"CrouchLock\" \"0\"\n\"GroupOffset7\" \"0\"\n\"MODELFULLBRITE\" \"1\"\n\"GroupOffset8\" \"0\"\n\"DEBUGLEVEL\" \"0\"\n\"GroupOffset9\" \"0\"\n\"CLOUDMAPLIGHT\" \"1.000000\"\n\"GameScreenHeight\" \"480\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"0\"\n\"SCREENHEIGHT\" \"480\"\n\"VS_MODELS_TRANSLUCENT\" \"512\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"MUSICENABLE\" \"1\"\n\"32BitLightmaps\" \"0\"\n\"WallWalkLock\" \"0\"\n\"DYNAMICLIGHT\" \"1\"\n\"GameScreenWidth\" \"640\"\n\"ImpactFXLevel\" \"0\"\n\"PerformanceConfig\" \".DefaultExtraHigh\"\n\"SOUNDENABLE\" \"1\"\n\"FogPerformanceScale\" \"20\"\n\"WARBLESCALE\" \".95\"\n\"LookUpRate\" \"2.500000\"\n\"GameBitDepth\" \"32\"\n\"Gore\" \"1.000000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"0\"\n\"VS_WORLDMODELS\" \"256\"\n\"ShellCasings\" \"0\"\n\"LookSpring\" \"0.000000\"\n\"MIPMAPDIST\" \"375.000000\"\n\"SHADOWZRANGE\" \"17.000000\"\n\"SHADOWLODOFFSET\" \"100.000000\"\n\"LIGHTSATURATE\" \"1.0\"\n\"ProfileName\" \"Player_0\"\n\"WARBLESPEED\" \"15\"\nAddAction Forward 0\nAddAction Backward 1\nAddAction Left 2\nAddAction Right 3\nAddAction Strafe 4\nAddAction StrafeLeft 5\nAddAction StrafeRight 6\nAddAction Run 7\nAddAction Duck 8\nAddAction Jump 9\nAddAction LookUp 10\nAddAction LookDown 11\nAddAction CenterView 12\nAddAction RunLock 13\nAddAction Fire 14\nAddAction AltFire 15\nAddAction Reload 16\nAddAction Activate 17\nAddAction PrevWeapon 18\nAddAction NextWeapon 19\nAddAction ZoomIn 20\nAddAction ZoomOut 21\nAddAction LastWeapon 22\nAddAction CrouchToggle 23\nAddAction TorchSelect 24\nAddAction WallWalk 25\nAddAction WallWalkToggle 26\nAddAction PounceJump 27\nAddAction EnergySift 28\nAddAction MediComp 29\nAddAction Weapon0 30\nAddAction Weapon1 31\nAddAction Weapon2 32\nAddAction Weapon3 33\nAddAction Weapon4 34\nAddAction Weapon5 35\nAddAction Weapon6 36\nAddAction Weapon7 37\nAddAction Weapon8 38\nAddAction Weapon9 39\nAddAction Item0 40\nAddAction Item1 41\nAddAction Item2 42\nAddAction Item3 43\nAddAction Item4 44\nAddAction Item5 45\nAddAction Item6 46\nAddAction Item7 47\nAddAction Item8 48\nAddAction Item9 49\nAddAction PrevVision 50\nAddAction NextVision 51\nAddAction PrevHud 60\nAddAction NextHud 61\nAddAction MouseAim 62\nAddAction Crosshair 63\nAddAction ChaseView 64\nAddAction QuickSave 65\nAddAction QuickLoad 66\nAddAction Message 70\nAddAction TeamMessage 71\nAddAction ScoreDisplay 72\nAddAction PlayerInfo 73\nAddAction Taunt 74\nAddAction LeaveUnassigned 99\nAddAction Axis3 -3\nAddAction Axis2 -2\nAddAction Axis1 -1\nAddAction AxisYaw -10001\nAddAction AxisPitch -10002\nAddAction AxisLeftRight -10003\nAddAction AxisForwardBackward -10004\n\nenabledevice \"##keyboard\"\nrangebind \"##keyboard\" \"##53\" 0.000000 0.000000 \"CrouchToggle\"\nrangebind \"##keyboard\" \"##29\" 0.000000 0.000000 \"Duck\"\nrangebind \"##keyboard\" \"##34\" 0.000000 0.000000 \"WallWalkToggle\"\nrangebind \"##keyboard\" \"##42\" 0.000000 0.000000 \"WallWalk\"\nrangebind \"##keyboard\" \"##18\" 0.000000 0.000000 \"PounceJump\"\nrangebind \"##keyboard\" \"##52\" 0.000000 0.000000 \"Crosshair\"\nrangebind \"##keyboard\" \"##14\" 0.000000 0.000000 \"Taunt\"\nrangebind \"##keyboard\" \"##43\" 0.000000 0.000000 \"TeamMessage\"\nrangebind \"##keyboard\" \"##28\" 0.000000 0.000000 \"Message\"\nrangebind \"##keyboard\" \"##15\" 0.000000 0.000000 \"ScoreDisplay\"\nrangebind \"##keyboard\" \"##210\" 0.000000 0.000000 \"MouseAim\"\nrangebind \"##keyboard\" \"##211\" 0.000000 0.000000 \"CenterView\"\nrangebind \"##keyboard\" \"##207\" 0.000000 0.000000 \"LookDown\"\nrangebind \"##keyboard\" \"##199\" 0.000000 0.000000 \"LookUp\"\nrangebind \"##keyboard\" \"##47\" 0.000000 0.000000 \"NextVision\"\nrangebind \"##keyboard\" \"##57\" 0.000000 0.000000 \"Jump\"\nrangebind \"##keyboard\" \"##50\" 0.000000 0.000000 \"RunLock\"\nrangebind \"##keyboard\" \"##58\" 0.000000 0.000000 \"Run\"\nrangebind \"##keyboard\" \"##37\" 0.000000 0.000000 \"Strafe\"\nrangebind \"##keyboard\" \"##32\" 0.000000 0.000000 \"StrafeRight\"\nrangebind \"##keyboard\" \"##30\" 0.000000 0.000000 \"StrafeLeft\"\nrangebind \"##keyboard\" \"##205\" 0.000000 0.000000 \"Right\"\nrangebind \"##keyboard\" \"##203\" 0.000000 0.000000 \"Left\"\nrangebind \"##keyboard\" \"##31\" 0.000000 0.000000 \"Backward\"\nrangebind \"##keyboard\" \"##17\" 0.000000 0.000000 \"Forward\"\nrangebind \"##keyboard\" \"##65\" 0.000000 0.000000 \"QuickLoad\"\nrangebind \"##keyboard\" \"##64\" 0.000000 0.000000 \"QuickSave\"\nrangebind \"##keyboard\" \"##13\" 0.000000 0.000000 \"NextHud\"\nrangebind \"##keyboard\" \"##12\" 0.000000 0.000000 \"PrevHud\"\nenabledevice \"##mouse\"\nrangebind \"##mouse\" \"##4\" 0.000000 0.000000 \"AltFire\"\nrangebind \"##mouse\" \"##3\" 0.000000 0.000000 \"Fire\"\nrangebind \"##mouse\" \"##x-axis\" 0.000000 0.000000 \"Axis1\"\nscale \"##mouse\" \"##x-axis\" 0.002711\nrangebind \"##mouse\" \"##y-axis\" 0.000000 0.000000 \"Axis2\"\nscale \"##mouse\" \"##y-axis\" 0.002983\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            File.WriteAllText(autoexecFile, outputLow);
            this.Close();
        }

        private void B_Medium_Click(object sender, EventArgs e)
        {
            string outputMedium = "\"NUMCONSOLELINES\" \"0\"\n\"FARZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Alien\"\n\"VS_SPRITES_NOZ\" \"128\"\n\"CARDDESC\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MouseInvertYAxis\" \"0\"\n\"DETAILTEXTURESCALE\" \"1.0\"\n\"MODELWARBLE\" \"0\"\n\"DynamicLightSetting\" \"2.000000\"\n\"LIGHTMODELSPRITES\" \"1\"\n\"MAXMODELSHADOWS\" \"1\"\n\"AutoswitchWeapons\" \"1\"\n\"VS_PARTICLESYSTEMS\" \"128\"\n\"FOGENABLE\" \"0\"\n\"ScreenFlash\" \"1.000000\"\n\"HeadCanting\" \"1\"\n\"ENVPANSPEED\" \"0.000500\"\n\"MODELLOD\" \"2.000000\"\n\"OPTIMIZESURFACES\" \"1.0\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"VS_SPRITES\" \"512\"\n\"OrientOverlay\" \"1\"\n\"ScalingMenus\" \"1\"\n\"LIGHTMAP\" \"1\"\n\"Renderer\" \"G??wny v sterownik ekranu\"\n\"DetailLevel\" \"2\"\n\"VS_POLYGRIDS_TRANSLUCENT\" \"32\"\n\"MouseSensitivity\" \"7.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"Sound16Bit\" \"1\"\n\"SATURATE\" \"1\"\n\"BITDEPTH\" \"32\"\n\"ClipSpeed\" \"1000.0\"\n\"VS_MODELS_CHROMAKEY\" \"512\"\n\"VS_POLYGRIDS\" \"32\"\n\"FixTJunc\" \"0\"\n\"SCREENWIDTH\" \"800\"\n\"RENDERDLL\" \"d3d.ren\"\n\"Trilinear\" \"0\"\n\"MaxWorldPoliesToDraw\" \"50000\"\n\"MASTERPALETTEMODE\" \"1.000000\"\n\"SpecialFX\" \"2.000000\"\n\"RATEENABLE\" \"2\"\n\"VS_WORLDMODELS_CHROMAKEY\" \"256\"\n\"modeldist1\" \"150.000000\"\n\"UpdateRateInitted\" \"1\"\n\"GAMMA\" \"1.000000\"\n\"32BITTEXTURES\" \"1\"\n\"modeldist2\" \"250.000000\"\n\"BulletHoles\" \"100.000000\"\n\"MuzzleLight\" \"1\"\n\"ObjectiveMessages\" \"1\"\n\"NumRuns\" \"106.000000\"\n\"EnableHints\" \"1\"\n\"DRAWSKY\" \"1\"\n\"VS_CANVASES\" \"32\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"modeldist3\" \"350.000000\"\n\"DETAILTEXTURES\" \"1\"\n\"enabledevice\" \"##mouse\"\n\"UseJoystick\" \"0\"\n\"MultipassGouraud\" \"1\"\n\"VS_CANVASES_TRANSLUCENT\" \"128\"\n\"PickupIconDuration\" \"5.000000\"\n\"IgnoreTaunts\" \"0\"\n\"ENVMAPENABLE\" \"1\"\n\"EnvMapWorld\" \"0\"\n\"MusicVolume\" \"50.000000\"\n\"maxswvoices\" \"48.000000\"\n\"multiplayer\" \"0\"\n\"VS_LINESYSTEMS\" \"128\"\n\"FORCECLEAR\" \"1\"\n\"FASTLIGHT\" \"0\"\n\"SoundVolume\" \"100.000000\"\n\"INPUTRATE\" \"0.000000\"\n\"VS_MODELS\" \"256\"\n\"POLYGRIDS\" \"1.000000\"\n\"GROUPOFFSET0\" \"0\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GROUPOFFSET1\" \"0\"\n\"globaldetail\" \"2.000000\"\n\"EnableSky\" \"1\"\n\"GROUPOFFSET2\" \"-1\"\n\"SFXVolume\" \"60.000000\"\n\"NEARZ\" \"4.000000\"\n\"musictype\" \"ima\"\n\"InvertHack\" \"0\"\n\"GROUPOFFSET3\" \"1\"\n\"PVWeapons\" \"0.000000\"\n\"MODELSHADOWALPHA\" \"96\"\n\"CONSOLEALPHA\" \"0.65\"\n\"TextureDetail\" \"2.000000\"\n\"VS_WORLDMODELS_TRANSLUCENT\" \"256\"\n\"GROUPOFFSET4\" \"1\"\n\"MouseInvertY\" \"0\"\n\"VS_LIGHTS\" \"64\"\n\"GROUPOFFSET5\" \"1\"\n\"UPDATERATE\" \"19\"\n\"GroupOffset6\" \"-1\"\n\"CrouchLock\" \"0\"\n\"GroupOffset7\" \"-1\"\n\"MODELFULLBRITE\" \"1\"\n\"GroupOffset8\" \"-1\"\n\"DEBUGLEVEL\" \"0\"\n\"GroupOffset9\" \"-1\"\n\"CLOUDMAPLIGHT\" \"1.000000\"\n\"GameScreenHeight\" \"600\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"SCREENHEIGHT\" \"600\"\n\"VS_MODELS_TRANSLUCENT\" \"512\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"MUSICENABLE\" \"1\"\n\"32BitLightmaps\" \"0\"\n\"WallWalkLock\" \"0\"\n\"DYNAMICLIGHT\" \"1\"\n\"GameScreenWidth\" \"800\"\n\"ImpactFXLevel\" \"1\"\n\"SOUNDENABLE\" \"1\"\n\"PerformanceConfig\" \".DefaultMid\"\n\"FogPerformanceScale\" \"60\"\n\"WARBLESCALE\" \".95\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"Gore\" \"1.000000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"1\"\n\"VS_WORLDMODELS\" \"256\"\n\"LookSpring\" \"0.000000\"\n\"ShellCasings\" \"1\"\n\"MIPMAPDIST\" \"375.000000\"\n\"SHADOWZRANGE\" \"17.000000\"\n\"SHADOWLODOFFSET\" \"100.000000\"\n\"LIGHTSATURATE\" \"1.0\"\n\"ProfileName\" \"Player_0\"\n\"WARBLESPEED\" \"15\"\nAddAction Forward 0\nAddAction Backward 1\nAddAction Left 2\nAddAction Right 3\nAddAction Strafe 4\nAddAction StrafeLeft 5\nAddAction StrafeRight 6\nAddAction Run 7\nAddAction Duck 8\nAddAction Jump 9\nAddAction LookUp 10\nAddAction LookDown 11\nAddAction CenterView 12\nAddAction RunLock 13\nAddAction Fire 14\nAddAction AltFire 15\nAddAction Reload 16\nAddAction Activate 17\nAddAction PrevWeapon 18\nAddAction NextWeapon 19\nAddAction ZoomIn 20\nAddAction ZoomOut 21\nAddAction LastWeapon 22\nAddAction CrouchToggle 23\nAddAction TorchSelect 24\nAddAction WallWalk 25\nAddAction WallWalkToggle 26\nAddAction PounceJump 27\nAddAction EnergySift 28\nAddAction MediComp 29\nAddAction Weapon0 30\nAddAction Weapon1 31\nAddAction Weapon2 32\nAddAction Weapon3 33\nAddAction Weapon4 34\nAddAction Weapon5 35\nAddAction Weapon6 36\nAddAction Weapon7 37\nAddAction Weapon8 38\nAddAction Weapon9 39\nAddAction Item0 40\nAddAction Item1 41\nAddAction Item2 42\nAddAction Item3 43\nAddAction Item4 44\nAddAction Item5 45\nAddAction Item6 46\nAddAction Item7 47\nAddAction Item8 48\nAddAction Item9 49\nAddAction PrevVision 50\nAddAction NextVision 51\nAddAction PrevHud 60\nAddAction NextHud 61\nAddAction MouseAim 62\nAddAction Crosshair 63\nAddAction ChaseView 64\nAddAction QuickSave 65\nAddAction QuickLoad 66\nAddAction Message 70\nAddAction TeamMessage 71\nAddAction ScoreDisplay 72\nAddAction PlayerInfo 73\nAddAction Taunt 74\nAddAction LeaveUnassigned 99\nAddAction Axis3 -3\nAddAction Axis2 -2\nAddAction Axis1 -1\nAddAction AxisYaw -10001\nAddAction AxisPitch -10002\nAddAction AxisLeftRight -10003\nAddAction AxisForwardBackward -10004\n\nenabledevice \"##keyboard\"\nrangebind \"##keyboard\" \"##53\" 0.000000 0.000000 \"CrouchToggle\"\nrangebind \"##keyboard\" \"##29\" 0.000000 0.000000 \"Duck\"\nrangebind \"##keyboard\" \"##34\" 0.000000 0.000000 \"WallWalkToggle\"\nrangebind \"##keyboard\" \"##42\" 0.000000 0.000000 \"WallWalk\"\nrangebind \"##keyboard\" \"##18\" 0.000000 0.000000 \"PounceJump\"\nrangebind \"##keyboard\" \"##52\" 0.000000 0.000000 \"Crosshair\"\nrangebind \"##keyboard\" \"##14\" 0.000000 0.000000 \"Taunt\"\nrangebind \"##keyboard\" \"##43\" 0.000000 0.000000 \"TeamMessage\"\nrangebind \"##keyboard\" \"##28\" 0.000000 0.000000 \"Message\"\nrangebind \"##keyboard\" \"##15\" 0.000000 0.000000 \"ScoreDisplay\"\nrangebind \"##keyboard\" \"##210\" 0.000000 0.000000 \"MouseAim\"\nrangebind \"##keyboard\" \"##211\" 0.000000 0.000000 \"CenterView\"\nrangebind \"##keyboard\" \"##207\" 0.000000 0.000000 \"LookDown\"\nrangebind \"##keyboard\" \"##199\" 0.000000 0.000000 \"LookUp\"\nrangebind \"##keyboard\" \"##47\" 0.000000 0.000000 \"NextVision\"\nrangebind \"##keyboard\" \"##57\" 0.000000 0.000000 \"Jump\"\nrangebind \"##keyboard\" \"##50\" 0.000000 0.000000 \"RunLock\"\nrangebind \"##keyboard\" \"##58\" 0.000000 0.000000 \"Run\"\nrangebind \"##keyboard\" \"##37\" 0.000000 0.000000 \"Strafe\"\nrangebind \"##keyboard\" \"##32\" 0.000000 0.000000 \"StrafeRight\"\nrangebind \"##keyboard\" \"##30\" 0.000000 0.000000 \"StrafeLeft\"\nrangebind \"##keyboard\" \"##205\" 0.000000 0.000000 \"Right\"\nrangebind \"##keyboard\" \"##203\" 0.000000 0.000000 \"Left\"\nrangebind \"##keyboard\" \"##31\" 0.000000 0.000000 \"Backward\"\nrangebind \"##keyboard\" \"##17\" 0.000000 0.000000 \"Forward\"\nrangebind \"##keyboard\" \"##12\" 0.000000 0.000000 \"PrevHud\"\nrangebind \"##keyboard\" \"##13\" 0.000000 0.000000 \"NextHud\"\nrangebind \"##keyboard\" \"##64\" 0.000000 0.000000 \"QuickSave\"\nrangebind \"##keyboard\" \"##65\" 0.000000 0.000000 \"QuickLoad\"\nenabledevice \"##mouse\"\nrangebind \"##mouse\" \"##4\" 0.000000 0.000000 \"AltFire\"\nrangebind \"##mouse\" \"##3\" 0.000000 0.000000 \"Fire\"\nrangebind \"##mouse\" \"##y-axis\" 0.000000 0.000000 \"Axis2\"\nscale \"##mouse\" \"##y-axis\" 0.002983\nrangebind \"##mouse\" \"##x-axis\" 0.000000 0.000000 \"Axis1\"\nscale \"##mouse\" \"##x-axis\" 0.002711\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            File.WriteAllText(autoexecFile, outputMedium);
            this.Close();

        }

        private void B_High_Click(object sender, EventArgs e)
        {
            string outputHigh = "\"NUMCONSOLELINES\" \"0\"\n\"FARZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Alien\"\n\"VS_SPRITES_NOZ\" \"128\"\n\"CARDDESC\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MouseInvertYAxis\" \"0\"\n\"DETAILTEXTURESCALE\" \"1.0\"\n\"MODELWARBLE\" \"0\"\n\"DynamicLightSetting\" \"2.000000\"\n\"LIGHTMODELSPRITES\" \"1\"\n\"MAXMODELSHADOWS\" \"1\"\n\"AutoswitchWeapons\" \"1\"\n\"VS_PARTICLESYSTEMS\" \"128\"\n\"FOGENABLE\" \"0\"\n\"ScreenFlash\" \"1.000000\"\n\"HeadCanting\" \"1\"\n\"ENVPANSPEED\" \"0.000500\"\n\"MODELLOD\" \"2.000000\"\n\"OPTIMIZESURFACES\" \"1.0\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"VS_SPRITES\" \"512\"\n\"OrientOverlay\" \"1\"\n\"ScalingMenus\" \"1\"\n\"LIGHTMAP\" \"1\"\n\"Renderer\" \"G??wny v sterownik ekranu\"\n\"DetailLevel\" \"4\"\n\"VS_POLYGRIDS_TRANSLUCENT\" \"32\"\n\"MouseSensitivity\" \"7.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"Sound16Bit\" \"1\"\n\"SATURATE\" \"1\"\n\"BITDEPTH\" \"32\"\n\"ClipSpeed\" \"1000.0\"\n\"VS_MODELS_CHROMAKEY\" \"512\"\n\"VS_POLYGRIDS\" \"32\"\n\"FixTJunc\" \"0\"\n\"SCREENWIDTH\" \"1024\"\n\"RENDERDLL\" \"d3d.ren\"\n\"Trilinear\" \"1\"\n\"MaxWorldPoliesToDraw\" \"50000\"\n\"MASTERPALETTEMODE\" \"1.000000\"\n\"SpecialFX\" \"2.000000\"\n\"RATEENABLE\" \"2\"\n\"VS_WORLDMODELS_CHROMAKEY\" \"256\"\n\"modeldist1\" \"150.000000\"\n\"UpdateRateInitted\" \"1\"\n\"GAMMA\" \"1.000000\"\n\"32BITTEXTURES\" \"1\"\n\"modeldist2\" \"250.000000\"\n\"BulletHoles\" \"100.000000\"\n\"MuzzleLight\" \"1\"\n\"ObjectiveMessages\" \"1\"\n\"NumRuns\" \"104.000000\"\n\"EnableHints\" \"1\"\n\"DRAWSKY\" \"1\"\n\"VS_CANVASES\" \"32\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"modeldist3\" \"350.000000\"\n\"DETAILTEXTURES\" \"1\"\n\"enabledevice\" \"##mouse\"\n\"UseJoystick\" \"0\"\n\"MultipassGouraud\" \"1\"\n\"VS_CANVASES_TRANSLUCENT\" \"128\"\n\"PickupIconDuration\" \"5.000000\"\n\"IgnoreTaunts\" \"0\"\n\"ENVMAPENABLE\" \"1\"\n\"EnvMapWorld\" \"1\"\n\"MusicVolume\" \"50.000000\"\n\"maxswvoices\" \"64.000000\"\n\"multiplayer\" \"0\"\n\"VS_LINESYSTEMS\" \"128\"\n\"FORCECLEAR\" \"1\"\n\"FASTLIGHT\" \"0\"\n\"SoundVolume\" \"100.000000\"\n\"INPUTRATE\" \"0.000000\"\n\"VS_MODELS\" \"256\"\n\"POLYGRIDS\" \"1.000000\"\n\"GROUPOFFSET0\" \"-1\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GROUPOFFSET1\" \"-1\"\n\"globaldetail\" \"2.000000\"\n\"EnableSky\" \"1\"\n\"GROUPOFFSET2\" \"-1\"\n\"SFXVolume\" \"60.000000\"\n\"NEARZ\" \"4.000000\"\n\"musictype\" \"ima\"\n\"InvertHack\" \"0\"\n\"GROUPOFFSET3\" \"-1\"\n\"PVWeapons\" \"0.000000\"\n\"MODELSHADOWALPHA\" \"96\"\n\"CONSOLEALPHA\" \"0.65\"\n\"TextureDetail\" \"2.000000\"\n\"VS_WORLDMODELS_TRANSLUCENT\" \"256\"\n\"GROUPOFFSET4\" \"-1\"\n\"MouseInvertY\" \"0\"\n\"VS_LIGHTS\" \"64\"\n\"GROUPOFFSET5\" \"-1\"\n\"UPDATERATE\" \"19\"\n\"GroupOffset6\" \"-1\"\n\"CrouchLock\" \"0\"\n\"GroupOffset7\" \"-1\"\n\"MODELFULLBRITE\" \"1\"\n\"GroupOffset8\" \"-1\"\n\"DEBUGLEVEL\" \"0\"\n\"GroupOffset9\" \"-1\"\n\"CLOUDMAPLIGHT\" \"1.000000\"\n\"GameScreenHeight\" \"768\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"SCREENHEIGHT\" \"768\"\n\"VS_MODELS_TRANSLUCENT\" \"512\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"MUSICENABLE\" \"1\"\n\"32BitLightmaps\" \"1\"\n\"WallWalkLock\" \"0\"\n\"DYNAMICLIGHT\" \"1\"\n\"GameScreenWidth\" \"1024\"\n\"ImpactFXLevel\" \"2\"\n\"SOUNDENABLE\" \"1\"\n\"PerformanceConfig\" \".DefaultExtraLow\"\n\"FogPerformanceScale\" \"100\"\n\"WARBLESCALE\" \".95\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"Gore\" \"1.000000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"2\"\n\"VS_WORLDMODELS\" \"256\"\n\"LookSpring\" \"0.000000\"\n\"ShellCasings\" \"1\"\n\"MIPMAPDIST\" \"375.000000\"\n\"SHADOWZRANGE\" \"17.000000\"\n\"SHADOWLODOFFSET\" \"100.000000\"\n\"LIGHTSATURATE\" \"1.0\"\n\"ProfileName\" \"Player_0\"\n\"WARBLESPEED\" \"15\"\nAddAction Forward 0\nAddAction Backward 1\nAddAction Left 2\nAddAction Right 3\nAddAction Strafe 4\nAddAction StrafeLeft 5\nAddAction StrafeRight 6\nAddAction Run 7\nAddAction Duck 8\nAddAction Jump 9\nAddAction LookUp 10\nAddAction LookDown 11\nAddAction CenterView 12\nAddAction RunLock 13\nAddAction Fire 14\nAddAction AltFire 15\nAddAction Reload 16\nAddAction Activate 17\nAddAction PrevWeapon 18\nAddAction NextWeapon 19\nAddAction ZoomIn 20\nAddAction ZoomOut 21\nAddAction LastWeapon 22\nAddAction CrouchToggle 23\nAddAction TorchSelect 24\nAddAction WallWalk 25\nAddAction WallWalkToggle 26\nAddAction PounceJump 27\nAddAction EnergySift 28\nAddAction MediComp 29\nAddAction Weapon0 30\nAddAction Weapon1 31\nAddAction Weapon2 32\nAddAction Weapon3 33\nAddAction Weapon4 34\nAddAction Weapon5 35\nAddAction Weapon6 36\nAddAction Weapon7 37\nAddAction Weapon8 38\nAddAction Weapon9 39\nAddAction Item0 40\nAddAction Item1 41\nAddAction Item2 42\nAddAction Item3 43\nAddAction Item4 44\nAddAction Item5 45\nAddAction Item6 46\nAddAction Item7 47\nAddAction Item8 48\nAddAction Item9 49\nAddAction PrevVision 50\nAddAction NextVision 51\nAddAction PrevHud 60\nAddAction NextHud 61\nAddAction MouseAim 62\nAddAction Crosshair 63\nAddAction ChaseView 64\nAddAction QuickSave 65\nAddAction QuickLoad 66\nAddAction Message 70\nAddAction TeamMessage 71\nAddAction ScoreDisplay 72\nAddAction PlayerInfo 73\nAddAction Taunt 74\nAddAction LeaveUnassigned 99\nAddAction Axis3 -3\nAddAction Axis2 -2\nAddAction Axis1 -1\nAddAction AxisYaw -10001\nAddAction AxisPitch -10002\nAddAction AxisLeftRight -10003\nAddAction AxisForwardBackward -10004\n\nenabledevice \"##keyboard\"\nrangebind \"##keyboard\" \"##53\" 0.000000 0.000000 \"CrouchToggle\" \nrangebind \"##keyboard\" \"##29\" 0.000000 0.000000 \"Duck\" \nrangebind \"##keyboard\" \"##34\" 0.000000 0.000000 \"WallWalkToggle\" \nrangebind \"##keyboard\" \"##42\" 0.000000 0.000000 \"WallWalk\" \nrangebind \"##keyboard\" \"##18\" 0.000000 0.000000 \"PounceJump\" \nrangebind \"##keyboard\" \"##52\" 0.000000 0.000000 \"Crosshair\" \nrangebind \"##keyboard\" \"##14\" 0.000000 0.000000 \"Taunt\" \nrangebind \"##keyboard\" \"##43\" 0.000000 0.000000 \"TeamMessage\" \nrangebind \"##keyboard\" \"##28\" 0.000000 0.000000 \"Message\" \nrangebind \"##keyboard\" \"##15\" 0.000000 0.000000 \"ScoreDisplay\" \nrangebind \"##keyboard\" \"##210\" 0.000000 0.000000 \"MouseAim\" \nrangebind \"##keyboard\" \"##211\" 0.000000 0.000000 \"CenterView\" \nrangebind \"##keyboard\" \"##207\" 0.000000 0.000000 \"LookDown\" \nrangebind \"##keyboard\" \"##199\" 0.000000 0.000000 \"LookUp\" \nrangebind \"##keyboard\" \"##47\" 0.000000 0.000000 \"NextVision\" \nrangebind \"##keyboard\" \"##57\" 0.000000 0.000000 \"Jump\" \nrangebind \"##keyboard\" \"##50\" 0.000000 0.000000 \"RunLock\" \nrangebind \"##keyboard\" \"##58\" 0.000000 0.000000 \"Run\" \nrangebind \"##keyboard\" \"##37\" 0.000000 0.000000 \"Strafe\" \nrangebind \"##keyboard\" \"##32\" 0.000000 0.000000 \"StrafeRight\" \nrangebind \"##keyboard\" \"##30\" 0.000000 0.000000 \"StrafeLeft\" \nrangebind \"##keyboard\" \"##205\" 0.000000 0.000000 \"Right\" \nrangebind \"##keyboard\" \"##203\" 0.000000 0.000000 \"Left\" \nrangebind \"##keyboard\" \"##31\" 0.000000 0.000000 \"Backward\" \nrangebind \"##keyboard\" \"##17\" 0.000000 0.000000 \"Forward\" \nrangebind \"##keyboard\" \"##12\" 0.000000 0.000000 \"PrevHud\" \nrangebind \"##keyboard\" \"##13\" 0.000000 0.000000 \"NextHud\" \nrangebind \"##keyboard\" \"##64\" 0.000000 0.000000 \"QuickSave\" \nrangebind \"##keyboard\" \"##65\" 0.000000 0.000000 \"QuickLoad\" \nenabledevice \"##mouse\"\nrangebind \"##mouse\" \"##4\" 0.000000 0.000000 \"AltFire\" \nrangebind \"##mouse\" \"##3\" 0.000000 0.000000 \"Fire\" \nrangebind \"##mouse\" \"##y-axis\" 0.000000 0.000000 \"Axis2\" \nscale \"##mouse\" \"##y-axis\" 0.002983\nrangebind \"##mouse\" \"##x-axis\" 0.000000 0.000000 \"Axis1\" \nscale \"##mouse\" \"##x-axis\" 0.002711\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            File.WriteAllText(autoexecFile, outputHigh);
            this.Close();
        }
    }
}

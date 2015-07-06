using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace AVP_CustomLauncher
{
    public partial class mainform : Form
    {
        GameSettings _GameSettings;
        GraphicsSettings _GraphicsSettings;
        GameHack _gamehack = new GameHack();

        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            /*if(!File.Exists(@"lithtech.exe"))
            {
                MessageBox.Show("No lithtech.exe found, please place the custom launcher in the directory with a game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }*/

            if(!File.Exists(@"autoexec.cfg"))
            {
                MessageBox.Show("No autoexec.cfg found. The launcher will create a generic config file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateGenericAutoconfig();
            }

            if (!File.Exists(@"avp2cmds.txt"))
            {
                MessageBox.Show("No avp2cmds.txt found. The launcher will try to create it based on files in your current directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateGenericAVP2Cmds();
            }

            _GameSettings = new GameSettings(this);
            _GraphicsSettings = new GraphicsSettings(this);
        }

        private void B_StartGame_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader(@"avp2cmds.txt");
            string cmdlineparamters = "";
            cmdlineparamters = SR.ReadToEnd();
            if (_GraphicsSettings.windowed)
                cmdlineparamters = cmdlineparamters + " +windowed 1";

            Thread GameHackThread = new Thread(_gamehack.DoWork);
            if (_GraphicsSettings.aspectratiohack)
            {
                _gamehack.SendValues(_GraphicsSettings.fov, _GraphicsSettings.ResolutionX, _GraphicsSettings.ResolutionY);
                GameHackThread.Start();
            }

            try
            {                
                Process gameProcess = new Process();
                gameProcess.StartInfo.FileName = "Lithtech.exe";
                gameProcess.StartInfo.Arguments = cmdlineparamters;
                gameProcess.EnableRaisingEvents = true;
                this.WindowState = FormWindowState.Minimized;
                
                gameProcess.Start();
                gameProcess.WaitForExit();
                _gamehack.RequestStop();
                this.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred!: " + ex.Message);
                return;
            }
        }

        private void B_DisplaySettings_Click(object sender, EventArgs e)
        {
            _GraphicsSettings.SetDesktopLocation(this.DesktopLocation.X + 10, this.DesktopLocation.Y + 10);
            _GraphicsSettings.ShowDialog();
        }

        private void B_GameSettings_Click(object sender, EventArgs e)
        {
            _GameSettings.SetDesktopLocation(this.DesktopLocation.X + 10, this.DesktopLocation.Y + 10);
            _GameSettings.ShowDialog();
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            _gamehack.RequestStop();
            this.Close();
        }

        private void CreateGenericAutoconfig()
        {
            StreamWriter SW = new StreamWriter(@"autoexec.cfg");
            string output = "\"NUMCONSOLELINES\" \"0\"\n\"FARZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Marine\"\n\"VS_SPRITES_NOZ\" \"128\"\n\"CARDDESC\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MouseInvertYAxis\" \"0\"\n\"DETAILTEXTURESCALE\" \"1.0\"\n\"MODELWARBLE\" \"0\"\n\"DynamicLightSetting\" \"2.000000\"\n\"LIGHTMODELSPRITES\" \"1\"\n\"MAXMODELSHADOWS\" \"1\"\n\"AutoswitchWeapons\" \"1\"\n\"VS_PARTICLESYSTEMS\" \"128\"\n\"FOGENABLE\" \"0\"\n\"ScreenFlash\" \"1.000000\"\n\"HeadCanting\" \"1\"\n\"ENVPANSPEED\" \"0.000500\"\n\"MODELLOD\" \"2.000000\"\n\"OPTIMIZESURFACES\" \"1.0\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"VS_SPRITES\" \"512\"\n\"OrientOverlay\" \"1\"\n\"ScalingMenus\" \"1\"\n\"LIGHTMAP\" \"1\"\n\"Renderer\" \"Main Screen Display\"\n\"DetailLevel\" \"2\"\n\"VS_POLYGRIDS_TRANSLUCENT\" \"32\"\n\"MouseSensitivity\" \"6.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"Sound16Bit\" \"1\"\n\"SATURATE\" \"1\"\n\"BITDEPTH\" \"32\"\n\"ClipSpeed\" \"1000.0\"\n\"VS_MODELS_CHROMAKEY\" \"512\"\n\"VS_POLYGRIDS\" \"32\"\n\"FixTJunc\" \"1\"\n\"SCREENWIDTH\" \"1024\"\n\"RENDERDLL\" \"d3d.ren\"\n\"Trilinear\" \"0\"\n\"MaxWorldPoliesToDraw\" \"50000\"\n\"MASTERPALETTEMODE\" \"1.000000\"\n\"SpecialFX\" \"2.000000\"\n\"RATEENABLE\" \"2\"\n\"VS_WORLDMODELS_CHROMAKEY\" \"256\"\n\"modeldist1\" \"150.000000\"\n\"UpdateRateInitted\" \"1\"\n\"GAMMA\" \"1.000000\"\n\"32BITTEXTURES\" \"1\"\n\"modeldist2\" \"250.000000\"\n\"BulletHoles\" \"100.000000\"\n\"MuzzleLight\" \"1\"\n\"ObjectiveMessages\" \"1\"\n\"NumRuns\" \"98.000000\"\n\"EnableHints\" \"1\"\n\"DRAWSKY\" \"1\"\n\"VS_CANVASES\" \"32\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"modeldist3\" \"350.000000\"\n\"DETAILTEXTURES\" \"1\"\n\"enabledevice\" \"##mouse\"\n\"UseJoystick\" \"0\"\n\"MultipassGouraud\" \"1\"\n\"VS_CANVASES_TRANSLUCENT\" \"128\"\n\"PickupIconDuration\" \"5.000000\"\n\"IgnoreTaunts\" \"0\"\n\"ENVMAPENABLE\" \"1\"\n\"EnvMapWorld\" \"0\"\n\"MusicVolume\" \"0.000000\"\n\"maxswvoices\" \"48.000000\"\n\"multiplayer\" \"0\"\n\"VS_LINESYSTEMS\" \"128\"\n\"FORCECLEAR\" \"1\"\n\"FASTLIGHT\" \"0\"\n\"SoundVolume\" \"100.000000\"\n\"INPUTRATE\" \"5.000000\"\n\"VS_MODELS\" \"256\"\n\"POLYGRIDS\" \"1.000000\"\n\"GROUPOFFSET0\" \"0\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GROUPOFFSET1\" \"0\"\n\"globaldetail\" \"2.000000\"\n\"EnableSky\" \"1\"\n\"GROUPOFFSET2\" \"-1\"\n\"SFXVolume\" \"60.000000\"\n\"NEARZ\" \"4.000000\"\n\"musictype\" \"ima\"\n\"InvertHack\" \"0\"\n\"GROUPOFFSET3\" \"1\"\n\"PVWeapons\" \"0.000000\"\n\"MODELSHADOWALPHA\" \"96\"\n\"CONSOLEALPHA\" \"0.65\"\n\"TextureDetail\" \"2.000000\"\n\"VS_WORLDMODELS_TRANSLUCENT\" \"256\"\n\"GROUPOFFSET4\" \"1\"\n\"MouseInvertY\" \"0\"\n\"VS_LIGHTS\" \"64\"\n\"GROUPOFFSET5\" \"1\"\n\"UPDATERATE\" \"4\"\n\"GroupOffset6\" \"-1\"\n\"CrouchLock\" \"0\"\n\"GroupOffset7\" \"-1\"\n\"MODELFULLBRITE\" \"1\"\n\"GroupOffset8\" \"-1\"\n\"DEBUGLEVEL\" \"0\"\n\"GroupOffset9\" \"-1\"\n\"CLOUDMAPLIGHT\" \"1.000000\"\n\"GameScreenHeight\" \"768\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"SCREENHEIGHT\" \"768\"\n\"VS_MODELS_TRANSLUCENT\" \"512\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"MUSICENABLE\" \"0\"\n\"32BitLightmaps\" \"0\"\n\"WallWalkLock\" \"0\"\n\"DYNAMICLIGHT\" \"1\"\n\"GameScreenWidth\" \"1024\"\n\"ImpactFXLevel\" \"1\"\n\"SOUNDENABLE\" \"1\"\n\"PerformanceConfig\" \".DefaultMid\"\n\"FogPerformanceScale\" \"60\"\n\"WARBLESCALE\" \".95\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"Gore\" \"1.000000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"1\"\n\"VS_WORLDMODELS\" \"256\"\n\"LookSpring\" \"0.000000\"\n\"ShellCasings\" \"1\"\n\"MIPMAPDIST\" \"375.000000\"\n\"SHADOWZRANGE\" \"17.000000\"\n\"SHADOWLODOFFSET\" \"100.000000\"\n\"LIGHTSATURATE\" \"1.0\"\n\"ProfileName\" \"Player_0\"\n\"WARBLESPEED\" \"15\"\nAddAction Forward 0\nAddAction Backward 1\nAddAction Left 2\nAddAction Right 3\nAddAction Strafe 4\nAddAction StrafeLeft 5\nAddAction StrafeRight 6\nAddAction Run 7\nAddAction Duck 8\nAddAction Jump 9\nAddAction LookUp 10\nAddAction LookDown 11\nAddAction CenterView 12\nAddAction RunLock 13\nAddAction Fire 14\nAddAction AltFire 15\nAddAction Reload 16\nAddAction Activate 17\nAddAction PrevWeapon 18\nAddAction NextWeapon 19\nAddAction ZoomIn 20\nAddAction ZoomOut 21\nAddAction LastWeapon 22\nAddAction CrouchToggle 23\nAddAction TorchSelect 24\nAddAction WallWalk 25\nAddAction WallWalkToggle 26\nAddAction PounceJump 27\nAddAction EnergySift 28\nAddAction MediComp 29\nAddAction Weapon0 30\nAddAction Weapon1 31\nAddAction Weapon2 32\nAddAction Weapon3 33\nAddAction Weapon4 34\nAddAction Weapon5 35\nAddAction Weapon6 36\nAddAction Weapon7 37\nAddAction Weapon8 38\nAddAction Weapon9 39\nAddAction Item0 40\nAddAction Item1 41\nAddAction Item2 42\nAddAction Item3 43\nAddAction Item4 44\nAddAction Item5 45\nAddAction Item6 46\nAddAction Item7 47\nAddAction Item8 48\nAddAction Item9 49\nAddAction PrevVision 50\nAddAction NextVision 51\nAddAction PrevHud 60\nAddAction NextHud 61\nAddAction MouseAim 62\nAddAction Crosshair 63\nAddAction ChaseView 64\nAddAction QuickSave 65\nAddAction QuickLoad 66\nAddAction Message 70\nAddAction TeamMessage 71\nAddAction ScoreDisplay 72\nAddAction PlayerInfo 73\nAddAction Taunt 74\nAddAction LeaveUnassigned 99\nAddAction Axis3 -3\nAddAction Axis2 -2\nAddAction Axis1 -1\nAddAction AxisYaw -10001\nAddAction AxisPitch -10002\nAddAction AxisLeftRight -10003\nAddAction AxisForwardBackward -10004\n\nenabledevice \"##keyboard\"\nrangebind \"##keyboard\" \"##45\" 0.000000 0.000000 \"LastWeapon\"\nrangebind \"##keyboard\" \"##11\" 0.000000 0.000000 \"Weapon9\"\nrangebind \"##keyboard\" \"##10\" 0.000000 0.000000 \"Weapon8\"\nrangebind \"##keyboard\" \"##9\" 0.000000 0.000000 \"Weapon7\"\nrangebind \"##keyboard\" \"##8\" 0.000000 0.000000 \"Weapon6\"\nrangebind \"##keyboard\" \"##7\" 0.000000 0.000000 \"Weapon5\"\nrangebind \"##keyboard\" \"##6\" 0.000000 0.000000 \"Weapon4\"\nrangebind \"##keyboard\" \"##5\" 0.000000 0.000000 \"Weapon3\"\nrangebind \"##keyboard\" \"##4\" 0.000000 0.000000 \"Weapon2\"\nrangebind \"##keyboard\" \"##3\" 0.000000 0.000000 \"Weapon1\"\nrangebind \"##keyboard\" \"##2\" 0.000000 0.000000 \"Weapon0\"\nrangebind \"##keyboard\" \"##20\" 0.000000 0.000000 \"TorchSelect\"\nrangebind \"##keyboard\" \"##35\" 0.000000 0.000000 \"Item2\"\nrangebind \"##keyboard\" \"##33\" 0.000000 0.000000 \"Item1\"\nrangebind \"##keyboard\" \"##34\" 0.000000 0.000000 \"Item0\"\nrangebind \"##keyboard\" \"##19\" 0.000000 0.000000 \"Reload\"\nrangebind \"##keyboard\" \"##44\" 0.000000 0.000000 \"PrevWeapon\"\nrangebind \"##keyboard\" \"##16\" 0.000000 0.000000 \"NextWeapon\"\nrangebind \"##keyboard\" \"##18\" 0.000000 0.000000 \"Activate\"\nrangebind \"##keyboard\" \"##53\" 0.000000 0.000000 \"CrouchToggle\"\nrangebind \"##keyboard\" \"##42\" 0.000000 0.000000 \"Duck\"\nrangebind \"##keyboard\" \"##52\" 0.000000 0.000000 \"Crosshair\"\nrangebind \"##keyboard\" \"##14\" 0.000000 0.000000 \"Taunt\"\nrangebind \"##keyboard\" \"##43\" 0.000000 0.000000 \"TeamMessage\"\nrangebind \"##keyboard\" \"##28\" 0.000000 0.000000 \"Message\"\nrangebind \"##keyboard\" \"##15\" 0.000000 0.000000 \"ScoreDisplay\"\nrangebind \"##keyboard\" \"##210\" 0.000000 0.000000 \"MouseAim\"\nrangebind \"##keyboard\" \"##211\" 0.000000 0.000000 \"CenterView\"\nrangebind \"##keyboard\" \"##207\" 0.000000 0.000000 \"LookDown\"\nrangebind \"##keyboard\" \"##199\" 0.000000 0.000000 \"LookUp\"\nrangebind \"##keyboard\" \"##47\" 0.000000 0.000000 \"NextVision\"\nrangebind \"##keyboard\" \"##57\" 0.000000 0.000000 \"Jump\"\nrangebind \"##keyboard\" \"##50\" 0.000000 0.000000 \"RunLock\"\nrangebind \"##keyboard\" \"##58\" 0.000000 0.000000 \"Run\"\nrangebind \"##keyboard\" \"##37\" 0.000000 0.000000 \"Strafe\"\nrangebind \"##keyboard\" \"##32\" 0.000000 0.000000 \"StrafeRight\"\nrangebind \"##keyboard\" \"##30\" 0.000000 0.000000 \"StrafeLeft\"\nrangebind \"##keyboard\" \"##205\" 0.000000 0.000000 \"Right\"\nrangebind \"##keyboard\" \"##203\" 0.000000 0.000000 \"Left\"\nrangebind \"##keyboard\" \"##31\" 0.000000 0.000000 \"Backward\"\nrangebind \"##keyboard\" \"##17\" 0.000000 0.000000 \"Forward\"\nrangebind \"##keyboard\" \"##12\" 0.000000 0.000000 \"PrevHud\"\nrangebind \"##keyboard\" \"##13\" 0.000000 0.000000 \"NextHud\"\nrangebind \"##keyboard\" \"##64\" 0.000000 0.000000 \"QuickSave\"\nrangebind \"##keyboard\" \"##65\" 0.000000 0.000000 \"QuickLoad\"\nenabledevice \"##mouse\"\nrangebind \"##mouse\" \"##z-axis\" -255.000000 -0.100000 \"NextWeapon\" 0.100000 255.000000 \"PrevWeapon\"\nrangebind \"##mouse\" \"##4\" 0.000000 0.000000 \"AltFire\"\nrangebind \"##mouse\" \"##3\" 0.000000 0.000000 \"Fire\"\nrangebind \"##mouse\" \"##y-axis\" 0.000000 0.000000 \"Axis2\"\nscale \"##mouse\" \"##y-axis\" 0.002583\nrangebind \"##mouse\" \"##x-axis\" 0.000000 0.000000 \"Axis1\"\nscale \"##mouse\" \"##x-axis\" 0.002348\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            SW.WriteLine(output);
            SW.Close();
        }

        private void CreateGenericAVP2Cmds()
        {
            string output = "-windowtitle \"Aliens vs. Predator 2\" -rez AVP2.rez -rez sounds.rez -rez Alien.rez -rez Marine.rez -rez Predator.rez -rez Multi.rez -rez AVP2dll.rez -rez AVP2l.rez -rez custom -rez AVP2p.rez -rez AVP2p2.rez -rez AVP2P1.REZ +DisableMusic 0 +DisableSound 0 +DisableMovies 0 +DisableJoystick 1 +EnableTripBuf 0 +DisableHardwareCursor 0";
            StreamWriter SW = new StreamWriter(@"avp2cmds.txt");
            SW.WriteLine(output);
            SW.Close();
        }
    }
}

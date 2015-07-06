using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AVP_CustomLauncher
{
    public partial class ConfigChoice : Form
    {
        public ConfigChoice()
        {
            InitializeComponent();
        }

        private void B_Low_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter(@"autoexec.cfg");
            string outputLow = "\"FarZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Marine\"\n\"CardDesc\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"AutoswitchWeapons\" \"1\"\n\"MaxModelShadows\" \"0\"\n\"FogEnable\" \"0\"\n\"HeadCanting\" \"1\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"OrientOverlay\" \"1\"\n\"Renderer\" \"Main Screen Display\"\n\"DetailLevel\" \"1\"\n\"MouseSensitivity\" \"6.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"BitDepth\" \"32\"\n\"ScreenWidth\" \"640\"\n\"RenderDll\" \"d3d.ren\"\n\"Trilinear\" \"0\"\n\"UpdateRateInitted\" \"1\"\n\"32BitTextures\" \"0\"\n\"ObjectiveMessages\" \"1\"\n\"MuzzleLight\" \"0\"\n\"NumRuns\" \"3.000000\"\n\"EnableHints\" \"1\"\n\"DrawSky\" \"1\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"DetailTextures\" \"0\"\n\"IgnoreTaunts\" \"0\"\n\"PickupIconDuration\" \"5.000000\"\n\"EnvMapEnable\" \"0\"\n\"EnvMapWorld\" \"0\"\n\"InputRate\" \"5.000000\"\n\"GroupOffset0\" \"1\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GroupOffset1\" \"1\"\n\"EnableSky\" \"1\"\n\"GroupOffset2\" \"0\"\n\"InvertHack\" \"0\"\n\"GroupOffset3\" \"1\"\n\"GroupOffset4\" \"1\"\n\"MouseInvertY\" \"0\"\n\"GroupOffset5\" \"2\"\n\"UpdateRate\" \"4\"\n\"GroupOffset6\" \"0\"\n\"GroupOffset7\" \"0\"\n\"GroupOffset8\" \"0\"\n\"GroupOffset9\" \"0\"\n\"GameScreenHeight\" \"480\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"ScreenHeight\" \"480\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"32BitLightMaps\" \"0\"\n\"GameScreenWidth\" \"640\"\n\"ImpactFXLevel\" \"0\"\n\"PerformanceConfig\" \".DefaultHigh\"\n\"FogPerformanceScale\" \"20\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"0\"\n\"ShellCasings\" \"0\"\n\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            SW.WriteLine(outputLow);
            SW.Close();
            this.Close();
        }

        private void B_Medium_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter(@"autoexec.cfg");
            string outputMedium = "\"FarZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Marine\"\n\"CardDesc\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MaxModelShadows\" \"1\"\n\"AutoswitchWeapons\" \"1\"\n\"FogEnable\" \"0\"\n\"HeadCanting\" \"1\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"OrientOverlay\" \"1\"\n\"Renderer\" \"Main Screen Display\"\n\"DetailLevel\" \"2\"\n\"MouseSensitivity\" \"6.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"BitDepth\" \"32\"\n\"ScreenWidth\" \"800\"\n\"RenderDll\" \"d3d.ren\"\n\"Trilinear\" \"0\"\n\"UpdateRateInitted\" \"1\"\n\"32BitTextures\" \"1\"\n\"MuzzleLight\" \"1\"\n\"ObjectiveMessages\" \"1\"\n\"EnableHints\" \"1\"\n\"NumRuns\" \"2.000000\"\n\"DrawSky\" \"1\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"DetailTextures\" \"1\"\n\"PickupIconDuration\" \"5.000000\"\n\"IgnoreTaunts\" \"0\"\n\"EnvMapEnable\" \"1\"\n\"EnvMapWorld\" \"0\"\n\"InputRate\" \"5.000000\"\n\"GroupOffset0\" \"0\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GroupOffset1\" \"0\"\n\"EnableSky\" \"1\"\n\"GroupOffset2\" \"-1\"\n\"InvertHack\" \"0\"\n\"GroupOffset3\" \"1\"\n\"GroupOffset4\" \"1\"\n\"MouseInvertY\" \"0\"\n\"GroupOffset5\" \"1\"\n\"UpdateRate\" \"4\"\n\"GroupOffset6\" \"-1\"\n\"GroupOffset7\" \"-1\"\n\"GroupOffset8\" \"-1\"\n\"GroupOffset9\" \"-1\"\n\"GameScreenHeight\" \"600\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"ScreenHeight\" \"600\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"32BitLightMaps\" \"0\"\n\"GameScreenWidth\" \"800\"\n\"ImpactFXLevel\" \"1\"\n\"PerformanceConfig\" \".DefaultMid\"\n\"FogPerformanceScale\" \"60\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"1\"\n\"ShellCasings\" \"1\"\n\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            SW.WriteLine(outputMedium);
            SW.Close();
            this.Close();

        }

        private void B_High_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter(@"autoexec.cfg");
            string outputHigh = "\"FarZ\" \"10000.000000\"\n\"LMFullBright\" \"0\"\n\"SpeciesName\" \"Marine\"\n\"CardDesc\" \"display\"\n\"NormalTurnRate\" \"1.500000\"\n\"MaxModelShadows\" \"1\"\n\"AutoswitchWeapons\" \"1\"\n\"FogEnable\" \"0\"\n\"HeadCanting\" \"1\"\n\"LowViolence\" \"0\"\n\"RunLock\" \"1\"\n\"WeaponSway\" \"1\"\n\"OrientOverlay\" \"1\"\n\"Renderer\" \"Main Screen Display\"\n\"DetailLevel\" \"3\"\n\"MouseSensitivity\" \"6.000000\"\n\"FastTurnRate\" \"2.300000\"\n\"BitDepth\" \"32\"\n\"ScreenWidth\" \"1024\"\n\"RenderDll\" \"d3d.ren\"\n\"Trilinear\" \"1\"\n\"UpdateRateInitted\" \"1\"\n\"32BitTextures\" \"1\"\n\"MuzzleLight\" \"1\"\n\"ObjectiveMessages\" \"1\"\n\"EnableHints\" \"1\"\n\"NumRuns\" \"2.000000\"\n\"DrawSky\" \"1\"\n\"MsgMgrTimeScale\" \"0.750000\"\n\"DetailTextures\" \"1\"\n\"PickupIconDuration\" \"5.000000\"\n\"IgnoreTaunts\" \"0\"\n\"EnvMapEnable\" \"1\"\n\"EnvMapWorld\" \"1\"\n\"InputRate\" \"5.000000\"\n\"GroupOffset0\" \"0\"\n\"MouseLook\" \"1\"\n\"Subtitles\" \"1\"\n\"GroupOffset1\" \"0\"\n\"EnableSky\" \"1\"\n\"GroupOffset2\" \"-1\"\n\"InvertHack\" \"0\"\n\"GroupOffset3\" \"0\"\n\"GroupOffset4\" \"0\"\n\"MouseInvertY\" \"0\"\n\"GroupOffset5\" \"0\"\n\"UpdateRate\" \"4\"\n\"GroupOffset6\" \"-1\"\n\"GroupOffset7\" \"-1\"\n\"GroupOffset8\" \"-1\"\n\"GroupOffset9\" \"-1\"\n\"GameScreenHeight\" \"768\"\n\"MsgMgrMaxHeight\" \"0.200000\"\n\"DrawViewModel\" \"1\"\n\"ScreenHeight\" \"768\"\n\"TripleBuffer\" \"0\"\n\"ServerConfig\" \"unnamed\"\n\"32BitLightMaps\" \"1\"\n\"GameScreenWidth\" \"1024\"\n\"ImpactFXLevel\" \"2\"\n\"PerformanceConfig\" \".DefaultLow\"\n\"FogPerformanceScale\" \"100\"\n\"GameBitDepth\" \"32\"\n\"LookUpRate\" \"2.500000\"\n\"HeadBob\" \"1\"\n\"DebrisFXLevel\" \"2\"\n\"ShellCasings\" \"1\"\n\nModelAdd 0.000000 0.000000 0.000000\nModelDirAdd 0.000000 0.000000 0.000000\nWMAmbient 0.000000 0.000000 0.000000\n";
            SW.WriteLine(outputHigh);
            SW.Close();
            this.Close();
        }
    }
}

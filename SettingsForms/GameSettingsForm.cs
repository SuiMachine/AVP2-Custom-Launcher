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
using System.Text.RegularExpressions;

namespace AVP_CustomLauncher
{
    public partial class GameSettings : Form
    {
        const string autoexecfile = "autoexec.cfg";
        const string customConfig = "autoexecextended.cfg";
        public int ResolutionX = 1280;
        public int ResolutionY = 720;
        public bool windowed = false;
        public bool disablemusic = false;
        public bool disablesound = false;
        public bool disablelogos = false;
        public bool disabletripplebuffering = false;
        public bool disablejoystick = true;
        public bool disablehardwarecursor = false;

        public bool aspectratiohack = false;
        public float fov = 90.0f;
        string text = "";

        public GameSettings(mainform parent)
        {
            InitializeComponent();

            if (!File.Exists(@customConfig))
            {
                File.Create(@customConfig);
            }
            else
                readcustomconfig();
        }

        
        struct autoexecstruct
        {
            public bool GameBitDepth;
            public bool TripleBuffer;
            public float ScaleMenus;
            public bool FixTJunc;
        }
        autoexecstruct autoexec;


        private void GraphicsSettings_Load(object sender, EventArgs e)
        {
            readfile();
        }
        
        public void readcustomconfig()
        {
            StreamReader SR = new StreamReader(@customConfig);
            string line = "";

            while((line = SR.ReadLine()) != null)
            {
                string[] words = line.Split(':');
                if (words[0] == "Windowed")
                {
                    if(words[1] == "True")
                    {
                        C_Windowed.Checked = true;
                    }
                    else
                    {
                        C_Windowed.Checked = false;
                    }
                }
                else if (words[0] == "DisableSound")
                {
                    if(words[1] == "True")
                    {
                        C_DisableSound.Checked = true;
                    }
                    else
                    {
                        C_DisableSound.Checked = false;
                    }
                }
                else if (words[0] == "DisableMusic")
                {
                    if (words[1] == "True")
                    {
                        C_DisableMusic.Checked = true;
                    }
                    else
                    {
                        C_DisableMusic.Checked = false;
                    }
                }
                else if (words[0] == "DisableLogos")
                {
                    if (words[1] == "True")
                    {
                        C_DisableLogos.Checked = true;
                    }
                    else
                    {
                        C_DisableLogos.Checked = false;
                    }
                }
                else if (words[0] == "DisableTrippleBuffering")
                {
                    if (words[1] == "True")
                    {
                        C_DisableTripleBuffering.Checked = true;
                    }
                    else
                    {
                        C_DisableTripleBuffering.Checked = false;
                    }
                }
                else if (words[0] == "DisableJoystick")
                {
                    if (words[1] == "True")
                    {
                        C_DisableJoystick.Checked = true;
                    }
                    else
                    {
                        C_DisableJoystick.Checked = false;
                    }
                }
                else if (words[0] == "DisableHardwareCursor")
                {
                    if (words[1] == "True")
                    {
                        C_DisableHardwareCursor.Checked = true;
                    }
                    else
                    {
                        C_DisableHardwareCursor.Checked = false;
                    }
                }
                else if (words[0] == "AspectRatioFix")
                {
                    if (words[1] == "True")
                    {
                        C_EnableAspectRatioMemoryWrite.Checked = true;
                    }
                    else
                    {
                        C_EnableAspectRatioMemoryWrite.Checked = false;
                    }
                }
                else if (words[0] == "FOV")
                {
                    TB_FOV.Text = words[1];     //Nothing else needed, cause it's getting parsed, when the text changes.
                }
                else if (words[0] == "CVARS")
                {
                    T_CommandLine.Text = words[1];
                }
            }
            SR.Close();

        }


        public void readfile()
        {
            StreamReader SR = new StreamReader(@autoexecfile);
            text = "";
            string line = "";

            ResolutionX = 1280;
            ResolutionY = 720;
            autoexec.GameBitDepth = true;
            autoexec.ScaleMenus = 1.0f;
            autoexec.TripleBuffer = false;
            autoexec.FixTJunc = false;

            while ((line = SR.ReadLine()) != null)                                              //Yes, I know this is slow... does its job for such files anyway
            {
                if (line.StartsWith("\"SCREENWIDTH\"") || line.StartsWith("\"ScreenWidth\""))
                {
                    var res = 0;
                    line = Regex.Match(line, @"\d+").Value;
                    if (int.TryParse(line, out res))
                    {
                        ResolutionX = res;
                    }
                    T_ResolutionX.Text = ResolutionX.ToString();

                    continue;
                }
                else if (line.StartsWith("\"GameScreenWidth\""))
                {
                    line = "";
                    continue;
                }
                else if (line.StartsWith("\"SCREENHEIGHT\"") || line.StartsWith("\"ScreenHeight\""))
                {
                    var res = 0;
                    line = Regex.Match(line, @"\d+").Value;
                    if (int.TryParse(line, out res))
                    {
                        ResolutionY = res;
                    }
                    T_ResolutionY.Text = ResolutionY.ToString();

                    continue;
                }
                else if (line.StartsWith("\"GameScreenHeight\""))
                {
                    line = "";
                    continue;
                }
                else if (line.StartsWith("\"GameBitDepth\""))
                {
                    if (line.EndsWith("\"16\""))
                    {
                        autoexec.GameBitDepth = false;
                        C_32color.Checked = false;
                    }
                    else
                    {
                        autoexec.GameBitDepth = true;
                        C_32color.Checked = true;
                    }

                    continue;
                }
                else if (line.StartsWith("\"FixTJunc\""))
                {
                    if (line.EndsWith("\"1\""))
                        autoexec.FixTJunc = true;
                    else autoexec.FixTJunc = false;

                    continue;
                }
                else
                    text = text + line + "\n";
            }
            B_ManualEdit.Text = text;
            SR.Close();
        }

        private void T_ResolutionX_TextChanged(object sender, EventArgs e)
        {
            var res = 1280;
            if(int.TryParse(T_ResolutionX.Text, out res))
            {
                ResolutionX = res;
            }
        }

        private void T_ResolutionY_TextChanged(object sender, EventArgs e)
        {
            var res = 720;
            if (int.TryParse(T_ResolutionY.Text, out res))
            {
                ResolutionY = res;
            }
        }

        private void C_Windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (C_Windowed.Checked)
                windowed = true;
            else
                windowed = false;
        }

        private void C_EnableAspectRatioMemoryWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (C_EnableAspectRatioMemoryWrite.Checked)
            {
                aspectratiohack = true;
                TB_FOV.Enabled = true;
            }
            else
            {
                aspectratiohack = false;
                TB_FOV.Enabled = false;
            }

        }

        private void C_32color_CheckedChanged(object sender, EventArgs e)
        {
            if (C_32color.Checked)
                autoexec.GameBitDepth = true;
            else
                autoexec.GameBitDepth = false;
        }

        private void TB_FOV_TextChanged(object sender, EventArgs e)
        {
            var res = 90.0f;
            if(float.TryParse(TB_FOV.Text, out res))
            {
                fov = res;
            }
        }

        private void savecustomconfig()
        {
            StreamWriter SW = new StreamWriter(@customConfig);
            string output = "";
            output = output + "Windowed:" + windowed.ToString() + "\n";
            output = output + "DisableSound:" + disablesound.ToString() + "\n";            
            output = output + "DisableMusic:" + disablemusic.ToString() + "\n";
            output = output + "DisableLogos:" + disablelogos.ToString() + "\n";
            output = output + "DisableTrippleBuffering:" + disabletripplebuffering.ToString() + "\n";
            output = output + "DisableJoystick:" + disablejoystick.ToString() + "\n";
            output = output + "DisableHardwareCursor:" + disablehardwarecursor.ToString() + "\n";
            output = output + "AspectRatioFix:" + aspectratiohack.ToString() + "\n";
            output = output + "FOV:" + fov.ToString() + "\n";
            output = output + "CVARS:" + T_CommandLine.Text + "\n"; 

            SW.WriteLine(output);
            SW.Close();
        }

        private void savefile()
        {
            StreamWriter SW = new StreamWriter(@autoexecfile);
            string output = "";
            output = output + "\"SCREENWIDTH\" \"" + ResolutionX.ToString() + "\"\n";
            output = output + "\"GameScreenWidth\" \"" + ResolutionX.ToString() + "\"\n";
            output = output + "\"SCREENHEIGHT\" \"" + ResolutionY.ToString() + "\"\n";
            output = output + "\"GameScreenWidth\" \"" + ResolutionY.ToString() + "\"\n";

            if(autoexec.GameBitDepth)
                output = output + "\"GameBitDepth\" \"32\"\n";
            else
                output = output + "\"GameBitDepth\" \"16\"\n";

            if(autoexec.FixTJunc)
                output = output + "\"FixTJunc\" \"1\"\n";
            else
                output = output + "\"FixTJunc\" \"0\"\n";

            output = output + text;
            SW.WriteLine(output);
            SW.Close();
        }

        private void B_ManualEdit_TextChanged(object sender, EventArgs e)
        {
            text = B_ManualEdit.Text;
        }

        private void B_SaveAndClose_Click(object sender, EventArgs e)
        {
            savecustomconfig();
            savefile();
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void C_DisableSound_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableSound.Checked)
                disablesound = true;
            else
                disablesound = false;
        }

        private void C_DisableMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableMusic.Checked)
                disablemusic = true;
            else
                disablemusic = false;
        }

        private void C_DisableLogos_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableLogos.Checked)
                disablelogos = true;
            else
                disablelogos = false;
        }

        private void C_DisableTripleBuffering_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableTripleBuffering.Checked)
                disabletripplebuffering = true;
            else
                disabletripplebuffering = false;
        }

        private void C_DisableJoystick_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableJoystick.Checked)
                disablejoystick = true;
            else
                disablejoystick = false;
        }

        private void C_DisableHardwareCursor_CheckedChanged(object sender, EventArgs e)
        {
            if (C_DisableHardwareCursor.Checked)
                disablehardwarecursor = true;
            else
                disablehardwarecursor = false;
        }

        private void T_CommandLine_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

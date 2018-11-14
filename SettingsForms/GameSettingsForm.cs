using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AVP_CustomLauncher
{
    public partial class GameSettings : Form
    {
        const string autoexecfile = "autoexec.cfg";
        const string customConfig = "autoexecextended.cfg";
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public bool windowed = false;
        public bool disablemusic = false;
        public bool disablesound = false;
        public bool disablelogos = false;
        public bool disabletripplebuffering = false;
        public bool disablejoystick = true;
        public bool disablehardwarecursor = false;
        public bool GameBitDepth = true;
        public bool TripleBuffer = false;
        public float ScaleMenus = 1.0f;
        public bool FixTJunc = false;
        public bool notificationWindowed = true;
        public bool notificationToBig = true;

        public bool aspectratiohack = false;
        public float fov = 90.0f;
        string text = "";

        public GameSettings(mainform parent)
        {
            ResolutionX = 1280;
            ResolutionY = 720;
            InitializeComponent();

            if (File.Exists(customConfig))
                readcustomconfig();

            readfile();
        }



        private void GraphicsSettings_Load(object sender, EventArgs e)
        {
        }

        #region ReadFunctions
        public void readcustomconfig()
        {
            StreamReader SR = new StreamReader(customConfig);
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
            StreamReader SR = new StreamReader(autoexecfile);
            text = "";
            string line = "";

            ResolutionX = 1280;
            ResolutionY = 720;
            GameBitDepth = true;
            ScaleMenus = 1.0f;
            TripleBuffer = false;
            FixTJunc = false;

            while ((line = SR.ReadLine()) != null)                                              //Yes, I know this is slow... does its job for such files anyway
            {
                if (line.StartsWith("\"SCREENWIDTH\"", StringComparison.InvariantCultureIgnoreCase))
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
                else if (line.StartsWith("\"GameScreenWidth\"", StringComparison.InvariantCultureIgnoreCase))
                {
                    line = "";
                    continue;
                }
                else if (line.StartsWith("\"SCREENHEIGHT\"", StringComparison.InvariantCultureIgnoreCase))
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
                else if (line.StartsWith("\"GameScreenHeight\"", StringComparison.InvariantCultureIgnoreCase))
                {
                    line = "";
                    continue;
                }
                else if (line.StartsWith("\"GameBitDepth\"", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (line.EndsWith("\"16\""))
                    {
                        GameBitDepth = false;
                        C_32color.Checked = false;
                    }
                    else
                    {
                        GameBitDepth = true;
                        C_32color.Checked = true;
                    }

                    continue;
                }
                else if (line.StartsWith("\"FixTJunc\"", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (line.EndsWith("\"1\""))
                        FixTJunc = true;
                    else FixTJunc = false;

                    continue;
                }
                else
                    text = text + line + "\n";
            }
            B_ManualEdit.Text = text;
            SR.Close();
            notificationToBig = false;
            notificationWindowed = false;
        }
        #endregion

        #region SaveFunctions
        private void savecustomconfig()
        {
            string output = "";
            output += "Windowed:" + windowed.ToString() + "\n";
            output += "DisableSound:" + disablesound.ToString() + "\n";            
            output += "DisableMusic:" + disablemusic.ToString() + "\n";
            output += "DisableLogos:" + disablelogos.ToString() + "\n";
            output += "DisableTrippleBuffering:" + disabletripplebuffering.ToString() + "\n";
            output += "DisableJoystick:" + disablejoystick.ToString() + "\n";
            output += "DisableHardwareCursor:" + disablehardwarecursor.ToString() + "\n";
            output += "AspectRatioFix:" + aspectratiohack.ToString() + "\n";
            output += "FOV:" + fov.ToString() + "\n";
            output += "CVARS:" + T_CommandLine.Text + "\n";

            File.WriteAllText(customConfig, output);
        }

        private void savefile()
        {
            string output = "";
            output += "\"SCREENWIDTH\" \"" + ResolutionX.ToString() + "\"\n";
            output += "\"GameScreenWidth\" \"" + ResolutionX.ToString() + "\"\n";
            output += "\"SCREENHEIGHT\" \"" + ResolutionY.ToString() + "\"\n";
            output += "\"GameScreenHeight\" \"" + ResolutionY.ToString() + "\"\n";

            if(GameBitDepth)
                output += "\"GameBitDepth\" \"32\"\n";
            else
                output += "\"GameBitDepth\" \"16\"\n";

            if(FixTJunc)
                output += "\"FixTJunc\" \"1\"\n";
            else
                output += "\"FixTJunc\" \"0\"\n";

            output += text;
            File.WriteAllText(autoexecfile, output);
        }
        #endregion

        #region EventHandlers
        private void T_ResolutionX_TextChanged(object sender, EventArgs e)
        {
            var res = 1280;
            if (int.TryParse(T_ResolutionX.Text, out res))
            {
                ResolutionX = res;

                if(ResolutionX > 2048 && notificationToBig == false)
                {
                    notificationToBig = true;
                    if(!File.Exists("D3DIM700.DLL"))
                    {
                        DialogResult result = MessageBox.Show("For resolutions wider than 2048 you'll need jackfuste's D3DIM700.dll wrapper. Running the game without it, will either crash the game or cause it to start in 640x480. Do you wish to download it?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("http://www.wsgf.org/forums/viewtopic.php?p=155982#p155982");
                        }
                    }
                }
            }
        }

        private void T_ResolutionY_TextChanged(object sender, EventArgs e)
        {
            var res = 720;
            if (int.TryParse(T_ResolutionY.Text, out res))
            {
                ResolutionY = res;
                if (ResolutionY > 2048 && notificationToBig == false)
                {
                    notificationToBig = true;
                    if (!File.Exists("D3DIM700.DLL"))
                    {
                        DialogResult result = MessageBox.Show("For resolutions higher than 2048 you'll need jackfuste's D3DIM700.dll wrapper. Running the game without it, will either crash the game or cause it to start in 640x480. Do you wish to download it?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("http://www.wsgf.org/forums/viewtopic.php?p=155982#p155982");
                        }
                    }
                }
            }
        }

        private void C_Windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (C_Windowed.Checked)
            {
                windowed = true;
                if(!notificationWindowed)
                {
                    notificationWindowed = true;
                    MessageBox.Show("Warning: The game uses V-sync to limit its framerate and has some unintended behaviours when the framerate is uncapped.\n\nSince V-sync doesn't work in windowed mode, make sure to use either GPU control panel setting or external application (like Dxtory) to limit your framerate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

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
                GameBitDepth = true;
            else
                GameBitDepth = false;
        }

        private void TB_FOV_TextChanged(object sender, EventArgs e)
        {
            var res = 90.0f;
            if (float.TryParse(TB_FOV.Text, out res))
            {
                fov = res;
            }
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
        #endregion
    }
}

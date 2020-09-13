using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AVP_CustomLauncher
{
    public partial class GameSettings : Form
    {
        const string autoexecfile = "autoexec.cfg";
        //const string customConfig = "autoexecextended.cfg";
        public Config.CustomConfig customConfig { get; set; }

        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public bool GameBitDepth = true;
        public bool TripleBuffer = false;
        public float ScaleMenus = 1.0f;
        public bool FixTJunc = false;
        public bool notificationWindowed = true;
        public bool notificationToBig = true;

        //LithFix Variables
        public bool lithFixEnabled = false;
        public bool lithFixBorderless = false;
        public float lithFixFPSCap = 60.0f;

        string text = "";

        public GameSettings(mainform parent)
        {
            ResolutionX = 1280;
            ResolutionY = 720;
            InitializeComponent();

            customConfig = Config.CustomConfig.Load();

            readfile();
        }

        #region ReadFunctions
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
                else if (line.StartsWith("\"lf_borderless_window\"", StringComparison.InvariantCultureIgnoreCase))
                {
                    if(line.Contains(" "))
                    {
                        var split = line.Split(new char[] { ' ' }, 2);
                        if (float.TryParse(split[1], out float result))
                        {
                            if (result == 1.0f)
                                lithFixBorderless = true;
                            else
                                lithFixBorderless = false;
                        }
                    }
                    else
                        lithFixEnabled = false;
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
                customConfig.Windowed = true;
                if(!notificationWindowed)
                {
                    notificationWindowed = true;
                    MessageBox.Show("Warning: The game uses V-sync to limit its framerate and has some unintended behaviours when the framerate is uncapped.\n\nSince V-sync doesn't work in windowed mode, make sure to use either GPU control panel setting or external application (like Dxtory) to limit your framerate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                customConfig.Windowed = false;
        }

        private void C_EnableAspectRatioMemoryWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (C_EnableAspectRatioMemoryWrite.Checked)
            {
                customConfig.AspectRatioFix = true;
                TB_FOV.Enabled = true;
            }
            else
            {
                customConfig.AspectRatioFix = false;
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
                customConfig.FOV = res;
            }
        }



        private void B_ManualEdit_TextChanged(object sender, EventArgs e)
        {
            text = B_ManualEdit.Text;
        }

        private void B_SaveAndClose_Click(object sender, EventArgs e)
        {
            customConfig.CVARS = T_CommandLine.Text;
            customConfig.Save();
            savefile();
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void C_DisableSound_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableSound = C_DisableSound.Checked;
        }

        private void C_DisableMusic_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableMusic = C_DisableMusic.Checked;
        }

        private void C_DisableLogos_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableLogos = C_DisableLogos.Checked;
        }

        private void C_DisableTripleBuffering_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableTrippleBuffering = C_DisableTripleBuffering.Checked;
        }

        private void C_DisableJoystick_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableJoystick = C_DisableJoystick.Checked;
        }

        private void C_DisableHardwareCursor_CheckedChanged(object sender, EventArgs e)
        {
            customConfig.DisableHardwareCursor = C_DisableHardwareCursor.Checked;
        }
        #endregion

        private void CB_LithFix_ENABLED_CheckedChanged(object sender, EventArgs e)
        {
            CB_LithFix_Borderless.Enabled = C_LithFix_ENABLED.Checked;
        }
    }
}

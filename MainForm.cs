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
using System.Runtime.InteropServices;

namespace AVP_CustomLauncher
{
    public partial class mainform : Form
    {
        Config.CustomConfig customConfig;
        Config.LithTechConfig lithTechConfig;


        GameHack _gamehack = new GameHack();
        int _posX = 0;
        int _posY = 0;
        private bool skipLauncher = false;
        string originalParams = "";

        bool SP_PatchInstalled = false;

        public mainform(string[] originalParams)
        {
            customConfig = Config.CustomConfig.Load();
            lithTechConfig = Config.LithTechConfig.Load();

            if (originalParams.Contains("-skiplauncher", StringComparer.InvariantCultureIgnoreCase))
            {
                originalParams = originalParams.Where(x => x.ToLower() != "-skiplauncher").ToArray();
                skipLauncher = true;
            }
            this.originalParams = string.Join(" ", originalParams);
            LogHandler.WriteLine("LogFile created.");
            InitializeComponent();
            if (File.Exists("autoexecextended.cfg"))
            {
                SetPositionFromConfig();
            }
        }

        #region Functions
        private void CheckForRequiredGameFiles()
        {
            string[] files = { "lithtech.exe", "ALIEN.REZ", "AVP2.REZ", "AVP2DLL.REZ", "AVP2L.REZ", "AVP2P1.REZ", "binkw32.dll", "d3d.ren", "MARINE.REZ", "MULTI.REZ", "PREDATOR.REZ", "SOUNDS.REZ" };

            for (int i = 0; i < files.Length; i++)
            {
                if (!File.Exists(files[i]))
                {
                    MessageBox.Show("No " + files[i] + " found. Please place the custom launcher in the directory with a game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            if(File.Exists("AVP2SP.REZ"))
                SP_PatchInstalled = true;

            if (!File.Exists("widescreenfix.dll"))
            {
                MessageBox.Show("Widescreenfix.dll has not been found. This file is required for Widescreen support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateGenericAVP2Cmds()
        {
            string output = "-windowtitle \"Aliens vs. Predator 2\" -rez AVP2.rez -rez sounds.rez -rez Alien.rez -rez Marine.rez -rez Predator.rez -rez Multi.rez -rez AVP2dll.rez -rez AVP2l.rez -rez AVP2p.rez -rez AVP2p2.rez -rez AVP2P1.REZ " +
                (SP_PatchInstalled ? "-rez AVP2SP.REZ ": "") +
                "-rez custom";
            File.WriteAllText("avp2cmds.txt", output);
        }

        private void SetPositionFromConfig()
        {
            if(checkIfPosIsCorrect(customConfig.PositionX, customConfig.PositionY))
            {
                this.StartPosition = FormStartPosition.Manual;
                this.SetDesktopLocation((int)customConfig.PositionX, (int)customConfig.PositionY);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }
        #endregion

        #region EventHandlers
        private void Mainform_Load(object sender, EventArgs e)
        {
            CheckForRequiredGameFiles();

            if (!File.Exists("autoexec.cfg"))
            {
                ConfigChoice _ConfigChoice = new ConfigChoice();
                _ConfigChoice.ShowDialog();
            }

            if (!File.Exists("avp2cmds.txt"))
            {
                MessageBox.Show("No avp2cmds.txt found. The launcher will try to create it based on files in your current directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateGenericAVP2Cmds();
            }


            if(skipLauncher)
            {
                this.WindowState = FormWindowState.Minimized;
                StartGame();
            }
        }

        private void B_StartGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }


        //        GameSettings _GraphicsSettings;

        private void StartGame()
        {
            string cmdlineparamters = File.ReadLines("avp2cmds.txt").FirstOrDefault();
            cmdlineparamters = stripResolutionParameters(cmdlineparamters);

            if(customConfig.Windowed)
                cmdlineparamters += " +windowed 1";
            else
				cmdlineparamters += " +windowed 0";

            if(customConfig.DisableSound)
				cmdlineparamters += " +DisableSound 1";
            else
                cmdlineparamters += " +DisableSound 0";

            if(customConfig.DisableMusic)
                cmdlineparamters += " +DisableMusic 1";
            else
                cmdlineparamters += " +DisableMusic 0";

            if(customConfig.DisableLogos)
                cmdlineparamters += " +DisableMovies 1";
            else
                cmdlineparamters += " +DisableMovies 0";

            if(customConfig.DisableJoystick)
                cmdlineparamters += " +DisableJoystick 1";
            else
                cmdlineparamters += " +DisableJoystick 0";

            if(customConfig.DisableTrippleBuffering)
                cmdlineparamters += " +EnableTripBuf 0";
            else
                cmdlineparamters += " +EnableTripBuf 1";

            if(customConfig.DisableHardwareCursor)
                cmdlineparamters += " +DisableHardwareCursor 1";
            else
                cmdlineparamters += " +DisableHardwareCursor 0";

			cmdlineparamters += $" {originalParams} {customConfig.CVARS}";

            LogHandler.WriteLine("Launch parameters are: " + cmdlineparamters);

            Thread GameHackThread = new Thread(_gamehack.DoWork);
            if (customConfig.AspectRatioFix)
            {
                _gamehack.SendValues(customConfig.FOV, (int)lithTechConfig.GameScreenWidth, (int)lithTechConfig.GameScreenHeight);
                GameHackThread.Start();
            }


            try
            {
                Process gameProcess = new Process();
                gameProcess.StartInfo.FileName = Path.Combine(Directory.GetCurrentDirectory(), "Lithtech.exe");
                gameProcess.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                gameProcess.StartInfo.Arguments = cmdlineparamters;
                this.WindowState = FormWindowState.Minimized;

                gameProcess.Start();
                gameProcess.WaitForExit();
                _gamehack.RequestStop();
                this.Close();
            }
            catch(Exception ex)
            {
                LogHandler.WriteLine("An error occurred when creating new process: " + ex.Message);
                return;
            }
        }

        private string stripResolutionParameters(string cmdlineparamters)
        {
            string[] words = cmdlineparamters.Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].ToLower() == "++gamescreenwidth" || words[i].ToLower() == "++screenwidth")
                {
					if (uint.TryParse(words[i + 1], out _))
                    {
                        words[i + 1] = lithTechConfig.GameScreenWidth.ToString();
                        i++;
                    }
                }
                else if (words[i].ToLower() == "++gamescreenheight" || words[i].ToLower() == "++screenheight")
                {
					if (uint.TryParse(words[i + 1], out _))
                    {
                        words[i + 1] = lithTechConfig.GameScreenHeight.ToString();
                        i++;
                    }
                }
                else if (words[i].ToLower() == "++gamebitdepth" || words[i].ToLower() == "++bitdepth")
                {
					if (uint.TryParse(words[i + 1], out _))
                    {
                        words[i + 1] = lithTechConfig.GameBitDepth.ToString();

                        i++;
                    }
                }
            }
            return string.Join(" ", words);
        }

        private void B_DisplaySettings_Click(object sender, EventArgs e)
        {
            using (GameSettings _GraphicsSettings = new GameSettings(new Config.CustomConfig(customConfig), new Config.LithTechConfig(lithTechConfig)))
			{
                _GraphicsSettings.StartPosition = FormStartPosition.Manual;
                _GraphicsSettings.SetDesktopLocation(this.DesktopLocation.X + 20, this.DesktopLocation.Y + 20);
                if (_GraphicsSettings.ShowDialog() == DialogResult.OK)
                {
                    lithTechConfig = _GraphicsSettings.lithTechConfig;
                    customConfig = _GraphicsSettings.customConfig;
                }
            }
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            _gamehack.RequestStop();
            this.Close();
        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            customConfig.Save();
            LogHandler.Close();
        }
        #endregion


        private bool checkIfPosIsCorrect(uint PosX, uint PosY)
        {
            Screen[] screens = Screen.AllScreens;
            foreach (Screen screen in screens)
            {
                Rectangle scrRect = screen.WorkingArea;
                if (PosX > scrRect.X && PosX < scrRect.X + scrRect.Width &&
                    PosY > scrRect.Y && PosY < scrRect.Y + scrRect.Height)
                    return true;
            }
            return false;
        }

        private void Mainform_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && this.DesktopLocation.X > 0 && this.DesktopLocation.Y>0 && this.DesktopLocation.X < 14000)
            {
                _posX = this.DesktopLocation.X;
                _posY = this.DesktopLocation.Y;
            }
        }

        private void ProjectPageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SuiMachine/AVP2-Custom-Launcher");
        }

        private void PcgwLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://pcgamingwiki.com/wiki/Aliens_versus_Predator_2");
        }

        private void DonatePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://streamlabs.com/suicidemachine");
        }

        private void WSGFLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.wsgf.org/dr/aliens-versus-predator-2-gold-edition");
        }
    }
}

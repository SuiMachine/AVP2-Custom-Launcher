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
        GameSettings _GraphicsSettings;
        ConfigChoice _ConfigChoice;
        GameHack _gamehack = new GameHack();
        int _posX = 0;
        int _posY = 0;
        public bool tbbcbaseCompatibility = false;
        private bool skipLauncher = false;
        string originalParams = "";

        public mainform(string[] originalParams)
        {
            if(originalParams.Contains("-skiplauncher", StringComparer.InvariantCultureIgnoreCase))
            {
                originalParams = originalParams.Where(x => x.ToLower() != "-skiplauncher").ToArray();
                skipLauncher = true;
            }
            this.originalParams = string.Join(" ", originalParams);
            LogHandler.WriteLine("LogFile created.");
            InitializeComponent();
            if (File.Exists("autoexecextended.cfg"))
            {
                setPositionFromConfig();
            }
        }

        #region Functions
        private void CheckForRequiredGameFiles()
        {
            string[] files = { "lithtech.exe", "ALIEN.REZ", "AVP2SP.REZ", "AVP2.REZ", "AVP2DLL.REZ", "AVP2L.REZ", "AVP2P1.REZ", "binkw32.dll", "d3d.ren", "MARINE.REZ", "MULTI.REZ", "PREDATOR.REZ", "SOUNDS.REZ" };

            for (int i = 0; i < files.Length; i++)
            {
                if (!File.Exists(files[i]))
                {
                    MessageBox.Show("No " + files[i] + " found. Please place the custom launcher in the directory with a game!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            if (File.Exists("LITHSERVER.REZ"))
                tbbcbaseCompatibility = true;

            if (!File.Exists("widescreenfix.dll") && !tbbcbaseCompatibility)
            {
                MessageBox.Show("Widescreenfix.dll has not been found. This file is required for Widescreen support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void CreateGenericAVP2Cmds()
        {
            string output = "-windowtitle \"Aliens vs. Predator 2\" -rez AVP2.rez -rez sounds.rez -rez Alien.rez -rez Marine.rez -rez Predator.rez -rez Multi.rez -rez AVP2dll.rez -rez AVP2l.rez -rez AVP2p.rez -rez AVP2p2.rez -rez AVP2P1.REZ -rez AVP2SP.REZ -rez custom";
            File.WriteAllText("avp2cmds.txt", output);
        }

        private void setPositionFromConfig()
        {
            uint positionX = 0;
            uint positionY = 0;
            string[] setings = File.ReadAllLines("autoexecextended.cfg");
            foreach (string line in setings)
            {
                if (line.StartsWith("PositionX:"))
                {
                    positionX = parsePosition(line);
                }
                else if (line.StartsWith("PositionY:"))
                {
                    positionY = parsePosition(line);
                }
            }

            if(checkIfPosIsCorrect(positionX, positionY))
            {
                this.StartPosition = FormStartPosition.Manual;
                this.SetDesktopLocation((int)positionX, (int)positionY);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }

        }
        #endregion

        #region EventHandlers
        private void mainform_Load(object sender, EventArgs e)
        {
            CheckForRequiredGameFiles();

            if (!File.Exists("autoexec.cfg"))
            {
                _ConfigChoice = new ConfigChoice();
                _ConfigChoice.ShowDialog();
            }

            if (!File.Exists("avp2cmds.txt"))
            {
                MessageBox.Show("No avp2cmds.txt found. The launcher will try to create it based on files in your current directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateGenericAVP2Cmds();
            }

            _GraphicsSettings = new GameSettings(this);

            if(skipLauncher)
            {
                this.WindowState = FormWindowState.Minimized;
                startGame();
            }
        }

        private void B_StartGame_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            StreamReader SR = new StreamReader("avp2cmds.txt");
            string cmdlineparamters = "";
            cmdlineparamters = SR.ReadToEnd();
            cmdlineparamters = stripResolutionParameters(cmdlineparamters);

            if(_GraphicsSettings.windowed)
                cmdlineparamters = cmdlineparamters + " +windowed 1";
            else
                cmdlineparamters = cmdlineparamters + " +windowed 0";

            if(_GraphicsSettings.disablesound)
                cmdlineparamters = cmdlineparamters + " +DisableSound 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableSound 0";

            if(_GraphicsSettings.disablemusic)
                cmdlineparamters = cmdlineparamters + " +DisableMusic 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableMusic 0";

            if(_GraphicsSettings.disablelogos)
                cmdlineparamters = cmdlineparamters + " +DisableMovies 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableMovies 0";

            if(_GraphicsSettings.disablejoystick)
                cmdlineparamters = cmdlineparamters + " +DisableJoystick 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableJoystick 0";

            if(_GraphicsSettings.disabletripplebuffering)
                cmdlineparamters = cmdlineparamters + " +EnableTripBuf 0";
            else
                cmdlineparamters = cmdlineparamters + " +EnableTripBuf 1";

            if(_GraphicsSettings.disablehardwarecursor)
                cmdlineparamters = cmdlineparamters + " +DisableHardwareCursor 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableHardwareCursor 0";

            cmdlineparamters = cmdlineparamters + " " + originalParams + " " + _GraphicsSettings.T_CommandLine.Text;

            LogHandler.WriteLine("Launch parameters are: " + cmdlineparamters);

            if(!tbbcbaseCompatibility)
            {
                Thread GameHackThread = new Thread(_gamehack.DoWork);
                if(_GraphicsSettings.aspectratiohack)
                {
                    _gamehack.SendValues(_GraphicsSettings.fov, _GraphicsSettings.ResolutionX, _GraphicsSettings.ResolutionY);
                    GameHackThread.Start();
                }
            }
            else
                LogHandler.WriteLine("Widescreen hack was not started due to TBBC AVP2 Multiplayer being installed.");


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
                    uint num;
                    if (uint.TryParse(words[i + 1], out num))
                    {
                        words[i + 1] = _GraphicsSettings.ResolutionX.ToString();
                        i++;
                    }
                }
                else if (words[i].ToLower() == "++gamescreenheight" || words[i].ToLower() == "++screenheight")
                {
                    uint num;
                    if (uint.TryParse(words[i + 1], out num))
                    {
                        words[i + 1] = _GraphicsSettings.ResolutionY.ToString();
                        i++;
                    }
                }
                else if (words[i].ToLower() == "++gamebitdepth" || words[i].ToLower() == "++bitdepth")
                {
                    uint num;
                    if (uint.TryParse(words[i + 1], out num))
                    {
                        if (_GraphicsSettings.GameBitDepth)
                            words[i + 1] = "32";
                        else
                            words[i + 1] = "16";
                        i++;
                    }
                }
            }
            return string.Join(" ", words);
        }

        private void B_DisplaySettings_Click(object sender, EventArgs e)
        {
            _GraphicsSettings.StartPosition = FormStartPosition.Manual;
            _GraphicsSettings.SetDesktopLocation(this.DesktopLocation.X + 20, this.DesktopLocation.Y + 20);
            _GraphicsSettings.ShowDialog();
        }

        private void B_Exit_Click(object sender, EventArgs e)
        {
            _gamehack.RequestStop();
            this.Close();
        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("autoexecextended.cfg")) //well should have thought about this earlier... whatever
            {
                bool flagX = false;
                bool flagY = false;
                string[] settings = File.ReadAllLines("autoexecextended.cfg");
                for (int i = 0; i < settings.Length; i++)
                {
                    if (settings[i].StartsWith("PositionX:"))
                    {
                        settings[i] = "PositionX:" + _posX.ToString();
                        flagX = true;
                    }
                    else if (settings[i].StartsWith("PositionY:"))
                    {
                        settings[i] = "PositionY:" + _posY.ToString();
                        flagY = true;
                    }
                }

                string output = string.Join("\n", settings);

                if (!flagX)
                    output += "\nPositionX:" + this._posX.ToString();
                if (!flagY)
                    output += "\nPositionY:" + this._posY.ToString();

                File.WriteAllText("autoexecextended.cfg", output);
            }
            LogHandler.Close();
        }
        #endregion

        #region ParseFunctions
        private uint parsePosition(string line)
        {
            uint outVal = 0;
            string valText = line.Split(':')[1];
            if (valText != String.Empty)
            {
                if (uint.TryParse(valText, out outVal))
                {
                    return outVal;
                }
                else
                    return 0;
            }
            else
                return 0;
        }

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
        #endregion



        private void mainform_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && this.DesktopLocation.X > 0 && this.DesktopLocation.Y>0 && this.DesktopLocation.X < 14000)
            {
                _posX = this.DesktopLocation.X;
                _posY = this.DesktopLocation.Y;
            }
        }

        private void projectPageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/SuiMachine/AVP2-Custom-Launcher");
        }

        private void pcgwLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://pcgamingwiki.com/wiki/Aliens_versus_Predator_2");
        }

        private void donatePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.gamingforgood.net/s/suicidemachine/widget");
        }

        private void WSGFLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.wsgf.org/dr/aliens-versus-predator-2-gold-edition");
        }

        private void tbbcLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://tbbcbase.net");
        }
    }
}

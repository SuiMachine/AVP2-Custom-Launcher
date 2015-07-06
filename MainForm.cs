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
                _ConfigChoice = new ConfigChoice();
                _ConfigChoice.ShowDialog();
            }

            if (!File.Exists(@"avp2cmds.txt"))
            {
                MessageBox.Show("No avp2cmds.txt found. The launcher will try to create it based on files in your current directory.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CreateGenericAVP2Cmds();
            }

            _GraphicsSettings = new GameSettings(this);
        }

        private void B_StartGame_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader(@"avp2cmds.txt");
            string cmdlineparamters = "";
            cmdlineparamters = SR.ReadToEnd();

            if (_GraphicsSettings.windowed)
                cmdlineparamters = cmdlineparamters + " +windowed 1";
            else
                cmdlineparamters = cmdlineparamters + " +windowed 1";  

            if (_GraphicsSettings.disablesound)
                cmdlineparamters = cmdlineparamters + " +DisableSound 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableSound 0";

            if (_GraphicsSettings.disablemusic)
                cmdlineparamters = cmdlineparamters + " +DisableMusic 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableMusic 0";

            if (_GraphicsSettings.disablelogos)
                cmdlineparamters = cmdlineparamters + " +DisableMovies 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableMovies 0";

            if (_GraphicsSettings.disablejoystick)
                cmdlineparamters = cmdlineparamters + " +DisableJoystick 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableJoystick 0";

            if (_GraphicsSettings.disabletripplebuffering)
                cmdlineparamters = cmdlineparamters + " +EnableTripBuf 0";
            else
                cmdlineparamters = cmdlineparamters + " +EnableTripBuf 1";

            if (_GraphicsSettings.disablehardwarecursor)
                cmdlineparamters = cmdlineparamters + " +DisableHardwareCursor 1";
            else
                cmdlineparamters = cmdlineparamters + " +DisableHardwareCursor 0";
                



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

        private void B_Exit_Click(object sender, EventArgs e)
        {
            _gamehack.RequestStop();
            this.Close();
        }

        private void CreateGenericAVP2Cmds()
        {
            string output = "-windowtitle \"Aliens vs. Predator 2\" -rez AVP2.rez -rez sounds.rez -rez Alien.rez -rez Marine.rez -rez Predator.rez -rez Multi.rez -rez AVP2dll.rez -rez AVP2l.rez -rez custom -rez AVP2p.rez -rez AVP2p2.rez -rez AVP2P1.REZ";
            StreamWriter SW = new StreamWriter(@"avp2cmds.txt");
            SW.WriteLine(output);
            SW.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace AVP_CustomLauncher
{
    struct autoexestruct
    {
        float FarZ;
        int LMFullBright;
        int MouseInvertYAxis;
        int LowViolence;

        string CARDDESC;
        string Renderer;
    }


    public partial class GameSettings : Form
    {
        public GameSettings(mainform parent)
        {
            InitializeComponent();
        }
        private void GameSettings_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("autoexec.cfg");
            string line = "";
            string text = "";
            autoexestruct autoexec;

            while ((line = SR.ReadLine())!=null)
            {
                if (line.StartsWith("\"FixTJunc\""))
                {
                    if (line.EndsWith("\"1\""))
                        MessageBox.Show("True");
                    else
                        MessageBox.Show("False");
                }
                text = text + line + "\n";
            }
            richTextBox1.Text = text;
        }
    }
}

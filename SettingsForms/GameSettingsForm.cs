using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AVP_CustomLauncher
{
	public partial class GameSettings : Form
	{
		public Config.CustomConfig customConfig;
		public Config.LithTechConfig lithTechConfig;

		public bool notificationWindowed = true;
		public bool notificationToBig = true;


		public GameSettings(Config.CustomConfig customConfig, Config.LithTechConfig lithTechConfig)
		{
			InitializeComponent();

			this.customConfig = customConfig;
			this.lithTechConfig = lithTechConfig;
		}

		private void GameSettings_Load(object sender, EventArgs e)
		{
			//Setup bindings - screw events!
			this.TB_FOV.DataBindings.Add("Text", customConfig, "FOV", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_EnableAspectRatioMemoryWrite.DataBindings.Add("Checked", customConfig, "AspectRatioFix", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_Windowed.DataBindings.Add("Checked", customConfig, "Windowed", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableSound.DataBindings.Add("Checked", customConfig, "DisableSound", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableMusic.DataBindings.Add("Checked", customConfig, "DisableMusic", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableLogos.DataBindings.Add("Checked", customConfig, "DisableLogos", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableTripleBuffering.DataBindings.Add("Checked", customConfig, "DisableTrippleBuffering", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableJoystick.DataBindings.Add("Checked", customConfig, "DisableJoystick", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_DisableHardwareCursor.DataBindings.Add("Checked", customConfig, "DisableHardwareCursor", false, DataSourceUpdateMode.OnPropertyChanged);
			this.C_LithFix_ENABLED.DataBindings.Add("Checked", customConfig, "LithFixEnabled", false, DataSourceUpdateMode.OnPropertyChanged);

			//LithTech stuff
			this.T_ResolutionX.DataBindings.Add("Text", lithTechConfig, "GameScreenWidth", false, DataSourceUpdateMode.OnPropertyChanged);
			this.T_ResolutionY.DataBindings.Add("Text", lithTechConfig, "GameScreenHeight", false, DataSourceUpdateMode.OnPropertyChanged);
			this.num_LithFix_FPSCAP.DataBindings.Add("Value", lithTechConfig, "lf_max_fps", false, DataSourceUpdateMode.OnPropertyChanged);

			//Other stuff that has to be done manually unless there is some magical way to bind those
			this.RB_ManualEdit.Lines = lithTechConfig.OtherLines.ToArray();
			this.C_32color.Checked = lithTechConfig.GameBitDepth > 16;
			this.C_LithFix_Borderless.Checked = lithTechConfig.lf_borderless_window > 0;


			notificationToBig = false;
			notificationWindowed = false;

			ToggleHackSpecificEnable();
			ToggleLithFixSpecificEnable();
		}


		private void ToggleHackSpecificEnable()
		{
			TB_FOV.Enabled = C_EnableAspectRatioMemoryWrite.Checked;
		}

		private void ToggleLithFixSpecificEnable()
		{
			C_LithFix_Borderless.Enabled = C_LithFix_ENABLED.Checked;
			num_LithFix_FPSCAP.Enabled = C_LithFix_ENABLED.Checked;
		}

		#region EventHandlers
		private void T_ResolutionX_TextChanged(object sender, EventArgs e)
		{
			if (uint.TryParse(T_ResolutionX.Text, out uint res))
			{
				lithTechConfig.GameScreenWidth = res;
				lithTechConfig.SCREENWIDTH = res;


				if (lithTechConfig.GameScreenWidth > 2048 && notificationToBig == false)
				{
					notificationToBig = true;
					if (!File.Exists("D3DIM700.DLL"))
					{
						DialogResult result = MessageBox.Show("For resolutions wider than 2048 you'll need jackfuste's D3DIM700.dll wrapper. Running the game without it, will either crash the game or cause it to start in 640x480. Do you wish to download it?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							System.Diagnostics.Process.Start("http://www.wsgf.org/forums/viewtopic.php?p=155982#p155982");
						}
					}
				}
			}
		}

		private void T_ResolutionY_TextChanged(object sender, EventArgs e)
		{
			if (uint.TryParse(T_ResolutionY.Text, out uint res))
			{
				lithTechConfig.GameScreenHeight = res;
				lithTechConfig.SCREENHEIGHT = res;

				if (lithTechConfig.GameScreenHeight > 2048 && notificationToBig == false)
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
				if (!notificationWindowed)
				{
					notificationWindowed = true;
					MessageBox.Show("Warning: The game uses V-sync to limit its framerate and has some unintended behaviours when the framerate is uncapped.\n\nSince V-sync doesn't work in windowed mode, make sure to use either GPU control panel setting or external application (like Dxtory) to limit your framerate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void C_EnableAspectRatioMemoryWrite_CheckedChanged(object sender, EventArgs e)
		{
			ToggleHackSpecificEnable();
		}

		private void C_32color_CheckedChanged(object sender, EventArgs e)
		{
			lithTechConfig.GameBitDepth = C_32color.Checked ? 32u : 16u;
		}

		private void B_SaveAndClose_Click(object sender, EventArgs e)
		{
			customConfig.CVARS = T_CommandLine.Text;
			customConfig.Save();
			lithTechConfig.SCREENWIDTH = lithTechConfig.GameScreenWidth;
			lithTechConfig.SCREENHEIGHT = lithTechConfig.GameScreenHeight;
			lithTechConfig.OtherLines = RB_ManualEdit.Lines.ToList();
			lithTechConfig.Save();
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void CB_LithFix_ENABLED_CheckedChanged(object sender, EventArgs e)
		{
			ToggleLithFixSpecificEnable();
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void CB_LithFix_Borderless_CheckedChanged(object sender, EventArgs e)
		{
			lithTechConfig.lf_borderless_window = C_LithFix_Borderless.Checked ? 1u : 0u;
		}
		#endregion
	}
}

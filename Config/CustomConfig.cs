using System;
using System.IO;
using System.Reflection;

namespace AVP_CustomLauncher.Config
{
	[Serializable]
	public class CustomConfig
	{
		static readonly string FILEPATH = "autoexecextended.cfg";

		[CustomFormatElement] public bool Windowed { get; set; }
		[CustomFormatElement] public bool DisableSound { get; set; }
		[CustomFormatElement] public bool DisableMusic { get; set; }
		[CustomFormatElement] public bool DisableLogos { get; set; }
		[CustomFormatElement] public bool DisableTrippleBuffering { get; set; }
		[CustomFormatElement] public bool DisableJoystick { get; set; }
		[CustomFormatElement] public bool DisableHardwareCursor { get; set; }
		[CustomFormatElement] public bool AspectRatioFix { get; set; }
		[CustomFormatElement] public float FOV { get; set; }
		[CustomFormatElement] public bool LithFixEnabled { get; set; }

		[CustomFormatElement] public uint PositionX { get; set; }
		[CustomFormatElement] public uint PositionY { get; set; }
		[CustomFormatElement] public string CVARS { get; set; }


		public CustomConfig()
		{
			Windowed = false;
			DisableSound = false;
			DisableMusic = false;
			DisableLogos = false;
			DisableTrippleBuffering = false;
			DisableJoystick = false;
			DisableHardwareCursor = false;
			AspectRatioFix = false;
			FOV = 90;
			PositionX = 0;
			PositionY = 0;
			LithFixEnabled = false;
			CVARS = "";
		}

		public CustomConfig(CustomConfig customConfigToCopy)
		{
			foreach (var property in customConfigToCopy.GetType().GetProperties())
			{
				var value = property.GetValue(customConfigToCopy);
				this.GetType().GetProperty(property.Name).SetValue(this, value);
			}
		}

		public static CustomConfig Load()
		{
			CustomConfig obj;
			if (File.Exists(FILEPATH))
			{
				obj = new CustomConfig();
				StreamReader streamReader = new StreamReader(FILEPATH);

				while (!streamReader.EndOfStream)
				{

					var line = streamReader.ReadLine();
					if (line.Contains(":"))
					{
						var split = line.Split(new char[] { ':' }, 2);
						var key = split[0];
						var value = split[1];

						var propInfo = obj.GetType().GetProperty(key);
						if (propInfo != null )
						{
							if(propInfo.PropertyType == typeof(uint))
								propInfo.SetValue(obj, uint.Parse(value));
							else if (propInfo.PropertyType == typeof(float))
								propInfo.SetValue(obj, float.Parse(value));
							else if (propInfo.PropertyType == typeof(bool))
								propInfo.SetValue(obj, bool.Parse(value));
							else if (propInfo.PropertyType == typeof(string))
								propInfo.SetValue(obj, value);
						}
					}
				}
				streamReader.Close();
				return obj;
			}
			else
				return new CustomConfig();
		}

		public void Save()
		{
			if (!Directory.Exists(Directory.GetDirectoryRoot(FILEPATH)))
				Directory.CreateDirectory(FILEPATH);
			StreamWriter fw = new StreamWriter(FILEPATH);
			foreach (var prop in this.GetType().GetProperties())
			{
				if(prop.GetCustomAttribute<CustomFormatElement>() != null)
				{
					fw.WriteLine(string.Format("{0}:{1}", prop.Name, prop.GetValue(this)));
				}
			}
			fw.Close();
		}

		internal class CustomFormatElement : Attribute
		{
		}
	}
}

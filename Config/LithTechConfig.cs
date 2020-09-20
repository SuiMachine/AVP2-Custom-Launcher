using System;
using System.Collections.Generic;
using System.IO;

namespace AVP_CustomLauncher.Config
{
	public class LithTechConfig
	{
		static readonly string FILEPATH = "autoexec.cfg";

		[LithTechConfigValue] public uint SCREENWIDTH { get; set; }
		[LithTechConfigValue] public uint GameScreenWidth { get; set; }
		[LithTechConfigValue] public uint SCREENHEIGHT { get; set; }
		[LithTechConfigValue] public uint GameScreenHeight { get; set; }
		[LithTechConfigValue] public uint GameBitDepth { get; set; }
		[LithTechConfigValue] public uint FixTJunc { get; set; }
		[LithTechConfigValue] public uint lf_borderless_window { get; set; }
		[LithTechConfigValue] public uint lf_max_fps { get; set; }

		public List<string> OtherLines;

		public LithTechConfig()
		{
			SCREENWIDTH = 800;
			GameScreenWidth = 800;
			SCREENHEIGHT = 600;
			GameScreenHeight = 600;
			GameBitDepth = 32;
			FixTJunc = 0;
			lf_borderless_window = 0;
			lf_max_fps = 60;
			OtherLines = new List<string>();
		}

		public LithTechConfig(LithTechConfig originalToCopy)
		{
			foreach (var property in originalToCopy.GetType().GetProperties())
			{
				var value = property.GetValue(originalToCopy);
				this.GetType().GetProperty(property.Name).SetValue(this, value);
			}

			OtherLines = new List<string>();
			foreach (var line in originalToCopy.OtherLines)
			{
				OtherLines.Add(line);
			}
		}

		public static LithTechConfig Load()
		{
			LithTechConfig obj;
			if (File.Exists(FILEPATH))
			{
				obj = new LithTechConfig();
				StreamReader streamReader = new StreamReader(FILEPATH);

				while (!streamReader.EndOfStream)
				{
					var line = streamReader.ReadLine();
					if (line.Contains(" "))
					{
						var split = line.Split(new char[] { ' ' }, 2);
						var key = split[0].Trim(new char[] { '\"' });
						var value = split[1].Trim(new char[] { '\"' });

						var propInfo = obj.GetType().GetProperty(key);
						if (propInfo != null && propInfo.PropertyType == typeof(uint))
						{
							propInfo.SetValue(obj, uint.Parse(value));
						}
						else
							obj.OtherLines.Add(line);
					}
					else
					{
						obj.OtherLines.Add(line);
					}
				}
				streamReader.Close();
				return obj;
			}
			else
				return new LithTechConfig();
		}

		public void Save()
		{

			if (!Directory.Exists(Directory.GetDirectoryRoot(FILEPATH)))
				Directory.CreateDirectory(FILEPATH);
			StreamWriter fw = new StreamWriter(FILEPATH);
			foreach (var prop in this.GetType().GetProperties())
			{
				fw.WriteLine(string.Format("\"{0}\" \"{1}\"", prop.Name, prop.GetValue(this)));
			}
			foreach (var otherline in OtherLines)
			{
				fw.WriteLine(otherline);
			}

			fw.Close();
		}

		internal class LithTechConfigValue : Attribute
		{
		}
	}
}

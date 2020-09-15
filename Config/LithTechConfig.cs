using AVP_CustomLauncher.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVP_CustomLauncher.Config
{
	public class LithTechConfig
	{
		static string FILEPATH = "autoexec.cfg";

		[LithTechConfigValue] uint SCREENWIDTH { get; set; }
		[LithTechConfigValue] uint GameScreenWidth { get; set; }
		[LithTechConfigValue] uint SCREENHEIGHT { get; set; }
		[LithTechConfigValue] uint GameScreenHeight { get; set; }
		[LithTechConfigValue] uint GameBitDepth { get; set; }

		[LithTechConfigOther] public List<string> OtherLines  { get; set; }


		public LithTechConfig()
		{
			SCREENWIDTH = 800;
			GameScreenWidth = 800;
			SCREENHEIGHT = 600;
			GameScreenHeight = 600;
			GameBitDepth = 32;
			OtherLines = new List<string>();
		}

		public static LithTechConfig Load()
		{

			LithTechConfig obj;
			if (File.Exists(FILEPATH))
			{
				LithTechFormatSerializer serializer = new LithTechFormatSerializer(typeof(LithTechConfig));
				FileStream fs = new FileStream(FILEPATH, FileMode.Open);

				obj = serializer.Deserialize<LithTechConfig>(fs);
				fs.Close();
				return obj;
			}
			else
				return new LithTechConfig();
		}

		public void Save()
		{
			LithTechFormatSerializer serializer = new LithTechFormatSerializer(typeof(LithTechConfig));
			if (!Directory.Exists(Directory.GetDirectoryRoot(FILEPATH)))
				Directory.CreateDirectory(FILEPATH);
			StreamWriter fw = new StreamWriter(FILEPATH);
			serializer.Serialize(fw, this);
			fw.Close();
		}
	}
}

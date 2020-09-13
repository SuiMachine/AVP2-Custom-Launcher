using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AVP_CustomLauncher.Serializers;

namespace AVP_CustomLauncher.Config
{
    [Serializable]
    public class CustomConfig
    {
        static string FILEPATH = "autoexecextended.cfg";

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

        [CustomFormatElement] public int PositionX { get; set; }
        [CustomFormatElement] public int PositionY { get; set; }
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

        public static CustomConfig Load()
        {
            
            CustomConfig obj;
            if (File.Exists(FILEPATH))
            {
                CustomFormatSerializer serializer = new CustomFormatSerializer(typeof(CustomConfig));
                FileStream fs = new FileStream(FILEPATH, FileMode.Open);

                obj = serializer.Deserialize<CustomConfig>(fs);
                fs.Close();
                return obj;
            }
            else
                return new CustomConfig();
        }

        public void Save()
        {
            CustomFormatSerializer serializer = new CustomFormatSerializer(typeof(CustomFormatElement));
            if (!Directory.Exists(Directory.GetDirectoryRoot(FILEPATH)))
                Directory.CreateDirectory(FILEPATH);
            StreamWriter fw = new StreamWriter(FILEPATH);
            serializer.Serialize(fw, this);
            fw.Close();
        }
    }
}

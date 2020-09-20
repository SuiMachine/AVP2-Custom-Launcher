using System;
using System.Diagnostics;
using System.IO;

namespace AVP_CustomLauncher
{
	static class LogHandler
	{
		static StreamWriter SR = new StreamWriter("avp2_customlauncher.log");
		static DateTime time = DateTime.Now;


		public static void Open()
		{
			SR.Flush();
			SR.WriteLine("This log is created each time, you start a launcher and writes down exceptions, errors etc.");
		}

		public static void WriteLine(string text)
		{
#if DEBUG
			Debug.WriteLine(text);
#endif

			string tString = (DateTime.Now - time).ToString();
			SR.WriteLine(tString + ": " + text);
		}

		public static void Close()
		{
			string tString = (DateTime.Now - time).ToString();
			SR.WriteLine(tString + ": Closing");
			SR.Close();
		}
	}
}

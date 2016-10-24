using System;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVP_CustomLauncher
{
    class GameHack
    {
        int LithTechBaseAdress = 0x00400000;
        int cshellBaseAdress = 0x0000000;           //Is changed later, when the app starts running.
        int d3dren = 0x0000000;           //Is changed later, when the app starts running.
        int hookedDllAddress = 0x0;
        Process[] myProcess;

        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        static int threadDelay = 500;
        private volatile bool _shouldStop = false;
        string processName = "lithtech";
        int ResolutionX = 1280;
        int ResolutionY = 720;
        float desiredfov = 90.0f;
        float readBgValue = 0;
        float bgCorrectedValue = 1.308997035f;
        float ReadFovX = 0;
        float ReadFovY = 0;
        float fovX = 2;
        float fovY = 1;
        bool foundProcess = false;
        bool dllInjected = false;

        int fovAddress = 0x01DDFEC;
        int[] offsetFovX = new int[] { 0x4, 0xC4 };
        int[] offsetFovY = new int[] { 0x4, 0xC8 };

        int bgScalingAddress = 0x001E03A4;
        int[] bgScalingOffsets = new int[] { 0x2BC, 0x1c4 };

        #region MainThread
        public void DoWork()
        {
            fovY = HorizontalFOVToVerticalRadians(desiredfov);
            fovX = VerticalRadiansToHorizontalFor4By3Monitor(fovY);
            bgCorrectedValue = correntMenuBGWithAspect(1.308997035f);

            LogHandler.WriteLine("Launcher directory is: " + path);
            LogHandler.WriteLine("Display FOV calculated to: " + fovX + " horizontal, " + fovY + " vertical");
            System.Threading.Thread.Sleep(5000);

            while (!_shouldStop)
            {
                try
                {
                    myProcess = Process.GetProcessesByName(processName);

                    if (myProcess.Length > 0)
                    {
                        if (foundProcess == false)
                            System.Threading.Thread.Sleep(2000);
                        if (cshellBaseAdress == 0x0 || LithTechBaseAdress == 0x0 || d3dren == 0x0)
                        {
                            String appToHookTo = processName;
                            Process[] foundProcesses = Process.GetProcessesByName(appToHookTo);
                            ProcessModuleCollection modules = foundProcesses[0].Modules;
                            foreach (ProcessModule i in modules)
                            {
                                if (i.ModuleName == "cshell.dll")
                                {
                                    cshellBaseAdress = i.BaseAddress.ToInt32();
                                }
                                else if (i.ModuleName == "d3d.ren")
                                {
                                    d3dren = i.BaseAddress.ToInt32();
                                }

                            }
                        }

                        foundProcess = true;
                    }

                    if (foundProcess)
                    {
                        ReadFovX = Trainer.ReadPointerFloat(myProcess, cshellBaseAdress + fovAddress, offsetFovX);
                        ReadFovY = Trainer.ReadPointerFloat(myProcess, cshellBaseAdress + fovAddress, offsetFovY);
                        readBgValue = Trainer.ReadPointerFloat(myProcess, cshellBaseAdress + bgScalingAddress, bgScalingOffsets);



                        if (ReadFovX != fovX && ReadFovX != 0x0000000)
                            Trainer.WritePointerFloat(myProcess, cshellBaseAdress + fovAddress, offsetFovX, fovX);
                        if (ReadFovY != fovY && ReadFovY != 0x0000000)
                            Trainer.WritePointerFloat(myProcess, cshellBaseAdress + fovAddress, offsetFovY, fovY);
                        if (readBgValue != bgCorrectedValue && readBgValue != 0x0000000)
                            Trainer.WritePointerFloat(myProcess, cshellBaseAdress + bgScalingAddress, bgScalingOffsets, bgCorrectedValue);

                        if (!dllInjected && LithTechBaseAdress != 0x0 && cshellBaseAdress != 0x0 && d3dren != 0x0)
                        {
                            #region LogAssemblyBytes
                            {
                                string strByte = "";
                                for (int i = 0; i < 5; i++)
                                {
                                    strByte += (Trainer.ReadByte(myProcess, cshellBaseAdress + 0xEF79 + i)).ToString("X2");
                                }

                                LogHandler.WriteLine("Bytes at injection point cshellBaseAdress + 0xEF79 (resolution hack):" + strByte);
                            }

                            {
                                string strByte = "";
                                for (int i = 0; i < 6; i++)
                                {
                                    strByte += (Trainer.ReadByte(myProcess, LithTechBaseAdress + 0xC370 + i)).ToString("X2");
                                }

                                LogHandler.WriteLine("Bytes at injection point LithTechBaseAdress + 0xC370 (fov hack):" + strByte);
                            }

                            {
                                string strByte = "";
                                for (int i = 0; i < 9; i++)
                                {
                                    strByte += (Trainer.ReadByte(myProcess, d3dren + 0x107F2 + i)).ToString("X2");
                                }

                                LogHandler.WriteLine("Bytes at injection point d3dren + 0x107F2 (viewmodel hack):" + strByte);
                            }
                            #endregion

                            DllInjectionResult result = DllInjector.GetInstance.Inject(myProcess, Path.Combine(path, "widescreenfix.dll"));
                            LogHandler.WriteLine("DLL Injection: " + result);
                            if(result == DllInjectionResult.Success)
                            {
                                dllInjected = true;
                            }
                            else
                            {
                                LogHandler.WriteLine("Error when injecting DLL: " + result.ToString());
                                MessageBox.Show("Error when injecting DLL: " + result.ToString());
                            }


                            System.Threading.Thread.Sleep(500);

                            ProcessModuleCollection modules = myProcess[0].Modules;
                            ProcessModule dllBaseAdressIWant = null;
                            foreach (ProcessModule i in modules)
                            {
                                if (i.ModuleName == "widescreenfix.dll")
                                {
                                    dllBaseAdressIWant = i;
                                }
                            }
                            hookedDllAddress = dllBaseAdressIWant.BaseAddress.ToInt32();
                            
                            #if DEBUG
                            {
                                LogHandler.WriteLine("DLL Injected at: 0x" + hookedDllAddress.ToString("X4"));
                                Trainer.WriteInteger(myProcess, hookedDllAddress + 0x19008, ResolutionX);
                                Trainer.WriteInteger(myProcess, hookedDllAddress + 0x1900C, ResolutionY);
                                LogHandler.WriteLine("Written to dllHook: " + ResolutionX + "x" + ResolutionY + " at address " + (hookedDllAddress + 0x19008).ToString("X4"));
                            }
                            #else
                            {
                                //And HOPE NOTHING MOVED
                                LogHandler.WriteLine("DLL Injected at: 0x" + hookedDllAddress.ToString("X4"));
                                Trainer.WriteInteger(myProcess, hookedDllAddress + 0x4008, ResolutionX);
                                Trainer.WriteInteger(myProcess, hookedDllAddress + 0x400C, ResolutionY);
                                LogHandler.WriteLine("Written to dllHook: " + ResolutionX + "x" + ResolutionY + " at address " + (hookedDllAddress + 0x4008).ToString("X4"));
                            }
                            #endif
                        }
                    }
                    System.Threading.Thread.Sleep(threadDelay);
                }
                catch(Exception ex)
                {
                    LogHandler.WriteLine("Exception in GameHack.cs" + ex.ToString());
                }

            }
        }

        public void SendValues(float value, int ResX, int ResY)
        {
            desiredfov = value;
            ResolutionX = ResX;
            ResolutionY = ResY;
            LogHandler.WriteLine("Thread received values: " + ResolutionX + "x" + ResolutionY + " @ " + desiredfov);
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
        #endregion

        #region FOVCalculation
        private float correntMenuBGWithAspect(float bgVal)
        {
            double verticalVal = 2 * Math.Atan(Math.Tan(bgVal / 2) * (ResolutionY * 1.0 / ResolutionX * 1.0));
            double dHorizontalRadians = 2 * Math.Atan(Math.Tan(verticalVal / 2) * (1024 * 1.0 / 768 * 1.0));
            return Convert.ToSingle(dHorizontalRadians);
        }

        public double ConvertToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public float VerticalRadiansToHorizontalFor4By3Monitor(float angle)
        {
            double dVerticalRadians = Convert.ToDouble(angle);
            double dHorizontalRadians;

            dHorizontalRadians = 2 * Math.Atan(Math.Tan(dVerticalRadians / 2) * (1024 * 1.0 / 768 * 1.0));

            return Convert.ToSingle(Math.Round(dHorizontalRadians, 3));
        }

        /*
        This part is no longer used, as the calculation is done using injected DLL
        public float VerticalRadiansToHorizontalRadiansWithResolution(float angle)
        {
            double dVerticalRadians = Convert.ToDouble(angle);
            double dHorizontalRadians;

            dHorizontalRadians = 2 * Math.Atan(Math.Tan(dVerticalRadians / 2) * (ResolutionX * 1.0 / ResolutionY * 1.0));

            return Convert.ToSingle(Math.Round(dHorizontalRadians, 3));
        }*/

        public float HorizontalFOVToVerticalRadians(float angle)
        {
            double dHorizontalRadians, dVertialRadians;

            dHorizontalRadians = ConvertToRadians(Convert.ToDouble(angle));
            dVertialRadians = 2 * Math.Atan(Math.Tan(dHorizontalRadians / 2) * (768 * 1.0 / 1024 * 1.0));
            return Convert.ToSingle(Math.Round(dVertialRadians, 3));
        }
        #endregion
    }
}

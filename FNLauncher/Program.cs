using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FNLauncher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Ac_bypass = "link to ac";
            string Dll_link = "link to dll";
            Console.Title = ("Loading FNLauncher");
            string TempPath = Path.GetTempPath();
            string Path1 = "";
            var version = "1";

            

            var path1 = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat"));
            dynamic Json = JsonConvert.DeserializeObject(path1);

            //credits to ender for path finder
            foreach (var installion in Json.InstallationList)
            {
                if (installion.AppName == "Fortnite")
                {
                    Path1 = installion.InstallLocation.ToString() + "";
                    version = installion.AppVersion.ToString().Split('-')[1];
                    Console.WriteLine("Path found!: " + Path1);
                }
            }

            new WebClient().DownloadFile(Ac_bypass, Path1 + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_EAC.exe");
            new WebClient().DownloadFile(Ac_bypass, Path1 + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_BE.exe");
            new WebClient().DownloadFile(Dll_link, Path1 + "/FortniteGame/Binaries/Win64/Dll.dll");
            Process.Start("cmd", "/C start com.epicgames.launcher://apps/Fortnite?action=launch");
        }
    }
}

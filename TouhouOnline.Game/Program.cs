using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Desktop;
using osu.Framework.Desktop.Platform;

namespace TouhouOnline.Game
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var cwd = Environment.CurrentDirectory;
            using (DesktopGameHost host = Host.GetSuitableHost("Touhou Online"))
            {
                if(host.IsPrimaryInstance)
                {
                    host.Run(new TouhouOnlineGame(args));
                    //test branch2
                }
            }
        }
    }
}

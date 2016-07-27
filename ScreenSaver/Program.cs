using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // > 0 means we have some args
            if(args.Length > 0)
            {
                string firstArg = args[0].ToLower().Trim();
                string secondArg = null;

                if(firstArg.Length > 2)
                {
                    secondArg = firstArg.Substring(3).Trim();
                    firstArg = firstArg.Substring(0, 2);
                }
                else if(args.Length > 1)
                {
                    secondArg = args[1];
                }

                if (firstArg.Equals("/s"))
                {
                    ShowScreenSaver();
                    Application.Run();
                }
            }
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screenSaver = new ScreenSaverForm(screen.Bounds);
                screenSaver.Show();
            }
        }
    }


}

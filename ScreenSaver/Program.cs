using System;
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
                string arg = args[0].ToLower().Trim().Substring(0, 2);

                if(arg.Equals("/s"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ShowScreenSaver();
                    Application.Run();
                }
                else if (arg.Equals("/p"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    ShowScreenSaver();
                    Application.Run(new ScreenSaverForm(new IntPtr(long.Parse(args[1]))));
                }
                else if (arg.Equals("/c"))
                {
                    MessageBox.Show("There are no settings to configure!", "So Much Blank",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ShowScreenSaver();
                Application.Run();
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

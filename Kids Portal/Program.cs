using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kids_Portal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Mutex mutex = null;
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = "KidsPortal";

        private static void SetStartup()
        {
            //Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());
        }

        [STAThread]
        static void Main()
        {
            const string appName = "Kids Portal";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            try
            {
                if (!createdNew)
                {
                    //app is already running! Exiting the application  
                    return;
                }
                SetStartup();
            }catch(Exception e)
            {
                SetNotepadText();   
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
          

            
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        const uint WM_PASTE = 0x302;

        static void SetNotepadText()
        {
            Clipboard.SetText("There is an internal error!\n\nKids Portal\n\n-JAN");
            Process p = Process.Start("notepad.exe");
            p.WaitForInputIdle();
            IntPtr EditHandle = FindWindowEx(p.MainWindowHandle, IntPtr.Zero, "edit", null);
            PostMessage(new HandleRef(p, EditHandle), WM_PASTE, IntPtr.Zero, IntPtr.Zero);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace ServerControl
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            //ShowWindow(GetConsoleWindow(), 0); // Скрыть.
            //ShowWindow(GetConsoleWindow(), 1); // Показать.
            //var icon = new NotifyIcon();
            //icon.Icon = new Icon("icon.ico");
            //icon.Visible = true;

            
            ClassFTP classFTP = new ClassFTP();
            while(true) classFTP.checkStatus();
            Console.WriteLine("Программа заканчивает рботу.");
            Console.ReadKey();
        }
        
    }
}

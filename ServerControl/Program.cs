using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerControl
{
    class Program
    {
        Thread thread = new Thread();
        

        private void checkServerStatus()
        {

        }

        private string getCurrentPathFtp()
        {

        }

        static void Main(string[] args)
        {
            

            if (args.GetLength(0) < 2)
            {
                Console.WriteLine("Не хватае аргументов! ");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("---args----");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            Console.WriteLine(" ");

            if (!File.Exists("currentDirectory.txt"))
            {
                Console.WriteLine("Отсутствует currentDirectory.txt");
                Console.ReadKey();
                return;
            }
            string[] currentDirectory = File.ReadLines("currentDirectory.txt", Encoding.Default).ToArray<string>();
            switch (args[0])
            {
                case "ftp":
                    string ftpPath = currentDirectory[0] + "\\FileZilla Server.exe";
                    if (!File.Exists(ftpPath)){
                        Console.WriteLine(ftpPath + " not found!");
                        Console.ReadKey();
                        return;
                    }
                    Process.Start(ftpPath, args[1]);
                    break;
            }
            Console.WriteLine("Complete...");
            Console.ReadKey();
        }
    }
}

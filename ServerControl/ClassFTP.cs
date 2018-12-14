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
    class ClassFTP
    {
        string fileForPath = "currentDirectory.txt";
        string fileServer = "FileZilla Server.exe";
        string fileConfig = "FileZilla Server.xml";

        public void checkStatus()
        {
            int hash = getHashConfig();
            while (true)
            {
                if (GetPathToConfig() == "")
                {
                    Console.WriteLine("Файл конфигурации отсутствует!");
                    break;
                }

                if (hash != getHashConfig())
                {
                    Process.Start(GetPathToServer(), "/reload-config");
                    hash = getHashConfig();
                    Console.WriteLine("checkStatus: изменение выявлено, перезагружаю конфигурацию сервера");
                    
                }
                else
                {
                    //Console.WriteLine("checkStatus: изменений не выявлено");
                    Console.Write(".");
                }
                Thread.Sleep(5000);
            }
        }

        public async Task checkStatusAsync()
        {
            await Task.Run(() => checkStatus());
        }

        public string getCurrentPathFtp()
        {
            if (!File.Exists(fileForPath))
            {
                Console.WriteLine("Отсутствует " + fileForPath);
                return "";
            }
            string[] currentDirectory = File.ReadAllLines(fileForPath, Encoding.Default);
            if (currentDirectory.GetLength(0) < 1)
            {
                Console.WriteLine("Файл " + fileForPath + " пуст!");
                return "";
            }

            return currentDirectory[0];
        }

        private string GetPathToConfig()
        {
            string pathFile = getCurrentPathFtp() + "\\" + fileConfig;
            
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("Отсутствует " + pathFile);
                return "";
            }
            return pathFile;
        }

        private string GetPathToServer()
        {
            string pathFile = getCurrentPathFtp() + "\\" + fileServer;
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("Отсутствует " + pathFile);
                return "";
            }
            return pathFile;
        }

        public int getHashConfig()
        {
            int resHash = File.ReadAllText(GetPathToConfig()).GetHashCode();
            //Console.WriteLine(GetPathToConfig().ToLower() + " " + File.ReadAllText(GetPathToConfig()));
            return resHash;
        }
    }
}

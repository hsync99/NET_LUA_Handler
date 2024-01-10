using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NET_LUA_Handler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string scriptname = Console.ReadLine();
            string executablePath = Assembly.GetEntryAssembly()?.Location;
            string currentDirectory = Path.GetDirectoryName(executablePath);
            string luaInterpreter = currentDirectory + "\\Lua\\lua53.exe"; 

            string luaScriptPath = currentDirectory + "\\scripts\\" + scriptname + ".lua"; 

          
            Process process = new Process();

          
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = luaInterpreter, 
                Arguments = luaScriptPath, 
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true 
            };

            process.StartInfo = startInfo;


            process.Start();


            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine("Output:");
            Console.WriteLine(output);

            process.WaitForExit();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

           

       
        }
    }
}

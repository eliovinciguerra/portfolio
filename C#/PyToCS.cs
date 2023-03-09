//https://softwareengineering.stackexchange.com/questions/385936/how-can-i-integrate-python-code-with-c-code
//https://learn.microsoft.com/it-it/dotnet/api/system.diagnostics.processstartinfo?view=net-7.0

using System; 
using System.IO; 
using System.Diagnostics; 
using System.Collections.Generic;

namespace ProgettoAPL{
    public class PyProgram{ 
        public string callPy(string programName, string func, Dictionary<string, string> pyParam ) { 
            string python = @"/usr/local/bin/python3";  //https://www.geeksforgeeks.org/c-sharp-verbatim-string-literal/

            // dummy parameters to send Python script 
            int x = 2; 
            int y = 5; 

            ProcessStartInfo processInfo = new ProcessStartInfo(python); 

            // make sure we can read the output from stdout 
            processInfo.UseShellExecute = false; 
            processInfo.RedirectStandardOutput = true; 

            int index = programName.IndexOf(".py");
            if (index != -1)
            {
                programName = programName.Remove(index);
            }

            
            Console.WriteLine(pyParam["email"]);

            //processInfo.Arguments = pyScript + " " + x + " " + y; 
            processInfo.Arguments = "-c 'import "+programName+"; print ("+programName+"."+func+"("+x+","+ y+"))'"; //print fa la stampa a schermo da py, che viene raccolta da C# nella variabile output

            Process process = new Process(); 

            process.StartInfo = processInfo; 

            Console.WriteLine("Avvio lo script Python e passo {0} e {1} come parametri", x,y); 

            process.Start(); 

            string output = process.StandardOutput.ReadToEnd(); 

            /*if you need to read multiple lines, you might use: 
                string output = process.StandardOutput.ReadToEnd() instead of string output = process.StandardOutput.ReadLine(); */           

            process.WaitForExit(); 
            process.Close(); 
            return output;
        } 
    } 
}
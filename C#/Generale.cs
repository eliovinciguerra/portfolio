using System; 
using System.IO;
using System.Collections.Generic;

namespace ProgettoAPL{
    class Generale{
        static void Main(string[] args) { 
            PyProgram py= new PyProgram();
            Dictionary<string, string> pyParam =  new Dictionary<string, string>(){
                                                    {"email", "emailTest"},
                                                    {"password", "pswTest"}
                                                }; 

            var a=py.callPy("sum.py", "sum", pyParam);
            Console.WriteLine(a);
        }
    }
}
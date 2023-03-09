using System.IO;
using System.Text;
using IronPython.Hosting;

namespace ProgettoAPL
{
    public class ToPython
    {
        public dynamic callPy(string programName, string funcName, params string[] pr)
        {
            var script = @"C:\Users\io\Desktop\ProgettoAPL_Roggio_Vinciguerra\ProgettoAPL\Python\" + programName;
            var engine = Python.CreateEngine();
            var source = engine.CreateScriptSourceFromFile(script);
            var eIO = engine.Runtime.IO;
            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);
            var scope = engine.CreateScope();
            source.Execute(scope);
            dynamic testFunction = scope.GetVariable(funcName);
            dynamic result;
            if (pr.Length != 0)
            {
                 result = testFunction(pr);
            }
            else
            {
                result = testFunction();
            }
            
            return result;
        }    
    }
}


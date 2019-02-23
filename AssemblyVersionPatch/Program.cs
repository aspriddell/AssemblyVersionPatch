using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyVersionPatch
{
    class Program
    {
        static List<string> newfile = new List<string>();
        static string file_location;
        static readonly string linetowrite = $"[assembly: AssemblyVersion(\"{DateTime.Now:yyyy.ddMM.HH}\")]";

        static void Main(string[] args)
        {
            try { file_location = args[0]; }
            catch { return; }

            string[] file = File.ReadAllLines(file_location);
            foreach (var line in file)
            {
                if (line.StartsWith("[assembly: AssemblyVersion"))
                    newfile.Add(linetowrite);
                else
                    newfile.Add(line);
            }

            File.WriteAllLines(file_location, newfile.ToArray());
        }
    }
}

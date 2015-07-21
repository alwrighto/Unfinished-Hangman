using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("TextFile1.txt");

            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDFLib;
using VDFLib.Items;

namespace VDFConsoleTests
{
    public class Program
    {
        public string filename;

        static void PrintInfo(string msg)
        {
            Console.WriteLine(msg);
        }

        static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WaitForKeypress()
        {
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintInfo("VDF Console Tests");
            WaitForKeypress();
            PrintError("Error test");
            WaitForKeypress();
        }

    }
}

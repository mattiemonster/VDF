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
        public static string filename;

        /// <summary>
        /// Print a message
        /// </summary>
        /// <param name="msg">Message to print</param>
        static void PrintInfo(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Print a message in red text and beep
        /// </summary>
        /// <param name="msg">Message to print</param>
        static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Print a message in green text
        /// </summary>
        /// <param name="msg">Message to print</param>
        static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Get a line of input from the user
        /// </summary>
        /// <param name="prompt">Text to print before getting the input</param>
        /// <returns>The users input</returns>
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        
        /// <summary>
        /// This method does not exit until the user presses a key
        /// </summary>
        static void WaitForKeypress()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintInfo("VDF Console Tests");
            PrintInfo("Save Test");
            filename = GetInput("Filename: ");
        }

    }
}

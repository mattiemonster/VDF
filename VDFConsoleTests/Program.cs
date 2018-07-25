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
        public static string vdfName;
        public static string stringToWrite;
        public static string catagoryName;
        public static string catagoryString;
        public static int intToWrite;

        public static VDF vdf;
        public static VDF loadedVDF;

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

        //static int GetIntKey(string prompt)
        //{
        //    Console.Write(prompt);
        //}

        static ConsoleKeyInfo GetKey(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadKey();
        }
        
        /// <summary>
        /// This method does not exit until the user presses a key
        /// </summary>
        static void WaitForKeypress()
        {
            Console.ReadKey();
        }

        static void CreateVDF()
        {
            vdf = new VDF(vdfName);
            VDFCatagory catagory = new VDFCatagory(catagoryName);
            catagory.AddItem(new VDFStringItem("Catagory String", catagoryString));
            vdf.AddCatagory(catagory);
            vdf.AddItem(new VDFStringItem("String", stringToWrite));
            vdf.AddItem(new VDFIntItem("Int", intToWrite));
        }

        static void GetIntToSave()
        {
            ConsoleKeyInfo ki = GetKey("Int to save: ");
            if (!Char.IsNumber(ki.KeyChar))
            {
                Console.WriteLine();
                PrintError("Your entry must be a whole number.");
                GetIntToSave();
            } else
            {
                intToWrite = int.Parse(ki.KeyChar.ToString());
                return;
            }
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

            // Get filename
            filename = GetInput("Filename: ");
            PrintSuccess("Set filename to: " + filename);

            // Get vdf name
            vdfName = GetInput("VDF Name: ");
            PrintSuccess("Set VDF name to: " + vdfName);

            // Get string to save
            stringToWrite = GetInput("String to save: ");
            PrintSuccess("Set the string to save to: " + stringToWrite);

            // Get int to save
            GetIntToSave();
            Console.WriteLine();
            PrintSuccess("Set the int to save to: " + intToWrite);

            // Get name of catagory
            catagoryName = GetInput("Name of first catagory: ");
            PrintSuccess("Set the first catagory name to: " + catagoryName);

            // Get string of first catagory
            catagoryString = GetInput("String inside first catagory: ");
            PrintSuccess("Set the string inside of the first catagory to: " + catagoryString);

            CreateVDF();
            vdf.Save(filename + ".vdf");

            WaitForKeypress();
        }

    }
}

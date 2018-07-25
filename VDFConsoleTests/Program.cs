using System;
using VDFLib;
using VDFLib.Items;

namespace VDFConsoleTests
{
    /// <summary>
    /// VDF Console Based Tests
    /// </summary>
    public class Program
    {
        public static string filename;         // Name of VDF file
        public static string vdfName;          // Name of the VDF
        public static string stringToWrite;    // String to write to the root of the VDF
        public static string catagoryName;     // Name of the catagory to add to the VDF
        public static string catagoryString;   // String to write inside of the catagory
        public static int intToWrite;          // Int to write to the root of the VDF

        public static VDF vdf;                 // VDF used by the create test
        public static VDF loadedVDF;           // VDF used by the load test

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

        /// <summary>
        /// Create a VDF based of data gathered
        /// </summary>
        static void CreateVDF()
        {
            vdf = new VDF(vdfName);
            VDFCatagory catagory = new VDFCatagory(catagoryName);
            catagory.AddItem(new VDFStringItem("Catagory String", catagoryString));
            vdf.AddCatagory(catagory);
            vdf.AddItem(new VDFStringItem("String", stringToWrite));
            vdf.AddItem(new VDFIntItem("Int", intToWrite));
        }

        /// <summary>
        /// Get an int and save it to intToWrite
        /// </summary>
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
        
        static void CreateVDFTest()
        {
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

            // Create and save VDF
            CreateVDF();
            vdf.Save(filename + ".vdf");

            PrintSuccess("Saved VDF!");

            return;
        }

        /// <summary>
        /// Test that loads a vdf file and prints information about it
        /// </summary>
        static void LoadVDFTest()
        {
            string fileToLoad = GetInput("VDF file to load (no extension): ");
            loadedVDF = VDFReader.LoadVDF(fileToLoad + ".vdf");

            PrintInfo(loadedVDF.ToString());
        }

        /// <summary>
        /// Get the command from the user
        /// </summary>
        static void GetCMD()
        {
            string cmd = GetInput("> ");
            if (cmd == "create") // Open create test
            {
                CreateVDFTest();
                GetCMD();
            } else if (cmd == "load") // Open load test
            {
                LoadVDFTest();
                GetCMD();
            } else if (cmd == "exit") // Exit program
            {
                return;
            } else // Command not found
            {
                PrintError("Command not found!");
                GetCMD();
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

            PrintInfo("Type 'create' for the creation test, 'load' for the loading test or 'exit' to quit.");
            GetCMD();
        }

    }
}

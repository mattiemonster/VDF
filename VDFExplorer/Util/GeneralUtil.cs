using System;
using System.Windows.Forms;

namespace VDFExplorer.Util
{
    public class GeneralUtil
    {
        public static void NotImplementedError()
        {
            MessageBox.Show("Not Implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.LogError("Not Implemented");
        }

        public static void NotImplementedError(string extendedMessage)
        {
            MessageBox.Show("Not Implemented: " + extendedMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.LogError("Not Implemented: " + extendedMessage);
        }

        public static void Error(string message)
        {
            MessageBox.Show("Error: " + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.LogError(message);
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.LogInfo(message);
        }

        public static bool AskYesNo(string message, string title)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch(result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;
            }
        }
    }
}

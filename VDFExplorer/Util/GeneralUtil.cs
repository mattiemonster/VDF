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
            MessageBox.Show("Erorr: " + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.LogError(message);
        }
    }
}

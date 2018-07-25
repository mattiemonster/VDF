using System;
using System.IO;

namespace VDFExplorer.Util
{
    public class Log
    {
        public static FileStream logStream;
        public static TextWriter tw;

        public static bool closed = false;

        public static void Init()
        {
            logStream = new FileStream(GetLogName(), FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            string logPath = logStream.Name;
            logStream.Close();
            logStream.Dispose();

            tw = File.CreateText(logStream.Name);
        }

        public static string GetLogName()
        {
            return "log_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + 
                DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
        }

        public static string GetDateTimeString()
        {
            return DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + ":" + 
                DateTime.Now.Second;
        }

        public static void LogInfo(string msg)
        {
            if (closed)
                throw new Exception("Tried to log message but the log is closed.");

            tw.WriteLine("[" + GetDateTimeString() + "] INFO: " + msg);
            tw.Flush();
        }

        public static void LogWarn(string msg)
        {
            if (closed)
                throw new Exception("Tried to log message but the log is closed.");

            tw.WriteLine("[" + GetDateTimeString() + "] WARN: " + msg);
            tw.Flush();
        }

        public static void LogError(string msg)
        {
            if (closed)
                throw new Exception("Tried to log message but the log is closed.");

            tw.WriteLine("[" + GetDateTimeString() + "] ERROR: " + msg);
            tw.Flush();
        }

        public static void LogFatal(string msg, bool closeLog)
        {
            if (closed)
                throw new Exception("Tried to log message but the log is closed.");

            tw.WriteLine("[" + GetDateTimeString() + "] FATAL ERROR: " + msg);
            tw.Flush();

            if (closeLog)
                Close();
        }

        public static void Close()
        {
            tw.Close();
            tw.Dispose();

            closed = true;
        }
    }
}

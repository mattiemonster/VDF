using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDFExplorer.Util
{
    [Serializable]
    public class RecentItems
    {
        public List<string> recentItems;
        public static string fileName = "RecentItems.bin";
        public FileStream stream;

        public RecentItems()
        {
            stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        }

        public void Init()
        {
            recentItems = new List<string>();
            fileName = "RecentItems.bin";
        }

        public void Init(string newFileName)
        {
            recentItems = new List<string>();
            fileName = newFileName;
        }

        public void AddItem(string value)
        {
            if (!recentItems.Contains(value))
                recentItems.Insert(0, value);
            else
            {
                int itemIndex = recentItems.IndexOf(value);
                string item = recentItems.ElementAt(itemIndex);
                recentItems.RemoveAt(itemIndex);
                recentItems.Insert(0, value);
            }
        }

        public void RemoveItem(string value)
        {
            recentItems.Remove(value);
        }

        public void RemoveItemAt(int index)
        {
            recentItems.RemoveAt(index);
        }

        public void Save(string fileName)
        {
            stream.SetLength(0);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, recentItems);
            stream.Flush();
        }

        public void Load(string fileName)
        {
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            if (stream.Length == 0)
            {
                Log.LogInfo("Recent items empty");
                return;
            }
            recentItems = (List<string>)formatter.Deserialize(stream);
        }

        public void Save()
        {
            stream.SetLength(0);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, recentItems);
            stream.Flush();
        }

        public void Load()
        {
            // FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            if (stream.Length == 0)
            {
                Log.LogInfo("Recent items empty");
                return;
            }
            recentItems = (List<string>)formatter.Deserialize(stream);
        }

        public void Close()
        {
            stream.Dispose();
            stream.Close();
        }
    }
}

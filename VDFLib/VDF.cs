using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using VDFLib.Items;

namespace VDFLib
{
    [Serializable]
    public class VDF
    {
        public List<VDFCatagory> catagories;
        public List<VDFItem> items;
        public string name;
        public string savePath;

        public VDF(string newName)
        {
            name = newName;
            Init();
        }

        public void SetSavePath(string newPath)
        {
            savePath = newPath;
        }

        public void Init()
        {
            catagories = new List<VDFCatagory>();
            items = new List<VDFItem>();
        }

        public void AddCatagory(VDFCatagory catagory)
        {
            catagories.Add(catagory);
        }

        public void RemoveCatagory(VDFCatagory catagory)
        {
            catagories.Remove(catagory);
        }

        public void RemoveCatagoryAt(int index)
        {
            catagories.RemoveAt(index);
        }

        public void AddItem(VDFItem item)
        {
            items.Add(item);
        }

        public void AddItemToCatagory(VDFCatagory catagory, VDFItem item)
        {
            foreach (VDFCatagory cat in catagories)
            {
                if (cat == catagory)
                {
                    cat.AddItem(item);
                }
            }
        }

        public void SetItemValue(VDFItem item, object value)
        {
            foreach (VDFItem cItem in items)
            {
                if (cItem == item)
                {
                    cItem.value = value;
                }
            }
        }

        public void RemoveCatagory(VDFItem item)
        {
            items.Remove(item);
        }

        public void RemoveItemAt(int index)
        {
            items.RemoveAt(index);
        }

        public void Save(FileStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            savePath = stream.Name;
        }

        public void Save(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
            savePath = path;
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public override string ToString()
        {
            StringWriter sr = new StringWriter();
            sr.WriteLine("VDF Name: " + name);
            foreach (VDFCatagory cat in catagories)
            {
                sr.WriteLine("Catagory (Name: " + cat.name + ")");
                foreach (VDFItem item in cat.items)
                {
                    sr.WriteLine("Item in Catagory " + cat.name);
                    sr.WriteLine("Name: " + item.name);
                    sr.WriteLine("Type: " + item.type);
                    sr.WriteLine("Value: " + item.value);
                }
            }

            sr.WriteLine("Items in root catagory:");

            foreach (VDFItem item in items)
            {
                sr.WriteLine("Name: " + item.name);
                sr.WriteLine("Type: " + item.type);
                sr.WriteLine("Value: " + item.value);
            }

            return sr.ToString();
        }

    }
}

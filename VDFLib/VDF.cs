using System;
using System.Collections.Generic;

using VDFLib.Items;

namespace VDFLib
{
    [Serializable]
    public class VDF
    {
        public List<VDFCatagory> catagories;
        public List<VDFItem> items;
        public string name;

        public VDF(string newName)
        {
            name = newName;
            Init();
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

        public void RemoveCatagory(VDFItem item)
        {
            items.Remove(item);
        }

        public void RemoveItemAt(int index)
        {
            items.RemoveAt(index);
        }

    }
}

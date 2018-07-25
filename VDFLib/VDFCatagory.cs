using System;
using System.Collections.Generic;
using System.Text;

using VDFLib.Items;

namespace VDFLib
{
    [Serializable]
    public class VDFCatagory
    {
        public List<VDFItem> items;
        public string name = "Catagory";

        public VDFCatagory(string newName)
        {
            name = newName;
        }

        public void AddItem(VDFItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(VDFItem item)
        {
            items.Remove(item);
        }

        public void RemoveItemAt(int index)
        {
            items.RemoveAt(index);
        }

    }
}

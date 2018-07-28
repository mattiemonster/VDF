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
        public List<VDFCatagory> catagories;
        public string name = "Catagory";

        public VDFCatagory(string newName)
        {
            name = newName;
            items = new List<VDFItem>();
            catagories = new List<VDFCatagory>();
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

    }
}

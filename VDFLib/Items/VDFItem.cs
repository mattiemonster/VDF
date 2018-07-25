using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFItem
    {
        public string name = "Item";

        public VDFItem(string newName)
        {
            name = newName;
        }
    }
}

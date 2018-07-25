using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFItem
    {
        public string name = "Item";
        public object value;
        public readonly string type;

        public VDFItem(string newName, string type)
        {
            name = newName;
            this.type = type;
        }
    }
}

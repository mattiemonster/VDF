using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    public class VDFStringItem : VDFItem
    {
        public string value = "String";

        public VDFStringItem(string name, string value)
            : base(name)
        {
            this.value = value;
        }

        public void SetValue(string newValue)
        {
            value = newValue;
        }
    }
}

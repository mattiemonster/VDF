using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    public class VDFBoolItem : VDFItem
    {
        public bool value = false;

        public VDFBoolItem(string name, bool value)
            : base(name)
        {
            this.value = value;
        }

        public void SetValue(bool newValue)
        {
            value = newValue;
        }
    }
}

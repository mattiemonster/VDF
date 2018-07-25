using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    public class VDFIntItem : VDFItem
    {
        public int value = 0;

        public VDFIntItem(string name, int value)
            : base(name)
        {
            this.value = value;
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
    }
}

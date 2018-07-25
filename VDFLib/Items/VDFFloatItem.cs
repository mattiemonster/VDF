using System;
using System.Collections.Generic;
using System.Text;

namespace VDFLib.Items
{
    public class VDFFloatItem : VDFItem
    {
        public float value = 0;

        public VDFFloatItem(string name, float value)
            : base(name)
        {
            this.value = value;
        }

        public void SetValue(float newValue)
        {
            value = newValue;
        }
    }
}

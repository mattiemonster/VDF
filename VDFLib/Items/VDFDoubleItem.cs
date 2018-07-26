using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFDoubleItem : VDFItem
    {
        public const string typeString = "double";

        public VDFDoubleItem(string name, double value)
            : base(name, "double")
        {
            this.value = value;
        }

        public void SetValue(double newValue)
        {
            value = newValue;
        }
    }
}

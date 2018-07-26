using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFLongItem : VDFItem
    {
        public const string typeString = "long";

        public VDFLongItem(string name, long value)
            : base(name, "long")
        {
            this.value = value;
        }

        public void SetValue(long newValue)
        {
            value = newValue;
        }
    }
}

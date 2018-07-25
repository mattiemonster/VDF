using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFIntItem : VDFItem
    {
        // public new int value = 0;
        public const string typeString = "int";

        public VDFIntItem(string name, int value)
            : base(name, "int")
        {
            this.value = value;
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
    }
}

using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFStringItem : VDFItem
    {
        // public new string value = "String";
        public const string typeString = "string";

        public VDFStringItem(string name, string value)
            : base(name, "string")
        {
            this.value = value;
        }

        public void SetValue(string newValue)
        {
            value = newValue;
        }
    }
}

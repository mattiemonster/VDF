using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFBoolItem : VDFItem
    {
        // public new bool value = false;
        public const string typeString = "bool";

        public VDFBoolItem(string name, bool value)
            : base(name, "bool")
        {
            this.value = value;
        }

        public void SetValue(bool newValue)
        {
            value = newValue;
        }
    }
}

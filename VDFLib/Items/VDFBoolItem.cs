using System;

namespace VDFLib.Items
{
    [Serializable]
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

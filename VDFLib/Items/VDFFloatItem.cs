using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFFloatItem : VDFItem
    {
        // public new float value = 0.0f;
        public const string typeString = "float";

        public VDFFloatItem(string name, float value)
            : base(name, "float")
        {
            this.value = value;
        }

        public void SetValue(float newValue)
        {
            value = newValue;
        }
    }
}

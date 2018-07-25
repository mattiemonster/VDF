using System;

namespace VDFLib.Items
{
    [Serializable]
    public class VDFFloatItem : VDFItem
    {
        public float value = 0.0f;

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

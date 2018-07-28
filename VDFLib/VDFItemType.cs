using System;

namespace VDFLib
{
    [Serializable]
    public enum VDFItemType
    {
        String = 0,
        Int = 1,
        Float = 2,
        Boolean = 3,
        Double = 4,
        Long = 5
    }

    public class VDFItemTypeUtil
    {
        public static string GetStringFromItemType(VDFItemType type)
        {
            switch (type)
            {
                case VDFItemType.Boolean:
                    return "Boolean";
                case VDFItemType.Double:
                    return "Double";
                case VDFItemType.Float:
                    return "Float";
                case VDFItemType.Int:
                    return "Int";
                case VDFItemType.Long:
                    return "Long";
                case VDFItemType.String:
                    return "String";
                default:
                    return "Unknown";
            }
        }
    }
}

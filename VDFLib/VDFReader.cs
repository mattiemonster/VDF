using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace VDFLib
{
    public class VDFReader
    {
        public static VDF LoadVDF(string path)
        {
            VDF vdf;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            vdf = (VDF)formatter.Deserialize(stream);
            stream.Close();
            return vdf;
        }

        public static VDF LoadVDF(Stream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            return (VDF)formatter.Deserialize(stream);
        }
    }
}

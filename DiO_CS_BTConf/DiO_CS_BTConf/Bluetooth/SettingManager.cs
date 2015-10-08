using System.IO;
using System.Xml.Serialization;

namespace DiO_CS_BTConf.Bluetooth
{
    public class SettingManager
    {

        /// <summary>
        /// Save to XML.
        /// </summary>
        /// <remarks>
        /// @"c:\temp\SerializationOverview.xml"
        /// </remarks>
        /// <param name="commands">Commands</param>
        /// <param name="path">File</param>
        public static void Save(object settings, string path)
        {
            XmlSerializer writer = new XmlSerializer(settings.GetType());
            StreamWriter file = new StreamWriter(path);
            writer.Serialize(file, settings);
            file.Close();
        }

        /// <summary>
        /// Read commands from XML.
        /// </summary>
        /// <remarks>@"c:\temp\SerializationOverview.xml"</remarks>
        /// <param name="path">File</param>
        /// <returns>Commands</returns>
        public static T Load<T>(string path)
        {
            XmlSerializer reader = new XmlSerializer(typeof(T));
            object deserialized = null;
            StreamReader file = new StreamReader(path);
            deserialized = reader.Deserialize(file);
            file.Close();

            return (T)deserialized;
        }

    }
}

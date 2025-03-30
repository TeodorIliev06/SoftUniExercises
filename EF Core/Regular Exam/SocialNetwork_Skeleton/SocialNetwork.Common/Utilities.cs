namespace SocialNetwork.Common
{
    using System.Xml;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    public class Utilities
    {
        public class XmlHelper
        {
            public  T? Deserialize<T>(string xml, string rootName)
                where T : class
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

                StringReader reader = new StringReader(xml);

                object? deserializedObject = xmlSerializer
                    .Deserialize(reader);

                if (deserializedObject == null)
                {
                    return null;
                }

                return (T)deserializedObject;
            }

            public  T? Deserialize<T>(Stream xml, string rootName)
                where T : class
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

                object? deserializedObject = xmlSerializer
                    .Deserialize(xml);

                if (deserializedObject == null)
                {
                    return null;
                }

                return (T)deserializedObject;
            }

            public string Serialize<T>(T obj, string rootName, bool OmitXmlDeclaration = false)
            {
                StringBuilder sb = new StringBuilder();
                XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

                // Remove unnecessary namespace
                XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add(prefix: string.Empty, ns: string.Empty);

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = OmitXmlDeclaration,
                    Indent = true // Optional: to format the XML with indentation
                };

                using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, obj, xmlNamespaces);
                }

                return sb.ToString().TrimEnd();
            }
        }

        public static class JsonHelper
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
            {
                //NullValueHandling = NullValueHandling.Ignore,
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            };
        }
    }
}

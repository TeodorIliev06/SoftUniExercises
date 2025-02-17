namespace Boardgames.Utilities
{
	using System.Xml;
	using System.Text;
	using System.Globalization;
	using System.Xml.Serialization;

	public class XmlHelper
	{
		public T Deserialize<T>(string inputXml, string rootName)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
			XmlSerializer serializer = new XmlSerializer(typeof(T), xmlRoot);

			using StringReader reader = new StringReader(inputXml);
			T deserializedDto = (T)serializer.Deserialize(reader);

			return deserializedDto;
		}

		public string Serialize<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
			StringBuilder stringBuilder = new StringBuilder();

			XmlWriterSettings settings = new XmlWriterSettings
			{
				OmitXmlDeclaration = omitDeclaration,
				Encoding = new UTF8Encoding(false),
				Indent = true
			};

			using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
			{
				XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
				xmlSerializerNamespaces.Add(string.Empty, string.Empty);

				try
				{
					xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
				}
				catch (Exception)
				{
					throw;
				}
			}

			return stringBuilder.ToString();
		}
	}
}

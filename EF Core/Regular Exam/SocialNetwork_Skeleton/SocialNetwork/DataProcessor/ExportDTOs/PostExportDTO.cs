namespace SocialNetwork.DataProcessor.ExportDTOs
{
    using System.Xml.Serialization;

    [XmlType("Post")]
    public class PostExportDTO
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        [XmlElement("CreatedAt")]
        public string CreatedAt { get; set; }
    }
}

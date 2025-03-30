namespace SocialNetwork.DataProcessor.ExportDTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserExportDTO
    {
        [XmlAttribute("Friendships")]
        public int Friendships { get; set; }

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlArray("Posts")]
        [XmlArrayItem("Post")]
        public PostExportDTO[] Posts { get; set; }
    }
}

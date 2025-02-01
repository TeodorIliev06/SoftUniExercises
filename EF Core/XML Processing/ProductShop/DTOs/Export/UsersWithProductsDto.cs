using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlRoot("Users")]
    public class UsersWithProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        [XmlArrayItem("User")]
        public List<UserDto> Users { get; set; } = null!;
    }
}

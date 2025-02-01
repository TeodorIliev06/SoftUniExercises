using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class CustomerExportDto
    {
        [XmlAttribute("full-name")] 
        public string FullName { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public int CarsBought { get; set; }

        [XmlAttribute("spent-money")]
        public decimal MoneySpent { get; set; }
    }
}
namespace TravelAgency.DataProcessor.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Guide")]
    public class GuideExportDto
    {
        [XmlElement("FullName")] 
        public string FullName { get; set; }

        [XmlArray("TourPackages")]
        public TourPackageDto[] TourPackages { get; set; }
    }
}

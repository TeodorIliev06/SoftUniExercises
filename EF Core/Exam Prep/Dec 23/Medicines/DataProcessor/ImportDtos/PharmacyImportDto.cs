using Medicines.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class PharmacyImportDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(ValidationConstants.PharmacyNameMinLength)]
        [MaxLength(ValidationConstants.PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression(ValidationConstants.PharmacyPhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression(ValidationConstants.PharmacyBooleanRegex)]
        public string IsNonStop { get; set; } = null!;

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public MedicineImportDto[] Medicines { get; set; }
    }
}

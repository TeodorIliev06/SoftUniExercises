using Medicines.Common;
using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Medicine))]
    public class MedicineImportDto
    {
        [XmlAttribute("category")]
        [Range(ValidationConstants.MedicineCategoryMinValue, ValidationConstants.MedicineCategoryMaxValue)]
        public int Category { get; set; }

        [Required]
        [XmlElement("Name")]
        [MinLength(ValidationConstants.MedicineNameMinLength)]
        [MaxLength(ValidationConstants.MedicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        [Range(ValidationConstants.MedicinePriceMinValue, ValidationConstants.MedicinePriceMaxValue)]
        public double Price { get; set; }

        [Required]
        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; } = null!;

        [Required]
        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [XmlElement("Producer")]
        [MinLength(ValidationConstants.MedicineProducerNameMinLength)]
        [MaxLength(ValidationConstants.MedicineProducerNameMaxLength)]
        public string Producer { get; set; } = null!;
    }
}

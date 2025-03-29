namespace TravelAgency.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Customer;

    [XmlType("Customer")]
    public class CustomerImportDto
    {
        [Required]
        [XmlElement("FullName")]
        [StringLength(FullNameMaxLength, MinimumLength = FullNameMinLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("Email")]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [XmlAttribute("phoneNumber")]
        [RegularExpression(PhoneNumberRegex)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}

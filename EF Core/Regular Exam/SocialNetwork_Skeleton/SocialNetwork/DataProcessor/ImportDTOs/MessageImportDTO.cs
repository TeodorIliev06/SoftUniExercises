namespace SocialNetwork.DataProcessor.ImportDTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using static Common.EntityValidationConstants.Message;

    [XmlType("Message")]
    public class MessageImportDTO
    {
        [Required]
        [XmlAttribute("SentAt")]
        public string SentAt { get; set; } = null!;

        [Required]
        [XmlElement("Content")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [XmlElement("Status")]
        public string Status { get; set; }

        [Required]
        [XmlElement("ConversationId")]
        public int ConversationId { get; set; }

        [Required]
        [XmlElement("SenderId")]
        public int SenderId { get; set; }
    }
}

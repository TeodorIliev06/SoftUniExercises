namespace SocialNetwork.DataProcessor.ImportDTOs
{
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using static Common.EntityValidationConstants.Post;

    public class PostImportDTO
    {
        [Required]
        [JsonProperty]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;

        [Required]
        [JsonProperty]
        public string CreatedAt { get; set; } = null!;

        [Required]
        [JsonProperty]
        public int CreatorId { get; set; }
    }
}

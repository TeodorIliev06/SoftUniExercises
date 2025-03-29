namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TravelAgency.Data.Models.Enums;

    using static Common.EntityValidationConstants.Guide;

    public class Guide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public Language Language { get; set; }

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
            = new List<TourPackageGuide>();
    }
}

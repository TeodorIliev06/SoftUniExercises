namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.TourPackage;

    public class TourPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PackageNameMaxLength)]
        public string PackageName { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
            = new List<TourPackageGuide>();
    }
}

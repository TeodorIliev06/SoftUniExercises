using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [Required]
        public int TourPackageId { get; set; }

        [ForeignKey(nameof(TourPackageId))]
        public virtual TourPackage TourPackage { get; set; } = null!;

        [Required]
        public int GuideId { get; set; }

        [ForeignKey(nameof(GuideId))]
        public virtual Guide Guide { get; set; } = null!;
    }
}

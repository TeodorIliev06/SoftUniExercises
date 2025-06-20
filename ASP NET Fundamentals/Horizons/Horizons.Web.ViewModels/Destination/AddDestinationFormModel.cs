namespace Horizons.Web.ViewModels.Destination
{
    using System.Globalization;
    using System.ComponentModel.DataAnnotations;

    using Horizons.Web.ViewModels.Terrain;

    using static GCommon.ValidationConstants.Destination;

    public class AddDestinationFormModel
    {
        public AddDestinationFormModel()
        {
            this.PublishedOn = DateTime.UtcNow
                .ToString(PublishedOnFormat, CultureInfo.InvariantCulture);
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int TerrainId { get; set; }

        public IEnumerable<TerrainViewModel>? Terrains { get; set; }

        [Required]
        public string PublishedOn { get; set; }
    }
}

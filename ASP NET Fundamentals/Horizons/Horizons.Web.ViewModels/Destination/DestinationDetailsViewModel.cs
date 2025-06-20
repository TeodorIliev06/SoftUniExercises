namespace Horizons.Web.ViewModels.Destination
{
    using System.Globalization;

    using static GCommon.ValidationConstants.Destination;

    public class DestinationDetailsViewModel : BaseDestinationViewModel
    {
        public DestinationDetailsViewModel()
        {
            this.PublishedOn = DateTime.UtcNow
                .ToString(PublishedOnFormat, CultureInfo.InvariantCulture);
        }

        public string Description { get; set; } = null!;

        public string PublishedOn { get; set; }

        public string PublisherName { get; set; } = null!;
    }
}

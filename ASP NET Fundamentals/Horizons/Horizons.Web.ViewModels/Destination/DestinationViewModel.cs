namespace Horizons.Web.ViewModels.Destination
{
    public class DestinationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string TerrainName { get; set; } = null!;

        public int FavouritesCount { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavourite { get; set; }

    }
}

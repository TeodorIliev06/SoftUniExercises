namespace Horizons.Web.ViewModels.Destination
{
    public class FavouriteDestinationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string TerrainName { get; set; } = null!;
    }
}

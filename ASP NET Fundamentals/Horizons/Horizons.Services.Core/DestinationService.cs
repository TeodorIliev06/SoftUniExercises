namespace Horizons.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using Horizons.Data;
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destination;

    public class DestinationService(
        ApplicationDbContext dbContext) : IDestinationService
    {
        public async Task<AllDestinationsViewModel> GetAllDestinationsAsync(string? userId)
        {
            bool isIdValid = !String.IsNullOrEmpty(userId);
            var allDestinations = await dbContext.Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations)
                .AsNoTracking()
                .Select(d => new DestinationViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    TerrainName = d.Terrain.Name,
                    ImageUrl = d.ImageUrl,
                    FavouritesCount = d.UsersDestinations.Count,
                    IsPublisher = isIdValid
                        ? d.PublisherId.ToLower() == userId!.ToLower()
                        : false,
                    IsFavourite = isIdValid
                        ? d.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId!.ToLower())
                        : false
                })
                .ToListAsync();

            var viewModel = new AllDestinationsViewModel()
            {
                Destinations = allDestinations
            };

            return viewModel;
        }
    }
}

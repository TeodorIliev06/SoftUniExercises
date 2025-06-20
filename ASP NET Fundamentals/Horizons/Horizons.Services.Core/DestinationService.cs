namespace Horizons.Services.Core
{
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using Horizons.Data;
    using Horizons.Data.Models;
    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destination;

    using static GCommon.ValidationConstants.Destination;

    public class DestinationService(
        ApplicationDbContext dbContext,
        UserManager<IdentityUser> userManager) : IDestinationService
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

        public async Task<bool> AddDestinationAsync(string userId, AddDestinationFormModel formModel)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var terrain = await dbContext.Terrains.FindAsync(formModel.TerrainId);

            if (terrain == null)
            {
                return false;
            }

            bool isPublishedOnDateValid = DateTime.TryParseExact(formModel.PublishedOn,
                PublishedOnFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime publishedOnDate);

            var newDestination = new Destination()
            {
                Name = formModel.Name,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                TerrainId = formModel.TerrainId,
                PublishedOn = publishedOnDate,
                PublisherId = userId
            };

            await dbContext.Destinations.AddAsync(newDestination);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}

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

        public async Task<IEnumerable<FavouriteDestinationViewModel>> GetUserFavouriteDestinationsAsync(string? userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var viewModel = await dbContext.UsersDestinations
                .AsNoTracking()
                .Include(ud => ud.Destination)
                .ThenInclude(d => d.Terrain)
                .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                .Select(ud => new FavouriteDestinationViewModel()
                {
                    Id = ud.Destination.Id,
                    Name = ud.Destination.Name,
                    ImageUrl = ud.Destination.ImageUrl,
                    TerrainName = ud.Destination.Terrain.Name
                })
                .ToListAsync();


            return viewModel;
        }

        public async Task<bool> AddDestinationToUserFavouritesAsync(string userId, int destinationId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var favouriteDestination = await dbContext.Destinations
                .FindAsync(destinationId);

            if (favouriteDestination == null)
            {
                return false;
            }

            var existingUserFavDest = await dbContext.UsersDestinations
                .SingleOrDefaultAsync(ud =>
                    ud.UserId.ToLower() == userId &&
                    ud.DestinationId == destinationId);

            if (existingUserFavDest != null)
            {
                return false;
            }

            var newFavDest = new UserDestination()
            {
                UserId = userId,
                DestinationId = destinationId
            };

            await dbContext.UsersDestinations.AddAsync(newFavDest);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveDestinationFromUserFavouritesAsync(string userId, int destinationId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var favouriteDestination = await dbContext.Destinations
                .FindAsync(destinationId);

            if (favouriteDestination == null)
            {
                return false;
            }

            var existingUserFavDest = await dbContext.UsersDestinations
                .SingleOrDefaultAsync(ud =>
                    ud.UserId.ToLower() == userId &&
                    ud.DestinationId == destinationId);

            if (existingUserFavDest == null)
            {
                return false;
            }

            dbContext.UsersDestinations.Remove(existingUserFavDest);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}

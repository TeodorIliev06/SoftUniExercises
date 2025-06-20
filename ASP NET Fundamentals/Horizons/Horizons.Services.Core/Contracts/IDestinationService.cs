namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Destination;

    public interface IDestinationService
    {
        Task<AllDestinationsViewModel> GetAllDestinationsAsync(string? userId);

        Task<bool> AddDestinationAsync(string userId, AddDestinationFormModel formModel);

        Task<IEnumerable<FavouriteDestinationViewModel>> GetUserFavouriteDestinationsAsync(string? userId);

        Task<bool> AddDestinationToUserFavouritesAsync(string userId, int destinationId);

        Task<bool> RemoveDestinationFromUserFavouritesAsync(string userId, int destinationId);

        Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? destinationId, string? userId);
    }
}
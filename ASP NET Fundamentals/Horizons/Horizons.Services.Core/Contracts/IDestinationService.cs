namespace Horizons.Services.Core.Contracts
{
    using Horizons.Web.ViewModels.Destination;

    public interface IDestinationService
    {
        Task<AllDestinationsViewModel> GetAllDestinationsAsync(string? userId);
    }
}
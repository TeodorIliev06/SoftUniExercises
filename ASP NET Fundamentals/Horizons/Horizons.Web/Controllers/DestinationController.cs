namespace Horizons.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Horizons.Services.Core.Contracts;

    public class DestinationController(
        IDestinationService destinationService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.GetUserId();

            var viewModel = await destinationService.GetAllDestinationsAsync(userId);

            return View(viewModel);
        }
    }
}

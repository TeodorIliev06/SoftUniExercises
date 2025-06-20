namespace Horizons.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Horizons.Services.Core.Contracts;
    using Horizons.Web.ViewModels.Destination;

    public class DestinationController(
        ITerrainService terrainService,
        IDestinationService destinationService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.GetUserId();

            var viewModel = await destinationService.GetAllDestinationsAsync(userId);

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            try
            {
                var formModel = new AddDestinationFormModel()
                {
                    Terrains = await terrainService.GetAllTerrainsAsync()
                };

                return View(formModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationFormModel formModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Add));
                }

                bool isDestinationAdded = await destinationService
                    .AddDestinationAsync(this.GetUserId()!, formModel);

                if (!isDestinationAdded)
                {
                    //TODO: Display an error
                    return RedirectToAction(nameof(Add));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}

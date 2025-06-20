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

        [HttpGet]
        public async Task<IActionResult> Favourites()
        {
            try
            {
                string userId = this.GetUserId();

                var viewModel = await destinationService.GetUserFavouriteDestinationsAsync(userId);

                if (viewModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavourites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var isDestAddedToFavourites = await destinationService
                    .AddDestinationToUserFavouritesAsync(userId, id.Value);

                if (!isDestAddedToFavourites)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavourites(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var isDestRemovedFromFavourites = await destinationService
                    .RemoveDestinationFromUserFavouritesAsync(userId, id.Value);

                if (!isDestRemovedFromFavourites)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Favourites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var userId = this.GetUserId();
                var viewModel = await destinationService.GetDestinationDetailsAsync(id, userId);

                if (viewModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

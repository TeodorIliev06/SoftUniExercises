namespace RecipeSharingPlatform.Web.Controllers
{
    using System.Globalization;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using RecipeSharingPlatform.Services.Core.Contracts;
    using RecipeSharingPlatform.ViewModels.Recipe;

    public class RecipeController(
        IRecipeService recipeService,
        ICategoryService categoryService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = this.GetUserId();

            var viewModel = await recipeService.GetAllRecipesAsync(userId);

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            try
            {
                var formModel = new AddRecipeFormModel()
                {
                    Categories = await categoryService.GetAllCategoriesAsync()
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
        public async Task<IActionResult> Create(AddRecipeFormModel formModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Create));
                }

                //Note: A workaround for saving the dava in required format (dd-MM-yyyy)
                if (DateTime.TryParseExact(formModel.CreatedOn, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    formModel.CreatedOn = parsedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }

                bool isRecipeCreated = await recipeService
                    .CreateRecipeAsync(this.GetUserId()!, formModel);

                if (!isRecipeCreated)
                {
                    //TODO: Display an error
                    return RedirectToAction(nameof(Create));
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
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = this.GetUserId();

                var viewModel = await recipeService
                    .GetUserFavouriteRecipesAsync(userId);

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
        public async Task<IActionResult> Save(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var isRecipeAddedToFavourites = await recipeService
                    .AddRecipeToUserFavouritesAsync(userId, id.Value);

                if (!isRecipeAddedToFavourites)
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
        public async Task<IActionResult> Remove(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;

                if (id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var isRecipeRemovedFromFavourites = await recipeService
                    .RemoveRecipeFromUserFavouritesAsync(userId, id.Value);

                if (!isRecipeRemovedFromFavourites)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}

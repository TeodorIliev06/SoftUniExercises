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

                return RedirectToAction(nameof(Create));
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
                    return RedirectToAction(nameof(Favorites));
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return RedirectToAction(nameof(Favorites));
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
                    return RedirectToAction(nameof(Save));
                }

                var isRecipeAddedToFavourites = await recipeService
                    .AddRecipeToUserFavouritesAsync(userId, id.Value);

                if (!isRecipeAddedToFavourites)
                {
                    return RedirectToAction(nameof(Save));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToAction(nameof(Save));
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
                    return RedirectToAction(nameof(Favorites));
                }

                var isRecipeRemovedFromFavourites = await recipeService
                    .RemoveRecipeFromUserFavouritesAsync(userId, id.Value);

                if (!isRecipeRemovedFromFavourites)
                {
                    return RedirectToAction(nameof(Favorites));
                }

                return RedirectToAction(nameof(Favorites));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return RedirectToAction(nameof(Favorites));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var userId = this.GetUserId();
                var viewModel = await recipeService.GetRecipeDetailsAsync(id, userId);

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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var userId = this.GetUserId();
                var viewModel = await recipeService.GetRecipeForEditingAsync(id, userId);

                if (viewModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                viewModel.Categories = await categoryService.GetAllCategoriesAsync();

                return View(viewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeFormModel formModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Edit));
                }

                //Note: A workaround for saving the dava in required format (dd-MM-yyyy)
                if (DateTime.TryParseExact(formModel.CreatedOn, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    formModel.CreatedOn = parsedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                }

                bool isRecipeEditPersisted = await recipeService
                    .UpdateRecipeForEditingAsync(this.GetUserId()!, formModel);

                if (!isRecipeEditPersisted)
                {
                    //TODO: Display an error
                    return RedirectToAction(nameof(Edit));
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
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var userId = this.GetUserId();
                var viewModel = await recipeService.GetRecipeForDeletionAsync(userId, id);

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
        public async Task<IActionResult> ConfirmDelete(DeleteRecipeFormModel formModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Delete));
                }

                bool isRecipeSoftDeleted = await recipeService
                    .SoftDeleteRecipeAsync(this.GetUserId()!, formModel);

                if (!isRecipeSoftDeleted)
                {
                    //TODO: Display an error
                    return RedirectToAction(nameof(Delete));
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

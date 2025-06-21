namespace RecipeSharingPlatform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RecipeSharingPlatform.Services.Core.Contracts;

    public class RecipeController(
        IRecipeService recipeService) : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var userId = this.GetUserId();

            var viewModel = await recipeService.GetAllRecipesAsync(userId);

            return View(viewModel);
        }
    }
}

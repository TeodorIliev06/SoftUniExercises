namespace RecipeSharingPlatform.Services.Core
{
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using RecipeSharingPlatform.Data;
    using RecipeSharingPlatform.Data.Models;
    using RecipeSharingPlatform.ViewModels.Recipe;
    using RecipeSharingPlatform.Services.Core.Contracts;

    using static GCommon.ValidationConstants.Recipe;

    public class RecipeService(
        ApplicationDbContext dbContext,
        UserManager<IdentityUser> userManager) : IRecipeService
    {
        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId)
        {
            bool isIdValid = !String.IsNullOrEmpty(userId);

            var recipes = await dbContext.Recipes
                .Include(r => r.Category)
                .AsNoTracking()
                .Select(r => new RecipeViewModel()
                {
                    Id = r.Id,
                    Title = r.Title,
                    CategoryName = r.Category.Name,
                    ImageUrl = r.ImageUrl,
                    SavedCount = r.UsersRecipes.Count,
                    IsAuthor = isIdValid
                        ? r.AuthorId.ToLower() == userId!.ToLower()
                        : false,
                    IsSaved = isIdValid
                        ? r.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId!.ToLower())
                        : false
                })
                .ToListAsync();

            return recipes;
        }

        public async Task<bool> CreateRecipeAsync(string userId, AddRecipeFormModel formModel)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var category = await dbContext.Categories.FindAsync(formModel.CategoryId);

            bool isCreatedOnDateValid = DateTime.TryParseExact(formModel.CreatedOn,
                CreatedOnFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime createdOnDate);

            if (!isCreatedOnDateValid || category == null)
            {
                return false;
            }

            var newRecipe = new Recipe()
            {
                Title = formModel.Title,
                Instructions = formModel.Instructions,
                ImageUrl = formModel.ImageUrl,
                CategoryId = formModel.CategoryId,
                CreatedOn = createdOnDate,
                AuthorId = userId
            };

            await dbContext.Recipes.AddAsync(newRecipe);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}

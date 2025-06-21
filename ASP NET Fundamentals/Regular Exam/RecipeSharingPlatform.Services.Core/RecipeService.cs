namespace RecipeSharingPlatform.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using RecipeSharingPlatform.Data;
    using RecipeSharingPlatform.ViewModels.Recipe;
    using RecipeSharingPlatform.Services.Core.Contracts;

    public class RecipeService(ApplicationDbContext dbContext) : IRecipeService
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
    }
}

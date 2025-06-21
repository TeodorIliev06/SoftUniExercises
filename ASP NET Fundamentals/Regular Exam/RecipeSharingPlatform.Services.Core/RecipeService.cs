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

        public async Task<IEnumerable<FavouriteRecipeViewModel>> GetUserFavouriteRecipesAsync(string? userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var viewModel = await dbContext.UsersRecipes
                .AsNoTracking()
                .Include(ur => ur.Recipe)
                .ThenInclude(r => r.Category)
                .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                .Select(ur => new FavouriteRecipeViewModel()
                {
                    Id = ur.RecipeId,
                    Title = ur.Recipe.Title,
                    ImageUrl = ur.Recipe.ImageUrl,
                    CategoryName = ur.Recipe.Category.Name
                })
                .ToListAsync();


            return viewModel;
        }

        public async Task<bool> AddRecipeToUserFavouritesAsync(string userId, int recipeId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var favRecipe = await dbContext.Recipes
                .FindAsync(recipeId);

            if (favRecipe == null)
            {
                return false;
            }

            var existingUserFavRecipe = await dbContext.UsersRecipes
                .SingleOrDefaultAsync(ur =>
                    ur.UserId.ToLower() == userId &&
                    ur.RecipeId == recipeId);

            if (existingUserFavRecipe != null)
            {
                return false;
            }

            var newFavRecipe = new UserRecipe()
            {
                UserId = userId,
                RecipeId = recipeId
            };

            await dbContext.UsersRecipes.AddAsync(newFavRecipe);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveRecipeFromUserFavouritesAsync(string userId, int recipeId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var favRecipe = await dbContext.Recipes
                .FindAsync(recipeId);

            if (favRecipe == null)
            {
                return false;
            }

            var existingUserFavRecipe = await dbContext.UsersRecipes
                .SingleOrDefaultAsync(ur =>
                    ur.UserId.ToLower() == userId &&
                    ur.RecipeId == recipeId);

            if (existingUserFavRecipe == null)
            {
                return false;
            }

            dbContext.UsersRecipes.Remove(existingUserFavRecipe);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? recipeId, string? userId)
        {
            if (recipeId == null)
            {
                return null;
            }

            var recipe = await dbContext.Recipes
                .AsNoTracking()
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.UsersRecipes)
                .SingleOrDefaultAsync(r => r.Id == recipeId);

            if (recipe == null)
            {
                return null;
            }

            bool isIdValid = !String.IsNullOrEmpty(userId);
            var viewModel = new RecipeDetailsViewModel()
            {
                Instructions = recipe.Instructions,
                Id = recipe.Id,
                ImageUrl = recipe.ImageUrl,
                CreatedOn = recipe.CreatedOn.ToString(CreatedOnFormat),
                CategoryName = recipe.Category.Name,
                AuthorName = recipe.Author.UserName!,
                IsAuthor = isIdValid
                    ? recipe.AuthorId.ToLower() == userId!.ToLower()
                    : false,
                IsSaved = isIdValid
                    ? recipe.UsersRecipes.Any(ud => ud.UserId.ToLower() == userId!.ToLower())
                    : false
            };

            return viewModel;
        }
    }
}

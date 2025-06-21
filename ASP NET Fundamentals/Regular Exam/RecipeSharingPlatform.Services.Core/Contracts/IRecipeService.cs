namespace RecipeSharingPlatform.Services.Core.Contracts
{
    using RecipeSharingPlatform.ViewModels.Recipe;

    public interface IRecipeService
    {       
        Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId);

        Task<bool> CreateRecipeAsync(string userId, AddRecipeFormModel formModel);

        Task<IEnumerable<FavouriteRecipeViewModel>> GetUserFavouriteRecipesAsync(string? userId);

        Task<bool> AddRecipeToUserFavouritesAsync(string userId, int recipeId);

        Task<bool> RemoveRecipeFromUserFavouritesAsync(string userId, int recipeId);
    }
}

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

        Task<RecipeDetailsViewModel?> GetRecipeDetailsAsync(int? recipeId, string? userId);

        Task<EditRecipeFormModel> GetRecipeForEditingAsync(int? recipeId, string? userId);

        Task<bool> UpdateRecipeForEditingAsync(string userId, EditRecipeFormModel formModel);

        Task<DeleteRecipeFormModel> GetRecipeForDeletionAsync(string userId, int? recipeId);

        Task<bool> SoftDeleteRecipeAsync(string userId, DeleteRecipeFormModel formModel);
    }
}

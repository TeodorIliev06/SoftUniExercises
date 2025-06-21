namespace RecipeSharingPlatform.Services.Core.Contracts
{
    using RecipeSharingPlatform.ViewModels.Recipe;

    public interface IRecipeService
    {       
        Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId);

        Task<bool> CreateRecipeAsync(string userId, AddRecipeFormModel formModel);
    }
}

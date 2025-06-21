namespace RecipeSharingPlatform.Services.Core.Contracts
{
    using RecipeSharingPlatform.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}

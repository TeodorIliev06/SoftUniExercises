namespace RecipeSharingPlatform.Services.Core
{
    using Microsoft.EntityFrameworkCore;

    using RecipeSharingPlatform.Data;
    using RecipeSharingPlatform.ViewModels.Category;
    using RecipeSharingPlatform.Services.Core.Contracts;

    public class CategoryService(ApplicationDbContext dbContext) : ICategoryService
    {
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var allCategories = await dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return allCategories;
        }
    }
}

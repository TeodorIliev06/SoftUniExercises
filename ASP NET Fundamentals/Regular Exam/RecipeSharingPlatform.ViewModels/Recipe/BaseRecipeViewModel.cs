namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public abstract class BaseRecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string? ImageUrl { get; set; }
    }
}

namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public int SavedCount { get; set; }

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }

        public string? ImageUrl { get; set; }
    }
}

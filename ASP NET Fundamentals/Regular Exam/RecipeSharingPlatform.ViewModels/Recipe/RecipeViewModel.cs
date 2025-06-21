namespace RecipeSharingPlatform.ViewModels.Recipe
{
    public class RecipeViewModel : BaseRecipeViewModel
    {
        public int SavedCount { get; set; }

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}

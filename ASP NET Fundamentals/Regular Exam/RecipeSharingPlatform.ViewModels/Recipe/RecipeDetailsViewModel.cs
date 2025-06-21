namespace RecipeSharingPlatform.ViewModels.Recipe
{
    using System.Globalization;

    using static GCommon.ValidationConstants.Recipe;

    public class RecipeDetailsViewModel : BaseRecipeViewModel
    {
        public RecipeDetailsViewModel()
        {
            this.CreatedOn = DateTime.UtcNow
                .ToString(CreatedOnFormat, CultureInfo.InvariantCulture);
        }

        public string Instructions { get; set; } = null!;

        public string CreatedOn { get; set; }

        public string AuthorName { get; set; } = null!;

        public bool IsAuthor { get; set; }

        public bool IsSaved { get; set; }
    }
}

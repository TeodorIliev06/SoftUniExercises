namespace RecipeSharingPlatform.ViewModels.Recipe
{
    using System.Globalization;
    using System.ComponentModel.DataAnnotations;

    using RecipeSharingPlatform.ViewModels.Category;

    using static GCommon.ValidationConstants.Recipe;
    public class AddRecipeFormModel
    {
        public AddRecipeFormModel()
        {
            this.CreatedOn = DateTime.UtcNow
                .ToString(CreatedOnFormat, CultureInfo.InvariantCulture);
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)] 
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(InstructionsMaxLength, MinimumLength = InstructionsMinLength)]
        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel>? Categories { get; set; }

        [Required]
        public string CreatedOn { get; set; }
    }
}

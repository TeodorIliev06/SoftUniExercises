namespace RecipeSharingPlatform.ViewModels.Recipe
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteRecipeFormModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        [Required]
        public string AuthorId { get; set; } = null!;

        public string? AuthorName { get; set; } = null!;
    }
}

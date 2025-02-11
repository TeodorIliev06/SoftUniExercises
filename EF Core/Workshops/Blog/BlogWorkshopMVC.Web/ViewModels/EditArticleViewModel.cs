namespace BlogWorkshopMVC.Web.ViewModels
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Article;

	public class EditArticleViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
		public string Content { get; set; } = null!;
	}
}

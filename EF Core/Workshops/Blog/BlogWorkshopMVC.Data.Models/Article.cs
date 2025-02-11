namespace BlogWorkshopMVC.Data.Models
{
	using System.Collections;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using static Common.EntityValidationConstants.Article;

	public class Article
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[Required]
		public string UserId { get; set; }

		[ForeignKey(nameof(UserId))] 
		public ApplicationUser User { get; set; } = null!;
	}
}

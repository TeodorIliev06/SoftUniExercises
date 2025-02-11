namespace BlogWorkshopMVC.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.ApplicationUser;

	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			this.Articles = new List<Article>();
		}

		[Key]
		public string Id { get; set; }

		[Required]
		[MaxLength(UserNameMaxLength)]
        public string UserName { get; set; } = null!;

		public ICollection<Article> Articles { get; set; }
	}
}

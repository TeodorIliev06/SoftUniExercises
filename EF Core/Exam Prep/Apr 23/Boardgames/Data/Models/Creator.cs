namespace Boardgames.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Creator;

	public class Creator
	{
		public Creator()
		{
			this.Boardgames = new List<Boardgame>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		public ICollection<Boardgame> Boardgames { get; set; }
	}
}

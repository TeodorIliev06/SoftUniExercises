namespace Boardgames.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	using Data.Models.Enums;
	using static Common.EntityValidationConstants.Boardgame;

	public class Boardgame
	{
		public Boardgame()
		{
			this.BoardgamesSellers = new List<BoardgameSeller>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public double Rating { get; set; }

		[Required]
		public int YearPublished { get; set; }

		[Required]
		public CategoryType CategoryType { get; set; }

		[Required]
		public string Mechanics { get; set; } = null!;

		[Required]
		public int CreatorId { get; set; }

		[ForeignKey(nameof(CreatorId))]
		public Creator Creator { get; set; } = null!;

		public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
	}
}

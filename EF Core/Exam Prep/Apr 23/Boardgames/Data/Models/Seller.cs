namespace Boardgames.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Seller;

	public class Seller
	{
		public Seller()
		{
			this.BoardgamesSellers = new List<BoardgameSeller>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		public string Country { get; set; } = null!;

		[Required]
		public string Website { get; set; } = null!;

		public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
	}
}

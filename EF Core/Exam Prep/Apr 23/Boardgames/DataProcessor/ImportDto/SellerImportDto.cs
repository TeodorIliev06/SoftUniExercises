namespace Boardgames.DataProcessor.ImportDto
{
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityValidationConstants.Seller;

	public class SellerImportDto
	{
		[Required]
		[JsonProperty("Name")]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[JsonProperty("Address")]
		[StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
		public string Address { get; set; } = null!;

		[Required]
		[JsonProperty("Country")]
		public string Country { get; set; } = null!;

		[Required]
		[JsonProperty("Website")]
		[RegularExpression(WebsiteRegex)]
		public string Website { get; set; } = null!;

		public int[] Boardgames { get; set; } = null!;
	}
}

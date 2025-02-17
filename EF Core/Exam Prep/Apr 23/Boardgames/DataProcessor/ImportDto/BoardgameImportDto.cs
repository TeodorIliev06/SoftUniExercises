namespace Boardgames.DataProcessor.ImportDto
{
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;

	using static Common.EntityValidationConstants.Boardgame;

	[XmlType("Boardgame")]
	public class BoardgameImportDto
	{
		[Required]
		[XmlElement("Name")]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[XmlElement("Rating")]
		[Range(RatingMinValue, RatingMaxValue)]
		public double Rating { get; set; }

		[Required]
		[XmlElement("YearPublished")]
		[Range(YearPublishedMinValue, YearPublishedMaxValue)]
		public int YearPublished { get; set; }

		[Required]
		[XmlElement("CategoryType")]
		[Range(CategoryTypeMinValue, CategoryTypeMaxValue)]
		public int CategoryType { get; set; }

		[Required]
		[XmlElement("Mechanics")]
		public string Mechanics { get; set; } = null!;
	}
}

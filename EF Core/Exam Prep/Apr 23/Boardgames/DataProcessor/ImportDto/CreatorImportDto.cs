using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
	using System.ComponentModel.DataAnnotations;
	using System.Xml.Serialization;

	using static Common.EntityValidationConstants.Creator;

	[XmlType("Creator")]
	public class CreatorImportDto
	{
		[Required]
		[XmlElement("FirstName")]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[XmlElement("LastName")]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
		public string LastName { get; set; } = null!;

		[XmlArray("Boardgames")]
		[XmlArrayItem("Boardgame")]
		public BoardgameImportDto[] Boardgames { get; set; }
	}
}

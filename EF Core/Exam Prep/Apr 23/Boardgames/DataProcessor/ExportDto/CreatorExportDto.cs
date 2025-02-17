using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
	using System.Xml.Serialization;

	[XmlType("Creator")]
	public class CreatorExportDto
	{

		[XmlElement("CreatorName")]
		public string CreatorName { get; set; } = null!;

		[XmlAttribute("BoardgamesCount")] 
		public int BoardgamesCount { get; set; }

		[XmlArray("Boardgames")]
		public BoardgameExportDto[] Boardgames { get; set; } = null!;
	}
}

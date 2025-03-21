﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ExportDto
{
	using System.Xml.Serialization;

	[XmlType("Boardgame")]
	public class BoardgameExportDto
	{
		[XmlElement("BoardgameName")]
		public string BoardgameName { get; set; } = null!;

		[XmlElement("BoardgameYearPublished")]
		public int BoardgameYearPublished { get; set; }
	}
}

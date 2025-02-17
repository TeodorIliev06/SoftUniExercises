namespace Boardgames.DataProcessor
{
	using System.Text;
	using Boardgames.DataProcessor.ExportDto;
	using Newtonsoft.Json;

	using Data;
	using Utilities;
	using static Utilities.JsonHelper;

	public class Serializer
	{
		private static XmlHelper? xmlHelper;

		public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
		{
			var sb = new StringBuilder();
			xmlHelper = new XmlHelper();

			CreatorExportDto[] creators = context.Creators
				.Where(c => c.Boardgames.Any())
				.AsEnumerable() // Switch to client-side evaluation
				.Select(c => new CreatorExportDto
				{
					CreatorName = $"{c.FirstName} {c.LastName}",
					BoardgamesCount = c.Boardgames.Count,
					Boardgames = c.Boardgames
						.Select(b => new BoardgameExportDto
						{
							BoardgameName = b.Name,
							BoardgameYearPublished = b.YearPublished
						})
						.OrderBy(b => b.BoardgameName)
						.ToArray()
				})
				.OrderByDescending(c => c.BoardgamesCount)
				.ThenBy(c => c.CreatorName)
				.ToArray();

			return xmlHelper.Serialize(creators, "Creators");
		}

		public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
		{
			var sellers = context.Sellers
				.Where(s => s.BoardgamesSellers.Any(bs =>
					bs.Boardgame.YearPublished >= year &&
					bs.Boardgame.Rating <= rating))
				.ToArray()
				.Select(s => new
				{
					s.Name,
					s.Website,
					Boardgames = s.BoardgamesSellers
						.Where(bs => bs.Boardgame.YearPublished >= year &&
							bs.Boardgame.Rating <= rating)
						.ToArray()
						.OrderByDescending(bs => bs.Boardgame.Rating)
						.ThenBy(bs => bs.Boardgame.Name)
						.Select(bs => new
						{
							Name = bs.Boardgame.Name,
							Rating = bs.Boardgame.Rating,
							Mechanics = bs.Boardgame.Mechanics,
							Category = bs.Boardgame.CategoryType.ToString()
						})
						.ToArray()
				})
				.OrderByDescending(s => s.Boardgames.Length)
				.ThenBy(s => s.Name)
				.Take(5)
				.ToArray();

			return JsonConvert.SerializeObject(sellers, Settings);
		}
	}
}
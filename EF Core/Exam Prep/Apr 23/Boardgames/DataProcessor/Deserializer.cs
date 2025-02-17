namespace Boardgames.DataProcessor
{
	using System.Text;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;

	using Data;
	using Utilities;
	using Data.Models;
	using Data.Models.Enums;
	using DataProcessor.ImportDto;

	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data!";

		private const string SuccessfullyImportedCreator
			= "Successfully imported creator – {0} {1} with {2} boardgames.";

		private const string SuccessfullyImportedSeller
			= "Successfully imported seller - {0} with {1} boardgames.";
		private static XmlHelper? xmlHelper;

		public static string ImportCreators(BoardgamesContext context, string xmlString)
		{
			var sb = new StringBuilder();
			xmlHelper = new XmlHelper();

			ICollection<Creator> validCreators = new List<Creator>();
			CreatorImportDto[] creatorDtos = xmlHelper.Deserialize<CreatorImportDto[]>(xmlString, "Creators");
			int boardgamesCount = 0;
			foreach (var crDto in creatorDtos)
			{
				if (!IsValid(crDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var creator = new Creator()
				{
					FirstName = crDto.FirstName,
					LastName = crDto.LastName
				};

				foreach (var bDto in crDto.Boardgames)
				{
					if (!IsValid(bDto))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					var boardgame = new Boardgame()
					{
						Name = bDto.Name,
						Rating = bDto.Rating,
						YearPublished = bDto.YearPublished,
						CategoryType = (CategoryType)bDto.CategoryType,
						Mechanics = bDto.Mechanics
					};

					creator.Boardgames.Add(boardgame);
				}

				validCreators.Add(creator);
				boardgamesCount += creator.Boardgames.Count;
				sb.AppendLine(String.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
			}

			context.Creators.AddRange(validCreators);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		public static string ImportSellers(BoardgamesContext context, string jsonString)
		{
			var sb = new StringBuilder();

			SellerImportDto[] sellerDtos = JsonConvert.DeserializeObject<SellerImportDto[]>(jsonString);
			ICollection<Seller> validSellers = new List<Seller>();

			foreach (var sDto in sellerDtos)
			{
				if (!IsValid(sDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				var seller = new Seller()
				{
					Name = sDto.Name,
					Address = sDto.Address,
					Country = sDto.Country,
					Website = sDto.Website
				};

				foreach (var boardgameId in sDto.Boardgames.Distinct())
				{
					var b = context.Boardgames.Find(boardgameId);

					if (b == null)
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					seller.BoardgamesSellers.Add(new BoardgameSeller()
					{
						BoardgameId = boardgameId
					});
				}

				validSellers.Add(seller);
				sb.AppendLine(String.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
			}

			context.Sellers.AddRange(validSellers);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}

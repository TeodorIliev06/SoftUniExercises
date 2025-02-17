namespace Boardgames.Common
{
	public static class EntityValidationConstants
	{
		public static class Boardgame
		{
			public const int NameMinLength = 10;
			public const int NameMaxLength = 20;

			public const double RatingMinValue = 1.0d;
			public const double RatingMaxValue = 10.0d;

			public const int YearPublishedMinValue = 2018;
			public const int YearPublishedMaxValue = 2023;

			public const int CategoryTypeMinValue = 0;
			public const int CategoryTypeMaxValue = 4;
		}

		public static class Creator
		{
			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 7;

			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 7;
		}

		public static class Seller
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 20;

			public const int AddressMinLength = 2;
			public const int AddressMaxLength = 30;

			public const string WebsiteRegex = @"^www\.[a-zA-Z0-9\-]{2,256}\.com$";
		}
	}
}

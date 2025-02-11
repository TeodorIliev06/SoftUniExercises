namespace BlogWorkshopMVC.Common
{
	public static class EntityValidationConstants
	{
		public static class Article
		{
			public const int TitleMinLength = 10;
			public const int TitleMaxLength = 50;

			public const int ContentMinLength = 50;
			public const int ContentMaxLength = 1500;
		}

        public static class ApplicationUser
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;
        }
    }
}

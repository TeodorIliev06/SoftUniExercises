namespace TravelAgency.Common
{
    public class EntityValidationConstants
    {
        public class Customer
        {
            public const int FullNameMinLength = 4;
            public const int FullNameMaxLength = 60;
            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 50;
            public const int PhoneNumberMinLength = 13;
            public const int PhoneNumberMaxLength = 13;
            public const string PhoneNumberRegex = @"^\+\d{12}$";
        }

        public class TourPackage
        {
            public const int PackageNameMinLength = 2;
            public const int PackageNameMaxLength = 400;
            public const int DescriptionMaxLength = 200;
        }

        public class Guide
        {
            public const int FullNameMinLength = 4;
            public const int FullNameMaxLength = 60;
            public const int LanguageMinValue = 0;
            public const int LanguageMaxValue = 4;
        }
    }
}

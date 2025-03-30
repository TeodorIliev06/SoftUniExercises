namespace SocialNetwork.Common
{
    public class EntityValidationConstants
    {
        public class User
        {
            public const int UsernameMinLength = 4;
            public const int UsernameMaxLength = 20;
            public const int EmailMinLength = 8;
            public const int EmailMaxLength = 60;
            public const int PasswordMinLength = 6;
        }

        public class Post
        {
            public const int ContentMinLength = 5;
            public const int ContentMaxLength = 300;
        }

        public class Message
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 200;
        }

        public class Conversation
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 30;
        }
    }
}

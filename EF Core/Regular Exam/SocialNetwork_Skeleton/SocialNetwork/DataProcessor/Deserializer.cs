namespace SocialNetwork.DataProcessor
{
    using System.Text;
    using System.Globalization;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using SocialNetwork.Data;
    using SocialNetwork.Data.Models;
    using SocialNetwork.Data.Models.Enums;
    using SocialNetwork.DataProcessor.ImportDTOs;

    using static SocialNetwork.Common.Utilities;
    using static SocialNetwork.Common.EntityValidationConstants.Post;
    using static SocialNetwork.Common.EntityValidationConstants.Message;

    public class Deserializer
    {
        private static XmlHelper? xmlHelper;

        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            var sb = new StringBuilder();
            xmlHelper = new XmlHelper();

            var messagesDtos = xmlHelper.Deserialize<MessageImportDTO[]>(xmlString, "Messages");

            foreach (var messageDto in messagesDtos)
            {
                bool isMessageDateValid = DateTime
                    .TryParseExact(messageDto.SentAt, SentAtDateFormat, CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out DateTime messageDate);

                if (!IsValid(messageDto) || !isMessageDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(messageDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var conversationExists = dbContext.Conversations.Any(c => c.Id == messageDto.ConversationId);
                var senderExists = dbContext.Users.Any(u => u.Id == messageDto.SenderId);

                if (!senderExists || !conversationExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isStatusValid = Enum
                    .TryParse(messageDto.Status, out MessageStatus messageStatus);

                if (!isStatusValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isDuplicate = dbContext.Messages.Any(m =>
                    m.Content == messageDto.Content &&
                    m.SentAt == messageDate &&
                    m.Status == messageStatus &&
                    m.SenderId == messageDto.SenderId &&
                    m.ConversationId == messageDto.ConversationId);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                var message = new Message()
                {
                    Content = messageDto.Content,
                    Status = messageStatus,
                    SentAt = messageDate,
                    ConversationId = messageDto.ConversationId,
                    SenderId = messageDto.SenderId
                };

                dbContext.Messages.Add(message);
                dbContext.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, messageDto.SentAt, messageStatus));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            var sb = new StringBuilder();

            var postDtos = JsonConvert.DeserializeObject<PostImportDTO[]>(jsonString);

            foreach (var postDto in postDtos)
            {
                bool isCreatedAtDateValid = DateTime.TryParseExact(postDto.CreatedAt, CreatedAtDateFormat,
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime createdAtDate);

                if (!IsValid(postDto) || !isCreatedAtDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = dbContext.Users.FirstOrDefault(u => u.Id == postDto.CreatorId);
                if (creator == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = dbContext.Posts.Any(p =>
                    p.Content == postDto.Content &&
                    p.CreatedAt == createdAtDate &&
                    p.CreatorId == postDto.CreatorId);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                var post = new Post
                {
                    Content = postDto.Content,
                    CreatedAt = createdAtDate,
                    CreatorId = postDto.CreatorId
                };

                dbContext.Posts.Add(post);
                dbContext.SaveChanges();

                sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username, postDto.CreatedAt));
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}

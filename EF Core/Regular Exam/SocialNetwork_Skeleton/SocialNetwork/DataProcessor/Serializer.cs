namespace SocialNetwork.DataProcessor
{
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data;
    using SocialNetwork.DataProcessor.ExportDTOs;

    using static SocialNetwork.Common.Utilities;
    using static Common.EntityValidationConstants.Post;
    using Newtonsoft.Json;
    using SocialNetwork.Data.Models.Enums;

    public class Serializer
    {
        private static XmlHelper? xmlHelper;

        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            xmlHelper = new XmlHelper();

            var users = dbContext.Users
                 .OrderBy(u => u.Username)
                 .Select(u => new UserExportDTO
                 {
                     Username = u.Username,
                     Friendships = dbContext.Friendships.Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                     Posts = u.Posts
                         .OrderBy(p => p.Id)
                         .Select(p => new PostExportDTO
                         {
                             Content = p.Content,
                             CreatedAt = p.CreatedAt.ToString(CreatedAtDateFormat)
                         })
                         .ToArray()
                 })
                 .ToArray();

            return xmlHelper.Serialize(users, "Users");
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversations = dbContext.Conversations
                .Include(c => c.Messages)
                .ThenInclude(m => m.Sender)
                .OrderBy(c => c.StartedAt)
                .Select(c => new ConversationExportDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    Messages = c.Messages 
                        .OrderBy(m => m.SentAt)
                        .Select(m => new MessageExportDTO
                        {
                            Content = m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                            Status = (int)m.Status,
                            SenderUsername = dbContext.Users.FirstOrDefault(u => u.Id == m.SenderId).Username
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(conversations, JsonHelper.Settings);
        }
    }
}

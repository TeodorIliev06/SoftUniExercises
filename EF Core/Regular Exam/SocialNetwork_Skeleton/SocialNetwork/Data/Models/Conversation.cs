namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Conversation;

    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime StartedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
            = new List<Message>();

        public virtual ICollection<UserConversation> UsersConversations { get; set; }
            = new List<UserConversation>();
    }
}

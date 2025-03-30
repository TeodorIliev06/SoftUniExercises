namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.User;

    public class User
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public virtual ICollection<Post> Posts { get; set; }
            = new List<Post>();

        public virtual ICollection<Message> Messages { get; set; }
            = new List<Message>();

        public virtual ICollection<UserConversation> UsersConversations { get; set; }
            = new List<UserConversation>();

        public virtual ICollection<Friendship> FriendshipsAsUserOne { get; set; }
            = new List<Friendship>();
        public virtual ICollection<Friendship> FriendshipsAsUserTwo { get; set; }
            = new List<Friendship>();
    }
}

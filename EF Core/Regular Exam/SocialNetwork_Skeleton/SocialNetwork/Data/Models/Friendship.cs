namespace SocialNetwork.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Friendship
    {
        [Required]
        public int UserOneId { get; set; }

        [ForeignKey(nameof(UserOneId))]
        public User UserOne { get; set; } = null!;

        [Required]
        public int UserTwoId { get; set; }

        [ForeignKey(nameof(UserTwoId))]
        public User UserTwo { get; set; } = null!;
    }
}

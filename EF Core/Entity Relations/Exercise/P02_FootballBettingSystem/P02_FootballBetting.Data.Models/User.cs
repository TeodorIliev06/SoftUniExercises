using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserUsernameLength)]
        public string Username { get; set; } = null!;

        [MaxLength(ValidationConstants.UserPasswordLength)]
        public string Password { get; set; } = null!;

        [MaxLength(ValidationConstants.UserEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        public decimal Balance { get; set; }

        [Required]
        [MaxLength(ValidationConstants.UserNameLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Bet> Bets { get; set; }
    }
}

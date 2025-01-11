using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayersStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PlayerNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public byte SquadNumber { get; set; }

        [Required]
        public int TownId { get; set; }

        //[ForeignKey(nameof(TownId))]
        public virtual Town Town { get; set; } = null!;

        [Required]
        public int PositionId { get; set; }

        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; } = null!;

        public bool IsInjured { get; set; }

        [Required]
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; } = null!;

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}

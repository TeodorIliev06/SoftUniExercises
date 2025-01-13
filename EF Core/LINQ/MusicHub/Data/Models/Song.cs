using MusicHub.Data.Common;
using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SongNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        public virtual Album Album { get; set; } = null!;

        [Required]
        public int WriterId { get; set; }

        [ForeignKey(nameof(WriterId))]
        public virtual Writer Writer { get; set; } = null!;

        public decimal Price { get; set; }
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ExamNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CourseId))]
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; }
    }
}

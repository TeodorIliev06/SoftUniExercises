using System.ComponentModel.DataAnnotations;

namespace AcademicRecordsApp.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Exams = new HashSet<Exam>();
            this.Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CourseNameLength)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

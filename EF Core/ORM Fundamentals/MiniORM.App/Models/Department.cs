namespace MiniORM.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public ICollection<Employee> Employees { get; set; } = null!;
    }
}

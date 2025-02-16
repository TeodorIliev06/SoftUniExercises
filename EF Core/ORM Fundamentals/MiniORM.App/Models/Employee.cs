namespace MiniORM.App.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        [Key] public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public bool IsEmployed { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

        public ICollection<EmployeeProject> EmployeesProjects { get; set; } = null!;
    }
}

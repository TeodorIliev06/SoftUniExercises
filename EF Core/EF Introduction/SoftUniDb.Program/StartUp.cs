using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveTown(new SoftUniContext()));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department,
                    e.Salary
                })
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (nakov != null)
            {
                nakov.Address = newAddress;
                context.SaveChanges();
            }

            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            return String.Join(Environment.NewLine, employees);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Take(10)
                .Select(e => new
                {
                    EmployeeNames = $"{e.FirstName} {e.LastName}",
                    ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects
                        .Where(ep =>
                            ep.Project.StartDate.Year >= 2001 &&
                            ep.Project.StartDate.Year <= 2003)
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                            EndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
                                "not finished"
                        })
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeNames} - Manager: {e.ManagerNames}");

                if (e.Projects.Any())
                {
                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .ToList();

            var sb = new StringBuilder();
            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            int searchedId = 147;
            var employee = context.Employees.Find(searchedId);
            var projects = employee.EmployeesProjects
                .OrderBy(p => p.Project.Name)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            int requiredEmployeeCount = 5;
            var departments = context.Departments
                .Select(d => new
                {
                    d.Name,
                    ManagerNames = $"{d.Manager.FirstName} {d.Manager.LastName}",
                    d.Employees
                })
                .Where(d => d.Employees.Count > requiredEmployeeCount)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerNames}");
                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .OrderBy(p => p.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                    .Contains(e.Department.Name))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = (decimal)((double)e.Salary * 1.12)
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            context.SaveChanges();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            int projectId = 2;

            // Remove all references to the project in the EmployeesProjects table
            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectId)
                .ToList();

            if (employeeProjects.Any())
            {
                context.EmployeesProjects.RemoveRange(employeeProjects);
            }

            // Remove the project itself
            var projectToDelete = context.Projects.Find(projectId);
            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }

            var projectsNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var name in projectsNames)
            {
                sb.AppendLine($"{name}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList();

            if (addressesToDelete.Any())
            {
                foreach (var a in addressesToDelete)
                {
                    var employees = context.Employees
                        .Where(e => e.AddressId == a.AddressId)
                        .ToList();

                    foreach (var e in employees)
                    {
                        e.AddressId = null;
                    }
                }

                context.Addresses.RemoveRange(addressesToDelete);
                context.SaveChanges();
            }

            var townToDelete = context.Towns
                .FirstOrDefault(t => t.Name == townName);
            if (townToDelete != null)
            {
                context.Towns.Remove(townToDelete);
                context.SaveChanges();
            }

            return $"{addressesToDelete.Count} addresses in {townName} were deleted";
        }
    }
}

namespace _01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();
            string input;

            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                string[] employeeData = input.Split();
                string name = employeeData[0];
                double salary = double.Parse(employeeData[1]);
                string departmentName = employeeData[2];

                Department department = GetOrCreateDepartment(departments, departmentName);
                department.AddNewEmployee(name, salary);
            }

            Department bestDepartment = departments.OrderByDescending(d => d.TotalSalaries / d.Employees.Count).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (Employee employee in bestDepartment.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
            }
        }

        static Department GetOrCreateDepartment(List<Department> departments, string departmentName)
        {
            Department department = departments.FirstOrDefault(d => d.DepartmentName == departmentName);

            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);
            }

            return department;
        }
    }

    class Employee
    {
        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }

        public double Salary { get; set; }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; }
        public double TotalSalaries { get; set; }

        public void AddNewEmployee(string empName, double empSalary)
        {
            TotalSalaries += empSalary;
            Employees.Add(new Employee(empName, empSalary));
        }

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            Employees = new List<Employee>();
        }
    }
}
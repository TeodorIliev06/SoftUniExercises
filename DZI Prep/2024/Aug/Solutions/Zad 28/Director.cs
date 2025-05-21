using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    internal class Director : ClubMember
    {
        public Director(string firstName, string lastName, int age, double salary, string directorType) 
            : base(firstName, lastName, age, salary)
        {
            this.DirectorType = directorType;
        }

        public string DirectorType { get; set; }

        public override void Info()
        {
            Console.WriteLine($"{this.DirectorType} director: {this.FirstName} {this.LastName}");
            Console.WriteLine($"salary: {this.Salary:F2} lv");
            Console.WriteLine($"age: {this.Age} years");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    internal class Coach : ClubMember
    {
        public Coach(string firstName, string lastName, int age,
            double salary, string coachType, int contractLength) 
            : base(firstName, lastName, age, salary)
        {
            this.CoachType = coachType;
            this.ContractLength = contractLength;
        }

        public string CoachType { get; set; }
        public int ContractLength { get; set; }

        public void Info()
        {
            Console.WriteLine($"{this.CoachType} coach: {this.FirstName} {this.LastName}");
            Console.WriteLine($"salary: {this.Salary:F2} lv");
            Console.WriteLine($"age: {this.Age} years");
        }
    }
}

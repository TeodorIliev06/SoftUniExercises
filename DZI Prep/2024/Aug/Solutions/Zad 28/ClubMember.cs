using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    internal abstract class ClubMember
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _salary;

        protected ClubMember(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The name can't be an empty string!");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"The name can't be an empty string!");
                }
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 17)
                {
                    throw new ArgumentNullException($"Age must be greater than 17 years!");
                }
                _age = value;
            }
        }

        public double Salary
        {
            get => _salary;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException($"Salary must be a positive number!");
                }
                _salary = value;
            }
        }

        public abstract void Info();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_28
{
    internal class ClubMember
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _salary;

        public ClubMember(string firstName, string lastName, int age, double salary)
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
                if (string.IsNullOrEmpty(_firstName))
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
                if (string.IsNullOrEmpty(_lastName))
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
                if (_age <= 17)
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
                if (_salary <= 0)
                {
                    throw new ArgumentNullException($"Salary must be a positive number!");
                }
                _salary = value;
            }
        }
    }
}

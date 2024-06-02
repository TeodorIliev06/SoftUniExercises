using System.Collections.Generic;
using System.Security.Cryptography;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = default;
            List<Student> students = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] studentToken = command.Split();
                string firstName = studentToken[0];
                string lastName = studentToken[1];
                int age = int.Parse(studentToken[2]);
                string homeTown = studentToken[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                students.Add(student);
            }
             
            string cityFilter = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == cityFilter)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
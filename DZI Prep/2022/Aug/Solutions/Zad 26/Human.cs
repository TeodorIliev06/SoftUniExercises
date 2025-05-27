namespace Zad_26
{
    public class Human
    {
        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}, {this.Age} years old";
        }
    }
}

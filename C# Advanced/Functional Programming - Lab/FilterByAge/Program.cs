namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string[] format = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);
        }

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            List<Person> filteredPeople = people.Where(p => filter(p)).ToList();

            filteredPeople.ForEach(person => printer(person));
        }

        private static Action<Person> CreatePrinter(string[] format)
        {
            if (format.Length > 1)
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            else if (format[0] == "name") 
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (format[0] == "age")
            {
                return p => Console.WriteLine($"{p.Age}");
            }

            return null;
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return p => p.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return p => p.Age >= ageThreshold;
            }
            return null;
        }

        private static List<Person> ReadPeople()
        {
            List<Person> people = new();
            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            return people;
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string  Name { get; set; }   
        public int  Age { get; set; }   
    }
}

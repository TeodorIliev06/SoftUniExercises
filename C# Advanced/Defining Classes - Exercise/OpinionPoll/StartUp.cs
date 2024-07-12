namespace OpinionPoll
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                people.Add(new Person(name, age));
            }

            List<Person> sortedPeople = people.Where(p => p.Age > 30).OrderBy(n => n.Name).ToList();
            sortedPeople.ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
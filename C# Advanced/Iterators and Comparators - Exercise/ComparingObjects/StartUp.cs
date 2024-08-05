namespace ComparingObjects;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> people = new();

        string command;
        while ((command = Console.ReadLine().ToLower()) != "end")
        {
            string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            people.Add(new Person(name, age, town));
        }

        int position = int.Parse(Console.ReadLine());
        Person comparedPerson = people[position - 1];

        int peopleCount = people.Count;
        int matches = people.Count(p => p.CompareTo(comparedPerson) == 0);
        int notMatches = peopleCount - matches;

        if (matches == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{matches} {notMatches} {peopleCount}");
        }
    }
}

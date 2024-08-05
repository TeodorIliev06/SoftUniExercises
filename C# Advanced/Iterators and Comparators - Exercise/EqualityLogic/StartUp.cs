namespace EqualityLogic;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        HashSet<Person> people = new();
        SortedSet<Person> sortedPeople = new();

        for (int i = 0; i < lines; i++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);

            sortedPeople.Add(new Person(name, age));
            people.Add(new Person(name, age));
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(people.Count);
    }
}

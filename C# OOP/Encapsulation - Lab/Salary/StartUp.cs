namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        List<Person> persons = new();

        for (int i = 0; i < lines; i++)
        {
            string[] personInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = personInfo[0];
            string lastName = personInfo[1];
            int age = int.Parse(personInfo[2]);
            decimal salary = decimal.Parse(personInfo[3]);

            persons.Add(new Person(firstName, lastName, age, salary));
        }

        decimal percentage = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(percentage));
        Console.WriteLine(String.Join("\n", persons));
    }
}

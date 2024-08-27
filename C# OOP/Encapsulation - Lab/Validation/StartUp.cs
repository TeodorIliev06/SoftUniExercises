using System.Globalization;

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

            try
            {
                Person person = new(personInfo[0], personInfo[1], int.Parse(personInfo[2]), decimal.Parse(personInfo[3], CultureInfo.InvariantCulture));
                persons.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        decimal percentage = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(percentage));
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}

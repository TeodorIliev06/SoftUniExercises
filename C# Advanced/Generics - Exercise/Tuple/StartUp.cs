namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = ReadStringArr();
            string firstName = firstLine[0];
            string lastName = firstLine[1];
            string address = firstLine[2];
            CustomTuple<string, string> firstTuple = new($"{firstName} {lastName}", address);

            string[] secondLine = ReadStringArr();
            string name = secondLine[0];
            int amountOfBeer = int.Parse(secondLine[1]);
            CustomTuple<string, int> secondTuple = new(name, amountOfBeer);

            string[] thirdLine = ReadStringArr();
            int integer = int.Parse(thirdLine[0]);
            double @double = double.Parse(thirdLine[1]);
            CustomTuple<int, double> thirdTuple = new(integer, @double);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }

        private static string[] ReadStringArr()
        {
            string[] stringArr = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return stringArr;
        }
    }
}

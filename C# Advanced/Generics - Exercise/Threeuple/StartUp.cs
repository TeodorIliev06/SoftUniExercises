namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstLine = ReadStringArr();
            string firstName = firstLine[0];
            string lastName = firstLine[1];
            string address = firstLine[2];
            string town = firstLine[3];
            CustomTuple<string, string, string> firstTuple = new($"{firstName} {lastName}", address, town);

            string[] secondLine = ReadStringArr();
            string name = secondLine[0];
            int amountOfBeer = int.Parse(secondLine[1]);
            bool drunkOrNot = secondLine[2] == "drunk";
            CustomTuple<string, int, bool> secondTuple = new(name, amountOfBeer, drunkOrNot);

            string[] thirdLine = ReadStringArr();
            string otherName = thirdLine[0];
            double bankBalance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];
            CustomTuple<string, double, string> thirdTuple = new(otherName, bankBalance, bankName);

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

namespace _02._Tax_Calculator;

internal class Program
{
    static void Main(string[] args)
    {
        string[] vehicles = Console.ReadLine()
            .Split(">>", StringSplitOptions.RemoveEmptyEntries);
        int totalTaxes = 0;

        for (int i = 0; i < vehicles.Length; i++)
        {
            string[] currVehicleInfo = vehicles[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string currType = currVehicleInfo[0];
            int years = int.Parse(currVehicleInfo[1]);
            int kilometers = int.Parse(currVehicleInfo[2]);

            int currTax = 0, addedTax = 0, removedTax = 0;
            switch (currType)
            {
                case "family":
                    currTax = 50;
                    addedTax = kilometers / 3000 * 12;
                    removedTax = years * 5;
                    AddTaxAndPrint(ref totalTaxes, currType, ref currTax, addedTax, removedTax);
                    break;
                case "heavyDuty":
                    currTax = 80;
                    addedTax = kilometers / 9000 * 14;
                    removedTax = years * 8;
                    AddTaxAndPrint(ref totalTaxes, currType, ref currTax, addedTax, removedTax);
                    break;
                case "sports":
                    currTax = 100;
                    addedTax = kilometers / 2000 * 18;
                    removedTax = years * 9;
                    AddTaxAndPrint(ref totalTaxes, currType, ref currTax, addedTax, removedTax);
                    break;
                default:
                    Console.WriteLine("Invalid car type.");
                    break;
            }
        }

        Console.WriteLine($"The National Revenue Agency will collect {totalTaxes:f2} euros in taxes.");
    }

    private static void AddTaxAndPrint(ref int totalTaxes, string currType, ref int currTax, int addedTax, int removedTax)
    {
        currTax = currTax + addedTax - removedTax;
        totalTaxes += currTax;
        Console.WriteLine($"A {currType} car will pay {currTax:f2} euros in taxes.");
    }
}

namespace Zad_28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("data.txt");
            var vehicles = new Stack<Car>();

            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                Car vehicle = null!;
                string brand;
                int year, mileage;
                decimal price;

                switch (int.Parse(line))
                {
                    case 1:
                        brand = reader.ReadLine()!;
                        var carInfo = reader.ReadLine()!.Split();

                        year = int.Parse(carInfo[0]);
                        mileage = int.Parse(carInfo[1]);
                        price = decimal.Parse(carInfo[2]);

                        vehicle = new Car(brand, year, mileage, price);

                        break;
                    case 2:
                        brand = reader.ReadLine()!;
                        var truckInfo = reader.ReadLine()!.Split();

                        year = int.Parse(truckInfo[0]);
                        mileage = int.Parse(truckInfo[1]);
                        price = decimal.Parse(truckInfo[2]);
                        int tonnage = int.Parse(truckInfo[3]);

                        vehicle = new Truck(brand, year, mileage, price, tonnage);

                        break;
                }

                vehicles.Push(vehicle);
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}

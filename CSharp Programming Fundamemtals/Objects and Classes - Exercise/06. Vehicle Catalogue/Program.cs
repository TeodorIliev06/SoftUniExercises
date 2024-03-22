using System.Text;

namespace CatalogVehicle;

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicles = new();
        double totalCarHorsepower = 0, totalTruckHorsepower = 0;
        int carCount = 0, truckCount = 0;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] vehicleInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string type = vehicleInfo[0];
            string model = vehicleInfo[1];
            string color = vehicleInfo[2];
            int horsepower = int.Parse(vehicleInfo[3]);

            vehicles.Add(new Vehicle(type, model, color, horsepower));

            if (type == "car")
            {
                totalCarHorsepower += horsepower;
                carCount++;
            }
            else if (type == "truck")
            {
                totalTruckHorsepower += horsepower;
                truckCount++;
            }
        }

        string filter;
        StringBuilder sb = new();
        while ((filter = Console.ReadLine()) != "Close the Catalogue")
        {
            foreach (var vehicle in vehicles.Where(x => x.Model == filter))
            {
                //Changing the first letter of the vehicle type
                vehicle.Type = vehicle.Type.Substring(0, 1).ToUpper() + vehicle.Type.Substring(1);
                sb.AppendLine($"Type: {vehicle.Type}");
                sb.AppendLine($"Model: {vehicle.Model}");
                sb.AppendLine($"Color: {vehicle.Color}");
                sb.AppendLine($"Horsepower: {vehicle.Horsepower}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
            sb.Clear();
        }

        double averageCarHorsepower = carCount > 0 ? totalCarHorsepower / carCount : 0;
        double averageTruckHorsepower = truckCount > 0 ? totalTruckHorsepower / truckCount : 0;

        Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
        Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
    }
}
class Vehicle
{
    public Vehicle(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }
}
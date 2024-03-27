using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carCount = int.Parse(Console.ReadLine());
            List<Car> carCollection = new List<Car>();
            string input;

            for (int i = 0; i < carCount; i++)
            {
                input = Console.ReadLine();
                string[] carData = input.Split();
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double consumption = double.Parse(carData[2]);
                double distanceTravelled = 0;

                Car car = new Car(model, fuelAmount, consumption, distanceTravelled);
                carCollection.Add(car);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandInfo = command.Split();
                string action = commandInfo[0];
                string model = commandInfo[1];
                int amountOfKm = int.Parse(commandInfo[2]);

                foreach (Car car in carCollection.Where(c => c.Model == model))
                {
                    car.Move(amountOfKm);
                }
            }

            carCollection.ForEach(car => Console.WriteLine(car));
        }
    }
    class Car
    {
        public Car(string model, double fuelAmount, double consumption, double distanceTravelled)
        {
            Model = model;
            FuelAmount = fuelAmount;
            Consumption = consumption;
            DistanceTravelled = distanceTravelled;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double Consumption { get; set; }
        public double DistanceTravelled { get; set; }
        public double TravelDistance 
        {
            get
            {
                return FuelAmount / Consumption;
            }
        }
        public void Move(int amountOfKm)
        {
            if (amountOfKm > TravelDistance)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= Consumption * amountOfKm;
                DistanceTravelled += amountOfKm;
            }
        }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {DistanceTravelled}";
        }
    }         
}
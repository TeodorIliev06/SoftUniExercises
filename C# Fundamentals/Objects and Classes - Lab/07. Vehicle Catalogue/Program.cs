using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = default;
            List<Car> carCollection = new List<Car>();
            List<Truck> truckCollection = new List<Truck>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputToken = input.Split('/');
                string type = inputToken[0];
                string brand = inputToken[1];
                string model = inputToken[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(inputToken[3]);
                    Car car = new Car(brand, model, horsePower);
                    carCollection.Add(car);
                }
                else if (type == "Truck")
                {
                    int weight = int.Parse(inputToken[3]);
                    Truck truck = new Truck(brand, model, weight);
                    truckCollection.Add(truck);
                }
            }

            VehicleCatalog catalog = new VehicleCatalog(carCollection, truckCollection);
            catalog.PrintCatalog();
        }

        public class Car
        {
            public string Brand { get; }
            public string Model { get; }
            public int HorsePower { get; }

            public Car(string brand, string model, int horsePower)
            {
                Brand = brand;
                Model = model;
                HorsePower = horsePower;
            }
        }

        public class Truck
        {
            public string Brand { get; }
            public string Model { get; }
            public int Weight { get; }

            public Truck(string brand, string model, int weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
            }
        }

        public class VehicleCatalog
        {
            public List<Car> Cars { get; }
            public List<Truck> Trucks { get; }

            public VehicleCatalog(List<Car> cars, List<Truck> trucks)
            {
                Cars = cars;
                Trucks = trucks;
            }

            public void PrintCatalog()
            {
                Console.WriteLine("Cars:");
                foreach (Car car in Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }

                Console.WriteLine("Trucks:");
                foreach (Truck truck in Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}

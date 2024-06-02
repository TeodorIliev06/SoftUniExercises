using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System;

namespace _04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carCount = int.Parse(Console.ReadLine());
            string input;
            List<Car> carCollection = new List<Car>();

            for (int i = 0; i < carCount; i++)
            {
                input = Console.ReadLine();
                string[] carInfo = input.Split();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car (model, engine, cargo);

                carCollection.Add(car);
            }

            input = Console.ReadLine();

            if (input == "fragile") 
            {
                carCollection = carCollection.Where(car => car.Cargo.CargoType == input 
                                && car.Cargo.CargoWeight < 1000).ToList();
                carCollection.ForEach(car => Console.WriteLine(car));
            }
            else if (input == "flamable")
            {
                carCollection = carCollection.Where(car => car.Cargo.CargoType == input
                                && car.Engine.EnginePower > 250).ToList();
                carCollection.ForEach(car => Console.WriteLine(car));
            }
        }

    }
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get;  }
        public Engine Engine { get;  }
        public Cargo Cargo { get;  }
        public override string ToString()
        {
            return $"{Model}";
        }
    }
    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}
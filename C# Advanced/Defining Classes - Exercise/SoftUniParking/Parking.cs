using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new();
            this.capacity = capacity;
        }
        public int Count => cars.Count;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.cars.Count() + 1 > this.capacity)
            {
                return "Parking is full!";
            }
            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        //public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        //{
        //    cars = cars.Where(c => !RegistrationNumbers.Contains(c.RegistrationNumber)).ToList();
        //}

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}

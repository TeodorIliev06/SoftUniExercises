namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {       
        private const string make = "Mercedes";
        private const string model = "C220";
        private const double fuelConsumption = 6.8;
        private const double fuelCapacity = 66;
        private const double fuelToRefuel = 10;
        private const double distance = 132.35;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }
        [Test]
        public void Ctor_ShouldWork()
        {
            Assert.That(0, Is.EqualTo(car.FuelAmount));
        }

        [TestCase("", model, fuelConsumption, fuelCapacity)]
        [TestCase(make, "", fuelConsumption, fuelCapacity)]
        [TestCase(make, model, 0, fuelCapacity)]
        [TestCase(make, model, fuelConsumption, 0)]
        public void Ctor_ShouldThrowError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Car data can't be missing or initialized as null.");
        }

        [Test]
        public void Refuel_ShouldWork()
        {
            double initialFuelAmount = car.FuelAmount;

            car.Refuel(fuelToRefuel);

            Assert.That(car.FuelAmount, Is.EqualTo(initialFuelAmount + fuelToRefuel));
        }

        [Test]
        public void Refuel_WhenFull_ShouldSetToFuelCapacity()
        {
            double toRefuel = fuelCapacity + 1;

            car.Refuel(toRefuel);

            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }

        [Test]
        public void Refuel_WhenNegativeOrZero_ShouldThrowError()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Car can't be refueled with invalid litres.");
        }

        [Test]
        public void Drive_ShouldWork()
        {
            double expectedLitersLeft = 1;

            car.Refuel(fuelToRefuel);
            car.Drive(distance);

            Assert.AreEqual(expectedLitersLeft, Math.Round(car.FuelAmount, 3));
            Assert.That(Math.Round(car.FuelAmount, 3), Is.EqualTo(expectedLitersLeft));
        }

        [Test]
        public void Drive_WhenInsufficientFuelAmount_ShouldThrowError()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "Car can't be driven with the current amount of fuel.");
        }
    }
}
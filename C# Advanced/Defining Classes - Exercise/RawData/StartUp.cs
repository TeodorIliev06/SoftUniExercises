namespace RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();
            List<Tire[]> tires = new();

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0],
                    cargoType = carInfo[4];

                int engineSpeed = int.Parse(carInfo[1]),
                    enginePower = int.Parse(carInfo[2]),
                    cargoWeight = int.Parse(carInfo[3]),
                    tire1Age = int.Parse(carInfo[6]),
                    tire2Age = int.Parse(carInfo[8]),
                    tire3Age = int.Parse(carInfo[10]),
                    tire4Age = int.Parse(carInfo[12]);

                double tire1Pressure = double.Parse(carInfo[5]),
                    tire2Pressure = double.Parse(carInfo[7]),
                    tire3Pressure = double.Parse(carInfo[9]),
                    tire4Pressure = double.Parse(carInfo[11]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                tires.Add(new Tire[]
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                });

                cars.Add(new Car(model, engine, cargo, tires[i]));
            }

            string filter = Console.ReadLine();

            if (filter == "fragile")
            {
                var fragileCars = cars
                    .Where(car => car.Cargo.Type == "fragile" && car.Tires.Any(tire => tire.Pressure < 1))
                    .Select(car => car.Model);

                foreach (var model in fragileCars)
                {
                    Console.WriteLine(model);
                }
            }

            else if (filter == "flammable")
            {
                var flammableCars = cars
                    .Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    .Select(car => car.Model);

                foreach (var model in flammableCars)
                {
                    Console.WriteLine(model);
                }
            }
        }
    }
}

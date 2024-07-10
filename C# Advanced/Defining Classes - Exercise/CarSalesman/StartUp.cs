namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new();
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = default;
                if (engineInfo.Length == 3)
                {
                    string input = engineInfo[2];
                    if (int.TryParse(input, out int displacement))
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, input);
                    }                   
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            List<Car> cars = new();
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine carEngine = engines.Find(e => e.Model == engineModel);

                if (carInfo.Length == 3)
                {
                    string input = carInfo[2];
                    if (int.TryParse(input, out int weight))
                    {
                        cars.Add(new Car(model, carEngine, weight));
                    }
                    else
                    {
                        cars.Add(new Car(model, carEngine, input));
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    cars.Add(new Car(model, carEngine, weight, color));
                }
                else
                {
                    cars.Add(new Car(model, carEngine));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

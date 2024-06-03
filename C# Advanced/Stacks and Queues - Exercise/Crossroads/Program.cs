namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carQueue = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input;
            char hitSymbol;
            int passedCars = 0;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    carQueue.Enqueue(input);
                    continue;
                }

                int currGLDuration = greenLightDuration;
                while (currGLDuration > 0 && carQueue.Count > 0)
                {
                    string currCar = carQueue.Dequeue();
                    int currCarLen = currCar.Length;

                    if (currGLDuration >= currCarLen)
                    {
                        currGLDuration -= currCarLen;
                        passedCars++;
                    }
                    else
                    {
                        currGLDuration += freeWindowDuration;

                        if (currGLDuration >= currCarLen)
                        {
                            passedCars++;
                            break;
                        }

                        hitSymbol = currCar[currGLDuration];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currCar} was hit at {hitSymbol}.");
                        return;
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}


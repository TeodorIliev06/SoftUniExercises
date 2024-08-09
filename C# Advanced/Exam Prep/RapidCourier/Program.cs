namespace RapidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> weights = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> couriers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int weightDelivered = 0;

            while (weights.Any() && couriers.Any())
            {
                if (couriers.Peek() >= weights.Peek())
                {
                    bool isNegative = couriers.Peek() - weights.Peek() * 2 <= 0;
                    if (!isNegative)
                    {
                        couriers.Enqueue(couriers.Peek() - weights.Peek() * 2);
                    }
                    couriers.Dequeue();
                    weightDelivered += weights.Pop();
                }
                else
                {
                    weightDelivered += couriers.Peek();
                    int packageWeight = weights.Pop() - couriers.Dequeue();
                    weights.Push(packageWeight);
                }
            }

            Console.WriteLine($"Total weight: {weightDelivered} kg");

            if (weights.Any() && !couriers.Any())
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", weights)}");
            }
            else if (!weights.Any() && couriers.Any())
            {
                Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
            }
            else
            {
                Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
            }
        }
    }
}
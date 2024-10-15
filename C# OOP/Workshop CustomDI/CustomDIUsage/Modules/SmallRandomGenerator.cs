using CustomDIUsage.Modules.Contracts;

namespace CustomDIUsage.Modules
{
    public class SmallRandomGenerator : IRandomGenerator
    {
        public SmallRandomGenerator(DateTime dateToday)
        {
            Console.WriteLine("Small random generator created");
        }
        public int GetRandom()
        {
            return new Random().Next(0, 10);
        }
    }
}

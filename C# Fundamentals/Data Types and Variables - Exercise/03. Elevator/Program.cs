namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = Convert.ToInt32(Console.ReadLine());
            int capacity = Convert.ToInt32(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)people / capacity);
            Console.WriteLine(courses);
        }
    }
}
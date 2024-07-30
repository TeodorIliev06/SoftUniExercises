namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> box = new();

            for (int i = 0; i < lines; i++)
            {
                box.Add(Console.ReadLine());
            }

            string compareWith = Console.ReadLine();
            Console.WriteLine(box.CountLarger(compareWith));
        }
    }
}

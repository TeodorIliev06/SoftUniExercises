namespace Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                Box<int> list = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                list.Add(int.Parse(value));
            }
            Console.WriteLine(list);
        }
    }
}
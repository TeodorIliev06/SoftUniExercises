namespace Zad_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new ItemList();
            int N = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < N; i++)
                {
                    var tokens = Console.ReadLine().Split();
                    var description = tokens[0];
                    var price = double.Parse(tokens[1]);

                    items.Add(new Item(description, price));
                }

                for (int i = 0;i < items.Count; i++)
                {
                    Console.WriteLine(items.Get(i));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}

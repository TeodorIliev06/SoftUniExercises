namespace CustomDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList();

            customList.Add(5);
            customList.Add(7);
            customList.RemoveAt(1);
            Console.WriteLine(customList.Contains(5));

            customList.Insert(0,6);
            customList.Swap(0,1);

            foreach (var element in customList)
            {
                Console.WriteLine(element);
            }
        }
    }
}

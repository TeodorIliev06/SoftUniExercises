namespace _07.SequenceNToM
{
    internal class Program
    {
        private class Item
        {
            public Item(int value, Item previous)
            {
                Value = value;
                Previous = previous;
            }

            public int Value { get; set; }
            public Item Previous { get; set; }
        }
        static void Main(string[] args)
        {
            var queue = new Queue<Item>();
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstItemValue = input[0];
            int expectedNum = input[1];

            queue.Enqueue(new Item(firstItemValue, null));
            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();

                if (currentItem.Value < expectedNum)
                {
                    queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                }
                if (currentItem.Value == expectedNum)
                {
                    var output = new List<int>(queue.Count);
                    int index = 0;

                    while (currentItem != null)
                    {
                        output.Insert(0, currentItem.Value);
                        currentItem = currentItem.Previous;
                    }

                    output.TrimExcess();
                    Console.WriteLine(String.Join(" -> ", output));
                    return;
                }
            }
        }
    }
}
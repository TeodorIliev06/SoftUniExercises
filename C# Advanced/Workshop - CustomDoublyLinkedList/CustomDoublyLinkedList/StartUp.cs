namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.ForEach(Console.WriteLine);

            int[] array = linkedList.ToArray();

            Console.WriteLine(string.Join(", ", array));

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.ForEach(Console.WriteLine);
        }
    }
}

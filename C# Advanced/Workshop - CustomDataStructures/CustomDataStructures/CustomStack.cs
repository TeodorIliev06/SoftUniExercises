namespace CustomDataStructures
{
    public class CustomStack
    {
        private const int IninitalCapacity = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            count = 0;
            items = new int[IninitalCapacity];
        }

        public int Count => count;

        public void Push(int element)
        {
            if (count == items.Length)
            {
                IncreaseSize();
            }

            items[count] = element;
            count++;
        }

        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            var lastIndex = count - 1;
            int last = items[lastIndex];
            count--;

            return last;
        }

        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            var lastIndex = count - 1;
            int lastElement = items[lastIndex];

            return lastElement;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        private void IncreaseSize()
        {
            var newItems = new int[items.Length * 2];
            items.CopyTo(newItems, 0);
            items = newItems;
        }
    }
}

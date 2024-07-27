namespace CustomDataStructures
{
    public class CustomQueue
    {
        private const int IninitalCapacity = 4;
        private int head;
        private int[] items;
        private int count;

        public CustomQueue()
        {
            head = 0;
            count = 0;
            items = new int[IninitalCapacity];
        }

        public int Count => count;

        public void Enqueue(int item)
        {
            if (count == items.Length)
            {
                IncreaseSize();
            }

            var tail = (head + count) % items.Length;
            items[tail] = item;
            count++;
        }

        //Circular buffer approach
        public int Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }

            var firstElement = items[head];
            items[head] = default;
            head = (head + 1) % items.Length;
            count--;

            return firstElement;
        }

        public int Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }

            var firstElement = items[head];

            return firstElement;
        }

        public void Clear()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }

            head = 0;
            count = 0;

            Array.Clear(items, 0, items.Length);
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

            for (int i = 0; i < count; i++)
            {
                newItems[i] = items[(head + i) % items.Length];
            }

            items = newItems;
            head = 0;
        }
    }
}

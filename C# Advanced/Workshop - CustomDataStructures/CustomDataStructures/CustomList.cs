using System.Collections;

namespace CustomDataStructures
{
    public class CustomList : IEnumerable
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = items[index];
            items[index] = default(int);
            Shift(index);

            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return item;
        }

        public void Insert(int index, int element)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            ShiftToRight(index);
            items[index] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count ||
                secondIndex < 0 || secondIndex >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            (items[firstIndex], items[secondIndex]) = (items[secondIndex], items[firstIndex]);
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

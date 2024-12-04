namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[Count - 1 - i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (Count == items.Length)
            {
                Resize();
            }

            index = Count - index;
            ShiftToRight(index);
            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            Shift(index);

            items[Count - 1] = default(T);
            Count--;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = Count - 1; currentIndex >= 0; currentIndex--)
            {
                yield return items[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Resize()
        {
            var copyArr = new T[items.Length * 2];
            Array.Copy(items, copyArr, Count);
            items = copyArr;
        }

        private void Shrink()
        {
            var copyArr = new T[items.Length / 2];
            Array.Copy(items, copyArr, Count);
            items = copyArr;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void Shift(int index)
        {
            index = Count - 1 - index;
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void ShiftToRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }
    }
}
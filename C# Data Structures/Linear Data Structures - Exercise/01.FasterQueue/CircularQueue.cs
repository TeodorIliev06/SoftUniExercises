namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int IninitalCapacity = 4;
        private int startIndex;
        private int endIndex;
        private T[] elements;

        public CircularQueue()
        {
            elements = new T[IninitalCapacity];
        }

        public int Count { get; set; }

        public T Dequeue()
        {
            CheckIfEmpty();

            var firstElement = elements[startIndex];
            elements[startIndex] = default;
            startIndex = (startIndex + 1) % elements.Length;
            Count--;

            return firstElement;
        }

        public void Enqueue(T item)
        {
            if (Count == elements.Length)
            {
                IncreaseSize();
            }

            elements[endIndex] = item;
            endIndex = (endIndex + 1) % elements.Length;
            Count++;
        }

        public T Peek()
        {
            CheckIfEmpty();

            return elements[startIndex];
        }

        public T[] ToArray()
        {
            return CopyElements(new T[Count]);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int currentIndex = 0; currentIndex < Count; currentIndex++)
            {
                var index = (startIndex + currentIndex) % elements.Length;
                yield return elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }

        private void IncreaseSize()
        {
            elements = CopyElements(new T[elements.Length * 2]);

            startIndex = 0;
            endIndex = Count;
        }

        private T[] CopyElements(T[] resultArr)
        {
            for (int currentIndex = 0; currentIndex < Count; currentIndex++)
            {
                resultArr[currentIndex] = elements[(startIndex + currentIndex) % elements.Length];
            }

            return resultArr;
        }
    }
}
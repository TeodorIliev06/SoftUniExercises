namespace _03.MaxHeap
{
    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }
        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(Size - 1);
        }

        public T ExtractMax()
        {
            CheckIfEmpty();

            var element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            CheckIfEmpty();

            return this.elements[0];
        }

        private void CheckIfEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            //We use IsGreater() with reverse logic -> IsLesser()
            while (IsIndexValid(biggerChildIndex) && this.IsLesser(index, biggerChildIndex))
            {
                this.Swap(biggerChildIndex, index);

                index = biggerChildIndex;
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if (IsIndexValid(rightChildIndex))
            {
                if (this.IsGreater(leftChildIndex, rightChildIndex))
                {
                    return leftChildIndex;
                }

                return rightChildIndex;
            }

            if (IsIndexValid(leftChildIndex))
            {
                return rightChildIndex;
            }

            return -1;
        }

        private void Swap(int index, int parentIndex)
        {
            (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.Size;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private bool IsLesser(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}

using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(Size - 1);
        }

        public T ExtractMin()
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

        protected void HeapifyUp(int index)
        {
            var parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.IsLesser(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        protected void HeapifyDown(int index)
        {
            var lesserChildIndex = this.GetLesserChildIndex(index);

            while (IsIndexValid(lesserChildIndex) && this.IsGreater(index, lesserChildIndex))
            {
                this.Swap(lesserChildIndex, index);

                index = lesserChildIndex;
                lesserChildIndex = this.GetLesserChildIndex(index);
            }
        }

        private int GetLesserChildIndex(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if (IsIndexValid(rightChildIndex))
            {
                if (this.IsLesser(leftChildIndex, rightChildIndex))
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

        private bool IsGreater(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) > 0;
        }

        private bool IsLesser(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.Size;
        }

        protected virtual void Swap(int index, int parentIndex)
        {
            (this.elements[index], this.elements[parentIndex]) = (this.elements[parentIndex], this.elements[index]);
        }

        protected void CheckIfEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}

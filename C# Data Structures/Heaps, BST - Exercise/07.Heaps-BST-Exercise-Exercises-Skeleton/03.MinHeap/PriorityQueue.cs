using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class PriorityQueue<T> : MinHeap<T> where T : IComparable<T>
    {
        private Dictionary<T, int> indices;
        public PriorityQueue()
        {
            this.elements = new List<T>();
            this.indices = new Dictionary<T, int>();
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);
            this.indices.Add(element, this.Size - 1);
            base.HeapifyUp(this.Size - 1);
            this.UpdateIndices();
        }

        public T Dequeue()
        {
            CheckIfEmpty();

            var element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            this.indices.Remove(element);

            base.HeapifyDown(0);
            this.UpdateIndices();

            return element;
        }

        public void DecreaseKey(T key)
        {
            base.HeapifyUp(this.indices[key]);
        }

        public void DecreaseKey(T key, T newKey)
        {
            //We swap the values in the dictionary and then promote the new element if necessary
            var oldIndex = this.indices[key];
            this.elements[oldIndex] = newKey;
            this.indices.Remove(key);
            this.indices.Add(newKey, oldIndex);

            base.HeapifyUp(oldIndex);
        }

        protected override void Swap(int index, int parentIndex)
        {
            base.Swap(index, parentIndex);

            this.indices[this.elements[index]] = index;
            this.indices[this.elements[parentIndex]] = parentIndex;
        }

        private void UpdateIndices()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                this.indices[this.elements[i]] = i;
            }
        }
    }
}

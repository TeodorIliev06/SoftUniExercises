namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }

            public Node(T value, Node next) : this(value)
            {
                Next = next;
            }
        }
        private Node head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currHead = head;
            while (currHead != null)
            {
                if (currHead.Value.Equals(item))
                {
                    return true;
                }

                currHead = currHead.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            CheckIfEmpty();

            var oldHead = this.head;
            this.head = oldHead.Next;


            Count--;
            return oldHead.Value;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }

            Count++;
        }

        public T Peek()
        {
            CheckIfEmpty();

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIfEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }
    }
}
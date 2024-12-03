namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            var newNode = new Node(item, this.head);

            head = newNode;
            Count++;
        }

        public void AddLast(T item)
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

        public T GetFirst()
        {
            CheckIfEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            CheckIfEmpty();

            var node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Value;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            var oldHead = this.head;
            head = oldHead.Next;

            Count--;
            return oldHead.Value;
        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            var node = this.head;
            Node last = null;

            //If we have only 1 element in the collection
            if (node.Next == null)
            {
                last = this.head;
                this.head = null;
            }
            else
            {
                while (node != null)
                {
                    //If we have 1+ elements in the list
                    if (node.Next.Next == null)
                    {
                        last = node.Next;
                        node.Next = null;
                        break;
                    }

                    node = node.Next;
                }
            }

            Count--;
            return last.Value;
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
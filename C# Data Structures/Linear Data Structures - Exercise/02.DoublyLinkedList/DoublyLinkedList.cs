namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public T GetFirst()
        {
            CheckCollection_Empty();

            return head.Value;
        }

        public T GetLast()
        {
            CheckCollection_Empty();

            return tail.Value;
        }

        public T RemoveFirst()
        {
            CheckCollection_Empty();

            var currentHead = head;

            if (head.Next == null)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }

            Count--;
            return currentHead.Value;
        }

        public T RemoveLast()
        {
            CheckCollection_Empty();

            var currentTail = tail;

            if (head.Next == null)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }

            Count--;
            return currentTail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckCollection_Empty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }
    }
}
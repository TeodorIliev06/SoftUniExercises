﻿namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var newHead = new Node<T>(element);

            if (Count == 0)
            {
                head = tail = newHead;
            }
            else
            {
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            var newTail = new Node<T>(element);

            if (Count == 0)
            {
                head = tail = newTail;
            }
            else
            {
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();

            var firstElement = head.Value;

            head = head.Next;

            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return firstElement;
        }


        public T RemoveLast()
        {
            CheckIfEmpty();

            var lastElement = tail.Value;

            tail = tail.Previous;

            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var current = head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var node = head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }
        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }
    }
}
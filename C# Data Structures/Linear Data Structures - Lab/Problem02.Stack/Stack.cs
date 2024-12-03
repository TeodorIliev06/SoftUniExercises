namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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
        private Node top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currTop = top;
            while (currTop != null)
            {
                if (currTop.Value.Equals(item))
                {
                    return true;
                }

                currTop = currTop.Next;
            }

            return false;
        }

        public T Peek()
        {
            CheckIfEmpty();

            return this.top.Value;
        }

        public T Pop()
        {
            CheckIfEmpty();

            var oldTopValue = this.top.Value;

            var newTop = this.top.Next;

            this.top.Next = null;

            this.top = newTop;
            this.Count--;

            return oldTopValue;
        }

        public void Push(T item)
        {
            var newNode = new Node(item, this.top);

            this.top = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckIfEmpty()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }
    }
}
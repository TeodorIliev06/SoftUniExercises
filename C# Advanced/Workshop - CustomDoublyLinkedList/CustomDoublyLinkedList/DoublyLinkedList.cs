namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode Previous { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;
            head = head.Next;

            if (head is not null)
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

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = tail.Value;
            tail = tail.Previous;

            if (tail is not null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return firstElement;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = head;

            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            var currNode = head;

            while (currNode != null)
            {
                array[counter] = currNode.Value;
                currNode = currNode.Next;
                counter++;
            }

            return array;
        }
    }
}

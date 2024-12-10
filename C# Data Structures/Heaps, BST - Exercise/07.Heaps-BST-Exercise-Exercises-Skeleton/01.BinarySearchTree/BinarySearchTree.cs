namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Count { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            this.CheckIfNullAndThrowException(this.root);

            this.root = this.Delete(element, this.root);
        }

        public void DeleteMax()
        {
            this.CheckIfNullAndThrowException(this.root);

            this.root = this.DeleteMax(this.root);
        }

        public void DeleteMin()
        {
            this.CheckIfNullAndThrowException(this.root);

            this.root = this.DeleteMin(this.root);
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        public int Rank(T element)
        {
            return this.Rank(element, this.root);
        }

        public T Select(int rank)
        {
            var node = this.Select(this.root, rank);
            this.CheckIfNullAndThrowException(node);

            return node.Value;
        }

        public T Ceiling(T element)
        {
            //We search for the node that has one more smaller element than the given one (round up to the next)
            return this.Select(this.Rank(element) + 1);
        }

        public T Floor(T element)
        {
            //Reverse logic for Ceiling()
            return this.Select(this.Rank(element) - 1);
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var collection = new Queue<T>();
            this.Range(this.root, startRange, endRange, collection);

            return collection;
        }

        private int Rank(T element, Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Rank(element, node.Left);
            }

            //If we go right we return the parent, the left child count and then find the rank of the right child
            if (element.CompareTo(node.Value) > 0)
            {
                return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
            }

            return this.Count(node.Left);
        }

        private Node Select(Node node, int rank)
        {
            if (node == null)
            {
                return null;
            }

            int leftCount = this.Count(node.Left);

            if (leftCount == rank)
            {
                return node;
            }

            if (leftCount > rank)
            {
                return this.Select(node.Left, rank);
            }

            //We go right after we've gone left once and search for smaller elements than the current one (which is node.Right)
            //We need to take the parent in the selection as well
            return this.Select(node.Right, rank - (leftCount + 1));
        }

        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + node.Count;

            //Recursive variant
            //return 1 + this.Count(node.Left) + this.Count(node.Right);
        }

        private Node Delete(T element, Node node)
        {
            if (node == null)
            {
                return null;
            }

            int compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                node.Left = this.Delete(element, node.Left);
            }

            else if (compare > 0)
            {
                node.Right = this.Delete(element, node.Right);
            }

            //When we find the searched element we check if there are no left or right children.
            //If there are - we simply replace with the other child
            //If there aren't - we find the min element in the subtree and replace it with the parent
            else
            {
                if (node.Left == null)
                {
                    return node.Right;
                }

                if (node.Right == null)
                {
                    return node.Left;
                }

                var temp = node;
                node = this.FindMin(temp.Right);
                node = this.DeleteMin(temp.Right);
                node.Left = temp.Left;
            }

            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        private Node FindMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            return this.FindMin(node.Left);
        }

        private Node DeleteMin(Node node)
        {
            //There is no left child of the min node. If there is no right child as well we set the value to null anyway.
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        private Node DeleteMax(Node node)
        {
            //Reverse logic for DeleteMin()
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

            return node;
        }

        private void Range(Node node, T startRange, T endRange, Queue<T> queue)
        {
            if (node == null)
            {
                return;
            }

            bool nodeInLowerRange = startRange.CompareTo(node.Value) < 0;
            bool nodeInUpperRange = endRange.CompareTo(node.Value) > 0;

            if (nodeInLowerRange)
            {
                this.Range(node.Left, startRange, endRange, queue);
            }

            //If the node is in the range - we add it
            if (startRange.CompareTo(node.Value) <= 0 &&
                endRange.CompareTo(node.Value) >= 0)
            {
                queue.Enqueue(node.Value);
            }

            if (nodeInUpperRange)
            {
                this.Range(node.Right, startRange, endRange, queue);
            }
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private void CheckIfNullAndThrowException(Node node)
        {
            if (node == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}

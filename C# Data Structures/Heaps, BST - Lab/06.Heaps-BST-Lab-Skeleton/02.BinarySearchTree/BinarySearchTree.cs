﻿namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;
        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            //We use pre-order so as not to "break" the structure of the bst
            this.PreOrderCopy(node);
        }

        public bool Contains(T element)
        {
            return this.FindNode(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = this.FindNode(element);

            if (node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.Right);
        }

        private Node Insert(T element, Node node)
        {
            //We traverse recursively, when element is < we go left and when > we go right
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

            return node;
        }

        private Node FindNode(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
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
    }
}

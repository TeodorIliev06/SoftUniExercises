﻿using System.Linq;

namespace _05.TopView
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var dict = new Dictionary<int, (T nodeValue, int nodeLevel)>();
            this.TopView(this, 0, 0, dict);

            return dict.Values.Select(x => x.nodeValue).ToList();
        }

        private void TopView(BinaryTree<T> node, int distance, int level, Dictionary<int, (T nodeValue, int nodeLevel)> dict)
        {
            if (node == null)
            {
                return;
            }

            //If we find a leaf that is distanced from the root and is on a higher level
            //than another leaf with the same distance - we override the value (and level)
            //Pre-order traversal
            if (dict.ContainsKey(distance))
            {
                if (dict[distance].nodeLevel > level)
                {
                    dict[distance] = (node.Value, level);
                }
            }
            else
            {
                dict.Add(distance, (node.Value, level));
            }

            this.TopView(node.LeftChild, distance - 1, level + 1, dict);
            this.TopView(node.RightChild, distance + 1, level + 1, dict);
        }
    }
}

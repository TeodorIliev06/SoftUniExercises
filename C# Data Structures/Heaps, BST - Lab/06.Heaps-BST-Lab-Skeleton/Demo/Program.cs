using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Threading.Channels;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(4);
            tree.Insert(16);

            tree.EachInOrder(Console.WriteLine);

            Console.WriteLine(tree.Contains(4));

            var heap = new MaxHeap<int>();
            heap.Add(4);
            heap.Add(9);
            heap.Add(5);
            heap.Add(1);
            heap.Add(9);

            Console.WriteLine(heap.ExtractMax());
        }
    }
}
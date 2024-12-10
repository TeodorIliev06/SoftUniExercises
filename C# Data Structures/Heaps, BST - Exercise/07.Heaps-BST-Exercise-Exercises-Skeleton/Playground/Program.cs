using System;
using _02.BinarySearchTree;
using _03.MinHeap;
using _04.CookiesProblem;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bst = new BinarySearchTree<int>();
            //bst.Insert(10);
            //bst.Insert(5);
            //bst.Insert(3);
            //bst.Insert(1);
            //bst.Insert(4);
            //bst.Insert(8);
            //bst.Insert(9);
            //bst.Insert(37);
            //bst.Insert(39);
            //bst.Insert(45);
            //bst.Insert(6);

            //int floor = bst.Floor(37);
            //Console.WriteLine(floor);

            //bst.Delete(5);
            //bst.EachInOrder(Console.WriteLine);

            //var priorityQueue = new PriorityQueue<int>();
            //priorityQueue.Enqueue(10);
            //priorityQueue.Enqueue(5);
            //priorityQueue.Enqueue(3);
            //priorityQueue.Enqueue(1);
            //priorityQueue.Enqueue(4);
            //priorityQueue.Enqueue(8);

            var cookie = new CookiesProblem();
            Console.WriteLine(cookie.Solve(7, new int[] {1, 1, 1}));
        }
    }
}

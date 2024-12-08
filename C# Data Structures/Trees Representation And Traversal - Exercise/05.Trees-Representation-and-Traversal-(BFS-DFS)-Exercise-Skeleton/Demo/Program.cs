using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    using Tree;

    class Program
    {
        private const int pathsGivenSum = 27;
        private const int subtreesGivenSum = 43;
        static void Main(string[] args)
        {
            var input = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };

            var treeFactory = new TreeFactory();
            var tree = treeFactory.CreateTreeFromStrings(input);

            //Console.WriteLine(tree.GetAsString());
            //Console.WriteLine(String.Join(' ', tree.GetLeafKeys()));
            //Console.WriteLine(String.Join(' ', tree.GetMiddleKeys()));

            //Console.WriteLine(tree.GetDeepestNode().Key);
            //Console.WriteLine(String.Join(' ', tree.GetLongestPath()));

            //Console.WriteLine(String.Join(Environment.NewLine, tree.PathsWithGivenSum(pathsGivenSum)
            //    .Select(x => String.Join(' ', x))));
            Console.WriteLine(String.Join(Environment.NewLine, tree.SubtreesWithGivenSum(subtreesGivenSum)
                .Select(x => String.Join(' ', GetKeysWithBfs(x)))));
        }

        private static IEnumerable<int> GetKeysWithBfs(Tree<int> node)
        {
            var result = new List<int>();
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.Key);

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}

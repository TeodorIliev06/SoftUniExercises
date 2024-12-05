using System;

namespace Tree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var subtree = new Tree<int>(36,
                new Tree<int>(42),
                new Tree<int>(3)
                        );
            var tree = new Tree<int>(34,
                subtree,
                            new Tree<int>(1,
                                new Tree<int>(2)
                                ),
                            new Tree<int>(103)
                        );

            //Console.WriteLine(string.Join(", ", tree.OrderBfs()));
            //Console.WriteLine(string.Join(", ", tree.OrderDfs()));

            //subtree.AddChild(42, new Tree<int>(2));
            //Console.WriteLine(string.Join(", ", subtree.OrderBfs()));

            //tree.RemoveNode(42);
            //Console.WriteLine(string.Join(", ", tree.OrderBfs()));

            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
            tree.Swap(36, 1);
            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
        }
    }
}

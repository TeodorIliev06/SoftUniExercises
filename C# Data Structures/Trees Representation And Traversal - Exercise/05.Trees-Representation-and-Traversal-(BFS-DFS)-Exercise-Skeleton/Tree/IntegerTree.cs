namespace Tree
{
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            int currentSum = this.Key;
            this.Dfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<int>> SubtreesWithGivenSum(int sum)
        {
            return SubTreesWithGivenSum(sum);
        }

        private List<Tree<int>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(this);

            //Iterating through each subtree and checking if its total sum matches the expected sum
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var subtreeSum = GetSubtreeSum(node);

                if (subtreeSum == sum)
                {
                    result.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private int GetSubtreeSum(Tree<int> node)
        {
            int sum = node.Key;
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var child in currentNode.Children)
                {
                    sum += child.Key;
                    queue.Enqueue(child);
                }
            }

            return sum;
        }

        private void Dfs(Tree<int> node, List<List<int>> result, LinkedList<int> currentPath,
            ref int currentSum, int expectedSum)
        {
            foreach (var child in node.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, result, currentPath, ref currentSum, expectedSum);
            }

            //LinkedList uses references, so we have to copy it using a new collection
            if (currentSum == expectedSum)
            {
                result.Add(new List<int>(currentPath));
            }

            currentSum -= node.Key;
            currentPath.RemoveLast();
        }
    }
}

using System.Linq;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();
            this.DfsAsString(sb, this, 0);
            return sb.ToString().Trim();
        }

        public List<T> GetMiddleKeys()
        {
            return GetKeysWithBfs(node => node.children.Count > 0 && node.Parent != null)
                .Select(tree => tree.Key).ToList();
        }

        public List<T> GetLeafKeys()
        {
            return GetKeysWithBfs(node => node.children.Count == 0)
                .Select(tree => tree.Key).ToList();
        }

        public Tree<T> GetDeepestNode()
        {
            Tree<T> deepestNode = default;
            var maxDepth = 0;

            var leafs = this.GetKeysWithBfs(node => node.children.Count == 0);
            foreach (var leaf in leafs)
            {
                var depth = this.GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestNode();
            var currentNode = deepestNode;
            var path = new Stack<T>();

            while (currentNode != null)
            {
                path.Push(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            return new List<T>(path);
        }

        private int GetDepth(Tree<T> leaf)
        {
            var depth = 0;
            var node = leaf;

            while (node.Parent != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int depth)
        {
            sb.Append(' ', depth)
                .AppendLine(tree.Key.ToString());

            //Recursively add children in front
            foreach (var child in tree.children)
            {
                this.DfsAsString(sb, child, depth + 2);
            }
        }

        private List<Tree<T>> GetKeysWithBfs(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (predicate.Invoke(node))
                {
                    result.Add(node);
                }

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}

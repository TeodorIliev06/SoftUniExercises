namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private Tree<T> parent;
        private T value;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBfs(parentKey);
            CheckEmptyNode(parentNode);

            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();
            queue.Enqueue(this);

            //Iterating through tree by levels
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var list = new List<T>();
            this.Dfs(this, list);
            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            var node = this.FindNodeWithBfs(nodeKey);
            CheckEmptyNode(node);

            //If node is root - exception
            var parentNode = node.parent;
            CheckIfRoot(parentNode);

            //Remove the descendants and then the node itself
            //foreach (var child in node.children)
            //{
            //    child.parent = null;
            //}
            //node.children.Clear();

            //Remove the node alongside its descendants (preferable)
            parentNode.children.Remove(node);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWithDfs(firstKey);
            var secondNode = this.FindNodeWithDfs(secondKey);

            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            var firstParentNode = firstNode.parent;
            CheckIfRoot(firstParentNode);
            var secondParentNode = secondNode.parent;
            CheckIfRoot(secondParentNode);

            /*Possible cases: swap internal node with an internal
                              swap leaf node with another leaf
                              swap internal with a leaf (we leave the leaf only)
            */
            var indexOfFirstNode = firstParentNode.children.IndexOf(firstNode);
            var indexOfSecondNode = secondParentNode.children.IndexOf(secondNode);

            firstParentNode.children[indexOfFirstNode] = secondNode;
            secondNode.parent = firstParentNode;

            secondParentNode.children[indexOfSecondNode] = firstNode;
            firstNode.parent = secondParentNode;
        }

        private IEnumerable<T> OrderDfsWithStack()
        {
            var stack = new Stack<Tree<T>>();
            var result = new Stack<T>();
            stack.Push(this);

            //Iterating through tree in depth
            while (stack.Count > 0)
            {
                var node = stack.Pop();

                //Get the final descendant and add it in the result stack then go up again
                foreach (var child in node.children)
                {
                    stack.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        private void Dfs(Tree<T> node, ICollection<T> result)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }

            result.Add(node.value);
        }

        private static void CheckEmptyNode(Tree<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException();
            }
        }

        private static void CheckIfRoot(Tree<T> parentNode)
        {
            if (parentNode is null)
            {
                throw new ArgumentException();
            }
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            //Iterating through tree by levels
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindNodeWithDfs(T parentKey)
        {
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            //Iterating through tree in depth
            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node.value.Equals(parentKey))
                {
                    return node;
                }

                //Get the final descendant and add it in the result stack then go up again
                foreach (var child in node.children)
                {
                    stack.Push(child);
                }
            }

            return null;
        }
    }
}

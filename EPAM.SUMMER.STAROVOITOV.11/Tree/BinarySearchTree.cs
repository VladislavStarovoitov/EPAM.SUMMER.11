using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public sealed class BinarySearchTree<T> : IEnumerable<T>
    {
        private IComparer<T> _comparer;
        private TreeNode _root;

        public IComparer<T> Comprer
        {
            get
            {
                return _comparer;
            }
            set
            {
                if (ReferenceEquals(value, null))
                    _comparer = Comparer<T>.Default;
                else
                    _comparer = value;
            }
        }

        public BinarySearchTree(IComparer<T> comparer = null)
        {
            Comprer = comparer;
        }

        public BinarySearchTree(IComparer<T> comparer, params T[] items) : this(comparer)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public BinarySearchTree(IComparer<T> comparer, IEnumerable<T> items) : this(comparer)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            if (ReferenceEquals(_root, null))
            {
                _root = new TreeNode(item, null);
            }
            else
            {
                Add(item, _root, null);
            }
        }

        public bool Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            return Remove(item, _root);
        }

        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();

            return Contains(item, _root);
        }

        public IEnumerable<T> InfixTraverse() => InfixTraverse(_root);

        public IEnumerable<T> PrefixTraverse() => PrefixTraverse(_root);

        public IEnumerable<T> PostfixTraverse() => PostfixTraverse(_root);        

        public IEnumerator<T> GetEnumerator() => InfixTraverse(_root).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region TRAVERSE
        private IEnumerable<T> PostfixTraverse(TreeNode node)
        {
            if (node == null) yield break;
            foreach (var item in PostfixTraverse(node.Left))
            {
                yield return item;
            }

            foreach (var item in PostfixTraverse(node.Right))
            {
                yield return item;
            }

            yield return node.Item;
        }

        private IEnumerable<T> PrefixTraverse(TreeNode node)
        {
            if (node == null) yield break;
            yield return node.Item;

            foreach (var item in PrefixTraverse(node.Left))
            {
                yield return item;
            }

            foreach (var item in PrefixTraverse(node.Right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> InfixTraverse(TreeNode node)
        {
            if (node == null) yield break;
            foreach (var item in InfixTraverse(node.Left))
            {
                yield return item;
            }

            yield return node.Item;

            foreach (var item in InfixTraverse(node.Right))
            {
                yield return item;
            }
        }
        #endregion

        private bool Contains(T iten, TreeNode node)
        {
            if (ReferenceEquals(node, null))
                return false;

            if (_comparer.Compare(iten, node.Item) > 0)
                return Contains(iten, node.Right);
            if (_comparer.Compare(iten, node.Item) < 0)
                return Contains(iten, node.Left);
            return true;
        }

        private bool Remove(T item, TreeNode node)
        {
            if (ReferenceEquals(node, null))
                return false;

            if (_comparer.Compare(item, node.Item) > 0) 
                return Remove(item, node.Right);
            if (_comparer.Compare(item, node.Item) < 0)
                return Remove(item, node.Left);

            TreeNode temp = null;            
            if (ReferenceEquals(node.Right, null))
                temp = node.Left;
            else
            {
                if (ReferenceEquals(node.Left, null))
                    temp = node.Right;
                else
                {
                    TreeNode rightestNodeInLeft = node.Left;
                    temp = rightestNodeInLeft;
                    while (!ReferenceEquals(rightestNodeInLeft.Right, null))
                    {
                        rightestNodeInLeft = rightestNodeInLeft.Right;
                        temp = rightestNodeInLeft;
                    }
                    if (!ReferenceEquals(temp, node.Left))
                    {
                        temp.Parent.Right = temp.Left;
                    }
                    else
                        node.Left = temp.Left;
                    if (!ReferenceEquals(temp.Left, null))
                        temp.Left.Parent = temp.Parent;
                    node.Item = temp.Item;
                    return true;
                }
            }
            if (!ReferenceEquals(node.Parent, null))
            {
                if (_comparer.Compare(item, node.Parent.Item) > 0)
                    node.Parent.Right = temp;
                else
                    node.Parent.Left = temp;
            }
            else
                _root = temp;
            if (!ReferenceEquals(temp, null))
            {
                temp.Parent = node.Parent;
            }
            return true; 
        }

        private void Add(T item, TreeNode node, TreeNode parent)
        {
            if (ReferenceEquals(node, null))
            {
                var newNode = new TreeNode(item, parent);
                if (_comparer.Compare(item, parent.Item) > 0)
                    parent.Right = newNode;
                if (_comparer.Compare(item, parent.Item) < 0)
                    parent.Left = newNode;
            }
            else
                if (_comparer.Compare(item, node.Item) > 0)
                    Add(item, node.Right, node);
                else
                    Add(item, node.Left, node);                    
        }

        private sealed class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode Parent { get; set; }

            public T Item { get; set; }            

            public TreeNode(T item, TreeNode parent)
            {
                Item = item;
                Parent = parent;
            }
        }  
    }
}

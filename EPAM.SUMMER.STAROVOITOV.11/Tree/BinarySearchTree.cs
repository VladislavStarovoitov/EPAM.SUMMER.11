using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public sealed class BinarySearchTree<T>
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

        public BinarySearchTree(IEnumerable<T> items, IComparer<T> comparer) : this(comparer)
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

        }

        private bool Remove(T item, TreeNode node)
        {
            if (!ReferenceEquals(node, null))
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
                if (ReferenceEquals(node.Right, null))
                    temp = node.Left;
                else
                {
                    TreeNode rightestNodeInLeft = node.Left;
                    temp = rightestNodeInLeft;
                    while (ReferenceEquals(rightestNodeInLeft.Right, null))
                    {
                        temp = rightestNodeInLeft;
                        rightestNodeInLeft = rightestNodeInLeft.Right;
                    }
                    if (!ReferenceEquals(temp, node.Left))
                    {
                        temp.Parent.Right = temp.Left;
                    }
                    else
                        node.Left = temp.Left;
                }
            }
            temp.Left = node.Left;
            temp.Right = node.Right;
            if (_comparer.Compare(item, node.Parent.Item) > 0)
                node.Parent.Right = temp;
            else
                node.Parent.Left = temp;
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

            public T Item { get; }            

            public TreeNode(T item, TreeNode parent)
            {
                Item = item;
                Parent = parent;
            }
        }  
    }
}

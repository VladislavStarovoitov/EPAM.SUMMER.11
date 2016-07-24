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
                Add(item, _root);
            }
        }

        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();
            Add(item, _root);
        }

        private void Add(T item, TreeNode node)
        {
            if (ReferenceEquals(node, null))
                node = new TreeNode(item);
            else
                if (_comparer.Compare(item, node.Item) > 0)
                    Add(item, node.Right);
                else
                    Add(item, node.Left);                    
        }

        private sealed class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public T Item { get; }            

            public TreeNode(T item)
            {
                Item = item;
            }
        }  
    }
}

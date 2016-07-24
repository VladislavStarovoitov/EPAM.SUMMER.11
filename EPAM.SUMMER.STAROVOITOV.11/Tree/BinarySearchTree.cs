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

        private sealed class TreeNode
        {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public T Item { get; }            

            TreeNode(T item)
            {
                Item = item;
            }
        }  
    }
}

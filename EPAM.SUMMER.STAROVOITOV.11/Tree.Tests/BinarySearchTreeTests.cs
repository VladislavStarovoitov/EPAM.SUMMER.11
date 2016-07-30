using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using NUnit.Framework;

namespace Tree.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void AddItem()
        {
            var tree = new BinarySearchTree<int>(null, 97, 342, 800, 360, 123, 230, 59, 20, 64, 63, 80, 82);

            CollectionAssert.AreEqual(postfix, tree.PostfixTraverse());
        }

        public int[] infix = new int[] { 20, 59, 63, 64, 80, 82, 97, 123, 230, 342, 360, 800 };
        public int[] prefix = new int[] { 97, 59, 20, 64, 63, 80, 82, 342, 123, 230, 800, 360 };
        public int[] postfix = new int[] { 20, 63, 82, 80, 64, 59, 230, 123, 360, 800, 342, 97 };
    }
}

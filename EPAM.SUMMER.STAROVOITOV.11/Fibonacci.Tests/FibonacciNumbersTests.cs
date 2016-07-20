using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Fibonacci.FibonacciNumbers;

namespace Fibonacci.Tests
{
    [TestFixture]
    public class FibonacciNumbersTests
    {
        [TestCase(6, new int[6] { 0, 1, 1, 2, 3, 5})]
        public void GetNumbersTest(int count, IEnumerable<int> expected)
        {
            var result = GetNumbers(count);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(-1, new int[6] { 0, 1, 1, 2, 3, 5 })]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeExceptionExpected(int count, IEnumerable<int> expected)
        {
            var result = GetNumbers(count);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}

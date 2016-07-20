using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    /// <summary>
    /// Contains method fot getting Fibonacci numbers.
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Returns Fibonacci numbers.
        /// </summary>
        /// <param name="count">Count of returned numbers.</param>
        /// <returns>A sequence that contains Fibonacci numbers.</returns>
        public static IEnumerable<int> GetNumbers(int count)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException();
            int previousNumber = 0;
            int currentNumber = 1;
            yield return previousNumber;
           
            for (int i = 0; i < count - 1; i++)
            {
                yield return currentNumber;
                int temp = currentNumber;
                currentNumber = previousNumber + currentNumber;
                previousNumber = temp;
            }
        }
    }
}

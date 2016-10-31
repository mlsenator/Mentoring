using System;
using System.Numerics;
using System.Threading;

namespace Fibonacci
{
    public class FibonacciGenerator : IFibonacciGenerator
    {
        public BigInteger GetNumber(BigInteger index)
        {
            if (index == 0)
            {
                return BigInteger.Zero;
            }

            if (index == 1 || index == 2)
            {
                return BigInteger.One;
            }

            var previous = BigInteger.One;
            var current = BigInteger.One;
            for (int i = 2; i <= index; i++)
            {
                var next = previous + current;
                previous = current;
                current = next;
            }

            Thread.Sleep(2000);
            return current;
        }
    }
}

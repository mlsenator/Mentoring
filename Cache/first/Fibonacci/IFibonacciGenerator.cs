using System.Numerics;

namespace Fibonacci
{
    public interface IFibonacciGenerator
    {
        BigInteger GetNumber(BigInteger index);
    }
}
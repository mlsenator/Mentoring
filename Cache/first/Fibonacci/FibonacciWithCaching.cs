using System;
using System.Numerics;
using Fibonacci.Cache;

namespace Fibonacci
{
    public class FibonacciWithCaching
    {
        private readonly IBigIntegerCache _cache;
        private readonly IFibonacciGenerator _generator;

        public FibonacciWithCaching(IBigIntegerCache cache, IFibonacciGenerator generator)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }

            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            _cache = cache;
            _generator = generator;
        }

        public BigInteger GetNumber(BigInteger index)
        {
            var result = _cache.Get(index.ToString());
            if (!result.HasValue)
            {
                result = _generator.GetNumber(index);
                _cache.Set(index.ToString(), result.Value);
            }

            return result.Value;
        }


    }
}

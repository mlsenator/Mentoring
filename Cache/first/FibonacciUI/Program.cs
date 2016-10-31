using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using Fibonacci.Cache;

namespace FibonacciUI
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstVersionMethod();
            //SecondVersionMethod();
        }

        public static void FirstVersionMethod()
        {
            var cache = new InMemoryCache();
            var fibonacci = new FibonacciWithCaching(cache, new FibonacciGenerator());
            while (true)
            {
                Console.Write("Enter fibonacci number index: ");
                var index = BigInteger.Parse(Console.ReadLine());
                var sw = new Stopwatch();
                sw.Restart();
                var result = fibonacci.GetNumber(index);
                sw.Stop();
                Console.WriteLine($"Finished in {sw.Elapsed.TotalMilliseconds} ms. Number: - {result}");
            }
        }

        public static void SecondVersionMethod()
        {
            using (var cache = new OutOfMemoryCache("localhost,allowAdmin=true")) // Redis server in packages folder
            {
                var fibonacci = new FibonacciWithCaching(cache, new FibonacciGenerator());
                while (true)
                {
                    Console.Write("Enter fibonacci number index: ");
                    var index = BigInteger.Parse(Console.ReadLine());
                    var sw = new Stopwatch();
                    sw.Restart();
                    var result = fibonacci.GetNumber(index);
                    sw.Stop();
                    Console.WriteLine($"Finished in {sw.Elapsed.TotalMilliseconds} ms. Number: - {result}");
                }
            }
        }
    }
}

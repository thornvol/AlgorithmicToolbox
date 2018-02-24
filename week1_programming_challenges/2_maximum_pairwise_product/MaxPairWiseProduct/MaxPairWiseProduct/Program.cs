using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxPairWiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            // From Console
            var n = Console.ReadLine();
            var a_temp = Console.ReadLine().Split(' ');
            var a = Array.ConvertAll(a_temp, Int64.Parse);
            //var product = MaxPairwiseProductNaive(a);
            //var product = MaxPairwiseProductFast(a);
            var product = MaxPairwiseProductBySorting(a);
            Console.WriteLine(product);

            // Stress Test
            //StressTest(10, 100000);

            // Pause
            //Console.ReadLine();
        }

        static long MaxPairwiseProductNaive(long[] a)
        {
            long product = 0;
            for (var i = 0; i < a.Length; i++)
            {
                for (var j = i + 1; j < a.Length; j++)
                {
                    if (i != j)
                    {
                        var temp = a[i] * a[j];
                        if (product < temp)
                        {
                            product = temp;
                        }
                    }
                }
            }
            return product;
        }

        static long MaxPairwiseProductFast(long[] a)
        {
            long product = 0;
            var firstIndex = 0;
            for (var i = 1; i < a.Length; i++)
            {
                if (a[i] > a[firstIndex])
                {
                    firstIndex = i;
                }
            }

            var secondIndex = 0;
            if (firstIndex == 0)
            {
                secondIndex = 1;
            }
            
            for (var i = 1; i < a.Length; i++)
            {
                if (i != firstIndex && a[i] > a[secondIndex])
                {
                    secondIndex = i;
                }
            }

            product = a[firstIndex] * a[secondIndex];

            return product;
        }

        static long MaxPairwiseProductBySorting(long[] a)
        {
            Array.Sort(a, new Comparison<long>((i,j) => j.CompareTo(i)));
            return a[0] * a[1];
        }

        static void StressTest(int N, int M)
        {
            while (true)
            {
                var random = new Random();
                var n = random.Next(2, N);
                var arr = new long[n];
                for (var i = 0; i < n; i++)
                {
                    arr[i] = random.Next(0, M);
                    Console.WriteLine($"{Print(arr)}");

                    //var result1 = MaxPairwiseProductNaive(arr);
                    var result1 = MaxPairwiseProductBySorting(arr);
                    var result2 = MaxPairwiseProductFast(arr);

                    if (result1 == result2)
                    {
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        Console.WriteLine($"Wrong answer: {result1} {result2}");
                        return;
                    }
                }
            }
        }

        static string Print(long[] arr)
        {
            var aTemp = new string[arr.Length];
            var result = string.Join(" ", Array.ConvertAll(arr, a => a.ToString()));
            return result;
        }
    }
}

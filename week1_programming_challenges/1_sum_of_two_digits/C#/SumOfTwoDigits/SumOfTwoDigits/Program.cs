using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfTwoDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            if (input != null)
            {
                var values = input.Split(' ');
                var a = Convert.ToInt64(values[0]);
                var b = Convert.ToInt64(values[1]);
                var product = a + b;
                Console.Write(product);
            }
            
            //Console.ReadLine();
        }
    }
}

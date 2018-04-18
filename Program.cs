using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleDynamicProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle();
            var total = triangle.GetLargestSumOfTriangle();

            Console.WriteLine($"Max Total Sum = {total}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleDynamicProgram
{
   public class Triangle
   {
       private static readonly int[,] TriangleData;
       static Triangle()
        {
            string line; //one row in the triangle
            var lines = 0;
            var reader = new StreamReader(Environment.CurrentDirectory + "\\triangle.txt");
            while ((reader.ReadLine()) != null)
            {
                lines++;
            }

            TriangleData = new int[lines, lines];
            reader.BaseStream.Seek(0, SeekOrigin.Begin); // return pointer in the file to 0

            var counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                var tempSplit = line.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < tempSplit.Length; i++)
                {
                    TriangleData[counter, i] = int.Parse(tempSplit[i]);
                }
                counter++;
            }
            reader.Close();
        }

       public int Lines => TriangleData.GetLength(0);

        // Iam using Dynamic Programming concept to get the more accureate result
        // caring about performance timing and memory size
        // we follow this step
        // 1 - Tringle Top [i,j]
        // 2 - and get the Max between varoius possiple entities in the triangle in the last row
        // moving from j = 0 to j not get over i
        
       public int GetLargestSumOfTriangle()
       {
           var highest = 0;
            
           for (var i = Lines - 2; i >= 0; i--)
           {
               for (var j = 0; j <= i; j++)
               {
                   highest = TriangleData[i, j] + Math.Max(TriangleData[Lines - 1, j], TriangleData[Lines - 1 ,j + 1]);
               }
           }

           return highest;
       }
   }
}

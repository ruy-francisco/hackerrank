using System;
using System.Collections.Generic;
using System.IO;

namespace src
{
    public class Program
    {
        // static int twoStacks(int x, int[] a, int[] b) {
        //     int sum = 0;
        //     int removed = 0;

        //     int aIndex = 0;

        //     while (aIndex < a.Length && sum + a[aIndex] <= x)
        //     {
        //         sum += a[aIndex];
        //         aIndex++;
        //     }

        //     removed = aIndex;

        //     int bIndex = 0;

        //     while (bIndex < b.Length && aIndex > 0)
        //     {
        //         sum += b[bIndex];
        //         bIndex++;

        //         while (sum > x && aIndex > 0)
        //         {
        //             aIndex--;
        //             sum -= a[aIndex];
        //         }

        //         if (sum <= x && aIndex + bIndex > removed)
        //         {
        //             removed = aIndex + bIndex;
        //         }
        //     }                

        //     return removed;
        // }


        static int twoStacks(int x, int[] a, int[] b) {
            int sumA = 0;
            int aIndex = 0;
            int moved = 0;
            var usedFromA = new List<int>();
            
            while ((sumA + a[aIndex]) <= x)
            {
                usedFromA.Add(a[aIndex]);
                sumA += a[aIndex];
                moved++;
                aIndex++;
            }

            int sumB = 0;
            int bIndex = 0;

            while ((sumB + b[bIndex]) <= x)
            {
                if ((sumA + b[bIndex]) <= x)
                {
                    sumA += b[bIndex];
                    sumB += b[bIndex];
                    moved++;
                    bIndex++;
                    continue;
                }

                sumA += b[bIndex] - usedFromA[0];
                usedFromA.RemoveAt(0);
                sumB += b[bIndex];
                bIndex++;
            }

            return moved;
        }

        static void Main(string[] args) {
            TextWriter textWriter = new StreamWriter(@"./output/output.txt", false);


            System.Console.WriteLine("Set the number of games");
            int g = Convert.ToInt32(Console.ReadLine());

            for (int gItr = 0; gItr < g; gItr++) {
                System.Console.WriteLine(@"Set, separed by exactly one blank space, number of integers in stack A, number of integers in stack B and the sum max");

                string[] nmx = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmx[0]);
                int m = Convert.ToInt32(nmx[1]);
                int x = Convert.ToInt32(nmx[2]);
                
                System.Console.WriteLine("Set the numbers of stack A separed by exactly one blank space");
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

                System.Console.WriteLine("Set the numbers of stack B separed by exactly one blank space");
                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));

                int result = twoStacks(x, a, b);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

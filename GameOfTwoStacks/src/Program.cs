using System;
using System.Collections.Generic;
using System.IO;

namespace src
{
    public class Program
    {
        static int twoStacks(int x, int[] a, int[] b) {
           int sum = 0;
            int movedNumber = 0;
            int aIndex = 0;

            while (aIndex < a.Length && (sum + a[aIndex] <= x))
            {
                sum += a[aIndex];
                aIndex++;
            }

            movedNumber = aIndex;
            int bIndex = 0;

            while (bIndex < b.Length && aIndex >= 0)
            {
                sum += b[bIndex];
                bIndex++;

                while (sum > x && aIndex > 0)
                {
                    aIndex--;
                    sum -= a[aIndex];
                }

                if (sum <= x && aIndex + bIndex > movedNumber)
                {
                    movedNumber = aIndex + bIndex;
                }
            }
            return movedNumber;
        
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

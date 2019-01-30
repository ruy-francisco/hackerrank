using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            int g = 0;
            Console.WriteLine("Set the number of games (between 1 and 50)");
            while (g == 0 || g > 50)
            {
                g = Convert.ToInt32(Console.ReadLine());
            }

            for (int gItr = 0; gItr < g; gItr++) {
                Console.WriteLine(@"Set, separed by exactly one blank space, number of integers in stack A (between 1 and 100000), number of integers in stack B (between 1 and 100000) and the sum max");

                string[] nmx = Console.ReadLine().Split(' ');

                while (nmx.Length != 3)
                {
                    System.Console.WriteLine("Input in wrong format.");
                    nmx = null;
                    nmx = Console.ReadLine().Split(' ');
                }

                int n = Convert.ToInt32(nmx[0]);

                while (n < 1 || n > Math.Pow(10, 5))
                {
                    System.Console.WriteLine("Number of integers in stack A must to be between 1 and 100000. Set it again.");
                    n = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
                }

                int m = Convert.ToInt32(nmx[1]);

                while (m < 1 || m > Math.Pow(10, 5))
                {
                    System.Console.WriteLine("Number of integers in stack B must to be between 1 and 100000. Set it again.");
                    m = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
                }

                int x = Convert.ToInt32(nmx[2]);

                while (x < 1 || x > Math.Pow(10, 9))
                {
                    System.Console.WriteLine("Sum max must to be between 1 and 1 billion. Set it again.");
                    x = Convert.ToInt32(Convert.ToInt32(Console.ReadLine()));
                }
                
                System.Console.WriteLine("Set the numbers of stack A separed by exactly one blank space");
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

                while (a.Any(e => e > Math.Pow(10, 6)))
                {
                    System.Console.WriteLine("Every number in stack A must to be less than 1 million. Set it again.");
                    a = null;
                    a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                }

                System.Console.WriteLine("Set the numbers of stack B separed by exactly one blank space");
                int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));

                while (b.Any(e => e > Math.Pow(10, 6)))
                {
                    System.Console.WriteLine("Every number in stack B must to be less than 1 million. Set it again.");
                    b = null;
                    b = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                }

                int result = twoStacks(x, a, b);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

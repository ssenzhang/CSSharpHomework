using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ary = new int[200];
            int i, j;
            for (i = 2; i <= 100; i++)
                ary[i] = 1;
            for (i = 2; i <= 100; i++)
            {
                for (j = 2; (i * j) <= 100; j++)
                    ary[i * j] = 0;
            }
            for (i = 2; i <= 100; i++)
            {
                if (ary[i] == 1)
                    Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}

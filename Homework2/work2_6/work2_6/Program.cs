using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个整数:"); 
            int num = int.Parse(Console.ReadLine());
            int i = 0;

            if (num < 2)
                Console.Write("No prime factors");
            else
            {
                for (i = 2; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        isprime(i);
                    }
                }
            }

            Console.ReadKey();
        }
        public static void isprime(int x)
        {
            int j = 1;
            int flag = 0;
            for (j = 2; j < x; j++)
            {
                if (x % j == 0)
                {
                    flag = 1;
                    return;
                }
            }
            if (flag == 0)
                Console.Write(x + " ");
        }
    }
}

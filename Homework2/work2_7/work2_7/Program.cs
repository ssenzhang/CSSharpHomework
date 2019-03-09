using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int min, max;
            int n,i;
            int flag = 0;
            int sum = 0;
            float avr;
            Console.WriteLine("输入数据(空格隔开):");

            string input = Console.ReadLine();
            string[] num = input.Split(' ');

            max = int.Parse(num[0]);
            min = int.Parse(num[0]);
            n = num.Length;
            if (num.Length % 2 == 1)
            {
                n--;
                flag = 1;
            }
            for (i = 0; i < n; i += 2)
            {
                if (int.Parse(num[i]) > int.Parse(num[i + 1]))
                {
                    if (int.Parse(num[i]) > max)
                        max = int.Parse(num[i]);
                    else if (int.Parse(num[i + 1]) < min)
                        min = int.Parse(num[i + 1]);
                }
                else
                {
                    if (int.Parse(num[i + 1]) > max)
                        max = int.Parse(num[i + 1]);
                    else if (int.Parse(num[i]) < min)
                        min = int.Parse(num[i]);
                }
            }
            if (flag == 1)
            {
                if (max < int.Parse(num[num.Length - 1]))
                {
                    max = int.Parse(num[num.Length - 1]);
                }
                else if (min > int.Parse(num[num.Length - 1]))
                {
                    min = int.Parse(num[num.Length - 1]);
                }
            }

            for (i = 0; i < num.Length; i++)
                sum += int.Parse(num[i]);

            avr = (float)sum / num.Length;

            Console.WriteLine("Max:" + max);
            Console.WriteLine("Min:" + min);
            Console.WriteLine("Sum:" + sum);
            Console.WriteLine("Avr:" + Math.Round(avr,2));       

            Console.ReadKey();
        }
    }
}

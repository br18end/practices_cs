using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static int n, m, odds = 0, cont;
        static int[] some_data = new int[100];

        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            Thread t1 = new Thread(new ThreadStart(digits));
            Thread t2 = new Thread(new ThreadStart(nodds));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("Digits: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(some_data[i]+" ");
            }
            Console.WriteLine("\nOdds: "+odds);
        }
        public static void digits()
        {
            int aux, position = 0;
            for (int i = n; i <= m; i++)
            {
                aux = i;
                while (aux > 0)
                {
                    position = aux % 10;
                    some_data[position]++;
                    aux = aux / 10;
                }
            }
        }
        public static void nodds()
        {
            for (int i = n; i <= m; i++)
            {
                cont = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i%j == 0)
                    {
                       cont++;
                    }
                }
                if (cont == 2)
                {
                    odds++;
                }
            }
        }
    }
}
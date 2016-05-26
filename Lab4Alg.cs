using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Lab4Alg
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            List<int> l = new List<int>();
            for (int i = 0; i < s.Split(',').Length; i++)
            {
                l.Add(int.Parse(s.Split(',')[i]));
            }
            Money(n, l);
        }
        public static void Money(int n, List<int> l)
        {
            int[] cents = new int[6] { 1, 2, 5, 10, 25, 50 };
            int a = n * 100;
            List<int> res = new List<int>();
            for (int i = cents.Length - 1; i >= 0; i--)
            {
                if (cents[i] * l[i]>a)
                {
                    for (int j = l[i]; j >= 0; j--)
                    {
                        if (cents[i] * j <= a)
                        {
                            res.Add(j);
                            a -= j * cents[i];
                            break;
                        }
                    }
                }
                else
                {
                    res.Add(l[i]);
                }
            }
            if (a > 0)
            {
                Console.WriteLine("Не удалось собрать достаточную сумму! Мало монет!");
            }
            else
            {
                res.Reverse();
                for (int i = 0; i < res.Count; i++)
                {
                    Console.WriteLine(cents[i] + " - " + res[i]);
                }
            }            
        }
    }
}

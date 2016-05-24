using System;
using System.Diagnostics;
//Сортировка вставками, выбором и цифровая сортировка на C#
//Insertion, selection and numeric sort C#
namespace ConsoleApplication1
{
    class Lab1Alg
    {
        static void ins(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[j] > a[i])
                    {
                        int t = a[j];
                        a[j] = a[i];
                        a[i] = t;
                    }
                }
            }

        }

        static void sel(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int max = Int32.MaxValue;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < max)
                    {
                        max = a[j];
                    }
                }
                int t = max;
                a[Array.IndexOf(a, max)] = a[i];
                a[i] = t;
            }

        }

        static string[] num(string[] a)
        {
            string[][] s = new string[a[0].Length + 1][];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = new string[a.Length];
            }
            Array.Copy(a, s[0], a.Length);
            int n = 0;
            for (int i = a[0].Length - 1; i >= 0; i--)
            {
                int m = 0;
                for (int k = 0; k < 10; k++)
                {
                    for (int j = 0; j < a.Length; j++)
                    {

                        if (s[n][j][i].ToString() == k.ToString())
                        {
                            s[n + 1][m] = s[n][j];
                            m++;
                        }
                    }
                }
                n++;
            }
            return s[a[0].Length - 1];
        }

        static string[] correct(string[] c)
        {
            int l = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].Length > l)
                {
                    l = c[i].Length;
                }
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].Length < l)
                {
                    while (c[i].Length < l)
                    {
                        c[i] = '0' + c[i];
                    }
                }
            }
            return c;
        }

        static void Main()
        {
            int[] a = new int[2000];
            Random r = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = r.Next(Int32.MaxValue);
            }
            int[] b = new int[2000];
            Array.Copy(a, b, 2000);

            string[] c = new string[2000];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i].ToString();
            }
            correct(c);

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            sel(a);
            sw1.Stop();
            Console.WriteLine(sw1.ElapsedMilliseconds.ToString());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            ins(b);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            num(c);
            sw2.Stop();
            Console.WriteLine(sw2.ElapsedMilliseconds.ToString());
        }
    }
}
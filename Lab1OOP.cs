using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab1
{
    struct Stud
    {
        public string Name;
        public int Group;
        public int Prog;
        public int Math;
        public int Phys;
        public Stud(string s, int gr, int pr, int math, int phys)
        {
            Name = s;
            Group = gr;
            Prog = pr;
            Math = math;
            Phys = phys;
        }
    }
    class Lab1
    {
        static void Main()
        {
            Stud[] a = new Stud[10];
            a[0] = new Stud("Алексей", 1, 4, 4, 4);
            a[1] = new Stud("Евгений", 2, 3, 3, 3);
            a[2] = new Stud("Александр", 3, 2, 2, 2);
            a[3] = new Stud("Владислав", 4, 5, 5, 5);
            a[4] = new Stud("Глеб", 5, 3, 4, 5);
            a[5] = new Stud("Василий", 6, 5, 4, 3);
            a[6] = new Stud("Михаил", 3, 4, 3, 4);
            a[7] = new Stud("Ира", 5, 4, 4, 4);
            a[8] = new Stud("Дмитрий", 1, 2, 3, 4);
            a[9] = new Stud("Максим", 2, 3, 3, 5);
            Console.WriteLine(Dolg(a));
            Console.WriteLine(Predm(a));
            Console.WriteLine(Kach(a));
            List(a);
        }
        static string Dolg(Stud[] st)
        {
            string s = "";
            foreach (Stud stud in st)
            {
                if (stud.Math == 2 || stud.Phys == 2 || stud.Prog == 2)
                {
                    s += stud.Name + " ";
                }
            }

            return s;
        }
        static string Kach(Stud[] st)
        {
            double a = 0;
            foreach (Stud stud in st)
            {
                if (stud.Math > 3 && stud.Phys > 3 && stud.Prog > 3)
                {
                    a++;
                }
            }
            double c = a / st.Length * 100;
            string s = c.ToString() + "%";
            return s;
        }
        static string Predm(Stud[] st)
        {
            int m = 0, p = 0, ph = 0;
            foreach (Stud stud in st)
            {
                m += stud.Math;
                p += stud.Prog;
                ph += stud.Phys;
            }
            if (m == p && m == ph) return "Math,Phys,Prog";
            if (m > p && m > ph) return "Math";
            if (p > m && p > ph) return "Prog";
            if (ph > m && ph > p) return "Phys";
            if (m == p) return "Math,Prog";
            if (m == ph) return "Math,Phys";
            if (p == ph) return "Prog,Phys";
            return "";
        }
        static void List(Stud[] st)
        {
            int[] a = new int[7];
            for (int i = 0; i < st.Length; i++)
            {
                a[st[i].Group] += st[i].Math + st[i].Phys + st[i].Prog;
            }
            while (true)
            {
                int c = 1;
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] >= c)
                    {
                        c = a[i];
                    }
                }
                if (Array.IndexOf(a, c) != -1)
                {
                    Console.WriteLine(Array.IndexOf(a, c) + " " + c);
                    a[Array.IndexOf(a, c)] = 0;
                }
                else
                {
                    break;
                }
            };
        }
    }
}
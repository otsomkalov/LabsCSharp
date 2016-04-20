using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace Lab2
{
    //18.		1,3 , 6, 10, 15, 16, 30, 41, 47
    class RList
    {
        private int key;
        private RList next;

        #region 47.Властивість Length - довжина списку (при зчитуванні - повернути довжину списку, при записі - встановити довжину списку, додавши елементи зі значенням 0 або відсікаючи зайві елементи);
        public int Length
        {
            get
            {
                int a = 0;
                for (RList i= this;i!= null; i = i.next)
                {
                    a++;
                }
                return a;                
            }
            set
            {
                if (Length > value)
                {
                    while (Length != value)
                    {
                        RList.Delete(this);
                    }
                }
                else
                {
                    while (Length != value)
                    {
                        RList.Add(this, 0);
                    }
                } 
            }
        }
        #endregion

        #region 1.Конструктор з одним параметром (число) 
        public RList(int n)
        {
            key = n;
            next = null;
        }
        #endregion

        #region 3.Конструктор копіювання
        public RList(RList rl)
        {
            key = rl.key;
            next = rl.next;
        }
        #endregion

        #region 6.Рекурсивний метод додавання нового елемента останнім у список
        public static void Add(RList rl,int n)
        {
            if (rl.next != null)
            {
                Add(rl.next, n);
            }
            else
            {
                rl.next = new RList(n);
            }
        }
        #endregion

        #region 10.Метод додавання нового елементу у список після елемента із заданим значенням
        public static void Insert(RList rl,int m,int n)
        {
            if (rl.key != n)
            {
                Insert(rl.next, m, n);
            }
            else
            {
                RList t = rl.next;
                rl.next = new RList(m);
                rl.next.next = t;
            }
        }
        #endregion

        #region 15.Рекурсивний метод видалення останнього в списку елемента
        public static void Delete(RList rl)
        {
            if (rl.next.next != null && rl.next!=null)
            {
                Delete(rl.next);
            }
            else
            {
                rl.next = null;
            }
        }
        #endregion

        #region 16.Рекурсивний метод видалення n-ного за рахунком елемента
        public static void DeleteNum(RList rl,int n)
        {
            if (n == 1)
            {
                for (RList i= rl;i.next!= null; i = i.next)
                {
                    i.key = i.next.key;
                }
                RList.Delete(rl);
            }
            else
            {
                if (n == rl.Length)
                {
                    RList.Delete(rl);
                }
                else
                {
                    RList.DeleteNum(rl.next, --n);
                }
            }
        }
        #endregion

        #region 30.Не рекурсивний метод друку всіх непарних значень елементів списку;
        public static void PrintOdd(RList rl)
        {
            for (RList i= rl;i!= null; i = i.next)
            {
                if (i.key % 2 != 0)
                {
                    Console.WriteLine(i.key);
                }
            }
        }
        #endregion

        #region 41.Метод пошуку елемента із заданим значенням (результат - номер знайденого елемента у списку)
        public static void Search(RList rl,int n)
        {
            for (RList i = rl; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    Console.WriteLine(rl.Length-i.Length+1);
                }
            }
        }
        #endregion

        #region Печать
        public static void Print(RList rl)
        {
            if (rl.next != null)
            {
                Console.WriteLine(rl.key);
                Print(rl.next);
            }
            else
            {
                Console.WriteLine(rl.key);
            }
        }
        #endregion

        #region Переопределить две любых операции.
        public static int operator +(RList rl1,RList rl2)
        {
            return rl1.key + rl2.key;
        }
        public static int operator *(RList rl1,RList rl2)
        {
            return rl1.key * rl2.key;
        }
        #endregion

    }
    class Program
    {
        public static void Main()
        {
            RList rl = new RList(1);
            RList.Add(rl, 2);
            RList.Add(rl, 3);
            RList.Add(rl, 4);
            RList.Add(rl, 5);
            RList.Add(rl, 6);
            RList.Add(rl, 7);
            RList rl1 = new RList(2);
            Console.WriteLine(rl + rl1);
            Console.WriteLine(rl * rl1);
            RList.Print(rl);
        }
    }
}

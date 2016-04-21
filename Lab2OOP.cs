using System;

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
                int a = -1;
                for (RList i = this; i != null; i = i.next)
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
                        this.Delete();
                    }
                }
                else
                {
                    while (Length != value)
                    {
                        this.Add(0);
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
        public void Add(int n)
        {
            if (this.next != null)
            {
                this.next.Add(n);
            }
            else
            {
                this.next = new RList(n);
            }
        }
        #endregion

        #region 10.Метод додавання нового елементу у список після елемента із заданим значенням
        public void Insert(int m, int n)
        {
            for (RList i = this.next; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    RList t = i.next;
                    i.next = new RList(m);
                    i.next.next = t;
                    return;
                }
            }     
        }
        #endregion

        #region 15.Рекурсивний метод видалення останнього в списку елемента
        public void Delete()
        {
            if (this.next.next != null)
            {
                this.next.Delete();
            }
            else
            {
                this.next = null;
            }
        }
        #endregion

        #region 16.Рекурсивний метод видалення n-ного за рахунком елемента
        public void DeleteNum(int n)
        {
            if (n != 1)
            {
                this.next.DeleteNum(--n);
            }
            else
            {
                RList t = this.next.next;
                this.next = t;
            }
        }
        #endregion

        #region 30.Не рекурсивний метод друку всіх непарних значень елементів списку;
        public void PrintOdd()
        {
            for (RList i = this.next; i != null; i = i.next)
            {
                if (i.key % 2 != 0)
                {
                    Console.WriteLine(i.key);
                }
            }
        }
        #endregion

        #region 41.Метод пошуку елемента із заданим значенням (результат - номер знайденого елемента у списку)
        public void Search(int n)
        {
            for (RList i =  this.next; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    Console.WriteLine(this.Length - i.Length );
                }
            }
        }
        #endregion

        #region Переопределить две любых операции.
        public static int operator +(RList rl1, RList rl2)
        {
            int res = 0;
            for (RList i = rl1; i != null; i=i.next)
            {
                res += i.key;
            }
            for (RList i = rl2; i != null; i = i.next)
            {
                res += i.key;
            }
            return res;
        }
        public static RList operator ++(RList rl)
        {
            return rl.next;
        }
        #endregion

        #region Печать
        public void Print()
        {
            for (RList i = this.next; i != null; i = i.next)
            {
                Console.WriteLine(i.key);
            }
        }
        #endregion
    }
    class Program
    {
        public static void Main()
        {
            RList rl = new RList(0);
            rl.Add(1);
            rl.Add(2);
            rl.Add(3);
            rl.Add(4);
            rl.Add(5);
            
            rl.Print(); 
        }
    }
}
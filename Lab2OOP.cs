using System;
//Singly linked list C#
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
            if (this.next != null)
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
            else
            {
                Console.Write("Список пуст!");
            }            
        }
        #endregion

        #region 16.Рекурсивний метод видалення n-ного за рахунком елемента
        public void DeleteNum(int n)
        {
            if (n<0 || n > Length)
            {
                Console.WriteLine("Элемент не существует!");
            }
            else
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
        }
        #endregion

        #region 30.Не рекурсивний метод друку всіх непарних значень елементів списку;
        public void PrintOdd()
        {
            for (RList i = this.next; i != null; i = i.next)
            {
                if (i.key % 2 != 0)
                {
                    Console.Write(i.key+" ");
                }
            }
        }
        #endregion

        #region 41.Метод пошуку елемента із заданим значенням (результат - номер знайденого елемента у списку)
        public int Search(int n)
        {
            for (RList i =  this.next; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    return this.Length - i.Length ;
                }
            }
            return -1;
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
        

        public static RList operator *(RList rl, int a)
        {
            for (RList i = rl; i != null; i = i.next)
            {
                i.key *= a; 
            }
            return rl;
        }
        #endregion

        #region Печать
        public void Print()
        {
            for (RList i = this.next; i != null; i = i.next)
            {
                Console.Write(i.key+" ");
            }
            Console.WriteLine();
        }
        #endregion

        #region 20.Рекурсивний метод видалення всіх елементів із заданим значенням
        public void DeleteElements(int n)
        {
            if (next != null)
            {
                if (next.key == n)
                {
                    if (next.next != null)
                    {
                        next = next.next;
                        next.DeleteElements(n);
                    }
                    else
                    {
                        Delete();
                    }
                }
                else
                {                
                    next.DeleteElements(n);                               
                }
            }
        }
        #endregion
    }
    class Program
    {
        public static void Main()
        {
            //#20
            RList rl = new RList(0);
            rl.Add(70);
            rl.Add(10);
            rl.Add(70);
            rl.Add(30);
            rl.Add(70);
            //rl.Print();
            //rl.Length = 3;
            //Console.WriteLine(rl.Length);
            //rl.Print();
            //RList r2 = new RList(0);
            //r2.Add(10);
            //Console.WriteLine(rl + r2);
            //Console.WriteLine(rl.Search(70));
            //rl.DeleteNum(200);
            rl.DeleteElements(75);
            rl.Print();
        }
    }
}
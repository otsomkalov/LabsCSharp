using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
    {
        class Stack
        {
            int[] a = new int[5];
            int top = 0;
            public void push(int n)
            {
                if (top < a.Length)
                {
                    a[top] = n;
                    top++;
                }
            }
            public void pop()
            {
                a[top - 1] = 0;
                a[top - 2] = 0;
                top -= 2;
                for (int i = 0; i < top; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }
        }

        class Queue
        {
            int start = 0;
            int end = 0;
            int[] a = new int[5];
            public void enqueue(int n)
            {
                a[end] = n;
                end++;
            }
            public void dequeue()
            {
                a[start] = 0;
                a[start + 1] = 0;
                start += 2;
                for (int i = start; i < end; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }
        }

        class List
        {
        public int key;
        public List next;

        public List(int n)
        {
            key=n;
        }
        public List(int n, List l)
        {
            key=n;
            next=l;
        }

        public void PrintList()
        {
            List that=this.next;
            while (that!=null)
            {
                Console.WriteLine(that.key);
                that = that.next;
            }
        }

        public void Add(int n)
        {
            if (this.next != null)
            {
                this.next.Add(n);
            }
            else
            {
                this.next = new List(n);
            }
        }

        public int Length
        {
            get
            {
                int a = -1;
                for (List i = this; i != null; i = i.next)
                {
                    a++;
                }
                return a;
            }
        }

        public void AddFirst(int item)
        {
            List temp = next;
            next = new List(next.key);
            next.next = temp;
            next.key = item;
        }

        public void Insert(int m, int n)
        {
            for (List i = this.next; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    List t = i.next;
                    i.next = new List(m);
                    i.next.next = t;
                    return;
                }
            }     
        }

        public void Search(int n)
        {
            for (List i =  this.next; i != null; i = i.next)
            {
                if (i.key == n)
                {
                    Console.WriteLine(this.Length - i.Length );
                }
            }
        }

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
  
        public void DeleteNum(int num)
        {
            List that=this;
            while (that.next != null)
            {
                if (that.next.key == num)
                {
                    that.next = that.next.next;
                }
                else
                {
                    that = that.next;
                }
            }
        }

        public void Switch(int m,int n)
        {
            int temp;
            if (m<n)
            {
                for (List i=this;i!=null;i=i.next)
                {
                    if (this.Length - i.Length == m)
                    {
                        for (List j = i; j != null; j = j.next)
                        {
                            if (this.Length - j.Length == n)
                            {
                                temp = i.key;
                                i.key = j.key;
                                j.key = temp;
                            }
                        }
                    }
                }
            }
            
        }
        public void Reverse()
        {
            int[] s = new int[0];
            List that = this;
            int n = 0;
            while (that != null)
            {
                Array.Resize(ref s, s.Length + 1);
                s[n] = that.key;
                n++;
                that = that.next;
            }
            that = this;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                that.key = s[i];
                that = that.next;
            }
            PrintList();
        }
    }
        class Pr
        {
            static void Main()
            {
                /*Stack st = new Stack();
                for (int i = 0; i < 5; i++)
                {
                    st.push(Int32.Parse(Console.ReadLine()));
                }
                st.pop();*/
                /*Queue q = new Queue();
                for (int i = 0; i < 5; i++)
                {
                    q.enqueue(Int32.Parse(Console.ReadLine()));
                }
                q.dequeue();*/
                List l = new List(0);
                for (int i = 0; i < 5; i++)
                {
                    l.Add(int.Parse(Console.ReadLine()));
                }
                //l.AddFirst(10);
                //l.DeleteNum(4);
                //l.Search(4);
                //l.Switch(2, 4);
                l.DeleteNum(1);
                l.PrintList();
            }
        }
}

        
    


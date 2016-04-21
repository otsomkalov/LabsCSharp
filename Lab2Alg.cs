using System;

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
        private List that;

        public List(int n)
        {
            key = n;
            that = this;
        }

        public void Add(int n)
        {
            that = this;
            while (that.next != null)
            {
                that = that.next;
            }
            that.next = new List(n);
        }

        public void Print()
        {
            that = this;
            while (that != null)
            {
                Console.WriteLine(that.key);
                that = that.next;
            }
        }

        public void Reverse()
        {
            int[] s = new int[0];
            that = this;
            int n = 0;
            while (that != null)
            {
                Array.Resize(ref s, s.Length + 1);
                s[n] = that.key;                
                n++;
                that = that.next;                
            }
            that = this;
            for (int i = s.Length-1; i>=0; i--)
            {
                that.key = s[i];
                that = that.next;
            }
            Print();
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
            List l = new List(1);
            for (int i = 0; i < 5; i++)
            {
                l.Add(Int32.Parse(Console.ReadLine()));
            }
            l.Reverse();
        }
    }
}

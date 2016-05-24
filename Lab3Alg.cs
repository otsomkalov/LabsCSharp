using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Двоичные деревья C#
//Binary-tree C#
namespace ConsoleApplication1
{
    class Tree
    {
        int key;
        Tree left;
        Tree right;

        public void Add(int n)
        {
            if (right==null && left == null && key==0)
            {
                key = n;
            }
            if (n > key)
            {
                if (right == null)
                {
                    right = new Tree();
                    right.Add(n);
                }
                else
                {
                    right.Add(n);
                }                
            }
            if (n < key)
            {
                if (left == null)
                {
                    left = new Tree();
                    left.Add(n);
                }
                else
                {
                    left.Add(n);
                }                
            }
        }

        public static void Print(Tree t)
        {
            if (t.left != null)
            {
                Console.WriteLine($"{t.key}-->{t.left.key}");
                Print(t.left);
            }
            if (t.right != null)
            {
                Console.WriteLine($"{t.key}-->{t.right.key}");
                Print(t.right);
            }
        }
        
        public Tree Find(int n)
        {
            if (key == n)
            {
                return this;
            }
            if (n > key)
            {
                if (right == null)
                {
                    return null;
                }
                else
                {
                    return right.Find(n);
                }
            }

            if (n < key)
            {
                if (left == null)
                {
                    return null;
                }
                else
                {
                    return left.Find(n);
                }
            }
            return null;
        }

        public int TwoNodes()
        {
            int n = 0;
            if (right!=null && left != null)
            {
                n++;
            }
            if (right != null)
            {
                n += right.TwoNodes();
            }
            if (left != null)
            {
                n += left.TwoNodes();
            }
            return n;
        }
    }

    class Pr
    {
        public static void Main()
        {
            Tree t = new Tree();
            t.Add(10);
            t.Add(8);
            t.Add(14);
            t.Add(12);
            t.Add(113);
            t.Add(11);
            t.Add(7);
            t.Add(9);
            Tree.Print(t);
            Console.WriteLine(t.Find(12));
            Console.WriteLine(t.TwoNodes());
        }
    }
}

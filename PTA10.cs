using System;

namespace PTA10
{
    class Program
    {
        class AVLNode
        {
            public int Data;
            public AVLNode Left;
            public AVLNode Right;
            public int Height;

            public AVLNode()
            {

            }
            public AVLNode(int data)
            {
                Data = data;
                Left = null;
                Right = null;
                Height = 0;
            }
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        static int GetHeight(AVLNode t)
        {
            if (t == null) return 0;
            int leftHeight = GetHeight(t.Left);
            int rightHeight = GetHeight(t.Right);

            return Max(leftHeight,rightHeight)+1;
        }
        static AVLNode SingleLeftRotation(AVLNode t)
        {
            AVLNode B = t.Left;
            t.Left = B.Right;
            B.Right = t;
            t.Height = Max(GetHeight(t.Left), GetHeight(t.Right)) + 1;
            B.Height = Max(GetHeight(B.Left), GetHeight(B.Right)) + 1;

            return B;
        }

        static AVLNode SingleRightRotation(AVLNode t)
        {
            AVLNode B = t.Right;
            t.Right = B.Left;
            B.Left = t;
            t.Height = Max(GetHeight(t.Left), GetHeight(t.Right)) + 1;
            B.Height = Max(GetHeight(B.Left), GetHeight(B.Right)) + 1;

            return B;
        }

        static AVLNode DoubleLeftRightRotation(AVLNode t)
        {
            t.Left = SingleRightRotation(t.Left);
            return SingleLeftRotation(t);
        }

        static AVLNode DoubleRightLeftRotation(AVLNode t)
        {
            t.Left = SingleLeftRotation(t.Left);
            return SingleRightRotation(t);
        }

        static AVLNode Insert(AVLNode t,int k)
        {
            AVLNode newNode = new AVLNode(k);
            if(t == null)
            {
                newNode.Data = k;
                newNode.Left = null;
                newNode.Right = null;
                newNode.Height = 0;
                t = newNode;
            }
            else if(k<t.Data)
            {
                if (t.Left != null)
                {
                    t.Left = Insert(t.Left, k);
                }
                else t.Left = newNode;
                //t.Height = GetHeight(t);
                int BF = Math.Abs(GetHeight(t.Left)-GetHeight(t.Right));
                if(BF==2)
                {
                    if (k < t.Left.Data) t = SingleLeftRotation(t);
                    else t = DoubleLeftRightRotation(t);
                }
            }
            else
            {
                if (t.Right != null)
                {
                    Insert(t.Right, k);
                }
                else t.Right = newNode;
                //t.Height = GetHeight(t);
                int BF = Math.Abs(GetHeight(t.Left) - GetHeight(t.Right));
                if (BF == 2)
                {
                    if (k > t.Right.Data) t = SingleRightRotation(t);
                    else t = DoubleRightLeftRotation(t);
                }
            }
            t.Height = Max(GetHeight(t.Left), GetHeight(t.Right)) + 1;

            return t;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            AVLNode head = null;
            for(int i =0;i<=n-1;i++)
            {
                int tmp = Convert.ToInt32(strs[i]);
                head = Insert(head, tmp);
            }
            Console.WriteLine(head.Data);
        }
    }
}

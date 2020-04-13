using System;
using System.Collections;

namespace PTA7
{
    class Program
    {
        struct TreeNode
        {
            private static int nextIndex=0;
            public int index;
            public bool Leaf;
            public string Left;
            public string Right;

            public TreeNode(string left, string right)
            {
                index = nextIndex;
                nextIndex++;
                Left = left;
                Right = right;
                if (left.Equals("-") && right.Equals("-")) Leaf = true;
                else Leaf = false;
            }
        }
        static TreeNode[] T1, T2 = new TreeNode[10];

        static TreeNode[] BuildTree(out string root, out int cnt)
        {
            cnt = 0;
            int N = Convert.ToInt32(Console.ReadLine());
            TreeNode[] tree = new TreeNode[N];
            root = "-1";
            bool[] ifRoot = new bool[N];
            for (int i = 0; i <= N - 1; i++)
            {
                ifRoot[i] = true;
            }

            for (int i = 0; i <= N - 1; i++)
            {
                string[] str = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
                TreeNode tmp = new TreeNode(str[0], str[1]);
                tree[i] = tmp;
                if (!str[0].Equals("-"))
                {
                    int index = Convert.ToInt32(str[0]);
                    ifRoot[index] = false;
                }
                if (!str[1].Equals("-"))
                {
                    int index = Convert.ToInt32(str[1]);
                    ifRoot[index] = false;
                }
                cnt++;
            }
            for (int i = 0; i <= N - 1; i++)
            {
                if (ifRoot[i]) root = i.ToString();
            }

            return tree;
        }

        static void OutPutLeaves(TreeNode[] t,string root)
        {
            int R = Convert.ToInt32(root);
            Queue q = new Queue();
            q.Enqueue(t[R]);
            string output = "";
            while(q.Count!=0)
            {
                TreeNode tmp = (TreeNode)q.Dequeue();

                if (tmp.Leaf) output = String.Format(output + "{0} ", tmp.index.ToString());
                if(!tmp.Left.Equals("-"))
                {
                    int left = Convert.ToInt32(tmp.Left);
                    q.Enqueue(t[left]);
                }
                if (!tmp.Right.Equals("-"))
                {
                    int right = Convert.ToInt32(tmp.Right);
                    q.Enqueue(t[right]);
                }
                
            }
            output = output.Trim();
            Console.WriteLine(output);

        }
        
        static void Main(string[] args)
        {
            string R;
            int cnt;
            TreeNode[] T = BuildTree(out R, out cnt);
            OutPutLeaves(T, R);
        }
    }
}


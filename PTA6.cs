using System;

namespace PTA6
{
    class Program
    {
        struct TreeNode
        {
            public string Data;
            public string Left;
            public string Right;

            public TreeNode(string data,string left,string right)
            {
                Data = data;
                Left = left;
                Right = right;
            }
        }
        static TreeNode[] T1, T2 = new TreeNode[10];

        static TreeNode[] BuildTree(out string root,out int cnt)
        {
            cnt = 0;
            int N = Convert.ToInt32(Console.ReadLine());
            TreeNode[] tree = new TreeNode[N];
            root = "-1";
            bool[] ifRoot = new bool[N];
            for(int i = 0;i<=N-1;i++)
            {
                ifRoot[i] = true;
            }
            
            for(int i = 0;i<=N-1;i++)
            {
                string[] str = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
                TreeNode tmp = new TreeNode(str[0],str[1],str[2]);
                tree[i] = tmp;
                if(!str[1].Equals("-"))
                {
                    int index = Convert.ToInt32(str[1]);
                    ifRoot[index] = false;
                }
                if (!str[2].Equals("-"))
                {
                    int index = Convert.ToInt32(str[2]);
                    ifRoot[index] = false;
                }
                cnt++;
            }
            for(int i = 0;i<=N-1;i++)
            {
                if (ifRoot[i]) root = i.ToString();
            }

            return tree;
        }

        static bool Isomorphous(TreeNode[] t1,TreeNode[] t2,string R1,string R2)
        {
            bool flag=false;

            int r1 = Convert.ToInt32(R1);
            int r2 = Convert.ToInt32(R2);
            int left1, left2, right1, right2;
            if (!t1[r1].Left.Equals("-")) left1 = Convert.ToInt32(t1[r1].Left);
            else left1 = -1;
            if (!t1[r1].Right.Equals("-")) right1 = Convert.ToInt32(t1[r1].Right);
            else right1 = -1;
            if (!t2[r2].Left.Equals("-")) left2 = Convert.ToInt32(t2[r2].Left);
            else left2 = -1;
            if (!t2[r2].Right.Equals("-")) right2 = Convert.ToInt32(t2[r2].Right);
            else right2 = -1;

            if (left1 != -1 && left2 != -1)
            {
                if (t1[left1].Data.Equals(t2[left2].Data))
                {
                    flag = Isomorphous(t1, t2, t1[r1].Left,t2[r2].Left);
                }
            }

            if (right1 != -1 && right2 != -1)
            {
                if (t1[right1].Data.Equals(t2[right2].Data))
                {
                    flag = Isomorphous(t1, t2, t1[r1].Right, t2[r2].Right);
                }
            }

            if (left1 != -1 && right2 != -1)
            {
                if (t1[left1].Data.Equals(t2[right2].Data))
                {
                    flag = Isomorphous(t1, t2, t1[r1].Left, t2[r2].Right);
                }
            }

            if (right1 != -1 && left2 != -1)
            {
                if (t1[right1].Data.Equals(t2[left2].Data))
                {
                    flag = Isomorphous(t1, t2, t1[r1].Right, t2[r2].Left);
                }
            }

            if (left1 ==-1&&left2==-1&&right1==-1&&right2==-1)
            {
                if (t1[r1].Data.Equals(t2[r2].Data)) flag = true;
            }

            return flag;
        }
        static void Main(string[] args)
        {
            string R1, R2;
            int cnt1, cnt2;
            bool flag = false;
            T1 = BuildTree(out R1,out cnt1);
            T2 = BuildTree(out R2,out cnt2);
            if (cnt1 == cnt2)
            {
                if (cnt1 != 0)
                {
                    if (Isomorphous(T1, T2, R1, R2))
                        flag = true;
                }
                else flag = true;
            }
            if (flag) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}

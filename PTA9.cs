using System;

namespace PTA9
{
    class Program
    {
        class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;
        }

        static TreeNode Insert(TreeNode T,int n)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = n;
            if (n < T.data)
            {
                if (T.left == null) T.left = newNode;
                else Insert(T.left, n);
            }
            else
            {
                if (T.right == null) T.right = newNode;
                else Insert(T.right, n);
            }
            return T;
        }
        static TreeNode BuildTree(int n)
        {
            
            TreeNode head = new TreeNode();
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);

            head.data = Convert.ToInt32(strs[0]);
            TreeNode tmp = new TreeNode();
            TreeNode next = new TreeNode();
            
            for(int i = 1;i<=n-1;i++)
            {
                int num = Convert.ToInt32(strs[i]);
                Insert(head, num);
            }
            return head;
        }

        static bool flag = true;
        static void Compare(TreeNode t1,TreeNode t2)
        {
            if (t1.data == t2.data)
            {
                if (t1.left != null && t2.left != null)
                {
                    Compare(t1.left, t2.left);
                }
                else if (t1.left == null ^ t2.left == null) flag = false;
                
                if (t1.right != null && t2.right != null)
                {
                    Compare(t1.right, t2.right);
                }
                else if (t1.right == null ^ t2.right == null) flag = false;
                
            }
            else flag = false;
        }
        static void Main(string[] args)
        {
            int n, m;
            while (true)
            {
                string str = Console.ReadLine();
                string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
                n = Convert.ToInt32(strs[0]);
                if (n == 0) break;
                else
                {
                    m = Convert.ToInt32(strs[1]);
                    TreeNode[] trees = new TreeNode[m+1];
                    for(int i =0;i<=trees.Length-1;i++)
                    {
                        trees[i] = BuildTree(n);
                    }
                    for(int i = 1;i<=trees.Length-1;i++)
                    {
                        Compare(trees[0], trees[i]);
                        if (flag) Console.WriteLine("Yes");
                        else Console.WriteLine("No");
                        flag = true;
                    }
                }
            }
        }
    }
}

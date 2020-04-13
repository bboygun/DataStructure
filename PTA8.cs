using System;
using System.Collections;

namespace PTA8
{
    class Program
    {
        class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;
        }

        static TreeNode BuildTree()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            TreeNode head = new TreeNode();
            TreeNode tmp = new TreeNode();
            Stack s = new Stack();
            

            string str1 = Console.ReadLine();
            string[] strs1 = str1.Split(new string[] { " " },StringSplitOptions.None);
            head.data = Convert.ToInt32(strs1[1]);
            s.Push(head);
            tmp = head;

            for (int i = 1; i <= 2*n - 1; i++)
            {
                string str = Console.ReadLine();
                string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
                
                switch (strs[0])
                {
                    case "Push":
                        TreeNode next = new TreeNode();
                        next.data = Convert.ToInt32(strs[1]);
                        next.left = next.right = null;
                        if (tmp.left == null)
                        {
                            tmp.left = next;
                        }
                        else tmp.right = next;
                        s.Push(next);
                        tmp = next;
                        break;
                    case "Pop":
                        tmp = (TreeNode)s.Pop();
                        //i++;
                        break;
                }
            }
            return head;
        }

        static string output = "";
        static void PostOrder(TreeNode T)
        {
            if(T!=null)
            {
                PostOrder(T.left);
                PostOrder(T.right);
                output = output + T.data + " ";
            }
        }
        static void Main(string[] args)
        {
            TreeNode T = BuildTree();
            PostOrder(T);
            output = output.Trim();
            Console.WriteLine(output);
        }
    }
}

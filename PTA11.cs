using System;

namespace PTA11
{
    class Program
    {
        static int GetLeftLength(int n)
        {
            int k;
            int H = (int)Math.Log(n+1,2);
            int x = (int)(n + 1 - Math.Pow(2, H));
            x = (x < (int)Math.Pow(2, H - 1)) ? x : (int)Math.Pow(2, H - 1);
            k = (int)(Math.Pow(2, H - 1) - 1 + x);
            return k;
        }
        static void Solve(int aLeft,int aRight,int tRoot,int[] A,int[] T)
        {
            int n = aRight - aLeft + 1;
            if (n == 0) return;
            int L = GetLeftLength(n);
            T[tRoot] = A[aLeft + L];
            int leftRoot = tRoot * 2 + 1;
            int rightRoot = leftRoot + 1;
            Solve(aLeft, aLeft + L - 1, leftRoot,A,T);
            Solve(aLeft + L + 1, aRight, rightRoot,A,T);

        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            for(int i = 0;i<=n-1;i++)
            {
                a[i] = Convert.ToInt32(strs[i]);
            }
            Array.Sort(a);
            int[] t = new int[n];
            Solve(0, n - 1, 0, a, t);
            string output = "";
            foreach (int num in t) output = string.Format(output + "{0} ", num);
            output = output.Trim();
            Console.WriteLine(output);
            
        }
    }
}

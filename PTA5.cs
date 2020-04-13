using System;

namespace PTA5
{
    public class Program
    {
        static void Main(string[] args)
        {
            int M, N, K;
            string input = Console.ReadLine();
            string[] inputs = input.Split(new string[] { " " }, StringSplitOptions.None);
            M = Convert.ToInt32(inputs[0]);
            N = Convert.ToInt32(inputs[1]);
            K = Convert.ToInt32(inputs[2]);

            bool[] flag = new bool[K];
            for (int i = 0; i <= K - 1; i++) flag[i] = true;

            for (int i = 0; i <= K - 1; i++)
            {
                bool[] stack = new bool[N];
                for (int j = 0; j <= N - 1; j++) stack[j] = false;

                string input2 = Console.ReadLine();
                string[] inputs2 = input2.Split(new string[] { " " }, StringSplitOptions.None);
                int[] a = new int[N];
                for (int j = 0; j <= N - 1; j++) a[j] = Convert.ToInt32(inputs2[j]);

                int before = a[0];
                if(before>M)
                {
                    flag[i] = false;
                }
                stack[a[0] - 1] = true;

                for(int j = 1;j<=N-1;j++)
                {
                    int cnt = 0;
                    for(int k = 0;k<=a[j]-1;k++)
                    {
                        if (stack[k] == false) cnt++;
                    }
                    if(cnt>M)
                    {
                        flag[i] = false;
                        break;
                    }
                    if(a[j]<before)
                    {
                        for(int k = a[j]+1;k<=before-1; k++)
                        {
                            if (!stack[k-1]) flag[i] = false;
                        }
                    }
                    before = a[j];
                    stack[a[j] - 1] = true;

                }

            }
            for (int i = 0; i <= K - 1; i++)
            {
                if (flag[i]) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
        }
    }
}
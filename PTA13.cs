using System;

namespace PTA13
{

    class Program
    {
        static int[] Computers;

        static int FindParent(int[]a,int x)
        {
            if (a[x] <0 ) return x;
            else return a[x]=FindParent(a,a[x]);
        }

        static void Check(int[] a, int n, int m)
        {
            int parent1 = FindParent(a, n);
            int parent2 = FindParent(a, m);
            if (parent1 == parent2) Console.WriteLine("yes");
            else Console.WriteLine("no");
        }

        static void Connect(int[] a,int n,int m)
        {
            int parent1 = FindParent(a, n);
            int parent2 = FindParent(a, m);
            //树1比树2小，将树1并到树2上
            if (a[parent1] >= a[parent2])
            {
                int tmp = a[parent1];
                a[n] = parent2;
                a[parent2] += tmp;
            }
            else
            {
                int tmp = a[parent2];
                a[m] = parent1;
                a[parent1]+=tmp;
            }
        }

        static void Count(int[] a)
        {
            int cnt = 0;
            for (int i = 0; i <= a.Length - 1; i++) if (a[i] < 0) cnt++;
            if (cnt == 1) Console.WriteLine("The network is connected.");
            else Console.WriteLine("There are " + cnt + " components.");
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Computers = new int[n];
            for (int i = 0; i <= n - 1; i++) Computers[i] = -1;

            string input = Console.ReadLine();
            string[] inputs = input.Split(new string[] { " " }, StringSplitOptions.None);
            while (!inputs[0].Equals("S"))
            {
                switch (inputs[0])
                {
                    case "C":
                        Check(Computers, Convert.ToInt32(inputs[1])-1, Convert.ToInt32(inputs[2])-1);
                        break;
                    case "I":
                        Connect(Computers, Convert.ToInt32(inputs[1])-1, Convert.ToInt32(inputs[2])-1);
                        break;
                }
                input = Console.ReadLine();
                inputs = input.Split(new string[] { " " }, StringSplitOptions.None);
            }
            Count(Computers);
        }
    }
}

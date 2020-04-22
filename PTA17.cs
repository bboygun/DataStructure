using System;
using System.Collections;

namespace PTA17
{
    class Program
    {
        static bool[] Visited;
        static int[,] Graph;
        static Queue Q;

        private static void BuildGraph(int n ,int m)
        {
            Graph = new int[n, n];
            for(int i = 1;i<=m;i++)
            {
                string str = Console.ReadLine();
                string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
                int a = Convert.ToInt32(strs[0])-1;
                int b = Convert.ToInt32(strs[1])-1;
                Graph[a, b] = 1;
                Graph[b, a] = 1;
            }
        }
        private static int BFS(int v)
        {
            int cal=1;
            Visited[v] = true;
            int level = 0;
            int last = v;
            int tail=0;
            
            Q.Enqueue(v);
            while (Q.Count != 0)
            {
                v = (int)Q.Dequeue();
                for (int w = 0; w <= Graph.GetLength(0) - 1; w++)
                {
                    if (w != v && Graph[v, w] == 1 && !Visited[w])
                    {
                        Visited[w] = true;
                        cal++;
                        Q.Enqueue(w);
                        tail = w;
                    }
                }
                if (v == last)
                {
                    level++;
                    last = tail;
                }
                if (level == 6) break;
            }
            return cal;
        }
        private static void SixDegrees(int n,int m)
        {
            for(int i = 0;i<=n-1;i++)
            {
                Visited = new bool[n];
                Q = new Queue();
                int cal = BFS(i);
                double percent = cal*100.0 / n;
                Console.WriteLine("{0}: {1:0.00}%", i + 1, percent);
            }
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int N = Convert.ToInt32(strs[0]);
            int M = Convert.ToInt32(strs[1]);
            
            BuildGraph(N, M);
            SixDegrees(N, M);
        }
    }
}

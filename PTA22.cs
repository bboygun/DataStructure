using System;

namespace PTA22
{
    class Program
    {
        private static int[,] CreatGraph(int n)
        {
            int[,] Graph = new int[n, n];
            for (int i = 0; i <= n - 1; i++)
                for (int j = 0; j <= n - 1; j++)
                    Graph[i, j] = int.MaxValue;
            for (int i = 0; i <= n - 1; i++) Graph[i, i] = 0;
            return Graph;
        }

        private static void InsertEdge(int[,] Graph,int s,int e,int weight)
        {
            Graph[s, e] = weight;
        }

        private static int FindSource(int[] before,bool[] visited)
        {
            int n = before.Length;
            int source = -1;
            for(int i = 0;i<=n-1;i++)
            {
                if(!visited[i]&&before[i]==0)
                {
                    visited[i] = true;
                    source = i;
                    break;
                }
            }
            return source;
        }

        private static void AOV(int[,] Graph)
        {
            int n = Graph.GetLength(0);
            int[] before = new int[n];
            int[] after = new int[n];

            for(int i =0;i<=n-1;i++)
            {
                for(int j = 0;j<=n-1;j++)
                {
                    if(i!=j)
                    {
                        if(Graph[i,j]<int.MaxValue)
                        {
                            after[i]++;
                            before[j]++;
                        }
                    }
                }
            }

            bool[] visited = new bool[n];
            int[] latest = new int[n];

            while(true)
            {
                int source = FindSource(before, visited);
                if (source == -1)
                    break;
                for(int i =0;i<=n-1;i++)
                {
                    if (i == source) continue;
                    if (Graph[source, i] < int.MaxValue) 
                    {
                        before[i]--;
                        if (latest[source] + Graph[source, i] > latest[i])
                        {
                            latest[i] = latest[source] + Graph[source, i];
                        }
                    }
                }
            }
            for(int i = 0;i<=n-1;i++)
            {
                if(!visited[i])
                {
                    Console.WriteLine("Impossible");
                    return;
                }
            }
            int time = -1;
            for(int i =0;i<=n-1;i++)
            {
                if (after[i] == 0)
                    if (latest[i] > time)
                        time = latest[i];
            }
            Console.WriteLine(time);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            int[,] Graph = BuildGraph();
            AOV(Graph);
        }

        private static int[,] BuildGraph()
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int n = Convert.ToInt32(strs[0]);
            int m = Convert.ToInt32(strs[1]);
            int[,] Graph = CreatGraph(n);
            for (int i = 1; i <= m; i++)
            {
                string str2 = Console.ReadLine();
                string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                int s = Convert.ToInt32(strs2[0]);
                int e = Convert.ToInt32(strs2[1]);
                int weight = Convert.ToInt32(strs2[2]);
                InsertEdge(Graph, s, e, weight);
            }
            return Graph;
        }
    }
}

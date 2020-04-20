using System;
using System.Collections;

namespace PTA15
{
    class Program
    {
        static bool[] Visited;
        static int[,] Graph;
        static Queue Q = new Queue();
        static void Main(string[] args)
        {
            ReadGraph();
            ListComponents();

        }

        private static void ListComponents()
        {
            Visited = new bool[Graph.GetLength(0)];
            for(int i =0;i<=Graph.GetLength(0)-1;i++)
            {
                if(!Visited[i])
                {
                    Console.Write("{ ");
                    DFS(i);
                    Console.Write("}\n");
                }
                
            }
            Visited = new bool[Graph.GetLength(0)];
            for (int i = 0; i <= Graph.GetLength(0) - 1; i++)
            {
                if (!Visited[i])
                {
                    Console.Write("{ ");
                    BFS(i);
                    Console.Write("}\n");
                }
            }
        }

        private static void DFS(int v)
        {
            Visited[v] = true;
            Console.Write("{0} ", v);
            for (int i = 0; i <= Graph.GetLength(0) - 1; i++)
            {
                if (i != v && Graph[v, i] == 1)
                {
                    if (!Visited[i])
                    {
                        DFS(i);

                    }
                }
            }
        }

        private static void BFS(int v)
        {
            Visited[v] = true;
            Console.Write("{0} ", v);
            Q.Enqueue(v);
            while(Q.Count!=0)
            {
                v = (int)Q.Dequeue();
                for(int w = 0;w<=Graph.GetLength(0)-1;w++)
                {
                    if(w!=v&&Graph[v,w]==1&&!Visited[w])
                    {
                        Visited[w] = true;
                        Console.Write("{0} ", w);
                        Q.Enqueue(w);
                    }
                }
            }
        }
        private static void ReadGraph()
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int n = Convert.ToInt32(strs[0]);
            int e = Convert.ToInt32(strs[1]);
            Graph = new int[n, n];
            for (int i = 1; i <= e; i++)
            {
                string edge = Console.ReadLine();
                string[] edges = edge.Split(new string[] { " " }, StringSplitOptions.None);
                int a = Convert.ToInt32(edges[0]);
                int b = Convert.ToInt32(edges[1]);
                Graph[a, b] = 1;
                Graph[b, a] = 1;
            }
            
        }
    }
}

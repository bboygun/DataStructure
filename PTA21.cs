using System;

namespace PTA21
{
    class Program
    {
        static int[,] Graph;

        private static int FindMinDist(int[] dist)
        {
            int minV = int.MaxValue;
            int V;
            int minDist = int.MaxValue;
            int n = Graph.GetLength(0);

            for(V=0;V<=n-1;V++)
            {
                if(dist[V]!=0&&dist[V]<minDist)
                {
                    minDist = dist[V];
                    minV = V;
                }
            }
            if (minDist < int.MaxValue) return minV;
            else return -1;
        }
        
        private static int Prim(int[,] MST)
        {
            int n = Graph.GetLength(0);
            int[] dist = new int[n];
            bool[] collected = new bool[n];
            int V, W;
            int totalWeight = 0;//总权重
            int VCount = 0;//计数
            int[] parent = new int[n];//记录每一条边放在哪棵树上
            

            for (V = 0; V <= n - 1; V++)
            {
                dist[V] = Graph[0, V];
                parent[V] = 0;
                collected[V] = false;
            }
                     

            dist[0] = 0;
            collected[0] = true;
            VCount++;
            parent[0] = -1;

            while(true)
            {
                V = FindMinDist(dist);
                if(V==-1)
                {
                    break;
                }
                int v1 = parent[V];
                int v2 = V;
                MST[v1, v2] = dist[V];
                MST[v2, v1] = dist[V];
                totalWeight += dist[V];
                dist[V] = 0;
                VCount++;
                
                for(W=0;W<=n-1;W++)
                {
                    if(dist[W]!=0&&Graph[V,W]<int.MaxValue)
                    {
                        if(Graph[V,W]<dist[W])
                        {
                            dist[W] = Graph[V, W];
                            parent[W] = V;
                        }
                    }
                }
            }
            if (VCount < n)
                totalWeight = -1;
            return totalWeight;

        }
        private static void BuildRoad(int n)
        {
            int[,] MST = new int[n,n];//将最小生成树保存在一个图里
            int totalWeight = Prim(MST);
            Console.WriteLine(totalWeight);
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int n = Convert.ToInt32(strs[0]);
            int m = Convert.ToInt32(strs[1]);
            Graph = new int[n, n];
            for(int i =1;i<=m;i++)
            {
                string str2 = Console.ReadLine();
                string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                int a = Convert.ToInt32(strs2[0])-1;
                int b = Convert.ToInt32(strs2[1])-1;
                int c = Convert.ToInt32(strs2[2]);
                Graph[a, b] = c;
                Graph[b, a] = c;
            }
            BuildRoad(n);
            Console.ReadKey();
        }
    }
}

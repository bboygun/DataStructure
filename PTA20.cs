using System;

namespace PTA20
{
    class Program
    {
        struct Edge
        {
            public int Distance;
            public int Cost;
        }
        static Edge[,] Graph;

        private static void BuildGraph(int n,int m)
        {
            Graph = new Edge[n,n];
            for (int i = 0; i <= n - 1; i++)
                for (int j = 0; j <= n - 1; j++)
                    if (i != j)
                    {
                        Graph[i, j].Distance = int.MaxValue;
                        Graph[i, j].Cost = int.MaxValue;
                    }
            for(int i = 0;i<=m-1;i++)
            {
                string str = Console.ReadLine();
                string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
                int a = Convert.ToInt32(strs[0]);
                int b = Convert.ToInt32(strs[1]);
                int distance = Convert.ToInt32(strs[2]);
                int cost = Convert.ToInt32(strs[3]);
                Graph[a, b].Distance = distance;
                Graph[b, a].Distance = distance;
                Graph[a, b].Cost = cost;
                Graph[b, a].Cost = cost;
            }

        }

        static int FindMinDist(Edge[,] Graph, int[] dist,int[] cost, bool[] collected )
        { /* 返回未被收录顶点中dist最小者 */
            int MinV = int.MaxValue;
            int V;
            int MinDist = int.MaxValue;
            int MinCost = int.MaxValue;

            for (V = 0; V < Graph.GetLength(0); V++)
            {
                if (collected[V] == false && dist[V] < MinDist)
                {
                    /* 若V未被收录，且dist[V]更小 */
                    MinDist = dist[V]; /* 更新最小距离 */
                    MinCost = cost[V];
                    MinV = V; /* 更新对应顶点 */
                }
                else if(collected[V]&&dist[V]==MinDist&&cost[V]<MinCost)
                {
                    /* 若V已被收录，且V的路径于当前最小路径相同，但费用较小 */
                    MinDist = dist[V]; /* 更新最小距离 */
                    MinCost = cost[V];
                    MinV = V; /* 更新对应顶点 */
                }
            }
            if (MinDist < int.MaxValue) /* 若找到最小dist */
                return MinV; /* 返回对应的顶点下标 */
            else return -1;  /* 若这样的顶点不存在，返回错误标记 */
        }

        static bool Dijkstra(Edge[,] Graph, int[] dist, int[] cost,int[] path, int S)
        {
            int n = Graph.GetLength(0);
            bool[] collected = new bool[n];
            int V, W;

            /* 初始化：此处默认邻接矩阵中不存在的边用INFINITY表示 */
            for (V = 0; V < Graph.GetLength(0); V++)
            {
                dist[V] = Graph[S,V].Distance;
                cost[V] = Graph[S, V].Cost;
                if (dist[V] < int.MaxValue)
                    path[V] = S;
                else
                    path[V] = -1;
                collected[V] = false;
            }
            /* 先将起点收入集合 */
            dist[S] = 0;
            cost[S] = 0;
            collected[S] = true;

            while (true)
            {
                /* V = 未被收录顶点中dist最小者 */
                V = FindMinDist(Graph, dist,cost,collected);
                if (V == -1) /* 若这样的V不存在 */
                    break;      /* 算法结束 */
                collected[V] = true;  /* 收录V */
                for (W = 0; W < Graph.GetLength(0); W++) /* 对图中的每个顶点W */
                    /* 若W是V的邻接点并且未被收录 */
                    if ( Graph[V,W].Distance < int.MaxValue)
                    {
                        if (Graph[V,W].Distance < 0) /* 若有负边 */
                            return false; /* 不能正确解决，返回错误标记 */
                        /* 若收录V使得dist[W]变小 */
                        //if (collected[V] == false)
                        //{
                        //    if (dist[V] + Graph[V, W].Distance < dist[W])
                        //    {
                        //        dist[W] = dist[V] + Graph[V, W].Distance; /* 更新dist[W] */
                        //        cost[W] = cost[V] + Graph[V, W].Cost;
                        //        path[W] = V; /* 更新S到W的路径 */
                        //    }
                        //}
                        //else
                        //{
                        //    if (dist[V] + Graph[V, W].Distance == dist[W])
                        //    {
                        //        if (cost[V] + Graph[V, W].Cost < cost[W])
                        //        {
                        //            cost[W] = cost[V] + Graph[V, W].Cost;
                        //            path[W] = V; /* 更新S到W的路径 */
                        //        }
                        //    }
                        //}
                        if (dist[V] + Graph[V, W].Distance < dist[W])
                        {
                            dist[W] = dist[V] + Graph[V, W].Distance; /* 更新dist[W] */
                            cost[W] = cost[V] + Graph[V, W].Cost;
                            path[W] = V; /* 更新S到W的路径 */
                        }
                        else if (dist[V] + Graph[V, W].Distance == dist[W])
                        {
                            if (cost[V] + Graph[V, W].Cost < cost[W])
                            {
                                cost[W] = cost[V] + Graph[V, W].Cost;
                                path[W] = V; /* 更新S到W的路径 */
                            }
                        }
                        
                    }
            } /* while结束*/
            return true; /* 算法执行完毕，返回正确标记 */
        }
        static void Main(string[] args)
        {
            int N, M, S, D;
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            N = Convert.ToInt32(strs[0]);
            M = Convert.ToInt32(strs[1]);
            S = Convert.ToInt32(strs[2]);
            D = Convert.ToInt32(strs[3]);
            BuildGraph(N, M);

            int[] dist = new int[N];
            int[] cost = new int[N];
            int[] path = new int[N];
            Dijkstra(Graph, dist, cost, path, S);

            //int totalDistance = 0;
            //int totalCost = 0;
            //while(S!=0)
            //{
            //    totalDistance+=
            //}
            Console.WriteLine("{0} {1}",dist[D],cost[D]);
            Console.ReadKey();
        }
    }
}

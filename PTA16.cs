using System;

namespace PTA16
{
    class Program
    {
        class Crocodile
        {
            public int x;
            public int y;

            public bool IfCanReach(Crocodile other,Double D)
            {
                return (Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y,2))<D);
            }

        }

        static int[,] Graph;
        static bool[] Visited;
        static Crocodile[] cros;

        private static void BuildGraph(Crocodile[] cros,double D)
        {
            int n = cros.Length;
            Graph = new int[n, n];
            for(int i = 1;i<=n-1;i++)
            {
                if(cros[0].IfCanReach(cros[i],D+15.0/2))
                {
                    Graph[0, i] = 1;
                    Graph[i, 0] = 1;
                }
            }
            for(int i = 1;i<=n-1;i++)
            {
                for(int j =1;j<=n-1;j++)
                {
                    if(i!=j)
                    {
                        if(cros[i].IfCanReach(cros[j],D))
                        {
                            Graph[i, j] = 1;
                            Graph[j, i] = 1;
                        }
                    }
                }
            }
        }

        private static bool IsSafe(int v,int D)
        {
            return (Math.Abs(Math.Abs(cros[v].x)-50) < D || Math.Abs(Math.Abs(cros[v].y) -50)< D);
        }

        private static bool DFS(int v,int D)
        {
            bool flag = false ;
            Visited[v] = true;
            if (IsSafe(v, D)) flag = true;
            else
            {
                for (int i = 0; i <= Graph.GetLength(0) - 1; i++)
                {
                    if (i != v && Graph[v, i] == 1)
                    {
                        if (!Visited[i])
                        {
                            flag = DFS(i,D);
                            if (flag) break;
                        }
                    }
                }
            }
            return flag;
        }
        private static void Save007(int D)
        {
            if (DFS(0, D)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int N = Convert.ToInt32(strs[0]);
            int D = Convert.ToInt32(strs[1]);
            cros = new Crocodile[N+1];
            cros[0] = new Crocodile { x = 0, y = 0 };
            for(int i = 1;i<=N;i++)
            {
                string str2 = Console.ReadLine();
                string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                cros[i]= new Crocodile { x = Convert.ToInt32(strs2[0]), y = Convert.ToInt32(strs2[1]) };
            }
            BuildGraph(cros,D);
            Visited = new bool[N + 1];
            Save007(D);
            Console.ReadKey();
        }
    }
}

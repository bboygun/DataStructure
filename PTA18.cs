using System;


namespace PTA18
{
    class Program
    {

        static int[,] Graph;


        private static void BuildGraph(int n, int m)
        {
            Graph = new int[n, n];
            for (int i = 0; i <= n - 1; i++)
                for (int j = 0; j <= n - 1; j++)
                    if (i != j) Graph[i, j] = 20000;
            for (int i = 1; i <= m; i++)
            {
                string str = Console.ReadLine();
                string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
                int a = Convert.ToInt32(strs[0]) - 1;
                int b = Convert.ToInt32(strs[1]) - 1;
                int weight = Convert.ToInt32(strs[2]);
                Graph[a, b] = weight;
                Graph[b, a] = weight;
            }
        }
        

        private static void Floyd()
        {
            for (int k = 0; k <= Graph.GetLength(0)-1; k++)
                for (int i = 0; i <= Graph.GetLength(0)-1; i++)
                    for (int j = 0; j <= Graph.GetLength(0)-1; j++)
                        if (Graph[i, j] > Graph[i, k] + Graph[k, j])
                            Graph[i, j] = Graph[i, k] + Graph[k, j];
        }

        private static void FindAnimal()
        {
            Floyd();
            int n = Graph.GetLength(0);
            int index1 = 0;
            int min = int.MaxValue;
            for (int i = 0;i<=n-1;i++)
            {
                int max = int.MinValue;
                for (int j = 0; j <= n - 1; j++)
                {
                    if (Graph[i, j] > max)
                    {
                        max = Graph[i, j];

                    }
                }
                if (max < min)
                {
                    min = max;
                    index1 = i;
                }
            }
            Console.WriteLine("{0} {1}", index1+1, min);

        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int N = Convert.ToInt32(strs[0]);
            int M = Convert.ToInt32(strs[1]);

            BuildGraph(N, M);
            FindAnimal();
            Console.ReadKey();
        }
    }
}

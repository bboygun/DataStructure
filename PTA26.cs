using System;

namespace PTA26
{
    class Program
    {
        private static void Insertion_Sort(int[] a, int[] b, int n)
        {
            bool flag = false;
            int p;
            for (p = 1; p <= n - 1; p++)
            {
                int tmp = a[p];
                int i;
                for (i = p; i > 0 && a[i - 1] > tmp; i--)
                {
                    a[i] = a[i - 1];
                }
                a[i] = tmp;
                bool equal = IfEqual(a, b, n);
                if (equal)
                {
                    Console.WriteLine("Insertion Sort");
                    flag = true;
                    continue;
                }
                if (flag)
                {
                    Console.Write(a[0]);
                    for (int j = 1; j <= n - 1; j++)
                        Console.Write(" {0}", a[j]);
                    break;
                }
            }
        }

        private static bool IfEqual(int[] a, int[] b, int n)
        {
            bool equal = true;
            for (int j = 0; j <= n - 1; j++)
            {
                if (a[j] != b[j])
                {
                    equal = false;
                    break;
                }
            }

            return equal;
        }

        private static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        private static void PercDown(int[] a, int p, int n)
        {
            int parent, child,x;
            x = a[p];
            for (parent = p; parent * 2 + 1 < n; parent = child)
            {
                child = parent * 2 + 1;
                if ((child != n - 1) && (a[child + 1] > a[child]))
                    child++;
                if (x > a[child]) break;
                else a[parent] = a[child];
            }
            a[parent] = x;
        }
        private static void Heap_Sort(int[] a, int[] b,int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)/* 建立最大堆 */
                PercDown(a, i, n);

            for (int i = n - 1; i > 0; i--)
            {
                /* 删除最大堆顶 */
                Swap(ref a[0], ref a[i]);
                PercDown(a, 0, i);
                if(IfEqual(a,b,n))
                {
                    i--;
                    Swap(ref a[0], ref a[i]);
                    PercDown(a, 0, i);
                    Console.WriteLine("Heap Sort");
                    Console.Write(a[0]);
                    for (int j = 1; j <= n - 1; j++)
                        Console.Write(" {0}", a[j]);
                    break;
                }
            }
        }

        private static void Judge(int[] a1, int[] a2, int n)
        {
            Insertion_Sort((int[])a1.Clone(), a2, n);
            Heap_Sort((int[])a1.Clone(), a2, n);
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            string str2 = Console.ReadLine();
            string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
            int[] a1 = new int[n];
            int[] a2 = new int[n];
            for (int i = 0; i <= n - 1; i++)
            {
                a1[i] = Convert.ToInt32(strs[i]);
                a2[i] = Convert.ToInt32(strs2[i]);
            }
            Judge(a1, a2, n);
        }
    }
}

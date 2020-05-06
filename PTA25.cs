using System;

namespace PTA25
{
    class Program
    {
        private static void Insertion_Sort(int[] a, int[] b,int n)
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

        private static void Merge1(int[] a, int[] tmpA, int l, int r, int rightEnd)
        {
            int leftEnd = r - 1;
            int tmp = l;
            int numElements = rightEnd - l + 1;
            while (l <= leftEnd && r <= rightEnd)
            {
                if (a[l] < a[r]) tmpA[tmp++] = a[l++];
                else tmpA[tmp++] = a[r++];
            }
            while (l <= leftEnd) tmpA[tmp++] = a[l++];
            while (r <= rightEnd) tmpA[tmp++] = a[r++];
        }

        private static void Merge_Pass(int[] a, int[] tmpA, int n, int length)
        {
            int i;
            for (i = 0; i <= n - 2 * length; i += 2 * length)
                Merge1(a, tmpA, i, i + length, i + 2 * length - 1);
            if (i + length < n)//最后i加上一个长度后还没到最右，表明有两个子列(最后一个字列长度不够length)
                Merge1(a, tmpA, i, i + length, n - 1);
            else//最后只剩一个子列,直接把最后一个子列导到tmpA里
                for (int j = i; j < n; j++) tmpA[j] = a[j];
        }
        private static void Merge_Sort_Loop(int[] a, int[] b,int n)
        {
            int length = 1;
            int[] tmpA = new int[n];
            while (length < n)
            {
                Merge_Pass(a, tmpA, n, length);
                length *= 2;
                if (IfEqual(tmpA,b,n))
                {
                    Console.WriteLine("Merge Sort");
                    Merge_Pass(tmpA, a, n, length);
                    Console.Write(a[0]);
                    for (int j = 1; j <= n - 1; j++)
                        Console.Write(" {0}", a[j]);
                    break;
                }
                
                Merge_Pass(tmpA, a, n, length);
                length *= 2;
                if (IfEqual(a, b, n))
                {
                    Console.WriteLine("Merge Sort");
                    Merge_Pass(a, tmpA, n, length);
                    Console.Write(tmpA[0]);
                    for (int j = 1; j <= n - 1; j++)
                        Console.Write(" {0}", tmpA[j]);
                    break;
                }
            }
        }
        private static void Judge(int[] a1,int[] a2,int n)
        {
            Insertion_Sort((int[])a1.Clone(), a2, n);
            Merge_Sort_Loop((int[])a1.Clone(), a2, n);
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
            for(int i = 0;i<=n-1;i++)
            {
                a1[i] = Convert.ToInt32(strs[i]);
                a2[i] = Convert.ToInt32(strs2[i]);
            }
            Judge(a1, a2, n);
        }
    }
}

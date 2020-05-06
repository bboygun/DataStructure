using System;


namespace PTA24
{
    class Program
    {
        private static void Swap(ref long a,ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }
        private static void Bubble_Sort(long[]a,int n)
        {
            int p;
            for(p=n-1;p>=0;p--)
            {
                int flag = 0;
                for(int i =0;i<=p-1;i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Swap(ref a[i], ref a[i + 1]);
                        flag = 1;
                    }
                }
                if (flag == 0) break;
            }
        }

        private static void Insertion_Sort(long[] a ,int n)
        {
            for(int p = 1;p<=n-1;p++)
            {
                long tmp = a[p];
                int i;
                for (i = p; i > 0 && a[i-1] > tmp; i--)
                {
                    a[i] = a[i-1];
                }
                a[i] = tmp;
            }
        }

        private static void Shell_Sort(long[] a,int n)
        {
            int d, p, i;
            for(d=n/2;d>0;d=d/2)
            {
                for(p=d;p<n;p++)
                {
                    long tmp = a[p];
                    for (i = p; i >= d && a[i - d] > tmp; i -= d)
                        a[i] = a[i - d];
                    a[i] = tmp;
                }
            }
        }

        private static void Shell_Sort_Sedgewick(long[] a, int n)
        {
            int[] s = new int[] { 587521, 260609, 146305, 64769, 36289, 16001, 8929, 3905, 2161, 929, 505, 209, 109, 41, 19, 5, 1, 0 };
            int p, i, si;
            for (si = 0; s[si] >= n; si++) { }
            for (int d = s[si]; d > 0; d=s[++si])
            {
                for (p = d; p < n; p++)
                {
                    long tmp = a[p];
                    for (i = p; i >= d && a[i - d] > tmp; i -= d)
                        a[i] = a[i - d];
                    a[i] = tmp;
                }
            }
        }

        private static int ScanForMin(long[] a,int i ,int n)
        {
            int minPosition=i;
            long min = a[i];
            for(int j = i;j<=n;j++)
            {
                if(a[j]<min)
                {
                    min = a[j];
                    minPosition = j;
                }
            }
            return minPosition;

        }
        private static void Selection_Sort(long[] a,int n)
        {
            for(int i =0;i<n;i++)
            {
                int minPosition = ScanForMin(a, i, n - 1);
                Swap(ref a[i], ref a[minPosition]);
            }
        }

        private static void PercDown(long[] a,int p ,int n)
        {
            int parent, child;
            long x;
            x = a[p];
            for(parent = p;parent*2+1<n;parent = child)
            {
                child = parent * 2 + 1;
                if ((child != n - 1) && (a[child + 1] > a[child]))
                    child++;
                if (x > a[child]) break;
                else a[parent] = a[child];
            }
            a[parent] = x;
        }
        private static void Heap_Sort(long[] a,int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)/* 建立最大堆 */
                PercDown(a, i, n);

            for (int i = n - 1; i > 0; i--)
            {
                /* 删除最大堆顶 */
                Swap(ref a[0], ref a[i]); 
                PercDown(a, 0, i);
            }
        }

        private static void Merge(long[] a ,long[] tmpA,int l,int r, int rightEnd)
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
            for(int i = 0;i<numElements;i++,rightEnd--)
            {
                a[rightEnd] = tmpA[rightEnd];
            }
        }

        private static void Merge1(long[] a, long[] tmpA, int l, int r, int rightEnd)
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

        private static void MSort_Recursion(long[] a,long[] tmpA,int l,int rightEnd)
        {
            int center;
            if(l<rightEnd)
            {
                center = (l + rightEnd) / 2;
                MSort_Recursion(a, tmpA, l, center);
                MSort_Recursion(a, tmpA, center + 1, rightEnd);
                Merge(a, tmpA, l, center + 1, rightEnd);
            }
        }
        private static void Merge_Sort_Recursion(long[] a, int n)
        {
            long[] tmpA = new long[n];
            MSort_Recursion(a, tmpA, 0, n-1);
        }

        private static void Merge_Pass(long[] a,long[] tmpA,int n,int length)
        {
            int i;
            for (i = 0; i <= n - 2 * length; i += 2 * length)
                Merge1(a, tmpA, i, i + length, i + 2 * length - 1);
            if (i + length < n)//最后i加上一个长度后还没到最右，表明有两个子列(最后一个字列长度不够length)
                Merge1(a, tmpA, i, i + length, n - 1);
            else//最后只剩一个子列,直接把最后一个子列导到tmpA里
                for (int j = i; j < n; j++) tmpA[j] = a[j];
        }
        private static void Merge_Sort_Loop(long[] a, int n)
        {
            int length = 1;
            long[] tmpA = new long[n];
            while(length<n)
            {
                Merge_Pass(a, tmpA, n, length);
                length *= 2;
                Merge_Pass(tmpA, a, n, length);
                length *= 2;
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            string[] inputs = input.Split(new string[] { " " }, StringSplitOptions.None);
            long[] a = new long[n];
            for(int i =0;i<=n-1;i++)
            {
                a[i] = Convert.ToInt64(inputs[i]);
            }

            //Bubble_Sort(a, n);
            //Insertion_Sort(a, n);
            //Shell_Sort(a, n);
            //Shell_Sort_Sedgewick(a, n);
            //Selection_Sort(a, n);
            //Heap_Sort(a, n);
            //Merge_Sort_Recursion(a, n);
            Merge_Sort_Loop(a, n);

            Console.Write(a[0]);
            for (int i = 1; i <= n - 1; i++)
                Console.Write(" " + a[i]);


        }
    }
}

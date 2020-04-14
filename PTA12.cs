using System;

namespace PTA12
{
    class Program
    {
        struct HNode
        {
            public int[] Data;
            public int Size;
            public int Capacity;
        }

        static HNode CreatMaxHeap(int MaxSize)
        {
            HNode H = new HNode();
            H.Data = new int[MaxSize + 1];
            H.Size = 0;
            H.Capacity = MaxSize;
            H.Data[0] = int.MaxValue;

            return H;
        }

        static HNode CreatMinHeap(int MaxSize)
        {
            HNode H = new HNode();
            H.Data = new int[MaxSize + 1];
            H.Size = 0;
            H.Capacity = MaxSize;
            H.Data[0] = int.MinValue;

            return H;
        }

        static bool IsFull(HNode H)
        {
            return (H.Size == H.Capacity);
        }

        static bool IsEmpty(HNode H)
        {
            return (H.Size == 0);
        }

        static bool InsertMax(HNode H,int x)
        {
            int i;
            if(IsFull(H))
            {
                Console.WriteLine("最大堆已满");
                return false;
            }
            i = ++H.Size;
            for (; H.Data[i / 2] < x; i /= 2) H.Data[i] = H.Data[i / 2];
            H.Data[i] = x;
            return true;
        }

        static bool InsertMin(HNode H, int x)
        {
            int i;
            if (IsFull(H))
            {
                Console.WriteLine("最小堆已满");
                return false;
            }
            i = ++H.Size;
            for (; H.Data[i / 2] > x; i /= 2) H.Data[i] = H.Data[i / 2];
            H.Data[i] = x;
            return true;
        }

        static int DeleteMax(HNode H)
        {
            int parent, child, maxItem, x;

            if(IsEmpty(H))
            {
                Console.WriteLine("最大堆已空");
                return -1;
            }

            maxItem = H.Data[1];
            x = H.Data[H.Size--];
            for(parent=1;parent*2<=H.Size;parent=child)
            {
                child = parent * 2;
                if ((child != H.Size) && (H.Data[child] < H.Data[child + 1]))
                    child++;
                if (x >= H.Data[child]) break;
                else H.Data[parent] = H.Data[child];
            }
            H.Data[parent] = x;
            return maxItem;
        }

        static int DeleteMin(HNode H)
        {
            int parent, child, minItem, x;

            if (IsEmpty(H))
            {
                Console.WriteLine("最小堆已空");
                return -1;
            }

            minItem = H.Data[1];
            x = H.Data[H.Size--];
            for (parent = 1; parent * 2 <= H.Size; parent = child)
            {
                child = parent * 2;
                if ((child != H.Size) && (H.Data[child] > H.Data[child + 1]))
                    child++;
                if (x <= H.Data[child]) break;
                else H.Data[parent] = H.Data[child];
            }
            H.Data[parent] = x;
            return minItem;
        }

        static void PercDownMax(HNode H, int p)
        {
            int parent, child, x;

            x = H.Data[p];
            for(parent=p;parent*2<=H.Size;parent=child)
            {
                child = parent * 2;
                if ((child != H.Size) && (H.Data[child] < H.Data[child + 1]))
                    child++;
                if (x >= H.Data[child]) break;
                else H.Data[parent] = H.Data[child];
            }
            H.Data[parent] = x;
        }

        static void PercDownMin(HNode H, int p)
        {
            int parent, child, x;

            x = H.Data[p];
            for (parent = p; parent * 2 <= H.Size; parent = child)
            {
                child = parent * 2;
                if ((child != H.Size) && (H.Data[child] > H.Data[child + 1]))
                    child++;
                if (x <= H.Data[child]) break;
                else H.Data[parent] = H.Data[child];
            }
            H.Data[parent] = x;
        }

        static void BuildHeapMax(HNode H)
        {
            int i;
            for (i = H.Size / 2; i > 0; i--)
                PercDownMax(H, i);
        }

        static void BuildHeapMin(HNode H)
        {
            int i;
            for (i = H.Size / 2; i > 0; i--)
                PercDownMin(H, i);
        }
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string[] strs1 = str1.Split(new string[] { " " }, StringSplitOptions.None);

            int n = Convert.ToInt32(strs1[0]);
            int m = Convert.ToInt32(strs1[1]);

            string str2 = Console.ReadLine();
            string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);

            HNode minHeap = CreatMinHeap(strs2.Length);
            
            //用插入的方法构建大顶堆，所得的大顶堆符合题目
            for(int i = 1;i<=n;i++)
            {
                int num = Convert.ToInt32(strs2[i - 1]);
                InsertMin(minHeap, num);
                minHeap.Size++;
            }
            
            //使用调整的方法来获取的大顶堆，所得的大顶堆不唯一
            /*
            for (int i = 1; i <= n; i++)
            {
                minHeap.Data[i] = Convert.ToInt32(strs2[i-1]);
                minHeap.Size++;
                
            }
            BuildHeapMin(minHeap);
            */
            

            string str3 = Console.ReadLine();
            string[] strs3 = str3.Split(new string[] { " " }, StringSplitOptions.None);
            int[] a = new int[strs3.Length];
            for (int i = 0; i <= a.Length - 1; i++)
            {
                string output = "";
                int index = Convert.ToInt32(strs3[i]);
                for (int j = index; j >= 1; j /= 2) output = string.Format(output + "{0} ", minHeap.Data[j]);
                output = output.Trim();
                Console.WriteLine(output);
            }
        }
    }
}

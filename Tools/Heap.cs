using System;

namespace Tools
{
    public static class Heap
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

        public static HNode CreatMinHeap(int MaxSize)
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

        static bool InsertMax(HNode H, int x)
        {
            int i;
            if (IsFull(H))
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

            if (IsEmpty(H))
            {
                Console.WriteLine("最大堆已空");
                return -1;
            }

            maxItem = H.Data[1];
            x = H.Data[H.Size--];
            for (parent = 1; parent * 2 <= H.Size; parent = child)
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
            for (parent = p; parent * 2 <= H.Size; parent = child)
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
        
    }
}

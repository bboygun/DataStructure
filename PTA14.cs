using System;

namespace PTA14
{
    class Program
    {
        class TreeNode
        {
            public int Weight;
            public string Word;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode()
            {
                Weight = int.MinValue;
                Word = null;
                Left = null;
                Right = null;
            }
        }
        class HNode
        {
            public TreeNode[] Data; /* 存储元素的数组 */
            public int Size;          /* 堆中当前元素个数 */
            public int Capacity;      /* 堆的最大容量 */

        };
 
        static HNode CreateMinHeap(int MaxSize)
        { /* 创建容量为MaxSize的空的最小堆 */

            HNode H = new HNode();
            TreeNode[] tmp = new TreeNode[MaxSize + 1];
            for(int i =0;i<=MaxSize;i++)
            {
                tmp[i] = new TreeNode();
            }
            H.Data = tmp;
            H.Size = 0;
            H.Capacity = MaxSize;
            H.Data[0].Weight = int.MinValue; /* 定义"哨兵"为小于堆中所有可能元素的值*/
 
            return H;
        }

        static HNode CreateMaxHeap(int MaxSize)
        { /* 创建容量为MaxSize的空的最大堆 */

            HNode H = new HNode();
            TreeNode[] tmp = new TreeNode[MaxSize + 1];
            for (int i = 0; i <= MaxSize; i++)
            {
                tmp[i] = new TreeNode();
            }
            H.Data = tmp;
            H.Size = 0;
            H.Capacity = MaxSize;
            H.Data[0].Weight = int.MaxValue; /* 定义"哨兵"为大于堆中所有可能元素的值*/

            return H;
        }

        static bool IsFull(HNode H)
        {
            return H.Size == H.Capacity;
        }

        static bool InsertMax(HNode H, TreeNode X)
        { /* 将元素X插入最大堆H，其中H.Data[0]已经定义为哨兵 */
            int i;

            if (IsFull(H))
            {
                Console.WriteLine("最大堆已满");
                return false;
            }
            i = ++H.Size; /* i指向插入后堆中的最后一个元素的位置 */
            for (; H.Data[i / 2].Weight < X.Weight; i /= 2)
                H.Data[i] = H.Data[i / 2]; /* 上滤X */
            H.Data[i] = X; /* 将X插入 */
            return true;
        }

        static bool InsertMin(HNode H, TreeNode X)
        { /* 将元素X插入最小堆H，其中H.Data[0]已经定义为哨兵 */
            int i;

            if (IsFull(H))
            {
                Console.WriteLine("最小堆已满");
                return false;
            }
            i = ++H.Size; /* i指向插入后堆中的最后一个元素的位置 */
            for (; H.Data[i / 2].Weight > X.Weight; i /= 2)
                H.Data[i] = H.Data[i / 2]; /* 上滤X */
            H.Data[i] = X; /* 将X插入 */
            return true;
        }


        static bool IsEmpty(HNode H)
        {
            return (H.Size == 0);
        }

        TreeNode DeleteMax(HNode H)
        { /* 从最大堆H中取出键值为最大的元素，并删除一个结点 */
            int Parent, Child;
            TreeNode MaxItem, X;

            if (IsEmpty(H))
            {
                Console.WriteLine("最大堆已为空");
                return null;
            }

            MaxItem = H.Data[1]; /* 取出根结点存放的最大值 */
            /* 用最大堆中最后一个元素从根结点开始向上过滤下层结点 */
            X = H.Data[H.Size--]; /* 注意当前堆的规模要减小 */
            for (Parent = 1; Parent * 2 <= H.Size; Parent = Child)
            {
                Child = Parent * 2;
                if ((Child != H.Size) && (H.Data[Child].Weight < H.Data[Child + 1].Weight))
                    Child++;  /* Child指向左右子结点的较大者 */
                if (X.Weight >= H.Data[Child].Weight) break; /* 找到了合适位置 */
                else  /* 下滤X */
                    H.Data[Parent] = H.Data[Child];
            }
            H.Data[Parent] = X;

            return MaxItem;
        }

        static TreeNode Deletemin(HNode H)
        { /* 从最大堆H中取出键值为最小的元素，并删除一个结点 */
            int Parent, Child;
            TreeNode minItem, X;

            if (IsEmpty(H))
            {
                Console.WriteLine("最小堆已为空");
                return null;
            }

            minItem = H.Data[1]; /* 取出根结点存放的最小值 */
            /* 用最小堆中最后一个元素从根结点开始向上过滤下层结点 */
            X = H.Data[H.Size--]; /* 注意当前堆的规模要减小 */
            for (Parent = 1; Parent * 2 <= H.Size; Parent = Child)
            {
                Child = Parent * 2;
                if ((Child != H.Size) && (H.Data[Child].Weight > H.Data[Child + 1].Weight))
                    Child++;  /* Child指向左右子结点的较小者 */
                if (X.Weight <= H.Data[Child].Weight) break; /* 找到了合适位置 */
                else  /* 下滤X */
                    H.Data[Parent] = H.Data[Child];
            }
            H.Data[Parent] = X;

            return minItem;
        }

        /*----------- 建造最大堆 -----------*/
        static void PercDownMax(HNode H, int p)
        { /* 下滤：将H中以H.Data[p]为根的子堆调整为最大堆 */
            int Parent, Child;
            TreeNode X;

            X = H.Data[p]; /* 取出根结点存放的值 */
            for (Parent = p; Parent * 2 <= H.Size; Parent = Child)
            {
                Child = Parent * 2;
                if ((Child != H.Size) && (H.Data[Child].Weight < H.Data[Child + 1].Weight))
                    Child++;  /* Child指向左右子结点的较大者 */
                if (X.Weight >= H.Data[Child].Weight) break; /* 找到了合适位置 */
                else  /* 下滤X */
                    H.Data[Parent] = H.Data[Child];
            }
            H.Data[Parent] = X;
        }

        static void PercDownMin(HNode H, int p)
        { /* 下滤：将H中以H.Data[p]为根的子堆调整为最小堆 */
            int Parent, Child;
            TreeNode X;

            X = H.Data[p]; /* 取出根结点存放的值 */
            for (Parent = p; Parent * 2 <= H.Size; Parent = Child)
            {
                Child = Parent * 2;
                if ((Child != H.Size) && (H.Data[Child].Weight > H.Data[Child + 1].Weight))
                    Child++;  /* Child指向左右子结点的较小者 */
                if (X.Weight <= H.Data[Child].Weight) break; /* 找到了合适位置 */
                else  /* 下滤X */
                    H.Data[Parent] = H.Data[Child];
            }
            H.Data[Parent] = X;
        }

        static void BuildHeapMax(HNode H)
        { /* 调整H.Data[]中的元素，使满足最大堆的有序性  */
        /* 这里假设所有H.Size个元素已经存在H.Data[]中 */

            int i;

        /* 从最后一个结点的父节点开始，到根结点1 */
            for (i = H.Size / 2; i > 0; i--)
                PercDownMax(H, i);
        }

        static void BuildHeapMin(HNode H)
        { /* 调整H.Data[]中的元素，使满足最小堆的有序性  */
            /* 这里假设所有H.Size个元素已经存在H.Data[]中 */

            int i;

            /* 从最后一个结点的父节点开始，到根结点1 */
            for (i = H.Size / 2; i > 0; i--)
                PercDownMin(H, i);
        }

        static string[] ReadFirstLine(HNode H)
        {
            int n = H.Data.Length-1;
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            for(int i = 0;i<=n-1;i++)
            {
                H.Data[i + 1].Word = strs[2*i];
                H.Data[i + 1].Weight = Convert.ToInt32(strs[2 * i + 1]);
                H.Size++;
            }
            return strs;
        }

        static TreeNode Huffman(HNode H)
        {
            int i;
            TreeNode T;
            BuildHeapMin(H);
            int n = H.Size;
            for(i = 1;i<n;i++)
            {
                T = new TreeNode();
                T.Left = Deletemin(H);
                T.Right = Deletemin(H);
                T.Weight = T.Left.Weight + T.Right.Weight;
                InsertMin(H, T);
            }
            T = Deletemin(H);
            return T;
        }

        static int WPL(TreeNode T,int Depth)
        {
            if (T.Left == null && T.Right == null)
                return (Depth * T.Weight);
            else
                return (WPL(T.Left, Depth + 1) + WPL(T.Right, Depth + 1));
        }

        class Coding
        {
            public string Word;
            public int Weight;
        }

        static void Check(int wpl, int cal, int n,string[] strs)
        {
            Coding[] inputs = new Coding[strs.Length / 2];
            for(int i = 0;i<=inputs.Length-1;i++)
            {
                inputs[i] = new Coding();
                inputs[i].Word = strs[2 * i];
                inputs[i].Weight = Convert.ToInt32(strs[2 * i + 1]);
            }
            string[] answer = new string[n];

            bool flag = false;
            for(int i=1;i<=cal;i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    answer[j] = Console.ReadLine();
                }
                if(flag=CheckWPL(wpl, n, inputs, answer))
                {
                    flag = CheckUnique(answer);
                }
                if (flag) Console.WriteLine("Yes");
                else Console.WriteLine("No");
            }
        }

        private static bool CheckUnique(string[] answer)
        {
            bool flag = false;
            TreeNode Tree = new TreeNode();
            for (int i = 0;i<=answer.Length-1;i++)
            {
                string[] answers = answer[i].Split(new string[] { " " }, StringSplitOptions.None);
                string word = answers[0];
                char[] code = answers[1].ToCharArray();
                TreeNode T = Tree;
                for (int j = 0;j<=code.Length-1;j++)
                {
                    if(code[j].Equals('0'))
                    {
                        if (T.Left == null)
                        {
                            T.Left = new TreeNode();
                            T = T.Left;
                        }
                        else if (T.Left.Word == null)
                            T = T.Left;
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    else if(code[j].Equals('1'))
                    {
                        if (T.Right == null)
                        {
                            T.Right = new TreeNode();
                            T = T.Right;
                        }
                        else if (T.Right.Word == null)
                            T = T.Right;
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(j==code.Length-1)
                    {

                        if (T.Right == null && T.Left == null&&T.Word==null)
                        {
                            flag = true;
                            T.Word = word;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                if (!flag) break;
            }
            return flag;
        }

        private static bool CheckWPL(int wpl, int n, Coding[] inputs, string[] answer)
        {
            int currentWPL = 0;
            for (int j = 0; j <= n - 1; j++)
            {

                string[] currentStrs = answer[j].Split(new string[] { " " }, StringSplitOptions.None);
                for (int k = 0; k <= inputs.Length - 1; k++)
                {
                    if (currentStrs[0].Equals(inputs[k].Word))
                    {
                        currentWPL += inputs[k].Weight * (currentStrs[1].Length);
                        break;
                    }
                }

            }
            if (currentWPL == wpl) return true;
            else return false;
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            HNode H = CreateMinHeap(n);
            string[] strs = ReadFirstLine(H);
            TreeNode T = Huffman(H);
            int wpl = WPL(T,0);
            int cal = Convert.ToInt32(Console.ReadLine());
            Check(wpl, cal, n, strs);
            Console.ReadKey();
            
        }
    }
}

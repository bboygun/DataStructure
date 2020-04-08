using System;

namespace PTA3
{
    struct item
    {
        public int key;
        public int next;
    }
    public class Program
    {
        static item[] list = new item[100000];
        static void Main(string[] args)
        {
            
            int ad, head, N, K;
            string str1 = Console.ReadLine();
            string[] strs1 = str1.Split(new string[] { " " }, StringSplitOptions.None);
            head = Convert.ToInt32(strs1[0]);
            N = Convert.ToInt32(strs1[1]);
            K = Convert.ToInt32(strs1[2]);
            for(int i = 0;i<N;i++)
            {
                string str2 = Console.ReadLine();
                string[] strs2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                ad = Convert.ToInt32(strs2[0]);
                list[ad].key = Convert.ToInt32(strs2[1]);
                list[ad].next = Convert.ToInt32(strs2[2]);
            }
            PrintLinkedList(ReversingLinkList(head, K));
            Console.ReadKey();
        }

        static void PrintLinkedList(int head)
        {
            int temp = head;
            for(;list[temp].next!=-1;temp=list[temp].next)
            {
                Console.WriteLine("{0:d5} {1} {2:d5}", temp, list[temp].key, list[temp].next);

            }
            Console.WriteLine("{0:d5} {1} {2}", temp, list[temp].key, list[temp].next);
        }

        static int ReversingLinkList(int head,int k)
        {
            int UnReversedHead = head;
            int ListHead;
            int TempTail;

            if (NeedReverse(UnReversedHead, k))
            {
                ListHead = Reverse(UnReversedHead, k);
                TempTail = UnReversedHead;
                UnReversedHead = list[TempTail].next;
            }
            else return head;

            while(NeedReverse(UnReversedHead,k))
            {
                list[TempTail].next = Reverse(UnReversedHead, k);
                TempTail = UnReversedHead;
                UnReversedHead = list[TempTail].next;
            }
            return ListHead;
        }
        static bool NeedReverse(int head,int k)
        {
            for(int i = 1;list[head].next!=-1;head = list[head].next)
            {
                i++;
                if (i == k) return true;
            }
            return false;
        }

        static int Reverse(int head,int k)
        {
            int New, Old, Tmp;
            int cnt = 1;
            New = head;
            Old = list[New].next;
            while(cnt<k)
            {
                Tmp = list[Old].next;
                list[Old].next = New;
                New = Old;
                Old = Tmp;
                cnt++;
            }
            list[head].next = Old;
            return New;
        }

    }
}

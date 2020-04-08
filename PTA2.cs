using System;

namespace PTA2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[10010];
            int n, ThisSum=0, MaxSum=-1, Minindex=0, Maxindex=0, Tempindex=0;
            n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] {" "},StringSplitOptions.None);
            for(int i = 0;i<= strs.Length-1;i++)
            {
                arr[i]=Convert.ToInt32(strs[i]);
                ThisSum+=arr[i];
                if(ThisSum>MaxSum)
                {
                    MaxSum=ThisSum;
                    Maxindex=i;
                    Minindex=Tempindex;
                }
                if(ThisSum<0)
                {
                    ThisSum=0;
                    Tempindex=i+1;
                }
            }
            if(MaxSum<0) Console.WriteLine("0 {0} {1}",arr[0],arr[n-1]);
            else Console.WriteLine("{0} {1} {2}",MaxSum,arr[Minindex],arr[Maxindex]);
        }
    }
}
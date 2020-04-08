using System;

namespace PTA1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int k;
            k = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] nums = str.Split(new string[]{" "},StringSplitOptions.None);
            int[] num = new int[k];
            for(int i = 0;i<=k-1;i++)
            {
    	        num[i] = Convert.ToInt32(nums[i]);
	        }
	
	        int maxSum = 0;
            int thisSum = 0;
            for(int i = 0;i<=k-1;i++)
            {
                thisSum = thisSum + num[i];
                if(thisSum<0) thisSum = 0;
                else
                {
                    if(thisSum>maxSum)
                    maxSum=thisSum;
                }
            }
	        Console.WriteLine("{0}",maxSum);
        }
    }
}

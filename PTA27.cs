using System;

namespace PTA27
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strs = str.Split(new string[] { " " }, StringSplitOptions.None);
            int[] ages = new int[51];
            foreach(string age in strs)
            {
                int tmp = Convert.ToInt32(age);
                ages[tmp]++;
            }
            for(int i = 0;i<=ages.Length-1;i++)
            {
                if (ages[i] != 0) Console.WriteLine("{0}:{1}", i, ages[i]);
            }
            Console.ReadKey();
        }
    }
}

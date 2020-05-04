using System;

namespace day04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            Solution sol = new Solution();
            int final = sol.FindComplement(number);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public int FindComplement(int num)
        {
            if (num == 0) return 1; // edge case

            int mask = 31;
            for (int i = 31; i >= 0; i--)
            {
                if ((num & (1 << i)) > 0)
                {
                    mask = i;
                    break;
                }
            }

            return num ^ ((1 << (mask + 1)) - 1);
        }
    }
}

using System;
using System.Linq;

namespace day15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.MaxSubarraySumCircular(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int MaxSubarraySumCircular(int[] A)
        {
            if (A.Length <= 1) return A[0];
            
            int sum = A.Sum();

            // ans 1 - answer for one-interval array
            int ans1 = int.MinValue;
            int current = int.MinValue;
            foreach (int x in A)
            {
                current = x + Math.Max(current, 0);
                ans1 = Math.Max(ans1, current);
            }

            // ans 2 - answer for two-interval subarray, interior in A[1:]
            int ans2 = int.MaxValue;
            current = int.MaxValue;
            for (int i = 1; i < A.Length; ++i)
            {
                current = A[i] + Math.Min(current, 0);
                ans2 = Math.Min(ans2, current);
            }
            ans2 = sum - ans2;

            // ans 3 - answer for two-interval subarray, interior in A[:-1]
            int ans3 = int.MaxValue;
            current = int.MaxValue;
            for (int i = 0; i < A.Length - 1; ++i)
            {
                current = A[i] + Math.Min(current, 0);
                ans3 = Math.Min(ans3, current);
            }

            return Math.Max(ans1, Math.Max(ans2, ans3));
        }
    }
}

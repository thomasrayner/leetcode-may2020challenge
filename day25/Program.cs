using System;
using System.Linq;

namespace day25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter A: ");
            int[] A = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();
            Console.Write("Enter B: ");
            int[] B = Console.ReadLine().Split(',').Select(n => int.Parse(n)).ToArray();

            Solution sol = new Solution();
            int final = sol.MaxUncrossedLines(A, B);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public int MaxUncrossedLines(int[] A, int[] B)
        {
            int[,] dp = new int[A.Length + 1, B.Length + 1];
            for (int i = 1; i <= A.Length; i++)
            {
                for (int j = 1; j <=B.Length; j++)
                {
                    if (A[i - 1] == B[j - 1])
                    {
                        dp[i,j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[A.Length, B.Length];
        }
    }
}

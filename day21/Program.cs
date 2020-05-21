using System;

namespace day21
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] test1 = new int[][] {
                new int[] {0,1,1,1},
                new int[] {1,1,1,1},
                new int[] {0,1,1,1}
            };

            int[][] test2 = new int[][] {
                new int[] {1, 0, 1},
                new int[] {1, 1, 0},
                new int[] {1, 1, 0}
            };

            Solution sol = new Solution();
            int res1 = sol.CountSquares(test1);
            int res2 = sol.CountSquares(test2);
            Console.WriteLine("One (15): " + res1.ToString() + " Two (7): " + res2.ToString());
        }
    }

    public class Solution
    {
        public int CountSquares(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] dp = new int[rows + 1][];

            for (int i = 0; i <= rows; i++)
            {
                dp[i] = new int[cols + 1];
            }

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        dp[i + 1][j + 1] = Math.Min(dp[i][j + 1], Math.Min(dp[i][j], dp[i + 1][j])) + 1;
                        count += dp[i + 1][j + 1];
                    }
                }
            }

            return count;
        }
    }
}

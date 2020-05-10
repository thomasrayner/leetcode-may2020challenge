using System;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int one = sol.FindJudge(2, new int[][] {new int[] {1, 2}}); //2
            int two = sol.FindJudge(3, new int[][] {new int[] {1, 3}, new int[] {2,3}}); //3
            int three = sol.FindJudge(3, new int[][] {new int[] {1, 3}, new int[] {2,3}, new int[] {3,1}}); //-1
            int four = sol.FindJudge(3, new int[][] {new int[] {1, 2}, new int[] {2,3}}); //-1
            Console.WriteLine("One (2):" + one.ToString());
            Console.WriteLine("Two (3):" + two.ToString());
            Console.WriteLine("Three (-1):" + three.ToString());
            Console.WriteLine("Four (-1):" + four.ToString());
        }
    }

    public class Solution
    {
        public int FindJudge(int N, int[][] trust)
        {
            if (N == 1 || trust.Length == 0)
            {
                return 1;
            }

            int[] trusts = new int[N + 1];
            int[] trustedBy = new int[N + 1];

            for (int i = 0; i < trust.Length; i++)
            {
                trusts[trust[i][0]]++;
                trustedBy[trust[i][1]]++;
            }

            for (int i = 0; i < trusts.Length; i++)
            {
                if (trustedBy[i] == N - 1 && trusts[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

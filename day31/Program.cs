using System;

namespace day31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Word one: ");
            string one = Console.ReadLine();
            Console.Write("Word two: ");
            string two = Console.ReadLine();
            Solution sol = new Solution();
            int final = sol.MinDistance(one, two);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public int MinDistance(string word1, string word2)
        {
            if (word1.Length == 0) return word2.Length;
            if (word2.Length == 0) return word1.Length;

            int length1 = word1.Length + 1;
            int length2 = word2.Length + 1;
            int[,] prog = new int[length1, length2];

            prog[0, 0] = 0;

            for (int i = 1; i < length1; i++)
            {
                prog[i, 0] = i;
            }

            for (int i = 1; i < length2; i++)
            {
                prog[0, i] = i;
            }

            for (int i = 1; i < length1; i++)
            {
                for (int j = 1; j < length2; j++)
                {
                    int min = Math.Min(prog[i - 1, j - 1], Math.Min(prog[i - 1, j], prog[i, j - 1]));
                    
                    if (word1[i - 1] == word2[j - 1])
                    {
                        prog[i, j] = prog[i - 1, j - 1];
                    }
                    else
                    {
                        prog[i, j] = min + 1;
                    }
                }

                return prog[length1 - 1, length2 - 1];
            }
        }
    }
}

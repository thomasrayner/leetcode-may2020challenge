using System;
using System.Linq;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Jewels: ");
            string jewels = Console.ReadLine();
            Console.Write("Stones: ");
            string stones = Console.ReadLine();

            Solution sol = new Solution();
            int final = sol.NumJewelsInStones(jewels, stones);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public int NumJewelsInStones(string J, string S)
        {
            char[] jewels = J.ToCharArray();
            int jewelCount = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (jewels.Contains(S[i]))
                {
                    jewelCount++;
                }
            }

            return jewelCount;
        }
    }
}

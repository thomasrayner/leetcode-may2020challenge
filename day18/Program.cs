using System;
using System.Collections.Generic;
using System.Linq;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s1: ");
            string s1 = Console.ReadLine();
            Console.Write("Enter s2: ");
            string s2 = Console.ReadLine();

            Solution sol = new Solution();
            bool final = sol.CheckInclusion(s1, s2);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            int[] delta = new int[26];
            int length = s1.Length;

            // analyze the target, how many of each char do we need?
            foreach (char c in s1)
            {
                delta[(int)c - (int)'a']++;
            }

            List<int> results = new List<int>();

            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];

                // decrement the current letter we've found
                delta[(int)c - (int)'a']--;

                if (i >= length)
                {
                    // if we're far enough into s that we might have a result, we have to undo
                    // the now irrelevant decrementation (slide the window)
                    delta[(int)s2[i - length] - (int)'a']++;
                }

                if (i >= length - 1 && delta.Where(x => x != 0).Count() == 0)
                {
                    // if we're far enough into s that we might have a result, and all the
                    // items in delta are 0, we have a result (we've used all the letters
                    // in p, without using any others)
                    // results.Add(i - (length - 1));
                    return true;
                }

            }

            return false;
        }
    }
}

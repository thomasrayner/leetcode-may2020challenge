using System;
using System.Collections.Generic;
using System.Linq;

namespace day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter S: ");
            string s = Console.ReadLine();
            Console.Write("Enter P: ");
            string p = Console.ReadLine();

            Solution sol = new Solution();
            IList<int> final = sol.FindAnagrams(s, p);
            Console.WriteLine("Final: " + string.Join(", ", final));
        }
    }

    public class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            int[] delta = new int[26];
            int length = p.Length;

            // analyze the target, how many of each char do we need?
            foreach (char c in p)
            {
                delta[(int)c - (int)'a']++;
            }

            List<int> results = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                // decrement the current letter we've found
                delta[(int)c - (int)'a']--;

                if (i >= length)
                {
                    // if we're far enough into s that we might have a result, we have to undo
                    // the now irrelevant decrementation (slide the window)
                    delta[(int)s[i - length] - (int)'a']++;
                }

                if (i >= length - 1 && delta.Where(x => x != 0).Count() == 0)
                {
                    // if we're far enough into s that we might have a result, and all the
                    // items in delta are 0, we have a result (we've used all the letters
                    // in p, without using any others)
                    results.Add(i - (length - 1));
                }

            }

            return results;
        }
    }
}

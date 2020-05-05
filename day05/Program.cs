using System;
using System.Collections.Generic;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("String: ");
            string userInput = "loveleetcode";//Console.ReadLine();
            Solution sol = new Solution();
            int final = sol.FirstUniqChar(userInput);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (charCount.TryGetValue(s[i], out int count))
                {
                    charCount[s[i]]++;
                }
                else
                {
                    charCount.Add(s[i], 1);
                }
            }

            foreach (KeyValuePair<char, int> entry in charCount)
            {
                if (entry.Value == 1)
                {
                    return s.IndexOf(entry.Key);
                }
            }

            return -1;
        }
    }
}

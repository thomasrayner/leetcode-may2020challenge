using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace day22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string s = Console.ReadLine();

            Solution sol = new Solution();
            string final = sol.FrequencySort(s);
            Console.WriteLine("Final: " + final);
        }
    }

    public class Solution
    {
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dict.TryGetValue(c, out int count))
                {
                    dict[c] = count + 1;
                }

                else
                {
                    dict.Add(c, 1);
                }
            }

            var sortedDict = from entry in dict orderby entry.Value descending select entry;

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<char, int> entry in sortedDict)
            {
                for (int i = 0; i < entry.Value; i++)
                {
                    sb.Append(entry.Key);
                }
            }

            return sb.ToString();
        }
    }
}

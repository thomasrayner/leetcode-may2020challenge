using System;
using System.Collections.Generic;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Note: ");
            string note = Console.ReadLine();
            Console.Write("Magazine: ");
            string mag = Console.ReadLine();

            Solution sol = new Solution();
            bool final = sol.CanConstruct(note, mag);
            Console.WriteLine("Final: " + final.ToString());
        }
    }

    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> noteDict = new Dictionary<char, int>();
            Dictionary<char, int> magDict = new Dictionary<char, int>();

            // Should make this into a method, but it's just for leetcode
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (noteDict.TryGetValue(ransomNote[i], out int count))
                {
                    noteDict[ransomNote[i]]++;
                }
                else
                {
                    noteDict.Add(ransomNote[i], 1);
                }
            }

            for (int i = 0; i < magazine.Length; i++)
            {
                if (magDict.TryGetValue(magazine[i], out int count))
                {
                    magDict[magazine[i]]++;
                }
                else
                {
                    magDict.Add(magazine[i], 1);
                }
            }

            foreach (KeyValuePair<char, int> entry in noteDict)
            {
                bool contained = magDict.TryGetValue(entry.Key, out int count);

                if (!contained || count < entry.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

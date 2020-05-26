using System;
using System.Linq;
using System.Collections.Generic;

namespace day26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.FindMaxLength(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> indexCountMap = new Dictionary<int, int>();
            int longestDistance = 0;
            int relativeCount = 0;

            // Initialize at the "spot before the array", ones relative to zeros is zero
            indexCountMap.Add(relativeCount, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                // If there is a one, increment the relative count, if there's a zero, decrement it
                // We don't care how many ones and zeros there are, just if the count of them is equal
                // So we're looking for indexes in the array that have the same relative count
                relativeCount += nums[i] == 1 ? 1 : -1;

                if (indexCountMap.ContainsKey(relativeCount))
                {
                    // If we've already seen this relative count, this is a candidate for the max length
                    // Because the 1:0 ratio is balanced with some other point in the array
                    // The new max length is either an already determined max length (because another
                    // Relative value occurs at further away points in the array), or the difference
                    // Between this current spot in the index, or the first occrence of this one
                    // We don't need to add this current instance of this relative count to the dictionary
                    // Because we only care about the distance between the first occurence of the relative
                    // Count and this most recent one - any instances of this count between the first and
                    // Last are inherently not as far away as the first and last instance
                    longestDistance = Math.Max(longestDistance, (i - indexCountMap[relativeCount]));
                }

                else 
                {
                    // We haven't seen this relative count before, so add it, identifying this spot as
                    // The first place we've seen this relative count
                    indexCountMap.Add(relativeCount, i);
                }
            }

            return longestDistance;
        }
    }
}

using System;
using System.Linq;

namespace day12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            int final = sol.SingleNonDuplicate(ints);
            Console.WriteLine(final.ToString());
        }
    }

    public class Solution
    {
        public int SingleNonDuplicate(int[] nums)
        {
            int length = nums.Length;
            int left = 0;
            int right = length;

            while (left < right)
            {
                int middle = left + (right - left) / 2;

                if (middle > 0 && nums[middle] == nums[middle - 1])
                {
                    if ((middle - 1) % 2 == 1)
                    {
                        right = middle - 1;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }

                else if ((middle + 1) < length && nums[middle] == nums[middle +1])
                {
                    if (middle % 2 == 1)
                    {
                        right = middle;
                    }
                    else
                    {
                        left = middle + 2;
                    }
                }

                else
                {
                    return nums[middle];
                }
            }

            return nums[left];
        }
    }
}

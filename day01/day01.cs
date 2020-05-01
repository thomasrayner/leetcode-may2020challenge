// From: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3316/
// Interactive problem that doesn't run outside leetcode

using System;

namespace day01
{
    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            int start = 0;
            int end = n;

            while (start < end)
            {
                int middle = start + (end - start) / 2;

                if (IsBadVersion(middle))
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return start;
        }
    }
}

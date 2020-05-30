using System;
using System.Linq;

namespace day30
{
    public class Solution
    {
        public int[][] KClosest(int[][] points, int K)
        {
            // in a hurry today
            return points.OrderBy(x => x[0] * x[0] + x[1] * x[1]).Take(K).ToArray();
        }
    }
}

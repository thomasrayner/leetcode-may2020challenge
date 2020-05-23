using System;
using System.Collections.Generic;

namespace day23
{
    public class Solution
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            List<int[]> answer = new List<int[]>();
            int i = 0, j = 0;

            while (i < A.Length && j < B.Length)
            {
                // check if A[i] intersects with B[j]
                // low = startpoint of intersection
                // high = endpoint of intersection
                int low = Math.Max(A[i][0], B[j][0]);
                int high = Math.Min(A[i][1], B[j][1]);

                if (low <= high)
                {
                    answer.Add(new int[] { low, high });
                }

                // remove the interval with the smallest endpoint
                if (A[i][1] < B[j][1])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return answer.ToArray();
        }
    }
}

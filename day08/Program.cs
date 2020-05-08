using System;

namespace day08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] goodSlope = new int[][] {
                    new int[] {1, 2},
                    new int[] {2, 3},
                    new int[] {3, 4},
                    new int[] {4, 5},
                    new int[] {5, 6},
                    new int[] {6, 7}
            };

            int[][] badSlope = new int[][] {
                new int[] {1,1},
                new int[] {2,2},
                new int[] {3,4},
                new int[] {4,5},
                new int[] {5,6},
                new int[] {7,7}
            };

            Solution sol = new Solution();
            bool goodSlopeCalc = sol.CheckStraightLine(goodSlope);
            bool badSlopeCalc = sol.CheckStraightLine(badSlope);
            Console.WriteLine("Good: " + goodSlopeCalc.ToString() + " Bad: " + badSlopeCalc.ToString());
        }
    }

    public class Solution
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length <= 2)
            {
                // if there are only two (or fewer) points, then the slope is inherently consistent
                return true;
            }

            double baselineSlope = (double)(Math.Abs(coordinates[0][1] - coordinates[1][1])) /
                (double)(Math.Abs(coordinates[0][0] - coordinates[1][0]));

            for (int i = 2; i < coordinates.Length; i++)
            {
                double currentSlope = (double)(Math.Abs(coordinates[0][1] - coordinates[i][1])) /
                    (double)(Math.Abs(coordinates[0][0] - coordinates[i][0]));
                
                if (baselineSlope != currentSlope)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

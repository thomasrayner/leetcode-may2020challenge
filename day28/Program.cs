using System;

namespace day28
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Solution sol = new Solution();
            int[] final = sol.CountBits(num);
            Console.WriteLine("Final: " + string.Join(", ", final));
        }
    }

    public class Solution
    {
        public int[] CountBits(int num)
        {
            // just in case they give us a negative number even though
            // they said they wouldn't
            if (num <= 0)
            {
                return new int[] {0};
            }

            long blockSize = 1;
            int[] result = new int[num + 1];

            // keep looping until we eventually hit our return statement
            while (true)
            {
                // counting the instances each number below the current blocksize
                for (int i = 0; i < blockSize; i++)
                {
                    result[i + blockSize] = 1 + result[i];
                    if (num == i + blockSize)
                    {
                        // we've gone as far as we need to go
                        return result;
                    }
                }

                // shift to the next bin slot
                blockSize <<= 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace day19
{
    public class StockSpanner
    {
        public Stack<(int price, int count)> StockStack { get; set; }

        public StockSpanner()
        {
            StockStack = new Stack<(int p, int c)>();
        }

        public int Next(int price)
        {
            int dayCount = 1;

            while (StockStack.Count > 0 && price >= StockStack.Peek().price)
            {
                dayCount += StockStack.Pop().count;
            }

            StockStack.Push((price, dayCount));
            return dayCount;
        }
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */
}

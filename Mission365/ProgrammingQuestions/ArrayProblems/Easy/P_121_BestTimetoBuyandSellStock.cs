using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.ArrayProblems.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// https://medium.com/algorithms-and-leetcode/best-time-to-buy-sell-stocks-on-leetcode-the-ultimate-guide-ce420259b323
    /// </summary>
    [TestClass]
    public class P_121_BestTimetoBuyandSellStock
    {
        [TestMethod]
        public void MyTestMethod()
        {
            int result = MaxProfit(new int[] { 1, 2, 3, 4 });
            string s = "anshuman";

        }
        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;
            int maxProfit = Int32.MinValue;
            int minStock = prices[0];
            foreach (int p in prices)
            {
                maxProfit = Math.Max(maxProfit, p - minStock);
                minStock = Math.Min(minStock, p);
            }
            return maxProfit;
        }

    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.ArrayProblems.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/product-of-array-except-self/
    /// </summary>
    [TestClass]
    public class P238_ProductofArrayExceptSelf
    {
        [TestMethod]
        public void MyTestMethod()
        {
            int[] result = ProductExceptSelf(new int[] { 1, 2, 3, 4 });

        }
        /// <summary>
        /// Note: Please solve it without division and in O(n). below solution is not without division
        /// i need to find solution without divide in O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int prod = 1;
            int countZero = 0;
            foreach (int item in nums)
            {
                if (item != 0)
                    prod *= item;
                else
                    countZero++;

            }
            if (countZero > 1)
            {
                return new int[nums.Length];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];
                if (countZero > 0)
                {
                    if (val == 0)
                        nums[i] = prod;
                    else
                        nums[i] = 0;
                }
                else
                {
                    nums[i] = prod / val;
                }

            }
            return nums;
        }
    }
}

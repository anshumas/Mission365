using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.ArrayProblems.Easy
{
    [TestClass]

    public class p1TwoSum
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var resut = TwoSum(new int[] { 2, 7, 3, 15 }, 9);
        }
        public int[] TwoSum(int[] nums, int target)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length - 1; i++)
            {

                for (int j = i + 1; j < nums.Length; j++)
                {

                    if (nums[i] + nums[j] == target)
                    {
                        result.Add(i);
                        result.Add(j);

                        return result.ToArray();
                    }
                }
            }
            return result.ToArray();
        }
    }
}

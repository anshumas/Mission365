using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Dictionary<int, int> dicNum = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dicNum.Keys.Contains(target - nums[i]))
                {
                    return new int[] { dicNum[target - nums[i]], i };
                }
                else
                {
                    dicNum.Add(nums[i], i);
                }
            }
            return new int[] { -1, -1 };
        }
        public int[] TwoSum_FirstSolution(int[] nums, int target)
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

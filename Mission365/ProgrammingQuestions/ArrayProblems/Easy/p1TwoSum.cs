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
            
            var resut = TwoSum(new int[] { 12, 13, 23, 28, 43, 44, 59, 60, 61, 68, 70, 86, 88, 92, 124, 125, 136, 168, 
            173, 173, 180, 199, 212, 221, 227, 230, 277, 282, 306, 314, 316, 321, 325, 328, 336, 337, 363, 365, 
            368, 370, 370, 371, 375, 384, 387, 394, 400, 404, 414, 422, 422, 427, 430, 435, 457, 493, 506, 527,
            531, 538, 541, 546, 568, 583, 585, 587, 650, 652, 677, 691, 730, 737, 740, 751, 755, 764, 778, 783, 
            785, 789, 794, 803, 809, 815, 847, 858, 863, 863, 874, 887, 896, 916, 920, 926, 927, 930, 933, 957, 981, 997
}, 542);
       
        
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
                else if (!dicNum.Keys.Contains(nums[i]))
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

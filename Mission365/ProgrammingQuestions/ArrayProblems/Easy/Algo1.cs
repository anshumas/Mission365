using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.ArrayProblems.Easy
{
    [TestClass]

    public class Algo1
    {
        [TestMethod]
        public void FirstBadVersionTest()
        {
            var resut = FirstBadVersion(2);
        }
        public int FirstBadVersion(int n)
        {
            int start = 1;
            int end = n;
            int index = 0;
            int target = 2;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (mid >= target)
                {
                    index = mid;
                    end = mid - 1;
                }
                else
                {

                    start = mid + 1;
                }
            }
            return index;
        }
        [TestMethod]
        public void RotateTest()
        {
            int[] nums = new int[] { -1, -100, 3, 99 };
            Rotate(nums, 14);
        }

        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            int r = k % len;
            int[] temp = new int[r];
            for (int i = 0; i < r; i++)
            {
                temp[i] = nums[len - r + i];
            }
            int t = 0;
            for (int i = len - r - 1; i >= 0; i--)
            {
                nums[len - 1 - t] = nums[i];
                t++;
            }
            for (int i = 0; i < r; i++)
            {
                nums[i] = temp[i];
            }

        }
        [TestMethod]
        public void MoveZeroesTest()
        {
            int[] nums = new int[] { 0, 0, 1 };
            MoveZeroes(nums);
        }
        public void MoveZeroes(int[] nums)
        {

            int len = nums.Length;
            int start = -1;

            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0 && start == -1)
                {
                    start = i;
                }
                else if (nums[i] != 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[start];
                    nums[start] = temp;
                    start++;
                }
            }


        }

    }
}

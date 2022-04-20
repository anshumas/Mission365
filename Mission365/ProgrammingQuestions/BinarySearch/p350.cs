using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p350
    {
        [TestMethod]
        public void IntersectTest()
        {
            int[] num1 = new int[] { 1, 2, 3, 4 };
            int[] num2 = new int[] { 1, 2 };
            var n = Intersect(num1, num2);


        }
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var lnum = nums1.Length > nums2.Length ? nums2 : nums1;
            var hnum = nums1.Length < nums2.Length ? nums2 : nums1;
            Dictionary<int, int> lmap = new Dictionary<int, int>();


            return nums1;

        }
    }


}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructureAlgorithm.DesignQuestions
{
    [TestClass]
    public class SortList
    {
        [TestMethod]
        public void MyTestMethod()
        {
            List<int> list = new List<int> { 9, 7, 5, 4, 2, 6, 7, 8, 2, 3, 4 };
            customSort cs = new customSort();
            list.Sort(0, 5, cs);

        }
        [TestMethod]
        public void MyTestMethod1()
        {
            List<int[]> list = new List<int[]> { new int[] {8,1 }, new int[] { 2, 1 }, new int[] { 4, 1 }, new int[] { 5, 2 } };
            customSort1 cs = new customSort1();
            var listArr = list.ToArray();
            Array.Sort(listArr, cs);


        }
    }
    public class customSort1 : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x[0] == 0 || y[0] == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return x[0].CompareTo(y[0]);
        }
    }
    public class customSort : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return x.CompareTo(y);
        }
    }
}

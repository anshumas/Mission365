using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.ArrayProblems.Medium
{
    [TestClass]
    public class P56MergeIntervals
    {
        [TestMethod]
        public void MyTestMethod()
        {
            List<int[]> input = new List<int[]>() {
                new int[]{2, 3 },
                new int[]{5, 5 },
                new int[]{2, 2 },
                new int[]{3, 4 },
                new int[]{3, 4 },
            };
            var r = Merge(input.ToArray());
            
        }
        public int[][] Merge(int[][] intervals)
        {

            SortedList<int, int> list = new SortedList<int, int>();
            foreach (int[] item in intervals)
            {
                if (list.ContainsKey(item[0]))
                {
                    if (list[item[0]] <= item[1])
                    {
                        list[item[0]] = item[1];
                    }
                }
                else
                {
                    list.Add(item[0], item[1]);
                }
            }
            int len = list.Count;
            List<int[]> result = new List<int[]>();
            int index = -1;
            KeyValuePair<int, int> prev = new KeyValuePair<int, int>();

            foreach (var item in list)
            {
                if (index == -1)
                {
                    result.Add(new int[] { item.Key, item.Value });
                    prev = item;
                    index++;
                }
                else if (prev.Value < item.Key)
                {
                    result.Add(new int[] { item.Key, item.Value });
                    prev = item;
                    index++;
                }
                else if (prev.Value < item.Value)
                {
                    result[index] = new int[] { prev.Key, item.Value };
                    prev = new KeyValuePair<int, int>(prev.Key, item.Value);
                }

            }

            Console.WriteLine(result.Count);
            return result.ToArray();

        }
    }
}

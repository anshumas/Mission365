using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p1647
    {
        [TestMethod]
        public void MyTestMethod()
        {
            string r = "abcabc";
            int r1 = MinDeletions(r);
        }
        public int MinDeletions(string s)
        {
            int[] chr = new int[26];
            foreach (char c in s.ToCharArray())
            {
                chr[c - 97]++;
            }
            Array.Sort(chr);
            int op = 0;

            for (int i = 25; i >=0 ; i--)
            {
                if (chr[i] > 0)
                {
                    int j = i - 1;
                    while (j >= 0)
                    {
                        if (chr[i ] == chr[j])
                        {
                            chr[j]--;
                            op++;

                        }
                        j--;
                    }
                    

                }
            }
            return op;
        }
    }
}

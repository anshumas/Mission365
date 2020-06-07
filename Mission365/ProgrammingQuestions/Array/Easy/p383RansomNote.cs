using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Array.Easy
{
    [TestClass]

    public class p383RansomNote
    {
        [TestMethod]
        public void MyTestMethod()
        {
            bool resut = CanConstruct("aa", "aab z");
        }
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] arr = new int[126];
            for (int i = 0; i < magazine.Length; i++)
            {
                int k = magazine[i] - 'a';
                arr[magazine[i] - 'a']++;
            }
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (--arr[ransomNote[i] - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;

        }
    }
}

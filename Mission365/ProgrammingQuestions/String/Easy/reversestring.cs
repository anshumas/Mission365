using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.String.Easy
{
    [TestClass]
    public class ReverseString
    {
        [TestMethod]
        public void MyTestMethod()
        {
            char[] r1 = ReverseAll(new char[] { 'h', 'i', ' ', 'a', 'm', ' ', 'd', 'e', 'v' });
            /*
             *'h', 'i', ' ', 'a', 'm', ' ', 'd', 'e', 'v'
             * 'd', 'e', 'v', ' ', 'a', 'm',  ' ', 'h', 'i'
             * 1-> 'd', 'e', 'v', 'a', 'm', ' ', 'd', 'h', 'i', 
             * 
             **/
        }
        public char[] ReverseAll(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            Reverse(s, left, right);
            int start = 0;
            for (int i = 0; i <= s.Length; i++)
            {
                if (i == s.Length || s[i] == ' ')
                {
                    left = start;
                    right = i - 1;
                    Reverse(s, left, right);
                    start = i + 1;
                }
            }
            return s;
        }
        public void Reverse(char[] s, int left, int right)
        {
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }


    }
}

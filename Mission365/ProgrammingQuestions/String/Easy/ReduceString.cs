using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.String.Easy
{
    [TestClass]
    public class ReduceString
    {
        [TestMethod]
        public void MyTestMethod()
        {
            //string r = ReduceStringSol1("aaabbbcccaaa");
            int r1 = Compress(new char[] { 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'c', 'c', 'c' });
        }
        public int CompressSol2(char[] chars)
        {
            Queue<char> charStack = new Queue<char>();
            Queue<int> intStack = new Queue<int>();
            int count = 1;
            for (int i = 0; i < chars.Length; i++)
            {
                if (i + 1 == chars.Length || chars[i + 1] != chars[i])
                {
                    charStack.Enqueue(chars[i]);
                    intStack.Enqueue(count);
                    count = 1;
                    continue;
                }
                count++;
            }
            int index = 0;
            while (charStack.Count > 0)
            {
                chars[index] = charStack.Dequeue();
                int stkcount = intStack.Dequeue();
                if (stkcount > 1)
                {
                    char[] countArr = stkcount.ToString().ToCharArray();
                    for (int i = 0; i < countArr.Length; i++)
                    {
                        chars[++index] = countArr[i];
                    }
                }
                index++;
            }
            return index;
        }
        public int Compress(char[] chars)
        {
            int pointer = 0, index = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (i + 1 == chars.Length || chars[i + 1] != chars[i])
                {
                    chars[index++] = chars[pointer];
                    if (i > pointer)
                    {
                        foreach (char c in ("" + (i - pointer + 1)).ToCharArray())
                        {
                            chars[index++] = c;
                        }
                    }
                    pointer = i + 1;
                }
            }
            return index;
        }
        private string ReduceStringSol2(string s)
        {
            StringBuilder result = new StringBuilder();
            char[] chrArray = (s + "$").ToCharArray();

            char current = chrArray[0];
            int count = 1;
            for (int i = 1; i < chrArray.Length; i++)
            {
                if (current != chrArray[i] && current != '$')
                {
                    result.Append(current).Append(count);
                    current = chrArray[i];
                    count = 1;
                    continue;
                }
                count++;
            }
            return result.ToString();
        }
        private string ReduceStringSol1(string s)
        {
            StringBuilder result = new StringBuilder();
            char[] chrArray = (s + "$").ToCharArray();

            char current = chrArray[0];
            int count = 1;
            for (int i = 1; i < chrArray.Length; i++)
            {
                if (current != chrArray[i] && current != '$')
                {
                    result.Append(current).Append(count);
                    current = chrArray[i];
                    count = 1;
                    continue;
                }
                count++;
            }
            return result.ToString();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.String.Easy
{
    [TestClass]
    public class countandsay
    {
        [TestMethod]
        public void MyTestMethod()
        {
            string result = CountAndSay(10);
            Assert.AreEqual("111221", result);
        }
        public string CountAndSay(int n)
        {

            string input = "1";
            for (int i = 1; i < n; i++)
            {
                input = CountAndSay(input);

            }
            return input.ToString();

        }
        public string CountAndSay(string n)
        {
            Queue<char> stk = new Queue<char>();
            string result = "";
            int count = 1;
            for(int i = 0; i < n.Length; i++)
            {
                if (stk.Count == 0)
                {
                    stk.Enqueue(n[i]);
                }
                else
                {
                    if(stk.Peek()== n[i])
                    {
                        count++;
                        if(i+1== n.Length)
                        {
                            result = result + count + stk.Peek();
                            stk.Dequeue();

                        }
                    }
                    else
                    {
                        result = result + count + stk.Peek();
                        stk.Dequeue();
                        stk.Enqueue(n[i]);
                        count = 1;
                    }
                }
            }
            while (stk.Count > 0)
            {
                result = result + 1 + stk.Dequeue();
            }

            return result;
        }
    }
}

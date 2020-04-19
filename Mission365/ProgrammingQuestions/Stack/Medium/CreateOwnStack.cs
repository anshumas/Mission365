using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.Stack.Medium
{
    [TestClass]
    public class CreateOwnStack
    {
        [TestMethod]
        public void MyTestMethod()
        {
            MinStack obj = new MinStack();
            //obj.Push(1);
            //obj.Push(2);
            //int param_1 = obj.Top();
            //int param_2 = obj.GetMin();
            //obj.Pop();
            //int param_4 = obj.GetMin();
            //int param_5 = obj.Top();
            

        }
    }
    public class MinStack
    {

        /** initialize your data structure here. */
        private Stack<int> stack = null;
        private Stack<int> minStack = null;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (minStack.Count <= 0 || x <= minStack.Peek()) minStack.Push(x);

        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                var value = stack.Pop();
                if (value == minStack.Peek()) minStack.Pop();
            }

        }

        public int Top()
        {
            return (stack.Count > 0) ? stack.Peek() : -1;
        }

        public int GetMin()
        {
            return (minStack.Count > 0) ? minStack.Peek() : -1;
        }
    }

}

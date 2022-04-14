using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p206
    {
        [TestMethod]
        public void ReverseListTest()
        {
            var l1 = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(3, new ListNode(3))
                        }
                    }
                }
            };

            var r = ReverseList(l1);
        }
        public ListNode ReverseList(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            ListNode proxy = head;
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }
            head = proxy;
            while (stack.Count > 0)
            {
                head.val = stack.Pop();
                head = head.next;
            }
            return proxy;
        }
    }


}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p234
    {
        [TestMethod]
        public void IsPalindromeTest()
        {
            var l1 = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(1)
                        }
                    }
                }
            };

            var r = IsPalindrome(l1);
        }
        public bool IsPalindrome(ListNode head)
        {

            ListNode proxy = head;

            Stack<int> stack = new Stack<int>();

            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }
            while (stack.Count > 0 && proxy != null)
            {
                if (proxy.val != stack.Pop()) return false;
                proxy = proxy.next;
            }

            return true;
        }
        public bool IsPalindrome1(ListNode head)
        {
            ListNode orignal = new ListNode();
            ListNode temp = orignal;
            ListNode proxy = head;
            while (head != null)
            {
                temp.val = head.val;
                if (head.next != null)
                {
                    temp.next = new ListNode();
                    temp = temp.next;
                }
                head = head.next;
            }

            head = proxy;
            proxy = head;
            Stack<int> stack = new Stack<int>();

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
            while (orignal != null && proxy != null)
            {
                if (orignal.val != proxy.val)
                {
                    return false;
                }
                orignal = orignal.next;
                proxy = proxy.next;
            }
            return true;
        }
    }


}

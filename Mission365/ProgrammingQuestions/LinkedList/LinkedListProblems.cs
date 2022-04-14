using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.LinkedList.Medium
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    [TestClass]
    public class LinkedListProblems
    {
        [TestMethod]
        public void MyTestMethod()
        {
            ListNode input = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };
            RemoveNthFromEnd(input, 2);
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode p = head;
            int len = 0;
            while (p != null)
            {
                p = p.next;
                len++;
            }
            int delete = len - n;
            p = head;
            ListNode prev = null;
            int i = 0;
            while (i < delete)
            {
                prev = p;
                p = p.next;
                i++;
            }
            if (p == head)
            {
                head = head.next;
            }
            else if (prev != null)
            {
                prev.next = p.next;
            }

            return head;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            Queue<int> que = new Queue<int>();
            ListNode p = head;
            int count = 0;
            while (p != null)
            {
                que.Enqueue(p.val);
                p = p.next;
                count++;
            }
            int nth = count - n + 1;
            head = new ListNode();
            ListNode r = head;
            int i = 0;
            while (que.Count > 0)
            {
                i++;
                if (nth == i)
                {
                    que.Dequeue();
                }
                else
                {
                    r.next = new ListNode(que.Dequeue());
                    r = r.next;
                }


            }
            return head.next;
        }
    }
}

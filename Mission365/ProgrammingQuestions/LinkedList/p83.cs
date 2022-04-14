using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p83
    {
        [TestMethod]
        public void DeleteDuplicatesTest()
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

            var r = DeleteDuplicates(l1);
        }
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return head;
            ListNode curr = head;
            while (curr != null)
            {
                if (curr.next != null && curr.val == curr.next.val)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }

            }
            return head;
        }
    }


}

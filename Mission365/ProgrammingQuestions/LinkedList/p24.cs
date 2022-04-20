using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p24
    {
        [TestMethod]
        public void HasCycleTest()
        {
            var l2 = new ListNode(2);
            var l3 = new ListNode(3);
            var l4 = new ListNode(4);
            var l1 = new ListNode(1)
            {
                next = l2
            };
            l2.next = l3;
            l3.next = l4;
            l4.next = null;


            var r = SwapPairs(l1);
        }
        public ListNode SwapPairs(ListNode head)
        {
            var dummy = new ListNode(-1);
            var prev = dummy;
            var current = head;
            while (current != null)
            {
                var first = current;
                var sec = current.next;
                //swap
                prev.next = sec;
                first.next = sec.next;
                sec.next = first;

                prev = first;
                current = first.next;

            }
            return dummy.next;
        }
    }


}

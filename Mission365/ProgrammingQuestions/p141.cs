using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p141
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
            l4.next = l2;
            

            var r = HasCycle(l1);
        }
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var fast = head;
            while (fast != null && fast.next != null)
            {
                head = head.next;
                fast = fast.next.next;
                if (head == fast) return true;
            }
            return false;
        }
    }


}

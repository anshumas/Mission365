using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p2
    {
        [TestMethod]
        public void AddTwoNumbersTest()
        {
            string r = "abcabc";
            var l1 = new ListNode()
            {
                val = 2,
                next = new ListNode()
                {
                    val = 4,
                    next = new ListNode()
                    {
                        val = 3
                    }
                }
            };
            var l2 = new ListNode()
            {
                val = 5,
                next = new ListNode()
                {
                    val = 6,
                    next = new ListNode()
                    {
                        val = 4
                    }
                }
            };
            var r1 = AddTwoNumbers(l1, l2);
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(); 
            ListNode curr = head; 
            int carry = 0; 
            while (l1 != null || l2 != null || carry == 1)
            {
                int sum = 0; 
                if (l1 != null)
                { 
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                { 
                    sum += l2.val;
                    l2 = l2.next;
                }
                sum += carry; 
                carry = sum / 10; 
                ListNode node = new ListNode(sum % 10); 
                curr.next = node; 
                curr = curr.next; 
            }
            return head.next; 
        }
    }
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
    
}

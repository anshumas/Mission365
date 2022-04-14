using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions
{
    [TestClass]
    public class p203
    {
        [TestMethod]
        public void RemoveElementsTest()
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

            var r = RemoveElements(l1,1);
        }
        public ListNode RemoveElements(ListNode head, int val)
        {

            var work = new ListNode(0, head);
            var save = work;

            while (work.next != null)
            {
                if (work.next.val == val)
                {
                    work.next = work.next.next;
                }
                else
                {
                    work = work.next;
                }
            }
            return save.next;

        }
    }


}

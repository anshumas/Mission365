using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mission365.ProgrammingQuestions.LinkedList.Hard
{
    /// <summary>
    /// https://leetcode.com/problems/merge-k-sorted-lists/
    /// </summary>
    [TestClass]
    public class P_23_MergekSortedLists
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        [TestMethod]
        public void MergekSortedListsTest()
        {
            List<int[]> arr = new List<int[]> { new int[] { 1, 4, 5 }, new int[] { 1, 3, 4 }, new int[] { 2, 6 } };

            List<ListNode> input = new List<ListNode>();
            foreach (var item in arr)
            {
                ListNode head = new ListNode(0);
                ListNode current = head;
                for (int i = 0; i < item.Length; i++)
                {
                    ListNode nd = new ListNode(item[i]);
                    current.next = nd;
                    current = current.next;
                }
                input.Add(head.next);
            }
            var result = MergeKLists(input.ToArray());
        }
        /// <summary>
        /// this is recursive with merge approach order of nk^2, need to optimize with min heap priorit queue
        /// this approach is fine only for brute force but not final solution.
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeKLists(lists, lists.Length);
        }
        public ListNode MergeKLists(ListNode[] lists, int len)
        {

            if (len == 0)
            {
                return null;
            }
            if (len == 1)
            {
                return lists[0];
            }
            int left = 0;
            int right = len - 1;

            ListNode leftNode;
            ListNode rightNode;

            while (left < right)
            {
                ListNode result = new ListNode(0);
                leftNode = lists[left];
                rightNode = lists[right];
                ListNode current = result;
                while (leftNode != null || rightNode != null)
                {
                    int val;
                    if (leftNode == null && rightNode != null)
                    {
                        val = rightNode.val;
                        rightNode = rightNode.next;
                    }
                    else if (leftNode != null && rightNode == null)
                    {
                        val = leftNode.val;
                        leftNode = leftNode.next;
                    }
                    else if (leftNode.val <= rightNode.val)
                    {
                        val = leftNode.val;
                        leftNode = leftNode.next;
                    }
                    else
                    {
                        val = rightNode.val;
                        rightNode = rightNode.next;
                    }
                    current.next = new ListNode(val);
                    current = current.next;
                }
                lists[left] = result.next;
                left++;
                lists[right] = null;
                right--;
                len--;
            }
            return MergeKLists(lists, len); ;
        }
    }
}

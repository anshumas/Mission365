using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.BinaryTree
{
    [TestClass]
    public class BinaryTreeTest
    {
        /// <summary>
        /// 33. Search in Rotated Sorted Array
        /// https://leetcode.com/problems/search-in-rotated-sorted-array/
        /// </summary>
        [TestMethod]
        public void MyTestMethod()
        {
            int result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 4);
            Assert.AreEqual(result, 0);
        }
        public int Search(int[] nums, int target)
        {
            int index = FindIndex(nums);
            int left = FindTarget(nums, 0, index, target);
            int right = FindTarget(nums, index + 1, nums.Length - 1, target);
            return Math.Max(left, right);
        }
        private int FindTarget(int[] nums, int low, int high, int target)
        {

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] < target)
                    low = mid + 1;
                if (nums[mid] > target)
                    high = mid - 1;

            }
            return -1;
        }
        private int FindIndex(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (arr[mid] > arr[mid + 1])
                    return mid;
                if (arr[mid] < arr[mid - 1])
                    return (mid - 1);
                if (arr[low] >= arr[mid])
                    high = mid - 1;
                else
                    low = mid + 1;

            }
            return -1;
        }
        /// <summary>
        /// https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
        /// </summary>
        [TestMethod]
        public void ConnectTest()
        {
            Node root = new Node(1)
            {
                left = new Node(2)
                {
                    left = new Node(4) { left = new Node(8) },
                    right = new Node(5)
                },
                right = new Node(3)
                {
                    left = new Node(6),
                    right = new Node(7)
                },
            };
            Connect(root);
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            Node pre = null;

            while (q.Count > 0)
            {
                pre = null;
                for (int j = 0, sz = q.Count; j < sz; j++)
                {
                    Node nd = q.Dequeue();
                    nd.next = pre;
                    pre = nd;
                    if (nd.right != null) q.Enqueue(nd.right);
                    if (nd.left != null) q.Enqueue(nd.left);
                }
            }

            return root;
        }
        public void ConnectTree(Node root, int level)
        {

            // return maxdia;
        }
        private int GetHeight(Node root)
        {
            if (root == null) return 0;
            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;
            public Node(int x) { val = x; }
        }
        /// <summary>
        /// https://leetcode.com/problems/combinations/
        /// </summary>
        [TestMethod]
        public void CombineTest()
        {

            var result = Combine(4, 2);
        }
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (k == 0)
            {
                result.Add(new List<int>());
                return result;
            }
            Combinations(1, new List<int>(), n, k, result);
            return result;
        }
        public void Combinations(int start, IList<int> current, int n, int k, IList<IList<int>> result)
        {
            if (current.Count == k)
            {
                result.Add(new List<int>(current));
            }
            for (int i = start; i <= n && current.Count < k; i++)
            {
                current.Add(i);
                Combinations(i + 1, current, n, k, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}

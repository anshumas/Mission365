using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// https://leetcode.com/problems/permutations/
        /// </summary>
        [TestMethod]
        public void PermuteTest()
        {
            string s = "ABC";
            var result = Permute(new int[] { 1, 2, 3 });
        }
        public List<List<int>> Permute(int[] s)
        {
            List<List<int>> result = new List<List<int>>();
            Permute(s.ToList(), 0, s.Length - 1, result);

            return result;
        }
        public void Permute(List<int> str, int l, int r, List<List<int>> result)
        {
            if (l == r)
            {
                result.Add(str);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    Permute(str, l + 1, r, result);
                    str = swap(str, l, i);
                }
            }
        }
        public static List<int> swap(List<int> a, int i, int j)
        {
            if (i == j) return a;
            int temp;
            temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            return new List<int>(a);
        }
        /// <summary>
        /// https://leetcode.com/problems/permutations/
        /// </summary>
        [TestMethod]
        public void PermuteTest3()
        {
            string s = "ABC";
            var result = Permute3(s);
        }
        public List<string> Permute3(string s)
        {
            List<string> result = new List<string>();
            Permute3(s, 0, s.Length - 1, result);

            return result;
        }
        public void Permute3(string str, int l, int r, List<string> result)
        {
            if (l == r)
            {
                result.Add(str);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap3(str, l, i);
                    Permute3(str, l + 1, r, result);
                    str = swap3(str, l, i);
                }
            }
        }
        public static string swap3(string a,
                              int i, int j)
        {
           
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
        /// <summary>
        /// https://leetcode.com/problems/permutations/
        /// </summary>
        [TestMethod]
        public void Permute1Test()
        {

            var result = Permute1(new int[] { 1, 2, 3 });
        }
        IList<IList<int>> Permutes = new List<IList<int>>();

        public IList<IList<int>> Permute1(int[] nums)
        {
            GetPermute(new List<int>(), nums);

            return Permutes;
        }

        private void GetPermute(List<int> list, int[] nums)
        {
            List<int> tempList = null;

            if (list.Count != nums.Length)
            {
                for (int i = 0; i <= nums.Length - 1; i++)
                {
                    if (!list.Contains(nums[i]))
                    {
                        tempList = new List<int>(list);
                        tempList.Add(nums[i]);
                        GetPermute(tempList, nums);
                    }
                }
            }
            else
                Permutes.Add(list);
        }

        public IList<IList<int>> Permute2(int[] nums)
        {
            var result = new List<IList<int>>();
            var fact = new[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800 };
            for (int i = 1; i <= fact[nums.Length]; i++)
            {
                result.Add(Perms(i, nums, fact));
            }
            return result;
        }

        public List<int> Perms(int n, int[] s, int[] fact)
        {
            var sb = new List<int>();
            var s2 = s.ToList();
            n--;
            for (int sl = s2.Count; sl > 0; sl--)
            {
                int g = fact[sl];
                n = n % (g);
                int i = (int)Math.Floor((double)n / (g / sl));
                sb.Add(s2[i]);
                s2.RemoveAt(i);
            }
            return sb;
        }
    }
}


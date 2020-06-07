using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.BinarySearchTree
{
    [TestClass]
    public class MyTestClass
    {

        [TestMethod]
        public void MyTestMethod()
        {
            TreeNode result = BstFromPreorder(new int[] { 8, 5, 1, 7, 10, 12 });
        }
        int index = 0;
        int len = 0;
        int[] preorder;
        public TreeNode BstFromPreorder(int[] preorder)
        {
            this.preorder = preorder;
            this.len = preorder.Length;
            return BstFromPreorder(Int32.MinValue, Int32.MaxValue);
        }
        private TreeNode BstFromPreorder(int lo,int hi)
        {
            if (index == len) return null;

            int val = preorder[index];
            if (val < lo || val > hi) return null;

            index++;
            TreeNode root = new TreeNode(val);
            root.left = BstFromPreorder(lo, val);
            root.right = BstFromPreorder(val, hi);
            return root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}

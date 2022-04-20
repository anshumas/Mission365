using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAlgorithm.ProgrammingQuestions.BinaryTree.Easy
{
    [TestClass]
    public class DiameterofBinaryree
    {/// <summary>
     /// https://leetcode.com/problems/diameter-of-binary-tree/
     /// </summary>
        [TestMethod]
        public void MyTestMethod()
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2) { left = new TreeNode(4) { left = new TreeNode(8) }, right = new TreeNode(5) },
                right = new TreeNode(3) { left = new TreeNode(6), right = new TreeNode(7) },
            };
            int result = DiameterOfBinaryTree(root);
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int maxdia = 0;
            maxdia = DiameterOfBinaryTree(root, ref maxdia);
            return maxdia;

        }
        public int DiameterOfBinaryTree(TreeNode root, ref int maxdia)
        {
            if (root == null) return 0;
            int leftheight = getHeight(root.left);
            int rightheight = getHeight(root.right);
            int dia = leftheight + rightheight + 1;
            maxdia = Math.Max(maxdia, dia);
            int leftdia = DiameterOfBinaryTree(root.left, ref maxdia);
            int rightdia = DiameterOfBinaryTree(root.right, ref maxdia);

            dia=  Math.Max(leftdia, rightdia);
            maxdia = Math.Max(maxdia, dia);
            return maxdia;
        }
        private int getHeight(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(getHeight(root.left), getHeight(root.right)) + 1;
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

    }
}

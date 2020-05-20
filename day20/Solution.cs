using System;
using System.Collections.Generic;

namespace day20
{
    //  Definition for a binary tree node.
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

    public class Solution
    {
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> nums = InOrder(root, new List<int>());
            return nums[k - 1];
        }

        private List<int> InOrder(TreeNode root, List<int> list)
        {
            if (root == null) return list;

            // in-order traversal
            InOrder(root.left, list);
            list.Add(root.val);
            InOrder(root.right, list);

            return list;
        }
    }
}

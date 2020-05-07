// From: https://leetcode.com/explore/challenge/card/may-leetcoding-challenge/534/week-1-may-1st-may-7th/3322/
// Interactive problem that doesn't run outside leetcode

using System;
using System.Collections.Generic;

namespace day07
{
    // Definition for a binary tree node.
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
        public bool IsCousins(TreeNode root, int x, int y)
        {
            TreeNode xParent = null, yParent = null, item = null;
            int xLvl = -1, yLvl = -1;
            int lvl = -1;
            var treeQueue = new Queue<Tuple<TreeNode, int, TreeNode>>();

            // Tuple is the item being checked, the current level, and the item being checked's parent
            treeQueue.Enqueue(Tuple.Create(root, 0, item));

            while (treeQueue.Count > 0)
            {
                var cur = treeQueue.Dequeue();
                lvl = cur.Item2;
                item = cur.Item1;

                if (item == null)
                {
                    continue;
                }

                if (item.val == x)
                {
                    xParent = cur.Item3;
                    xLvl = lvl;
                }

                if (item.val == y)
                {
                    yParent = cur.Item3;
                    yLvl = lvl;
                }

                // if we found nodes that match both x and y, return if they're on the same
                // level with different parents
                if (xLvl > -1 && yLvl > -1)
                {
                    return xLvl == yLvl && xParent != yParent;
                }

                // otherwise, queue up the left and right elements of this node
                treeQueue.Enqueue(Tuple.Create(item.left, lvl + 1, item));
                treeQueue.Enqueue(Tuple.Create(item.right, lvl + 1, item));
            }

            // if we hit this, it should always return false
            return xLvl == yLvl && xParent != yParent;
        }
    }
}

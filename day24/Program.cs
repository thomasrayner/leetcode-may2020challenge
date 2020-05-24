using System;

namespace day24
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an array to check: ");
            string intString = Console.ReadLine();
            int[] ints = intString.Split(',').Select(n => int.Parse(n)).ToArray();

            var sol = new Solution();
            TreeNode final = sol.BstFromPreorder(ints);

            // It doesn't appear that the output is preorder, inorder, or postorder, and
            // it seems like a hassle to figure out, but the answer was accepted 🤷‍♂️
        }
    }

    /**
 * Definition for a binary tree node.
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

    }

    public class Solution
    {
        private TreeNode root {get; set;}
        public TreeNode BstFromPreorder(int[] preorder)
        {
            // the root node's value is the first item in the array
            root = new TreeNode(preorder[0]);

            // all the rest of the items in the array need to be leftie-rightied
            for (int i = 1; i < preorder.Length; i++)
            {
                LeftieRightie(root, preorder[i]);
            }

            return root;
        }

        public void LeftieRightie(TreeNode node, int val)
        {
            // This value needs to go left if val < node.val
            if (val < node.val)
            {
                // If there's already a node.left, let's recurse on that node
                if (node.left != null)
                {
                    LeftieRightie(node.left, val);
                }
                // If there's no node.left, this is the val for it
                else
                {
                    node.left = new TreeNode(val);
                }
            }
            // This node needs to go right if val > node.val
            else
            {
                // If there's already a node.right, let's recurse on that node
                if (node.right != null)
                {
                    LeftieRightie(node.right, val);
                }
                // If there's no node.right, this is the val for it
                else 
                {
                    node.right = new TreeNode(val);
                }
            }
        }
    }
}

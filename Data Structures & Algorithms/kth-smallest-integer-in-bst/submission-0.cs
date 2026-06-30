/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */


public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (current != null || stack.Count > 0) {
            // Reach the leftmost node of the current node
            while (current != null) {
                stack.Push(current);
                current = current.left;
            }

            // Current must be null at this point
            current = stack.Pop();
            k--;

            // If we have reached the k-th smallest element, return its value
            if (k == 0) {
                return current.val;
            }

            // We have visited the node and its left subtree. Now, visit the right subtree
            current = current.right;
        }

        return -1; // Fallback value if k is out of bounds
    }
}


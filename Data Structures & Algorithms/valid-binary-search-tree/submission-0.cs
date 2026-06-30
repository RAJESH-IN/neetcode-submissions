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
    public bool IsValidBST(TreeNode root) {
        return Validate(root, long.MinValue, long.MaxValue);
    }

    private bool Validate(TreeNode node, long min, long max) {
        // Base case: an empty tree is a valid BST
        if (node == null) {
            return true;
        }

        // The current node's value must be strictly within the allowed range
        if (node.val <= min || node.val >= max) {
            return false;
        }

        // Recursively check left and right subtrees with updated bounds
        return Validate(node.left, min, node.val) && 
               Validate(node.right, node.val, max);
    }
}

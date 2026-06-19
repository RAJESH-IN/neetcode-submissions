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
    public bool IsBalanced(TreeNode root) {
        // If the helper returns -1, the tree is unbalanced
        return CheckHeight(root) != -1;
    }

    private int CheckHeight(TreeNode node) {
        // Base case: An empty node has a height of 0
        if (node == null) {
            // An empty tree is perfectly balanced
            return 0; 
        }

        // Check the height of the left subtree
        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1) {
            // Left subtree is already unbalanced
            return -1; 
        }

        // Check the height of the right subtree
        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1) {
            // Right subtree is already unbalanced
            return -1; 
        }

        // If the current node violates the balance factor rule, return -1
        if (Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }

        // Otherwise, return the actual height of this subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}


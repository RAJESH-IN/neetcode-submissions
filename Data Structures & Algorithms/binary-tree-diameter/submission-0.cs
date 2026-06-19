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
    private int maxDiameter = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        CalculateHeight(root);
        return maxDiameter;
    }

    private int CalculateHeight(TreeNode node) {
        // Base case: An empty node has a height of 0
        if (node == null) {
            return 0;
        }

        // Recursively find the height of left and right subtrees
        int leftHeight = CalculateHeight(node.left);
        int rightHeight = CalculateHeight(node.right);

        // The path length passing through the current node is leftHeight + rightHeight
        // Update the global maximum diameter found so far
        maxDiameter = Math.Max(maxDiameter, leftHeight + rightHeight);

        // Return the height of the current subtree to the parent call
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}


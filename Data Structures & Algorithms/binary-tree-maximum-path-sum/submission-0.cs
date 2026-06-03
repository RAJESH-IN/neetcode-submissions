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
    int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return maxSum;
    }

    private int DFS(TreeNode node) {
        if (node == null) return 0;

        // If negative, ignore that side (take 0 instead)
        int left  = Math.Max(0, DFS(node.left));
        int right = Math.Max(0, DFS(node.right));

        // Path through current node (can't pass this up to parent)
        maxSum = Math.Max(maxSum, node.val + left + right);

        // Return best single path to parent (can only go one direction)
        return node.val + Math.Max(left, right);
    }
}


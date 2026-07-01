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
    public int GoodNodes(TreeNode root) {
        // Start DFS tracking the root's value as the initial maximum
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxSoFar) {
        // Base case: an empty node contributes 0 good nodes
        if (node == null) {
            return 0;
        }

        int count = 0;

        // If current value is >= the max seen on this path, it is a good node
        if (node.val >= maxSoFar) {
            count = 1;
            // Update the maximum value for the deeper path
            maxSoFar = node.val; 
        }

        // Recursively count good nodes in left and right subtrees
        count += Dfs(node.left, maxSoFar);
        count += Dfs(node.right, maxSoFar);

        return count;
    }
}

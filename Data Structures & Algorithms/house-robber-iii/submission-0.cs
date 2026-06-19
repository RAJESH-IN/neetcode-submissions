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
    public int Rob(TreeNode root) {
        int[] result = RobSub(root);
        // Return the maximum value between robbing the root or skipping the root
        return Math.Max(result[0], result[1]);
    }

    private int[] RobSub(TreeNode node) {
        // Base case: empty house yields $0 for both options
        if (node == null) {
            return new int[] { 0, 0 };
        }

        // Recursively evaluate children subtrees
        int[] leftInfo = RobSub(node.left);
        int[] rightInfo = RobSub(node.right);

        int[] currentInfo = new int[2];

        // Scenario 1: Rob this current node
        // Cannot rob left or right child nodes; must take their "skipped" values
        currentInfo[0] = node.val + leftInfo[1] + rightInfo[1];

        // Scenario 2: Skip this current node
        // Free to choose the optimal choice (rob vs skip) independently for each child
        currentInfo[1] = Math.Max(leftInfo[0], leftInfo[1]) + 
                         Math.Max(rightInfo[0], rightInfo[1]);

        return currentInfo;
    }
}

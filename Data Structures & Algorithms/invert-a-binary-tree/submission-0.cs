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
    public TreeNode InvertTree(TreeNode root) {
         // 1. Base case: If the node is null, return null
        if (root == null) {
            return null;
        }

        // 2. Swap the left and right children
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        // 3. Recursively invert the subtrees
        InvertTree(root.left);
        InvertTree(root.right);

        // 4. Return the root of the inverted tree
        return root;
    }
}

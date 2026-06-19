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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // Base case 1: Both nodes are null -> structurally identical empty spots
        if (p == null && q == null) {
            return true;
        }

        // Base case 2: One node is null but the other isn't -> structural mismatch
        if (p == null || q == null) {
            return false;
        }

        // Base case 3: Both exist but have different data values -> value mismatch
        if (p.val != q.val) {
            return false;
        }

        // Recursively check if left subtrees match AND right subtrees match
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}


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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        // Base case 1: An empty subRoot is always a subtree of any tree
        if (subRoot == null) return true;
        
        // Base case 2: If main tree is empty but subRoot isn't, it cannot be a subtree
        if (root == null) return false;

        // If current nodes match structural values, check if the trees are identical
        if (IsSameTree(root, subRoot)) {
            return true;
        }

        // Recursively check if subRoot matches any subtree in the left or right branches
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        if (p.val != q.val) return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}


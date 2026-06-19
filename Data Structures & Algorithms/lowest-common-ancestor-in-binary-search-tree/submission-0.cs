/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode current = root;

        while (current != null) {
            // If both p and q are greater, move to the right subtree
            if (p.val > current.val && q.val > current.val) {
                current = current.right;
            }
            // If both p and q are smaller, move to the left subtree
            else if (p.val < current.val && q.val < current.val) {
                current = current.left;
            }
            // The split point has been found; this node is the LCA
            else {
                return current;
            }
        }

        return null;
    }
}

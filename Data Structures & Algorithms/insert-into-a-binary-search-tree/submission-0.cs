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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        // Base case: If the tree is empty, return a new node as the root
        if (root == null) {
            return new TreeNode(val);
        }

        TreeNode current = root;
        while (true) {
            // If the value belongs in the right subtree
            if (val > current.val) {
                if (current.right == null) {
                    current.right = new TreeNode(val);
                    break;
                }
                current = current.right;
            } 
            // If the value belongs in the left subtree
            else {
                if (current.left == null) {
                    current.left = new TreeNode(val);
                    break;
                }
                current = current.left;
            }
        }

        return root;
    }
}

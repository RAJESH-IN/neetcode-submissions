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
    public List<int> PostorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        Traverse(root, result);
        return result;
    }

    private void Traverse(TreeNode node, List<int> result) {
        if (node == null) return;
    
        Traverse(node.left, result);  // 1. Visit Left
        Traverse(node.right, result); // 2. Visit Right
        result.Add(node.val);         // 3. Visit Root
    }
}

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
public class Solution
{
    public List<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();

        DFS(root, result);

        return result;
    }

    private void DFS(TreeNode node, List<int> result)
    {
        if (node == null)
            return;

        // Left
        DFS(node.left, result);

        // Root
        result.Add(node.val);

        // Right
        DFS(node.right, result);
    }
}
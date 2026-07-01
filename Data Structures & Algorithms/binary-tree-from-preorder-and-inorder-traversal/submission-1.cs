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
    // Map to store value -> index for quick inorder lookups
    private Dictionary<int, int> inorderMap = new Dictionary<int, int>();
    private int preorderIndex = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // Build the map from the inorder array
        for (int i = 0; i < inorder.Length; i++) {
            inorderMap[inorder[i]] = i;
        }
        
        // Helper function defining the initial valid boundaries of inorder array
        return BuildTreeHelper(preorder, 0, inorder.Length - 1);
    }

    private TreeNode BuildTreeHelper(int[] preorder, int inorderStart, int inorderEnd) {
        // Base case: if there are no elements to construct the subtree
        if (inorderStart > inorderEnd) {
            return null;
        }

        // Select the current element from preorder as the root node
        int rootValue = preorder[preorderIndex];
        TreeNode root = new TreeNode(rootValue);
        preorderIndex++;

        // Find the index of this root in the inorder array
        int inorderRootIndex = inorderMap[rootValue];

        // Build left and right subtrees
        // Elements to the left of inorderRootIndex form the left subtree
        root.left = BuildTreeHelper(preorder, inorderStart, inorderRootIndex - 1);
        
        // Elements to the right of inorderRootIndex form the right subtree
        root.right = BuildTreeHelper(preorder, inorderRootIndex + 1, inorderEnd);

        return root;
    }
}

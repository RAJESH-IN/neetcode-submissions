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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> result = new List<List<int>>();
        
        // Base case: if the tree is empty, return an empty list
        if (root == null) {
            return result;
        }
        
        // Initialize a queue to keep track of nodes to visit
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            // Number of elements at the current level
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();
            
            // Process all nodes at the current level
            for (int i = 0; i < levelSize; i++) {
                TreeNode currentNode = queue.Dequeue();
                currentLevel.Add(currentNode.val);
                
                // Enqueue left child if it exists
                if (currentNode.left != null) {
                    queue.Enqueue(currentNode.left);
                }
                
                // Enqueue right child if it exists
                if (currentNode.right != null) {
                    queue.Enqueue(currentNode.right);
                }
            }
            
            // Add the completed level to the final result
            result.Add(currentLevel);
        }
        
        return result;
    }
}

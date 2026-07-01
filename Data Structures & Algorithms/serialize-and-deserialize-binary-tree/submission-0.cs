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
public class Codec {
    private const string NullMarker = "N";
    private const string Delimiter = ",";

    // Encodes a tree to a single string (Capital 'S')
    public string Serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        SerializeHelper(root, sb);
        return sb.ToString();
    }

    private void SerializeHelper(TreeNode node, StringBuilder sb) {
        if (node == null) {
            sb.Append(NullMarker).Append(Delimiter);
            return;
        }

        sb.Append(node.val).Append(Delimiter);
        SerializeHelper(node.left, sb);
        SerializeHelper(node.right, sb);
    }

    // Decodes your encoded data to tree (Capital 'D')
    public TreeNode Deserialize(string data) {
        if (string.IsNullOrEmpty(data)) return null;

        string[] tokens = data.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries);
        Queue<string> queue = new Queue<string>(tokens);
        
        return DeserializeHelper(queue);
    }

    private TreeNode DeserializeHelper(Queue<string> queue) {
        if (queue.Count == 0) return null;

        string current = queue.Dequeue();

        if (current == NullMarker) {
            return null;
        }

        TreeNode node = new TreeNode(int.Parse(current));
        node.left = DeserializeHelper(queue);
        node.right = DeserializeHelper(queue);

        return node;
    }
}

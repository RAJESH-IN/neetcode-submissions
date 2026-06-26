/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    // Map to store original nodes as keys and cloned nodes as values
    private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

    public Node CloneGraph(Node node) {
        if (node == null) return null;

        // If the node is already cloned, return its copy
        if (visited.ContainsKey(node)) {
            return visited[node];
        
        }

        // Create a deep copy of the current node (without neighbors yet)
        Node cloneNode = new Node(node.val);
        visited[node] = cloneNode;

        // Recursively clone and populate all neighbors
        foreach (var neighbor in node.neighbors) {
            cloneNode.neighbors.Add(CloneGraph(neighbor));
        }

        return cloneNode;
    }
}

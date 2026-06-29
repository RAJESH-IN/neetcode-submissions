/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        // Dictionary to map: Original Node -> Copied Node
        Dictionary<Node, Node> oldToNew = new Dictionary<Node, Node>();

        // Step 1: Create all new copied nodes and store them in the map
        Node curr = head;
        while (curr != null) {
            oldToNew[curr] = new Node(curr.val);
            curr = curr.next;
        }

        // Step 2: Assign next and random pointers for the copied nodes
        curr = head;
        while (curr != null) {
            Node clone = oldToNew[curr];
            
            // Link next node
            clone.next = curr.next != null ? oldToNew[curr.next] : null;
            
            // Link random node
            clone.random = curr.random != null ? oldToNew[curr.random] : null;

            curr = curr.next;
        }

        return oldToNew[head];
    }
}

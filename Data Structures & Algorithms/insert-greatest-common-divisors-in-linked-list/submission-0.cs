/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
        // If the list has 0 or 1 node, no pairs exist to insert between
        if (head == null || head.next == null) {
            return head;
        }
        
        ListNode current = head;
        
        while (current != null && current.next != null) {
            // Find GCD of the current node and the next adjacent node
            int gcdVal = Gcd(current.val, current.next.val);
            
            // Create the new node and link it into the chain
            ListNode gcdNode = new ListNode(gcdVal, current.next);
            current.next = gcdNode;
            
            // Move current to the node after the inserted node (the old next node)
            current = gcdNode.next;
        }
        
        return head;
    }
    
    // Iterative Euclidean algorithm to find the Greatest Common Divisor
    private int Gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

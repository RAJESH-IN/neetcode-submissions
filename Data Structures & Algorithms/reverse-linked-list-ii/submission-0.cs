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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (head == null || left == right) {
            return head;
        }

        // Step 1: Create dummy node to simplify edge cases when left = 1
        ListNode dummy = new ListNode(0, head);
        ListNode prev = dummy;

        // Move prev pointer up to the node right before position 'left'
        for (int i = 0; i < left - 1; i++) {
            prev = prev.next;
        }

        // Step 2: Initialize node tracking references
        ListNode curr = prev.next; // This node remains the tail of reversed sub-list

        // Step 3: Shift nodes forward one-by-one
        for (int i = 0; i < right - left; i++) {
            ListNode nextNode = curr.next;
            
            // Adjust links to splice out nextNode and place it right after prev
            curr.next = nextNode.next;
            nextNode.next = prev.next;
            prev.next = nextNode;
        }

        return dummy.next;
    }
}

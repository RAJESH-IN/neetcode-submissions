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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // Step 1: Initialize dummy node to protect the head references
        ListNode dummy = new ListNode(0, head);
        ListNode fast = dummy;
        ListNode slow = dummy;

        // Step 2: Advance fast pointer so there is an n-node gap
        for (int i = 0; i <= n; i++) {
            fast = fast.next;
        }

        // Step 3: Move both pointers until fast reaches the end
        while (fast != null) {
            fast = fast.next;
            slow = slow.next;
        }

        // Step 4: Delete the nth node from the end
        slow.next = slow.next.next;

        return dummy.next;
    }
}

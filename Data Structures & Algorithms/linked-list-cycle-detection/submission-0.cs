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
    public bool HasCycle(ListNode head) {
        // Edge case: An empty list or a single node cannot have a cycle
        if (head == null || head.next == null) {
            return false;
        }

        ListNode slow = head;
        ListNode fast = head;

        // Move fast pointer by 2 steps and slow pointer by 1 step
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            // If they meet, a cycle exists
            if (slow == fast) {
                return true;
            }
        }

        // If fast reaches the end, there is no cycle
        return false;
    }
}


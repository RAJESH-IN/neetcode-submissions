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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k == 1) return head;

        ListNode dummy = new ListNode(0, head);
        ListNode groupPrev = dummy;

        while (true) {
            // Find the k-th node of the current group
            ListNode kth = GetKthNode(groupPrev, k);
            if (kth == null) break; // Fewer than k nodes left, keep as is

            ListNode groupNext = kth.next;

            // Reverse the current group
            ListNode prev = kth.next; // Connect tail of reversed group to the next group
            ListNode curr = groupPrev.next;
            
            while (curr != groupNext) {
                ListNode nextNode = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextNode;
            }

            // Fix the connection from the previous group's tail to new head
            ListNode temp = groupPrev.next; // Original head becomes the new tail
            groupPrev.next = kth;          // 'kth' node becomes the new head
            groupPrev = temp;              // Move pointer to the end of reversed group
        }

        return dummy.next;
    }

    private ListNode GetKthNode(ListNode curr, int k) {
        while (curr != null && k > 0) {
            curr = curr.next;
            k--;
        }
        return curr;
    }
}


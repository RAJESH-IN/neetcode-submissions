public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        // Deque stores indices, front = largest element in window
        LinkedList<int> deque = new LinkedList<int>();

        for (int i = 0; i < n; i++) {
            // Remove indices outside the window
            if (deque.Count > 0 && deque.First.Value < i - k + 1)
                deque.RemoveFirst();

            // Remove smaller elements from back (they'll never be max)
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            // Start adding results once first window is complete
            if (i >= k - 1)
                result[i - k + 1] = nums[deque.First.Value];
        }

        return result;
    }
}
public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // Initialize a Min-Heap using C#'s PriorityQueue
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums) {
            // Push the current number with itself as the priority
            minHeap.Enqueue(num, num);

            // If the heap grows larger than size k, remove the smallest element
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }

        // The top of the heap is the smallest of the k largest elements (the kth largest)
        return minHeap.Peek();
    }
}

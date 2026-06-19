public class KthLargest {
    private readonly PriorityQueue<int, int> minHeap;
    private readonly int kSize;

    public KthLargest(int k, int[] nums) {
        minHeap = new PriorityQueue<int, int>();
        kSize = k;

        // Initialize the heap with given array elements
        foreach (int num in nums) {
            Add(num);
        }
    }
    
    public int Add(int val) {
        // Enqueue value; using the number itself as priority (Min-Heap behavior)
        minHeap.Enqueue(val, val);

        // If the heap exceeds size k, drop the smallest element
        if (minHeap.Count > kSize) {
            minHeap.Dequeue();
        }

        // The peeked element is the smallest within the k largest elements
        return minHeap.Peek();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

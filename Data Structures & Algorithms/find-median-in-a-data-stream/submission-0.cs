public class MedianFinder {
    // Stores the smaller half of numbers (Max-Heap behavior via inverted priority)
    private PriorityQueue<int, int> small;
    // Stores the larger half of numbers (Standard Min-Heap)
    private PriorityQueue<int, int> large;

    public MedianFinder() {
        small = new PriorityQueue<int, int>();
        large = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        // Step 1: Add to small heap (Invert priority for max-heap behavior)
        small.Enqueue(num, -num);
        
        // Step 2: Make sure every element in small is <= every element in large
        int maxFromSmall = small.Dequeue();
        large.Enqueue(maxFromSmall, maxFromSmall);
        
        // Step 3: Maintain size invariant (small can have at most 1 more element than large)
        if (large.Count > small.Count) {
            int minFromLarge = large.Dequeue();
            small.Enqueue(minFromLarge, -minFromLarge);
        }
    }
    
    public double FindMedian() {
        // If odd number of elements altogether, the middle is at the top of small
        if (small.Count > large.Count) {
            small.TryPeek(out int maxFromSmall, out _);
            return maxFromSmall;
        }
        
        // If even number of elements altogether, average the tops of both heaps
        small.TryPeek(out int sTop, out _);
        large.TryPeek(out int lTop, out _);
        return (sTop + lTop) / 2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

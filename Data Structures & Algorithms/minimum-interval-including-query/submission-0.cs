public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        int n = intervals.Length;
        int m = queries.Length;

        // 1. Sort intervals by their starting point
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // 2. Pair queries with their original indices and sort by query value
        int[][] sortedQueries = new int[m][];
        for (int i = 0; i < m; i++) {
            sortedQueries[i] = new int[] { queries[i], i };
        }
        Array.Sort(sortedQueries, (a, b) => a[0].CompareTo(b[0]));

        int[] result = new int[m];
        
        // Min-Heap stores: (Interval Length, Right Endpoint)
        // C# PriorityQueue sorts ascending by priority (the first element of the tuple: length)
        PriorityQueue<(int length, int right), int> minHeap = new PriorityQueue<(int length, int right), int>();

        int intervalIdx = 0;

        // 3. Process each query in increasing order
        for (int i = 0; i < m; i++) {
            int queryVal = sortedQueries[i][0];
            int originalIdx = sortedQueries[i][1];

            // Push all intervals that start before or at the current query value
            while (intervalIdx < n && intervals[intervalIdx][0] <= queryVal) {
                int left = intervals[intervalIdx][0];
                int right = intervals[intervalIdx][1];
                int length = right - left + 1;
                
                minHeap.Enqueue((length, right), length);
                intervalIdx++;
            }

            // Remove intervals from the top that end before the current query value
            while (minHeap.Count > 0 && minHeap.Peek().right < queryVal) {
                minHeap.Dequeue();
            }

            // The top of the heap is the shortest valid interval
            if (minHeap.Count > 0) {
                result[originalIdx] = minHeap.Peek().length;
            } else {
                result[originalIdx] = -1;
            }
        }

        return result;
    }
}

public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
          if (intervals.Length == 0) return 0;

        // Step 1: Sort the intervals by their end times in ascending order
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int removeCount = 0;
        // Track the end time of the last safely included interval
        int prevEnd = intervals[0][1];

        // Step 2: Iterate through the sorted intervals starting from the second one
        for (int i = 1; i < intervals.Length; i++) {
            // Check if the current interval starts before the previous one ends
            if (intervals[i][0] < prevEnd) {
                // Overlap detected! We must remove this interval.
                removeCount++;
            } else {
                // No overlap. Update the tracking end point to the current interval's end.
                prevEnd = intervals[i][1];
            }
        }

        return removeCount;
    }
}

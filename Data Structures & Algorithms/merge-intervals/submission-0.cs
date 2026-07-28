public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals == null || intervals.Length <= 1) {
            return intervals;
        }

        // 1. Sort intervals by their start time
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> merged = new List<int[]>();
        
        // 2. Initialize with the first interval
        int[] currentInterval = intervals[0];
        merged.Add(currentInterval);

        // 3. Iterate and merge overlapping intervals
        foreach (var interval in intervals) {
            int currentEnd = currentInterval[1];
            int nextStart = interval[0];
            int nextEnd = interval[1];

            if (currentEnd >= nextStart) {
                // Overlap detected: update the end time of the current interval
                currentInterval[1] = Math.Max(currentEnd, nextEnd);
            } else {
                // No overlap: move to the next interval and add it to the list
                currentInterval = interval;
                merged.Add(currentInterval);
            }
        }

        return merged.ToArray();
    }
}

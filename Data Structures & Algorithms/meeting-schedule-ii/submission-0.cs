/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */


public class Solution {
    public int MinMeetingRooms(List<Interval> intervals) {
        if (intervals == null || intervals.Count == 0) return 0;

        int n = intervals.Count;
        int[] startTimes=new int[n];
        int[] endTimes = new int[n];

        // Extract start and end times into separate arrays
        for (int i = 0; i < n; i++) {
            startTimes[i] = intervals[i].start;
            endTimes[i] = intervals[i].end;
        }

        // Sort both arrays independently
        Array.Sort(startTimes);
        Array.Sort(endTimes);

        int startPointer = 0;
        int endPointer = 0;
        int currentRooms = 0;
        int maxRooms = 0;

        // Chronologically process the events
        while (startPointer < n) {
            // If a meeting starts before the earliest ending meeting finishes
            if (startTimes[startPointer] < endTimes[endPointer]) {
                currentRooms++;
                startPointer++;
            } 
            // If a meeting ends before or exactly when the next meeting starts
            else {
                currentRooms--;
                endPointer++;
            }

            // Track the maximum number of overlapping rooms needed
            maxRooms = Math.Max(maxRooms, currentRooms);
        }

        return maxRooms;
    }
}


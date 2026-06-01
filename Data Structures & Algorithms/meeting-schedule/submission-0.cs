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
    public bool CanAttendMeetings(List<Interval> intervals) {
  if (intervals == null || intervals.Count <= 1) return true;

        // Step 1: Sort meetings by their start times in ascending order
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        // Step 2: Check for overlapping adjacent meetings
        for (int i = 1; i < intervals.Count; i++) {
            // If current meeting starts before the previous meeting ends, conflict found!
            if (intervals[i].start < intervals[i - 1].end) {
                return false;
            }
        }

        // No conflicts found across all scheduled meetings
        return true;
    }
}

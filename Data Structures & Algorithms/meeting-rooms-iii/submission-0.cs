
public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        // 1. Sort meetings chronologically by start time
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        
        // Array to count how many meetings each room hosts
        int[] roomCount = new int[n];
        
        // Min-heap for currently available room IDs
        PriorityQueue<int, int> availableRooms = new PriorityQueue<int, int>();
        for (int i = 0; i < n; i++) {
            availableRooms.Enqueue(i, i);
        }
        
        // Min-heap for occupied rooms, ordered by (endTime, roomId)
        PriorityQueue<int, (long endTime, int roomId)> occupiedRooms = 
            new PriorityQueue<int, (long, int)>(Comparer<(long endTime, int roomId)>.Create((a, b) => {
                int cmp = a.endTime.CompareTo(b.endTime);
                if (cmp != 0) return cmp;
                return a.roomId.CompareTo(b.roomId);
            }));
            
        // 2. Process each meeting sequentially
        foreach (var meeting in meetings) {
            long start = meeting[0];
            long end = meeting[1];
            long duration = end - start;
            
            // Release rooms that have finished before the current meeting's start time
            while (occupiedRooms.Count > 0) {
                occupiedRooms.TryPeek(out int rId, out var state);
                if (state.endTime <= start) {
                    occupiedRooms.Dequeue();
                    availableRooms.Enqueue(rId, rId);
                } else {
                    break;
                }
            }
            
            if (availableRooms.Count > 0) {
                // Case A: A room is available immediately
                int room = availableRooms.Dequeue();
                roomCount[room]++;
                occupiedRooms.Enqueue(room, (end, room));
            } else {
                // Case B: No rooms are available; wait for the earliest room to open
                occupiedRooms.TryPeek(out int room, out var state);
                occupiedRooms.Dequeue();
                
                roomCount[room]++;
                long newEnd = state.endTime + duration; // Delayed finish time
                occupiedRooms.Enqueue(room, (newEnd, room));
            }
        }
        
        // 3. Find the room with the maximum number of meetings
        int maxMeetingsRoom = 0;
        for (int i = 1; i < n; i++) {
            if (roomCount[i] > roomCount[maxMeetingsRoom]) {
                maxMeetingsRoom = i;
            }
        }
        
        return maxMeetingsRoom;
    }
}

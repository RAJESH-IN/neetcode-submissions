public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        // Since max location in constraints is 1000, 1001 elements covers all bounds
        int[] locationChanges = new int[1001];
        
        // Step 1: Record passenger changes at pick-up and drop-off points
        foreach (var trip in trips) {
            int numPassengers = trip[0];
            int fromLocation = trip[1];
            int toLocation = trip[2];
            
            locationChanges[fromLocation] += numPassengers; // Passengers get in
            locationChanges[toLocation] -= numPassengers;   // Passengers get out
        }
        
        // Step 2: Simulate the journey and calculate current passenger load
        int currentPassengers = 0;
        for (int i = 0; i < locationChanges.Length; i++) {
            currentPassengers += locationChanges[i];
            
            // If the capacity is breached at any kilometer marker, trip fails
            if (currentPassengers > capacity) {
                return false;
            }
        }
        
        return true;
    }
}

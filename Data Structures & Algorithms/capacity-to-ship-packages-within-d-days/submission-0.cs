
public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        int low = 0;
        int high = 0;
        
        // Find boundaries for binary search
        foreach (int w in weights) {
            low = Math.Max(low, w);
            high += w;
        }
        
        int result = high;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            if (CanShip(weights, days, mid)) {
                result = mid;       // Record the valid minimized capacity
                high = mid - 1;     // Try to find an even smaller valid capacity
            } else {
                low = mid + 1;      // Increase capacity since mid was too small
            }
        }
        
        return result;
    }
    
    // Helper method to check if a specific capacity can ship within the target days
    private bool CanShip(int[] weights, int maxDays, int capacity) {
        int daysUsed = 1;
        int currentLoad = 0;
        
        foreach (int w in weights) {
            if (currentLoad + w > capacity) {
                daysUsed++;         // Start a new day
                currentLoad = 0;    // Reset load for the new day
            }
            currentLoad += w;
        }
        
        return daysUsed <= maxDays;
    }
}

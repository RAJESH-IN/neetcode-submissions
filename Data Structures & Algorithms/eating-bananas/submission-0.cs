public class Solution {
   
     public int MinEatingSpeed(int[] piles, int h) {
        // The minimum possible speed is 1 banana per hour
        int low = 1;
        // The maximum useful speed is the size of the largest pile
        int high = piles.Max();
        int result = high;

        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            // Calculate total hours needed with speed 'mid'
            long totalHours = 0;
            foreach (int pile in piles) {
                // Ceiling division: Math.Ceiling((double)pile / mid)
                totalHours += (pile + mid - 1) / mid;
            }

            if (totalHours <= h) {
                result = mid;      // Found a valid speed, try to find a smaller one
                high = mid - 1;
            } else {
                low = mid + 1;     // Speed too slow, increase it
            }
        }

        return result;
    }
}

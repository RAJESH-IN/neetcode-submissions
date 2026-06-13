public class Solution {
    public int MySqrt(int x) {
        // Base cases for 0 and 1
        if (x < 2) {
            return x;
        }
        
        int low = 1;
        int high = x / 2;
        int result = 0;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;
            long square = (long)mid * mid; // Use long to prevent integer overflow
            
            if (square == x) {
                return mid; // Exact match found
            } else if (square < x) {
                result = mid;   // Save the potential rounded-down answer
                low = mid + 1;  // Try to find a closer, larger value
            } else {
                high = mid - 1; // Square is too big, search lower half
            }
        }
        
        return result;
    }
}

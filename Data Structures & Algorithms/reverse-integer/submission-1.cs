public class Solution {
    public int Reverse(int x) {

        long reversed = 0;
        
        while (x != 0) {
            // Extract last digit and append
            reversed = (reversed * 10) + (x % 10);
            // Remove the last digit
            x /= 10;
        }

        // Check for 32-bit signed integer overflow
        if (reversed > int.MaxValue || reversed < int.MinValue) {
            return 0;
        }

        return (int)reversed;
    
    }
}

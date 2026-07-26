public class Solution {
    public long MinEnd(int n, int x) {
        long result = x;
        long remaining = n - 1;
        long mask = 1;
        
        // Distribute the bits of (n - 1) into the 0-bits of x
        while (remaining > 0) {
            if ((x & mask) == 0) {
                if ((remaining & 1) == 1) {
                    result |= mask;
                }
                remaining >>= 1;
            }
            mask <<= 1;
        }
        
        return result;
    }
}

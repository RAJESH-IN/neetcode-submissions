public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        int shiftCount = 0;
        
        // Shift both numbers right until they become equal
        while (left < right) {
            left >>= 1;
            right >>= 1;
            shiftCount++;
        }
        
        // Shift back to the left to restore trailing zeros
        return left << shiftCount;
    }
}

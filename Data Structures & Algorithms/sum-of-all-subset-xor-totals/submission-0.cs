public class Solution {
    public int SubsetXORSum(int[] nums) {
        int bitwiseOrSum = 0;
        
        // Find the bitwise OR of all elements
        foreach (int num in nums) {
            bitwiseOrSum |= num;
        }
        
        // Multiply by 2^(n-1) using a left bitwise shift
        return bitwiseOrSum << (nums.Length - 1);
    }
}

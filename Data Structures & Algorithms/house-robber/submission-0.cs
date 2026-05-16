public class Solution {
    public int Rob(int[] nums) {
         if (nums == null || nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];

        int prev2 = 0; // Max money if we stopped 2 houses ago
        int prev1 = 0; // Max money if we stopped 1 house ago

        foreach (int currentHouse in nums) {
            // Option 1: Rob current house + max from 2 houses ago
            // Option 2: Skip current house and keep max from 1 house ago
            int currentMax = Math.Max(prev2 + currentHouse, prev1);
            
            // Move pointers forward
            prev2 = prev1;
            prev1 = currentMax;
        }

        return prev1;
    }
}

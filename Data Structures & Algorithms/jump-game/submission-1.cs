public class Solution {
    public bool CanJump(int[] nums) {
        int maxReachable = 0;

        for (int i = 0; i < nums.Length; i++) {
            // If the current index is beyond the maximum reachable point,
            // it means we are stuck and cannot proceed further.
            if (i > maxReachable) {
                return false;
            }

            // Update the maximum index we can reach from the current position
            maxReachable = Math.Max(maxReachable, i + nums[i]);

            // Early exit optimization: if we can already reach or pass the last index, return true
            if (maxReachable >= nums.Length - 1) {
                return true;
            }

    }
    

        return true;
    }
}

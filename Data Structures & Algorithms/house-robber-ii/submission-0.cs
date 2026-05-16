public class Solution {
    public int Rob(int[] nums) {
      int n = nums.Length;
        if (n == 1) return nums[0];
        
        // Return the max of robbing houses [0...n-2] or [1...n-1]
        return Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1));
    }

    private int RobRange(int[] nums, int start, int end) {
        int prev2 = 0;
        int prev1 = 0;

        for (int i = start; i <= end; i++) {
            int current = Math.Max(prev2 + nums[i], prev1);
            prev2 = prev1;
            prev1 = current;
        }

        return prev1;    
    }
}

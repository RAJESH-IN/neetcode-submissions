public class Solution {
    public int MaxSubArray(int[] nums) {
         // Initialize with the first element to handle single-element arrays
        int currentSum = nums[0];
        int maxSum = nums[0];

       for(int i=1;i<nums.Length;i++){
            // Decide whether to add the current number to the existing subarray
            // or start a completely new subarray from the current number
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            
            // Keep track of the global maximum sum found so far
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}

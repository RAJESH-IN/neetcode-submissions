public class Solution {
    public int SplitArray(int[] nums, int k) {
        int low = 0;
        int high = 0;
        
        // Establish search boundaries
        foreach (int num in nums) {
            low = Math.Max(low, num);
            high += num;
        }
        
        int result = high;
        
        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            // Check if it's possible to split array with 'mid' as the maximum subarray sum
            if (CanSplit(nums, k, mid)) {
                result = mid;       // Record the valid minimized maximum sum
                high = mid - 1;     // Try to find a smaller valid maximum sum
            } else {
                low = mid + 1;      // Increase the allowed sum threshold
            }
        }
        
        return result;
    }
    
    // Helper method to validate if we can partition into <= k subarrays with maximum sum 'maxSum'
    private bool CanSplit(int[] nums, int maxSplits, int maxSum) {
        int subarrayCount = 1;
        int currentSum = 0;
        
        foreach (int num in nums) {
            if (currentSum + num > maxSum) {
                subarrayCount++;    // Create a new subarray partition
                currentSum = 0;     // Reset the sum for the new subarray
            }
            currentSum += num;
        }
        
        return subarrayCount <= maxSplits;
    }
}

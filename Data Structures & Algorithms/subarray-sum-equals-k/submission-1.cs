public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int count = 0;
        int currentSum = 0;
        
        // Dictionary to store frequency of prefix sums: Key = prefixSum, Value = frequency
        Dictionary<int, int> prefixSumCounts = new Dictionary<int, int>();
        
        // Base case: a prefix sum of 0 has occurred once
        prefixSumCounts[0] = 1;
        
        foreach (int num in nums) {
            currentSum += num;
            
            // Check if there is a prefix sum that satisfies (currentSum - target) == k
            int target = currentSum - k;
            if (prefixSumCounts.ContainsKey(target)) {
                count += prefixSumCounts[target];
            }
            
            // Record the current prefix sum into the tracking dictionary
            if (prefixSumCounts.ContainsKey(currentSum)) {
                prefixSumCounts[currentSum]++;
            } else {
                prefixSumCounts[currentSum] = 1;
            }
        }
        
        return count;
    }
}

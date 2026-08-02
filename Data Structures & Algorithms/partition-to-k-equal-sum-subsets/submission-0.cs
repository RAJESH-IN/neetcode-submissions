public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        int total = nums.Sum();
        // If the total sum cannot be divided evenly into k buckets, return false
        if (total % k != 0) return false;
        
        int target = total / k;
        
        // Sort ascending to easily process from largest to smallest elements
        Array.Sort(nums);
        
        // If the single largest number exceeds target, partitioning is impossible
        if (nums[nums.Length - 1] > target) return false;
        
        // Track the current sum of each of the k subsets
        int[] subsets = new int[k];
        
        return Backtrack(nums, nums.Length - 1, subsets, target);
    }

    private bool Backtrack(int[] nums, int index, int[] subsets, int target) {
        // Base Case: All numbers successfully placed into buckets
        if (index < 0) return true;

        for (int i = 0; i < subsets.Length; i++) {
            // Check if current number fits in the subset bucket
            if (subsets[i] + nums[index] <= target) {
                subsets[i] += nums[index];
                
                // Recursively place the next element
                if (Backtrack(nums, index - 1, subsets, target)) return true;
                
                // Backtrack (revert choice)
                subsets[i] -= nums[index];
            }
            
            // Pruning: Skip duplicate empty bucket evaluations to avoid TLE
            if (subsets[i] == 0) break;
        }
        return false;
    }
}

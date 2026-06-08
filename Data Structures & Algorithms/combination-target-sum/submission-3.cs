//using System.Collections.Generic;

public class Solution {
    public List<List<int>> CombinationSum(int[] candidates, int target) {
        List<List<int>> result = new List<List<int>>();
        List<int> currentCombination = new List<int>();
        
        // Note: The method signature in the image says 'int[] nums', using it here
        Backtrack(0, candidates, target, currentCombination, result);
        
        return result;
    }

    private void Backtrack(int index, int[] nums, int target, List<int> current, List<List<int>> result) {
        // Base case: successfully found a valid combination
        if (target == 0) {
            result.Add(new List<int>(current));
            return;
        }

        // Base case: exceeded target or out of array bounds
        if (target < 0 || index >= nums.Length) {
            return;
        }

        // Choice 1: Include the current element (can reuse it, so index stays the same)
        current.Add(nums[index]);
        Backtrack(index, nums, target - nums[index], current, result);

        // Choice 2: Exclude the current element (move to the next number)
        current.RemoveAt(current.Count - 1); // Backtrack
        Backtrack(index + 1, nums, target, current, result);
    }
}

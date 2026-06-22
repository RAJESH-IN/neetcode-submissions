public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        
        // 1. Sort the array to place duplicates adjacent to each other
        Array.Sort(nums);
        
        // 2. Begin backtracking from index 0
        Backtrack(0, nums, new List<int>(), result);
        
        return result;
    }
    
    private void Backtrack(int index, int[] nums, List<int> currentSubset, List<List<int>> result) {
        // Base Case: If we have considered all elements, add a copy of the subset to the results
        if (index >= nums.Length) {
            result.Add(new List<int>(currentSubset));
            return;
        }
        
        // Decision 1: INCLUDE the current element nums[index]
        currentSubset.Add(nums[index]);
        Backtrack(index + 1, nums, currentSubset, result);
        currentSubset.RemoveAt(currentSubset.Count - 1); // Backtrack
        
        // Decision 2: EXCLUDE the current element and skip all identical duplicates
        while (index + 1 < nums.Length && nums[index] == nums[index + 1]) {
            index++;
        }
        Backtrack(index + 1, nums, currentSubset, result);
    }
}

public class Solution {
    public List<List<int>> Subsets(int[] nums) {
         List<List<int>> result = new List<List<int>>();
        List<int> currentSubset = new List<int>();
        
        Backtrack(0, nums, currentSubset, result);
        
        return result;
    }

    private void Backtrack(int index, int[] nums, List<int> currentSubset, List<List<int>> result) {
        // Base case: if we have considered all elements, add a copy of the current subset to result
        if (index == nums.Length) {
            result.Add(new List<int>(currentSubset));
            return;
        }

        // Choice 1: Include the current element
        currentSubset.Add(nums[index]);
        Backtrack(index + 1, nums, currentSubset, result);

        // Choice 2: Exclude the current element (Backtrack)
        currentSubset.RemoveAt(currentSubset.Count - 1);
        Backtrack(index + 1, nums, currentSubset, result);
    }
}

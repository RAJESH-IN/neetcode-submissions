public class Solution {
    public List<List<int>> PermuteUnique(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        
        // 1. Sort to group identical numbers together
        Array.Sort(nums);
        
        // 2. Track visited positions and build permutations
        bool[] used = new bool[nums.Length];
        Backtrack(nums, used, new List<int>(), result);
        
        return result;
    }
    
    private void Backtrack(int[] nums, bool[] used, List<int> current, List<List<int>> result) {
        // Base case: If the current permutation is full length, add a copy to results
        if (current.Count == nums.Length) {
            result.Add(new List<int>(current));
            return;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            // Skip if this index is already part of the current path
            if (used[i]) continue;
            
            // Prune duplicate branches: Skip if current element equals previous 
            // and the previous element hasn't been used yet in this recursion layer
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;
            
            // Make choice
            used[i] = true;
            current.Add(nums[i]);
            
            // Move down the recursion tree
            Backtrack(nums, used, current, result);
            
            // Undo choice (backtrack)
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}

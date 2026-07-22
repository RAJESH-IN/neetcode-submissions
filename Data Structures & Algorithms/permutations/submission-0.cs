
public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        bool[] used = new bool[nums.Length];
        
        Backtrack(nums, used, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, List<int> current, List<List<int>> result) {
        // Base case: full permutation complete
        if (current.Count == nums.Length) {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = 0; i < nums.Length; i++) {
            // Skip elements already used in the current path
            if (used[i]) {
                continue;
            }

            // Make choice
            used[i] = true;
            current.Add(nums[i]);

            // Explore
            Backtrack(nums, used, current, result);

            // Undo choice (backtrack)
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
